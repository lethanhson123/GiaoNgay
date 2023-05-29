import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BankComponent } from './bank/bank.component';
import { UploadComponent } from './upload/upload.component';
import { ProvinceComponent } from './province/province.component';
import { DistrictComponent } from './district/district.component';
import { WardComponent } from './ward/ward.component';
import { CategoryMembershipComponent } from './category-membership/category-membership.component';
import { CategoryOrderDetailComponent } from './category-order-detail/category-order-detail.component';
import { CategoryOrderPaymentComponent } from './category-order-payment/category-order-payment.component';
import { CategoryOrderStatusComponent } from './category-order-status/category-order-status.component';
import { CompanyComponent } from './company/company.component';
import { MembershipComponent } from './membership/membership.component';
import { ShopComponent } from './shop/shop.component';
import { ShipperComponent } from './shipper/shipper.component';
import { OrderDeliveryComponent } from './order-delivery/order-delivery.component';
import { OrderDeliveryInfoComponent } from './order-delivery/order-delivery-info/order-delivery-info.component';
import { OrderReceiveComponent } from './order-receive/order-receive.component';
import { OrderReceiveInfoComponent } from './order-receive/order-receive-info/order-receive-info.component';
import { OrderShipperComponent } from './order-shipper/order-shipper.component';
import { OrderShipperInfoComponent } from './order-shipper/order-shipper-info/order-shipper-info.component';
import { OrderShipperLiveComponent } from './order-shipper-live/order-shipper-live.component';
import { OrderCallComponent } from './order-call/order-call.component';
import { HomepageComponent } from './homepage/homepage.component';
import { QuickAccessComponent } from './quick-access/quick-access.component';
import { MembershipTotalDebtInfoComponent } from './membership-total-debt/membership-total-debt-info/membership-total-debt-info.component';
import { MembershipTotalDebtComponent } from './membership-total-debt/membership-total-debt.component';

const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },
  {
    path: 'Homepage', component: HomepageComponent,
  },
  {
    path: 'QuickAccess', component: QuickAccessComponent,
  },
  {
    path: 'OrderCall', component: OrderCallComponent,
  },
  {
    path: 'OrderShipperLive', component: OrderShipperLiveComponent,
  },
  {
    path: 'MembershipTotalDebt', component: MembershipTotalDebtComponent,
  },
  {
    path: 'MembershipTotalDebtInfo/:ID', component: MembershipTotalDebtInfoComponent,
  },
  {
    path: 'OrderShipper', component: OrderShipperComponent,
  },
  {
    path: 'OrderShipperInfo/:ID', component: OrderShipperInfoComponent,
  },
  {
    path: 'OrderReceive', component: OrderReceiveComponent,
  },
  {
    path: 'OrderReceiveInfo/:ID', component: OrderReceiveInfoComponent,
  },
  {
    path: 'OrderDelivery', component: OrderDeliveryComponent,
  },
  {
    path: 'OrderDeliveryInfo/:ID', component: OrderDeliveryInfoComponent,
  },
  {
    path: 'Membership', component: MembershipComponent,
  },
  {
    path: 'Shop', component: ShopComponent,
  },
  {
    path: 'Shipper', component: ShipperComponent,
  },
  {
    path: 'Company', component: CompanyComponent,
  },
  {
    path: 'CategoryMembership', component: CategoryMembershipComponent,
  },
  {
    path: 'CategoryOrderDetail', component: CategoryOrderDetailComponent,
  },
  {
    path: 'CategoryOrderPayment', component: CategoryOrderPaymentComponent,
  },
  {
    path: 'CategoryOrderStatus', component: CategoryOrderStatusComponent,
  },
  {
    path: 'Bank', component: BankComponent,
  },
  {
    path: 'Province', component: ProvinceComponent,
  },
  {
    path: 'District', component: DistrictComponent,
  },
  {
    path: 'Ward', component: WardComponent,
  },
  {
    path: 'Upload', component: UploadComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
