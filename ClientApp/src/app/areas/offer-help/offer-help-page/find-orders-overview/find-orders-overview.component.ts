import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../../../../orders.service';
import { Observable } from 'rxjs';
import { Order } from '../../../../order.model';
import { OfferHelpStateService } from '../offer-help-state.service';

@Component({
  selector: 'app-find-orders-overview',
  templateUrl: './find-orders-overview.component.html',
  styleUrls: ['./find-orders-overview.component.scss']
})
export class FindOrdersOverviewComponent implements OnInit {

  orders$: Observable<Order[]>;

  constructor(private readonly ordersService: OrdersService, private readonly offerHelpStateChange: OfferHelpStateService) { }

  ngOnInit(): void {
    this.orders$ = this.ordersService.getOrders();
  }

  claimOrder(order: Order) {
    this.ordersService.claimOrder(order);
  }

  changeState() :void {
    this.offerHelpStateChange.startSeeOrders();
  }
}
