import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { CategoryOrderPaymentService } from 'src/app/shared/CategoryOrderPayment.service';

@Component({
  selector: 'app-category-order-payment-detail',
  templateUrl: './category-order-payment-detail.component.html',
  styleUrls: ['./category-order-payment-detail.component.css']
})
export class CategoryOrderPaymentDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public CategoryOrderPaymentService: CategoryOrderPaymentService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<CategoryOrderPaymentDetailComponent>,
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
    this.CategoryOrderPaymentService.SaveAsync(form.value).subscribe(
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
