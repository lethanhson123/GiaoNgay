import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MembershipComponent } from './membership/membership.component';
import { OrderDeliveryComponent } from './order-delivery/order-delivery.component';
import { OrderDeliveryInfoComponent } from './order-delivery/order-delivery-info/order-delivery-info.component';



const routes: Routes = [  
  { path: '', redirectTo: '/OrderDelivery', pathMatch: 'full' },
  {
    path: 'Membership', component: MembershipComponent,
  },
  {
    path: 'OrderDelivery', component: OrderDeliveryComponent,
  },
  {
    path: 'OrderDeliveryInfo/:ID', component: OrderDeliveryInfoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
