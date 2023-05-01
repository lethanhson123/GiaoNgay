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

const routes: Routes = [  
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
