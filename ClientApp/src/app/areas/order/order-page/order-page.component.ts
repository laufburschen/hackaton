import { AfterViewInit, Component } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Order, OrderItem } from '../order.model';
import { OrderStates, OrderStateService } from './order-state.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmOrderModalContentComponent } from '../confirm-order-modal-content/confirm-order-modal-content.component';
import { OrdersService } from './orders.service';
import { switchMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.scss'],
})
export class OrderPageComponent implements AfterViewInit{
  states = OrderStates;
  readonly state: Observable<OrderStates>;

  order: Order = { orderItems: [] };

  // Bestellbestätigung BEGIN
  confirmedOrder: boolean | null = null;
  // Bestellbestätigung END

  constructor(
    private readonly orderStateService: OrderStateService,
    private readonly ordersService: OrdersService,
    private readonly snackBar: MatSnackBar,
    public dialog: MatDialog,
  ) {
    this.state = orderStateService.observable();
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.orderStateService.startCheckout();
    });
  }

  startCheckout() {
    this.orderStateService.startCheckout();
  }

  completeOrder() {
    this.orderStateService.completeOrder();
  }

  startProductSelection() {
    this.orderStateService.startProductSelection();
  }

  addOrderItem(orderItem: OrderItem): void {
    this.order.orderItems.push(orderItem);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ConfirmOrderModalContentComponent, {
      width: 'auto',
      data: { confirmedOrder: this.confirmedOrder }
    });

    dialogRef.afterClosed().pipe(
      switchMap((result: undefined | boolean) => {
        if (!result) {
          return of(false);
        }

        return this.ordersService.postOrder(this.order);
      })
    ). subscribe(
      (result: boolean | undefined) => {
        if (!!result) {
          this.snackBar.open('Deine Bestellung wurde aufgenommen!');
          this.completeOrder();
        }
      },
      () => {
        this.snackBar.open('Bei der Aufnahme deiner Bestellung ist ein Fehler aufgetreten.');
      }
    );
  }
}
