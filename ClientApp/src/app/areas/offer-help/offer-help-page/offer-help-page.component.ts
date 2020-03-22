import { AfterViewInit, Component } from '@angular/core';
import {Observable} from 'rxjs';
import { OfferHelpStates, OfferHelpStateService } from './offer-help-state.service';

@Component({
  selector: 'app-offer-help-page',
  templateUrl: './offer-help-page.component.html',
  styleUrls: ['./offer-help-page.component.scss'],
})
export class OfferHelpPageComponent implements AfterViewInit {
  states = OfferHelpStates;
  readonly state: Observable<OfferHelpStates>;

  constructor(
    private readonly offerHelpStateService: OfferHelpStateService,
  ) {
    this.state = offerHelpStateService.observable();
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.startFindOrders();
    });
  }

  private startFindOrders() {
    this.offerHelpStateService.startFindOrders();
  }
}
