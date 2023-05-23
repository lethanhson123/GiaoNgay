import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { BankService } from 'src/app/shared/Bank.service';

@Component({
  selector: 'app-bank-detail',
  templateUrl: './bank-detail.component.html',
  styleUrls: ['./bank-detail.component.css']
})
export class BankDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public BankService: BankService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<BankDetailComponent>,
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
    this.BankService.SaveAsync(form.value).subscribe(
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
