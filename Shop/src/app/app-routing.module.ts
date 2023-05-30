import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MembershipComponent } from './membership/membership.component';
import { OrderDeliveryComponent } from './order-delivery/order-delivery.component';
import { OrderDeliveryInfoComponent } from './order-delivery/order-delivery-info/order-delivery-info.component';
import { HomepageComponent } from './homepage/homepage.component';
import { OrderCallComponent } from './order-call/order-call.component';
import { OrderDeliveryDesktopComponent } from './order-delivery-desktop/order-delivery-desktop.component';
import { MembershipTotalDebtComponent } from './membership-total-debt/membership-total-debt.component';
import { OrderShipperComponent } from './order-shipper/order-shipper.component';
import { OrderShipperInfoComponent } from './order-shipper/order-shipper-info/order-shipper-info.component';



const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },
  {
    path: 'Homepage', component: HomepageComponent,
  },
  {
    path: 'OrderShipper', component: OrderShipperComponent,
  },
  {
    path: 'OrderShipperInfo/:ID', component: OrderShipperInfoComponent,
  },
  {
    path: 'MembershipTotalDebt', component: MembershipTotalDebtComponent,
  },
  {
    path: 'OrderCall', component: OrderCallComponent,
  },
  {
    path: 'Membership', component: MembershipComponent,
  },
  {
    path: 'OrderDeliveryDesktop', component: OrderDeliveryDesktopComponent,
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
