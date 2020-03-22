import {Component} from '@angular/core';
import {Observable} from 'rxjs';
import {OfferHelpStates} from './offer-help-state.service';

@Component({
  selector: 'app-offer-help-page',
  templateUrl: './offer-help-page.component.html',
  styleUrls: ['./offer-help-page.component.scss'],
})
export class OfferHelpPageComponent {
  states = OfferHelpStates;
  readonly state: Observable<OfferHelpStates>;

  constructor() {
  }

}
