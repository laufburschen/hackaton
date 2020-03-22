import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {startWith} from 'rxjs/operators';

export enum OfferHelpStates {
  Unknown = 1,
  FindOrders = 2,
  SeeOrders = 3,
}

@Injectable({
  providedIn: 'root',
})
export class OfferHelpStateService {
  private readonly currentState = new Subject<OfferHelpStates>();

  constructor() {
  }

  observable(): Observable<OfferHelpStates> {
    return this.currentState.pipe(
      startWith(OfferHelpStates.Unknown),
    );
  }

  startFindOrders(): void {
    this.currentState.next(OfferHelpStates.FindOrders);
  }

  startSeeOrders(): void {
    this.currentState.next(OfferHelpStates.SeeOrders);
  }
}
