import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';
import { MembershipService } from 'src/app/shared/Membership.service';
import { UploadComponent } from '../upload/upload.component';
import { OrderDeliveryDisplayColumnsComponent } from './order-delivery-display-columns/order-delivery-display-columns.component';
import { CategoryOrderStatus } from 'src/app/shared/CategoryOrderStatus.model';
import { CategoryOrderStatusService } from 'src/app/shared/CategoryOrderStatus.service';

@Component({
  selector: 'app-order-delivery',
  templateUrl: './order-delivery.component.html',
  styleUrls: ['./order-delivery.component.css']
})
export class OrderDeliveryComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  dateTimeBegin: Date = new Date();
  dateTimeEnd: Date = new Date();
  id: any;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public OrderDeliveryService: OrderDeliveryService,
    public CategoryOrderStatusService: CategoryOrderStatusService,
    public DownloadService: DownloadService,
    public MembershipService: MembershipService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) {

  }

  ngOnInit(): void {   
    this.GetCategoryOrderStatusToList();
    this.onSearch();
    this.id = setInterval(() => {
      this.onSearch();
    }, 60000);
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
  onSearch() {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;    
    this.OrderDeliveryService.GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.MembershipService.MembershipID, this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
      res => {
        this.OrderDeliveryService.list = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list);
        this.displayColumns = this.OrderDeliveryService.displayColumns;
        this.dataSource = new MatTableDataSource(this.OrderDeliveryService.list.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onPrint(ID: number) {
    this.isShowLoading = true;
    this.DownloadService.OrderDeliveryByIDToHTML(ID).then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
  onAdd(ID: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(UploadComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.onSearch();
    });
  }
  onDelete(element: OrderDelivery) {
    if (confirm(environment.DeleteConfirm)) {
      element.Active = false;
      this.OrderDeliveryService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearch();
        },
        err => {
          this.NotificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  onShowHidden() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    const dialog = this.dialog.open(OrderDeliveryDisplayColumnsComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {      
    });
  }
}
