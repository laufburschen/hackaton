import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {OrdersService} from '../../../orders.service';
import {Order} from '../../../order.model';

@Component({
  selector: 'app-orders-overview',
  templateUrl: './orders-overview.component.html',
  styleUrls: ['./orders-overview.component.scss'],
})
export class OrdersOverviewComponent implements OnInit {
  orders: Observable<Order[]>;
  panelOpenState = false;
  public columnsToDisplay: String[];

  constructor(
    private readonly ordersService: OrdersService,
  ) {
    this.getOrders();
    this.columnsToDisplay = ["product", "items", "maxPricePerItem", "comment"];
  }

  ngOnInit(): void {
  }

  private getOrders() {
    this.orders = this.ordersService.getOrders();
  }

}
