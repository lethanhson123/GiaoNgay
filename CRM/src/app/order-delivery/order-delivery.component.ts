import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { OrderDeliveryDetailComponent } from './order-delivery-detail/order-delivery-detail.component';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';
import { CategoryOrderStatus } from 'src/app/shared/CategoryOrderStatus.model';
import { CategoryOrderStatusService } from 'src/app/shared/CategoryOrderStatus.service';
import { Province } from 'src/app/shared/Province.model';
import { ProvinceService } from 'src/app/shared/Province.service';

@Component({
  selector: 'app-order-delivery',
  templateUrl: './order-delivery.component.html',
  styleUrls: ['./order-delivery.component.css']
})
export class OrderDeliveryComponent implements OnInit {

  provinceID: number = environment.InitializationNumber;
  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['DateCreated', 'Barcode', 'ShopFullName', 'TotalBeforeTax', 'CategoryOrderStatusID', 'IsCompleteShop', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;

  dateTimeBegin: Date = new Date();
  dateTimeEnd: Date = new Date();
  id: any;
  constructor(
    public OrderDeliveryService: OrderDeliveryService,
    public CategoryOrderStatusService: CategoryOrderStatusService,
    public ProvinceService: ProvinceService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.GetProvinceToList();
    this.GetCategoryOrderStatusToList();
    this.onSearch();
    this.id = setInterval(() => {
      this.onSearch();
    }, 60000);
  }
  ngOnDestroy() {
    if (this.id) {
      clearInterval(this.id);
    }
  }
  GetProvinceToList() {
    this.ProvinceService.GetAllToListAsync().subscribe(
      res => {
        this.ProvinceService.list = (res as Province[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.ProvinceService.list) {
          if (this.ProvinceService.list.length > 0) {
            this.provinceID = this.ProvinceService.list[0].ID;
          }
        }
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

  GetToLisAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.provinceID, this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
      res => {
        this.OrderDeliveryService.list = res as OrderDelivery[];
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
  onSearch() {
    this.GetToLisAsync();
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
  GetCategoryOrderStatusToList() {
    this.CategoryOrderStatusService.GetAllToListAsync().subscribe(
      res => {
        this.CategoryOrderStatusService.list = (res as CategoryOrderStatus[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
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
}
