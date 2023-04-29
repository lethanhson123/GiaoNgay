import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BankComponent } from './bank/bank.component';
import { UploadComponent } from './upload/upload.component';
import { ProvinceComponent } from './province/province.component';
import { DistrictComponent } from './district/district.component';
import { WardComponent } from './ward/ward.component';

const routes: Routes = [  
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
