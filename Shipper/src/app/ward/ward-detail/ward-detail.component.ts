import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { WardService } from 'src/app/shared/Ward.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';

@Component({
  selector: 'app-ward-detail',
  templateUrl: './ward-detail.component.html',
  styleUrls: ['./ward-detail.component.css']
})
export class WardDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public DistrictService: DistrictService,
    public WardService: WardService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<WardDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.ID = data["ID"] as number;
  }  
  ngOnInit(): void {
    this.getDistrictToList();    
  }
  getDistrictToList() {    
    this.DistrictService.GetByParentIDToListAsync(1).subscribe(
      res => {        
        this.DistrictService.list = (res as District[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));        
      },
      err => {        
      }
    );
  }
  onClose() {    
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {    
    this.WardService.SaveAsync(form.value).subscribe(
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