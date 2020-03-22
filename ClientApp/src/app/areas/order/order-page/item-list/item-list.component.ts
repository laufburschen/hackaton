import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { OrderStateService } from '../order-state.service';
import { Order } from '../../order.model';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent {

  @Input() order: Order;

  columnsToDisplay = ['product','items','maxPricePerItem', 'comment'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private readonly orderStateService:OrderStateService) {}

  addProduct() {
    this.orderStateService.startProductSelection()
  }
}
