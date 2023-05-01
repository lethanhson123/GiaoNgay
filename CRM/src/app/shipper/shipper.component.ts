import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { ShipperDetailComponent } from './shipper-detail/shipper-detail.component';
import { MembershipFileDetailComponent } from '../membership-file/membership-file-detail/membership-file-detail.component';
import { MembershipFile } from 'src/app/shared/MembershipFile.model';
import { MembershipFileService } from 'src/app/shared/MembershipFile.service';

@Component({
  selector: 'app-shipper',
  templateUrl: './shipper.component.html',
  styleUrls: ['./shipper.component.css']
})
export class ShipperComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'FullName', 'Phone', 'MotorbicycleNumber', 'Active', 'actions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public MembershipFileService: MembershipFileService,
    public MembershipService: MembershipService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.MembershipService.GetByParentIDToListAsync(environment.ShipperID).subscribe(
      res => {
        this.isShowLoading = false;
        this.MembershipService.list = res as Membership[];
        this.dataSource = new MatTableDataSource(this.MembershipService.list.sort((a, b) => (a.FullName > b.FullName ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearch() {
    if (this.searchString.length > 0) {
      this.dataSource.filter = this.searchString.toLowerCase();
    }
    else {
      this.getToList();
    }
  }
  onAdd(ID: any) {
    this.MembershipService.GetByIDAsync(ID).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        this.MembershipService.formData.ParentID = environment.ShipperID;
        console.log(this.MembershipService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(ShipperDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
  onOpenMembershipFile(ID: any) {
    this.MembershipService.GetByIDAsync(ID).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        console.log(this.MembershipService.formData);
        this.MembershipFileService.GetByIDAsync(0).subscribe(
          res => {
            this.MembershipFileService.formData = res as MembershipFile;
            this.MembershipFileService.formData.ParentID = ID;
            console.log(this.MembershipFileService.formData);
            const dialogConfig = new MatDialogConfig();
            dialogConfig.disableClose = true;
            dialogConfig.autoFocus = true;
            dialogConfig.width = environment.DialogConfigWidth;
            dialogConfig.data = { ID: ID };
            const dialog = this.dialog.open(MembershipFileDetailComponent, dialogConfig);
            dialog.afterClosed().subscribe(() => {
            });
          },
          err => {
          }
        );

      },
      err => {
      }
    ); 
  }
}
