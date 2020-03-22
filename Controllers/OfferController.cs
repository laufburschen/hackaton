using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.DbContext;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OfferCreateDto
    {
        public string comment  {get; set;}  
    }

    public class OfferGetDto : OfferCreateDto
    {
        public string id {get; set;}
    }

    public static class OfferExtensions
    {
        public static OfferGetDto CreateGetDto(this Offer Offer)
        {
            return new  OfferGetDto {
                id = Offer.id,
                comment = Offer.comment,
            };
        }
    }


    [ApiController]
    [Route("offer")]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly MariaContext _context;

        public OfferController(
            MariaContext context,
            ILogger<OfferController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<List<OfferGetDto>> Create([FromBody][Required]List<OfferCreateDto> createOfferArgs)
        {
            var Offers = new List<OfferGetDto>();

            foreach (var singleCreateOffer in createOfferArgs)
            {
                var id = $"Offer_{Guid.NewGuid():N}";
                var Offer = new Offer
                {
                    id = id
                };

                _context.Offers.Add(Offer);
                Offers.Add(Offer.CreateGetDto());
            }
           
            await _context.SaveChangesAsync();

            return Offers;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OfferGetDto>> Get()
        {
            return _context.Offers.ToList().Select(_ => _.CreateGetDto()).ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<OfferGetDto>> Get(string id)
        {
            var foundOffer = _context.Offers.FirstOrDefault(_ => _.id == id);
            if (foundOffer != null)
            {
                return new [] { foundOffer.CreateGetDto() };
            }
            return BadRequest();
        }
    }
}
