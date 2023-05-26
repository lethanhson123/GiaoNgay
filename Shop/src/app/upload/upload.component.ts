import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UploadService } from 'src/app/shared/upload.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { MembershipService } from 'src/app/shared/Membership.service';
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  isShowLoading: boolean = false;

  isOrderDelivery: boolean = false;
  excelTemplateOrderDeliveryURL: string = environment.APIRootURL + environment.Download + "/" + environment.OrderDelivery + "/" + environment.OrderDelivery + ".xlsx";
  @ViewChild('uploadOrderDelivery') uploadOrderDelivery!: ElementRef;

  constructor(
    public UploadService: UploadService,
    public NotificationService: NotificationService,
    public MembershipService: MembershipService,
    public dialogRef: MatDialogRef<UploadComponent>,
  ) { }
  changeOrderDelivery(files: FileList) {
    if (files) {
      this.isOrderDelivery = true;
    }
  }
  ngOnInit(): void {
  }
  onClose() {
    this.dialogRef.close();
  }
  onSubmit() {
    let fileToUpload: File;
    fileToUpload = this.uploadOrderDelivery.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostOrderDeliveryListByExcelFile(this.MembershipService.MembershipID, fileToUpload).subscribe(
      data => {
        this.NotificationService.warn(environment.UploadSuccess);
        this.isShowLoading = false;
        this.onClose();
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
        this.onClose();
      }
    );
  }
}
