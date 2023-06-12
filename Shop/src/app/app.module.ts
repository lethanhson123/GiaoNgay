import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { CKEditorModule } from 'ngx-ckeditor';
import { WjInputModule } from '@grapecity/wijmo.angular2.input';
import { NotificationService } from './shared/notification.service';
import { CookieService } from 'ngx-cookie-service';
import { ChartsModule } from 'ng2-charts';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { MembershipComponent } from './membership/membership.component';
import { OrderDeliveryComponent } from './order-delivery/order-delivery.component';
import { OrderDeliveryInfoComponent } from './order-delivery/order-delivery-info/order-delivery-info.component';
import { HomepageComponent } from './homepage/homepage.component';
import { OrderCallComponent } from './order-call/order-call.component';
import { OrderCallDetailComponent } from './order-call/order-call-detail/order-call-detail.component';
import { UploadComponent } from './upload/upload.component';
import { OrderDeliveryDesktopComponent } from './order-delivery-desktop/order-delivery-desktop.component';
import { MembershipTotalDebtComponent } from './membership-total-debt/membership-total-debt.component';
import { OrderShipperComponent } from './order-shipper/order-shipper.component';
import { OrderShipperInfoComponent } from './order-shipper/order-shipper-info/order-shipper-info.component';
import { OrderDeliveryDisplayColumnsComponent } from './order-delivery/order-delivery-display-columns/order-delivery-display-columns.component';


@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,
    MembershipComponent,
    OrderDeliveryComponent,
    OrderDeliveryInfoComponent,    
    HomepageComponent,
    OrderCallComponent,
    OrderCallDetailComponent,
    UploadComponent,
    OrderDeliveryDesktopComponent,
    MembershipTotalDebtComponent,
    OrderShipperComponent,
    OrderShipperInfoComponent,
    OrderDeliveryDisplayColumnsComponent,
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
    WjInputModule,
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
