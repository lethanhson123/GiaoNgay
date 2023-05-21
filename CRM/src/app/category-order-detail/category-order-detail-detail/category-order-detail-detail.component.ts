import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { CategoryOrderDetailService } from 'src/app/shared/CategoryOrderDetail.service';

@Component({
  selector: 'app-category-order-detail-detail',
  templateUrl: './category-order-detail-detail.component.html',
  styleUrls: ['./category-order-detail-detail.component.css']
})
export class CategoryOrderDetailDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public CategoryOrderDetailService: CategoryOrderDetailService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<CategoryOrderDetailDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.ID = data["ID"] as number;
  }  
  ngOnInit(): void {
  }
  onClose() {    
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {    
    this.CategoryOrderDetailService.SaveAsync(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.onClose();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.onClose();
      }
    );
  }

}
