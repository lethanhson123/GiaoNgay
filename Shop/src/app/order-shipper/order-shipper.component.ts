import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderShipper } from 'src/app/shared/OrderShipper.model';
import { OrderShipperService } from 'src/app/shared/OrderShipper.service';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-order-shipper',
  templateUrl: './order-shipper.component.html',
  styleUrls: ['./order-shipper.component.css']
})
export class OrderShipperComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderShipperInfo";
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'DateCreated', 'Name'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;

  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  day: number = new Date().getUTCDate();
  id: any;
  constructor(
    public OrderShipperService: OrderShipperService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,    
  ) { }

  ngOnInit(): void {
    this.GetYear();
    this.GetMonth();
    this.GetDay();
    this.onSearch();   
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
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  getToList() {
    this.isShowLoading = true;
    this.OrderShipperService.GetByYearAndMonthAndDayAndSearchStringToLisAsync(this.year, this.month, this.day, this.searchString).subscribe(
      res => {        
        this.OrderShipperService.list = res as OrderShipper[];        
        this.dataSource = new MatTableDataSource(this.OrderShipperService.list.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
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
    this.getToList();
  }
}
