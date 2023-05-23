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

@Component({
  selector: 'app-order-delivery',
  templateUrl: './order-delivery.component.html',
  styleUrls: ['./order-delivery.component.css']
})
export class OrderDeliveryComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  dataSource01: MatTableDataSource<any>;
  dataSource02: MatTableDataSource<any>;
  dataSource03: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'DateCreated', 'Barcode','ShopFullName', 'TotalBeforeTax', 'TotalPayment', 'TotalDebt', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;

  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  day: number = new Date().getUTCDate();
  id: any;
  constructor(
    public OrderDeliveryService: OrderDeliveryService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.GetYear();
    this.GetMonth();
    this.GetDay();
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
  GetYear() {
    this.isShowLoading = true;
    this.DownloadService.GetYear().subscribe(
      res => {        
        this.DownloadService.listYear = res as DateHelper[];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetMonth() {
    this.isShowLoading = true;
    this.DownloadService.GetMonth().subscribe(
      res => {        
        this.DownloadService.listMonth = res as DateHelper[];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetDay() {
    this.isShowLoading = true;
    this.DownloadService.GetDay().subscribe(
      res => {        
        this.DownloadService.listDay = res as DateHelper[];
        this.get01ToList();
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  get01ToList() {
    this.isShowLoading = true;
    this.OrderDeliveryService.Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(this.year, this.month, this.day, this.searchString).subscribe(
      res => {        
        this.OrderDeliveryService.list01 = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list01);
        this.dataSource01 = new MatTableDataSource(this.OrderDeliveryService.list01.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
        this.dataSource01.sort = this.sort;
        this.dataSource01.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  get02ToList() {    
    this.isShowLoading = true;
    this.OrderDeliveryService.Get02ByYearAndMonthAndDayAndSearchStringToLisAsync(this.year, this.month, this.day, this.searchString).subscribe(
      res => {                
        this.OrderDeliveryService.list02 = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list02);
        this.dataSource02 = new MatTableDataSource(this.OrderDeliveryService.list02.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
        this.dataSource02.sort = this.sort;
        this.dataSource02.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  get03ToList() {
    this.isShowLoading = true;
    this.OrderDeliveryService.Get03ByYearAndMonthAndDayAndSearchStringToLisAsync(this.year, this.month, this.day, this.searchString).subscribe(
      res => {        
        this.OrderDeliveryService.list03 = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list03);
        this.dataSource03 = new MatTableDataSource(this.OrderDeliveryService.list03.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
        this.dataSource03.sort = this.sort;
        this.dataSource03.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearch() {
    this.get01ToList();
    this.get02ToList();
    this.get03ToList();
  }
  onAdd(ID: any) {
    this.OrderDeliveryService.GetByIDAsync(ID).subscribe(
      res => {
        this.OrderDeliveryService.formData = res as OrderDelivery;                    
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(OrderDeliveryDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearch();
        });
      },
      err => {
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
}
