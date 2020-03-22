import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatAccordion, MatExpansionModule} from '@angular/material/expansion';
import {MatListModule} from '@angular/material/list';
import { OrderAreaRoutingModule } from './order-area-routing.module';
import { OrderPageComponent } from './order-page/order-page.component';
import { OrderFormComponent } from './order-page/order-form/order-form.component';
import { ConfirmOrderModalContentComponent } from './confirm-order-modal-content/confirm-order-modal-content.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ItemListComponent } from 'src/app/areas/order/order-page/item-list/item-list.component';
import {MatTableModule} from '@angular/material/table';
import {MatSort, MatSortModule} from '@angular/material/sort';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS, MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { OrdersOverviewComponent } from './order-overview/orders-overview.component';
@NgModule({
  imports: [
    OrderAreaRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatIconModule,
    MatSnackBarModule,
    MatListModule,
    MatExpansionModule,
  ],
  declarations: [
    OrderPageComponent,
    OrderFormComponent,
    ItemListComponent,
    ConfirmOrderModalContentComponent,
    OrdersOverviewComponent,
  ],
  providers: [
    {provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 2500}}
  ]
})
export class OrderAreaModule {
}
