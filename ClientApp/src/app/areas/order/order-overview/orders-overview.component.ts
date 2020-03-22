import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {OrdersService} from '../order-page/orders.service';
import {Order} from '../order.model';

@Component({
  selector: 'app-orders-overview',
  templateUrl: './orders-overview.component.html',
  styleUrls: ['./orders-overview.component.scss'],
})
export class OrdersOverviewComponent implements OnInit {
  private orders: Observable<Order[]>;

  constructor(
    private readonly ordersService: OrdersService,
  ) {
    this.getOrders();
  }

  ngOnInit(): void {
  }

  private getOrders() {
    this.orders = this.ordersService.getOrders();
  }

}
