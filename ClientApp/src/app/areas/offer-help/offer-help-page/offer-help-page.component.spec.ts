import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {OfferHelpPageComponent} from './offer-help-page.component';
import {OfferHelpStateService} from './offer-help-state.service';

describe('OfferHelpPageComponent', () => {
  let component: OfferHelpPageComponent;
  let fixture: ComponentFixture<OfferHelpPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OfferHelpPageComponent],
      providers: [OfferHelpStateService],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferHelpPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
