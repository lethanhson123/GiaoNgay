import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderCall } from 'src/app/shared/OrderCall.model';
import { OrderCallService } from 'src/app/shared/OrderCall.service';
import { OrderCallDetailComponent } from './order-call-detail/order-call-detail.component';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';
import { MembershipService } from 'src/app/shared/Membership.service';


@Component({
  selector: 'app-order-call',
  templateUrl: './order-call.component.html',
  styleUrls: ['./order-call.component.css']
})
export class OrderCallComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ShopFullName', 'Quantity'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  dateTimeBegin: Date = new Date();
  dateTimeEnd: Date = new Date();
  id: any;
  constructor(
    public OrderCallService: OrderCallService,
    public DownloadService: DownloadService,
    public MembershipService: MembershipService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {

    this.onSearch();
    this.id = setInterval(() => {
      this.onSearch();
    }, 60000);
  }
  onChangeDateTimeBegin(value) {
    this.dateTimeBegin = new Date(value);
  }
  onChangeDateTimeEnd(value) {
    this.dateTimeEnd = new Date(value);
  }
  getToList() {
    this.isShowLoading = true;
    this.OrderCallService.GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.MembershipService.MembershipID, 1, this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
      res => {
        this.OrderCallService.list = res as OrderCall[];
        this.dataSource = new MatTableDataSource(this.OrderCallService.list.sort((a, b) => (a.ShopFullName > b.ShopFullName ? 1 : -1)));
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
    this.OrderCallService.GetByIDAsync(ID).subscribe(
      res => {
        this.OrderCallService.formData = res as OrderCall;
        if (this.OrderCallService.formData) {
          this.OrderCallService.formData.ShopID = this.MembershipService.MembershipID;
        }
        console.log(this.MembershipService.MembershipID);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(OrderCallDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
}
