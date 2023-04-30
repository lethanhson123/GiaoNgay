import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { CategoryMembershipService } from 'src/app/shared/CategoryMembership.service';

@Component({
  selector: 'app-category-membership-detail',
  templateUrl: './category-membership-detail.component.html',
  styleUrls: ['./category-membership-detail.component.css']
})
export class CategoryMembershipDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public CategoryMembershipService: CategoryMembershipService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<CategoryMembershipDetailComponent>,
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
    this.CategoryMembershipService.SaveAsync(form.value).subscribe(
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
