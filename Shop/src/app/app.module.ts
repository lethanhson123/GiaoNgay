import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { CKEditorModule } from 'ngx-ckeditor';
import { NotificationService } from './shared/notification.service';
import { CookieService } from 'ngx-cookie-service';
import { ChartsModule } from 'ng2-charts';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { BankComponent } from './bank/bank.component';
import { BankDetailComponent } from './bank/bank-detail/bank-detail.component';
import { UploadComponent } from './upload/upload.component';
import { ProvinceComponent } from './province/province.component';
import { DistrictComponent } from './district/district.component';
import { WardComponent } from './ward/ward.component';
import { ProvinceDetailComponent } from './province/province-detail/province-detail.component';
import { DistrictDetailComponent } from './district/district-detail/district-detail.component';
import { WardDetailComponent } from './ward/ward-detail/ward-detail.component';
import { CategoryMembershipComponent } from './category-membership/category-membership.component';
import { CategoryMembershipDetailComponent } from './category-membership/category-membership-detail/category-membership-detail.component';
import { CategoryOrderDetailComponent } from './category-order-detail/category-order-detail.component';
import { CategoryOrderDetailDetailComponent } from './category-order-detail/category-order-detail-detail/category-order-detail-detail.component';
import { CategoryOrderPaymentComponent } from './category-order-payment/category-order-payment.component';
import { CategoryOrderPaymentDetailComponent } from './category-order-payment/category-order-payment-detail/category-order-payment-detail.component';
import { CategoryOrderStatusComponent } from './category-order-status/category-order-status.component';
import { CategoryOrderStatusDetailComponent } from './category-order-status/category-order-status-detail/category-order-status-detail.component';
import { CompanyComponent } from './company/company.component';
import { CompanyDetailComponent } from './company/company-detail/company-detail.component';
import { MembershipComponent } from './membership/membership.component';
import { MembershipDetailComponent } from './membership/membership-detail/membership-detail.component';
import { ShopComponent } from './shop/shop.component';
import { ShopDetailComponent } from './shop/shop-detail/shop-detail.component';
import { ShipperComponent } from './shipper/shipper.component';
import { ShipperDetailComponent } from './shipper/shipper-detail/shipper-detail.component';
import { MembershipFileComponent } from './membership-file/membership-file.component';
import { MembershipFileDetailComponent } from './membership-file/membership-file-detail/membership-file-detail.component';
import { OrderDeliveryComponent } from './order-delivery/order-delivery.component';
import { OrderDeliveryDetailComponent } from './order-delivery/order-delivery-detail/order-delivery-detail.component';
import { OrderDeliveryInfoComponent } from './order-delivery/order-delivery-info/order-delivery-info.component';
import { OrderDeliveryPaymentHistoryComponent } from './order-delivery-payment-history/order-delivery-payment-history.component';
import { OrderDeliveryPaymentHistoryDetailComponent } from './order-delivery-payment-history/order-delivery-payment-history-detail/order-delivery-payment-history-detail.component';
import { OrderReceiveComponent } from './order-receive/order-receive.component';
import { OrderReceiveInfoComponent } from './order-receive/order-receive-info/order-receive-info.component';
import { OrderShipperComponent } from './order-shipper/order-shipper.component';
import { OrderShipperInfoComponent } from './order-shipper/order-shipper-info/order-shipper-info.component';
import { OrderShipperLiveComponent } from './order-shipper-live/order-shipper-live.component';


@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,
    BankComponent,
    BankDetailComponent,
    UploadComponent,
    ProvinceComponent,
    DistrictComponent,
    WardComponent,
    ProvinceDetailComponent,
    DistrictDetailComponent,
    WardDetailComponent,
    CategoryMembershipComponent,
    CategoryMembershipDetailComponent,
    CategoryOrderDetailComponent,
    CategoryOrderDetailDetailComponent,
    CategoryOrderPaymentComponent,
    CategoryOrderPaymentDetailComponent,
    CategoryOrderStatusComponent,
    CategoryOrderStatusDetailComponent,
    CompanyComponent,
    CompanyDetailComponent,
    MembershipComponent,
    MembershipDetailComponent,
    ShopComponent,
    ShopDetailComponent,
    ShipperComponent,
    ShipperDetailComponent,
    MembershipFileComponent,
    MembershipFileDetailComponent,
    OrderDeliveryComponent,
    OrderDeliveryDetailComponent,
    OrderDeliveryInfoComponent,
    OrderDeliveryPaymentHistoryComponent,
    OrderDeliveryPaymentHistoryDetailComponent,
    OrderReceiveComponent,
    OrderReceiveInfoComponent,
    OrderShipperComponent,
    OrderShipperInfoComponent,
    OrderShipperLiveComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ChartsModule,
    CKEditorModule,
  ],
  providers: [   
    CookieService,  
    NotificationService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}
  ],
  bootstrap: [AppComponent],
  entryComponents:[]
})
export class AppModule { }
