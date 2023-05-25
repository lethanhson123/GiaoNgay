import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { QuickAccessService } from 'src/app/shared/QuickAccess.service';
import { CategoryMembership } from 'src/app/shared/CategoryMembership.model';
import { CategoryMembershipService } from 'src/app/shared/CategoryMembership.service';

@Component({
  selector: 'app-quick-access-detail',
  templateUrl: './quick-access-detail.component.html',
  styleUrls: ['./quick-access-detail.component.css']
})
export class QuickAccessDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public QuickAccessService: QuickAccessService,  
    public CategoryMembershipService: CategoryMembershipService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<QuickAccessDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.ID = data["ID"] as number;
  }  
  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.CategoryMembershipService.GetAllToListAsync().subscribe(
      res => {        
        this.CategoryMembershipService.list = (res as CategoryMembership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));         
        if (this.CategoryMembershipService.list) {
          if (this.CategoryMembershipService.list.length > 0) {
            if (this.QuickAccessService.formData.ID == 0) {
              this.QuickAccessService.formData.ParentID = this.CategoryMembershipService.list[0].ID;
            }
          }
        }       
      },
      err => {        
      }
    );
  }
  onClose() {    
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {    
    this.QuickAccessService.SaveAsync(form.value).subscribe(
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