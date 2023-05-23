import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { CategoryOrderStatusService } from 'src/app/shared/CategoryOrderStatus.service';

@Component({
  selector: 'app-category-order-status-detail',
  templateUrl: './category-order-status-detail.component.html',
  styleUrls: ['./category-order-status-detail.component.css']
})
export class CategoryOrderStatusDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public CategoryOrderStatusService: CategoryOrderStatusService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<CategoryOrderStatusDetailComponent>,
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
    this.CategoryOrderStatusService.SaveAsync(form.value).subscribe(
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