import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderCall } from 'src/app/shared/OrderCall.model';
import { OrderCallService } from 'src/app/shared/OrderCall.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { OrderCallFile } from 'src/app/shared/OrderCallFile.model';
import { OrderCallFileService } from 'src/app/shared/OrderCallFile.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-order-call-detail',
  templateUrl: './order-call-detail.component.html',
  styleUrls: ['./order-call-detail.component.css']
})
export class OrderCallDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  fileToUpload: any;
  imageURL: string = environment.APIRootURL + "" + environment.Image + "/" + environment.OrderCall + "/";  
  isShowLoading: boolean = false;

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Note', 'actions'];

  

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public OrderCallService: OrderCallService,
    public OrderCallFileService: OrderCallFileService,
    public MembershipService: MembershipService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<OrderCallDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }
  ngOnInit(): void {   
    this.GetOrderCallFileByParentIDToListAsync();
  } 
 
  onClose() {
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {    
    this.OrderCallService.SaveAsync(form.value).subscribe(
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
    }
  }
  GetOrderCallFileByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderCallFileService.GetByParentIDToListAsync(this.OrderCallService.formData.ID).subscribe(
      res => {
        this.OrderCallFileService.list = res as OrderCallFile[];
        this.dataSource = new MatTableDataSource(this.OrderCallFileService.list.sort((a, b) => (a.CreatedDate > b.CreatedDate ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onOrderCallFileAdd() {
    this.OrderCallFileService.SaveAndUploadFiles(this.OrderCallService.formData.ID, this.fileToUpload).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.GetOrderCallFileByParentIDToListAsync();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onOrderCallFileDelete(element: OrderCallFile) {
    if (confirm(environment.DeleteConfirm)) {
      this.OrderCallFileService.RemoveAsync(element.ID).subscribe(
        res => {
          this.GetOrderCallFileByParentIDToListAsync();
        },
        err => {
          this.notificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  onChangeDateCreated(value) {
    this.OrderCallService.formData.DateCreated = new Date(value);
  }
}
