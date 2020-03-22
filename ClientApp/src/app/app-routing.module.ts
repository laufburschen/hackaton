import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {offerHelpAreaPluggable} from './areas/offer-help/offer-help-area.pluggable';
import { orderAreaPluggable } from './areas/order/order-area.pluggable';
import { FirstViewComponent } from './first-view/first-view.component';

const routes: Routes = [
  {
    path: '',
    canActivate: [],
    children: [
      ...orderAreaPluggable.lazyRoutes,
      ...offerHelpAreaPluggable.lazyRoutes,
      { path: '**', component: FirstViewComponent }
    ],
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes,
      {
        enableTracing: false,
        onSameUrlNavigation: 'reload',
      },
    ),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
