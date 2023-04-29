import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { DistrictService } from 'src/app/shared/District.service';

@Component({
  selector: 'app-district-detail',
  templateUrl: './district-detail.component.html',
  styleUrls: ['./district-detail.component.css']
})
export class DistrictDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public DistrictService: DistrictService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<DistrictDetailComponent>,
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
    this.DistrictService.SaveAsync(form.value).subscribe(
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