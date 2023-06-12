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
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { CategoryOrderStatus } from 'src/app/shared/CategoryOrderStatus.model';
import { CategoryOrderStatusService } from 'src/app/shared/CategoryOrderStatus.service';

@Component({
  selector: 'app-order-call',
  templateUrl: './order-call.component.html',
  styleUrls: ['./order-call.component.css']
})
export class OrderCallComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['DateCreated', 'CategoryOrderStatusID', 'ShopFullName', 'ShipperFullName', 'Quantity', 'ShopAddress', 'Note', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  dateTimeBegin: Date = new Date();
  dateTimeEnd: Date = new Date();
  id: any;
  constructor(
    public OrderCallService: OrderCallService,
    public MembershipService: MembershipService,
    public CategoryOrderStatusService: CategoryOrderStatusService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {    
    this.GetCategoryOrderStatusToList();
    this.GetShipperToList();
    this.onSearch();
    this.id = setInterval(() => {
      this.onSearch();
    }, 60000);
  }
  GetShipperToList() {
    this.MembershipService.GetByParentIDToListAsync(environment.ShipperID).subscribe(
      res => {
        this.MembershipService.listShipper = (res as Membership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));        
      },
      err => {
      }
    );
  }
  GetCategoryOrderStatusToList() {
    this.CategoryOrderStatusService.GetAllToListAsync().subscribe(
      res => {
        this.CategoryOrderStatusService.list = (res as CategoryOrderStatus[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  onChangeDateTimeBegin(value) {
    this.dateTimeBegin = new Date(value);
  }
  onChangeDateTimeEnd(value) {
    this.dateTimeEnd = new Date(value);
  }
  getToList() {
    this.isShowLoading = true;
    this.OrderCallService.GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
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
        console.log(this.OrderCallService.formData);
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
  onDelete(element: OrderCall) {
    if (confirm(environment.DeleteConfirm)) {
      element.Active = false;
      this.OrderCallService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearch();
        },
        err => {
          this.NotificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  onSave(element: OrderCall) {
    this.OrderCallService.SaveAsync(element).subscribe(
      res => {
        this.NotificationService.success(environment.SaveSuccess);        
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);        
      }
    );
  }
}
