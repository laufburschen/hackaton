import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';

export interface IOrderResponse {
  id: string;
  product: string;
  items: number;
  maximum_price_per_item: number;
  comment: string;
}

export interface PostOrderReq {

  product: string;
  items: number;
  maximum_price_per_item: number;
  comment: string;

}

@Injectable({
  providedIn: 'root',
})
export class OrdersGateway {
  constructor(private readonly http: HttpClient) {
  }

  postOrders(params: any): Observable<void> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json');
    return this.http.post<void>('https://deinlaufbursche.de/order', JSON.stringify(params), {headers: headers});
  }

  getOrders(): Observable<IOrderResponse[]> {
    return of([]);
  }
}
