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

@Component({
  selector: 'app-order-call',
  templateUrl: './order-call.component.html',
  styleUrls: ['./order-call.component.css']
})
export class OrderCallComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'DateCreated', 'ShopFullName', 'ShipperFullName', 'Quantity'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  day: number = new Date().getUTCDate();
  id: any;
  constructor(
    public OrderCallService: OrderCallService,
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
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  getToList() {
    this.isShowLoading = true;
    this.OrderCallService.GetByYearAndMonthAndDayAndSearchStringToLisAsync(this.year, this.month, this.day, this.searchString).subscribe(
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
}
