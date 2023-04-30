import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { CompanyService } from 'src/app/shared/Company.service';
import { Bank } from 'src/app/shared/Bank.model';
import { BankService } from 'src/app/shared/Bank.service';

@Component({
  selector: 'app-company-detail',
  templateUrl: './company-detail.component.html',
  styleUrls: ['./company-detail.component.css']
})
export class CompanyDetailComponent implements OnInit {

  imageURL: string = environment.APIRootURL + environment.Image;
  ID: number = environment.InitializationNumber;
  fileToUpload: any;
  fileToUpload0: File = null;
  constructor(
    public BankService: BankService,
    public CompanyService: CompanyService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<CompanyDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.ID = data["ID"] as number;    
  }  
  ngOnInit(): void {
    this.getDistrictToList();
  }
  getDistrictToList() {    
    this.BankService.GetAllToListAsync().subscribe(
      res => {        
        this.BankService.list = (res as Bank[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));        
      },
      err => {        
      }
    );
  }
  onClose() {    
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {    
    this.CompanyService.SaveAndUploadFile(form.value, this.fileToUpload).subscribe(
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
  changeImage(files: FileList) {
    if (files) {
      this.fileToUpload = files;
      this.fileToUpload0 = files.item(0);
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.CompanyService.formData.QRcodeFile = event.target.result;
      };
      reader.readAsDataURL(this.fileToUpload0);
    }
  }
}
