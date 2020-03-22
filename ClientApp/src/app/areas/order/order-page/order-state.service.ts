import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {startWith} from 'rxjs/operators';

export enum OrderStates {
  Unknown = 1,
  ProductSelection,
  Overview,
  Complete,
}

@Injectable({
  providedIn: 'root',
})
export class OrderStateService {
  private readonly currentState = new Subject<OrderStates>();

  constructor() {
  }

  observable(): Observable<OrderStates> {
    return this.currentState.pipe(
      startWith(OrderStates.Unknown),
    );
  }

  startProductSelection() {
    this.currentState.next(OrderStates.ProductSelection);
  }

  startCheckout() {
    this.currentState.next(OrderStates.Overview);
  }

  completeOrder() {
    this.currentState.next(OrderStates.Complete);
  }
}
