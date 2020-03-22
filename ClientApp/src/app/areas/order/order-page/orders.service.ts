import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {OrdersGateway, PostOrderReq} from '../../../core/backend-api/gateways/orders.gateway';
import {Order} from '../order.model';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  constructor(
    private readonly ordersGateway: OrdersGateway,
  ) {
  }

  postOrder(order: Order): Observable<void> {
    const params: PostOrderReq[] =
      order.orderItems.map((order) => {
        return {
          product: order.product,
          items: order.items,
          maximum_price_per_item: order.maxPricePerItem,
          comment: order.comment,
        };
      });

    return this.ordersGateway.postOrders(params);
  }

  getOrders(): Observable<Order[]> {
    return of([
      {
        id: 1, orderItems: [
          {
            id: 2,
            product: 'name',
            items: 99,
            maxPricePerItem: 12,
            comment: 'comment',
          },
        ],
      },
    ]);
    // return this.ordersGateway.getOrders();
    // .pipe(
    // map((orders) => {
    //   return {
    //     id: undefined,
    //     orderItems: response.map((orderItem) => {
    //       return {
    //         id: orderItem.id,
    //         product: orderItem.product,
    //         items: orderItem.items,
    //         maxPricePerItem: orderItem.maximum_price_per_item,
    //         comment: orderItem.comment,
    //       }
    //     })
    //   };
    // })
  }
}
