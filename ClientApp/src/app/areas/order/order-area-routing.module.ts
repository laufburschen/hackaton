import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {OrderPageComponent} from './order-page/order-page.component';

const routes: Routes = [
  {
    path: '',
    component: OrderPageComponent,
    canActivate: [],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderAreaRoutingModule {
}
