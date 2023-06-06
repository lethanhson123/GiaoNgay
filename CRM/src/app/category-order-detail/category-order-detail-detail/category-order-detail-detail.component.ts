import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { CategoryOrderDetailService } from 'src/app/shared/CategoryOrderDetail.service';
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { Province } from 'src/app/shared/Province.model';
import { ProvinceService } from 'src/app/shared/Province.service';

@Component({
  selector: 'app-category-order-detail-detail',
  templateUrl: './category-order-detail-detail.component.html',
  styleUrls: ['./category-order-detail-detail.component.css']
})
export class CategoryOrderDetailDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public CategoryOrderDetailService: CategoryOrderDetailService,
    public WardService: WardService,
    public DistrictService: DistrictService,
    public ProvinceService: ProvinceService,
    public NotificationService: NotificationService,
    public dialogRef: MatDialogRef<CategoryOrderDetailDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.ID = data["ID"] as number;
  }  
  ngOnInit(): void {
    this.GetProvinceToList();
  }
  onClose() {    
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {    
    this.CategoryOrderDetailService.SaveAsync(form.value).subscribe(
      res => {
        this.NotificationService.success(environment.SaveSuccess);
        this.onClose();
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
        this.onClose();
      }
    );
  }
  GetProvinceToList() {
    this.ProvinceService.GetAllToListAsync().subscribe(
      res => {
        this.ProvinceService.list = (res as Province[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.ProvinceService.list) {
          if (this.ProvinceService.list.length > 0) {
            if (this.CategoryOrderDetailService.formData.ID == 0) {
              this.CategoryOrderDetailService.formData.ProvinceID = this.ProvinceService.list[0].ID;
            }
          }
        }
        this.getDistrictToList();
      },
      err => {
      }
    );
  }
  getDistrictToList() {
    this.DistrictService.GetByParentIDToListAsync(this.CategoryOrderDetailService.formData.ProvinceID).subscribe(
      res => {
        this.DistrictService.list = (res as District[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.DistrictService.list) {
          if (this.DistrictService.list.length > 0) {
            if (this.CategoryOrderDetailService.formData.ID == 0) {
              this.CategoryOrderDetailService.formData.DistrictID = this.DistrictService.list[0].ID;
            }
          }
        }
        this.getWardToList();
      },
      err => {
      }
    );
  }
  getWardToList() {
    this.WardService.GetByParentIDToListAsync(this.CategoryOrderDetailService.formData.DistrictID).subscribe(
      res => {
        this.WardService.list = (res as Ward[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.WardService.list) {
          if (this.WardService.list.length > 0) {
            if (this.CategoryOrderDetailService.formData.ID == 0) {
              this.CategoryOrderDetailService.formData.WardID = this.WardService.list[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  onChangeProvinceID($event) {
    this.getDistrictToList();
  }
  onChangeDistrictID($event) {
    this.getWardToList();
  }
}
