import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from 'src/app/shared/notification.service';
import { MembershipFile } from 'src/app/shared/MembershipFile.model';
import { MembershipFileService } from 'src/app/shared/MembershipFile.service';
import { MembershipService } from 'src/app/shared/Membership.service';


@Component({
  selector: 'app-membership-file-detail',
  templateUrl: './membership-file-detail.component.html',
  styleUrls: ['./membership-file-detail.component.css']
})
export class MembershipFileDetailComponent implements OnInit {

  imageURL: string = environment.APIRootURL + environment.Image + "/" + environment.Membership;
  ID: number = environment.InitializationNumber;
  fileToUpload: any;
  fileToUpload0: File = null;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'actions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public MembershipService: MembershipService,
    public MembershipFileService: MembershipFileService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<MembershipFileDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }
  ngOnInit(): void {
    this.getToList();
  }

  onClose() {
    this.dialogRef.close();
  }
  getToList() {
    this.MembershipFileService.GetByParentIDToListAsync(this.MembershipFileService.formData.ParentID).subscribe(
      res => {
        this.MembershipFileService.list = res as MembershipFile[];
        this.dataSource = new MatTableDataSource(this.MembershipFileService.list.sort((a, b) => (a.Name > b.Name ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      err => {
      }
    );
  }
  onSubmit(form: NgForm) {
    this.MembershipFileService.SaveAndUploadFile(form.value, this.fileToUpload).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getToList();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  changeImage(files: FileList) {
    if (files) {
      this.fileToUpload = files;
      this.fileToUpload0 = files.item(0);
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.MembershipFileService.formData.Note = event.target.result;
      };
      reader.readAsDataURL(this.fileToUpload0);
    }
  }
  onDelete(element: MembershipFile) {
    if (confirm(environment.DeleteConfirm)) {
      this.MembershipFileService.RemoveAsync(element.ID).subscribe(
        res => {
          this.notificationService.success(environment.DeleteSuccess);
          this.getToList();
        },
        err => {
          this.notificationService.warn(environment.SaveNotSuccess);
        }
      );      
    }
  }
}