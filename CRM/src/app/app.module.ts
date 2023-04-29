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
import { BankComponent } from './bank/bank.component';
import { BankDetailComponent } from './bank/bank-detail/bank-detail.component';
import { UploadComponent } from './upload/upload.component';
import { ProvinceComponent } from './province/province.component';
import { DistrictComponent } from './district/district.component';
import { WardComponent } from './ward/ward.component';
import { ProvinceDetailComponent } from './province/province-detail/province-detail.component';
import { DistrictDetailComponent } from './district/district-detail/district-detail.component';
import { WardDetailComponent } from './ward/ward-detail/ward-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    BankComponent,
    BankDetailComponent,
    UploadComponent,
    ProvinceComponent,
    DistrictComponent,
    WardComponent,
    ProvinceDetailComponent,
    DistrictDetailComponent,
    WardDetailComponent    
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
