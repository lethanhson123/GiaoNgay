import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-order-delivery',
  templateUrl: './order-delivery.component.html',
  styleUrls: ['./order-delivery.component.css']
})
export class OrderDeliveryComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  day: number = new Date().getUTCDate();
  id: any;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Barcode'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public OrderDeliveryService: OrderDeliveryService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
  ) {

  }

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
  onSearch() {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    let membershipID = localStorage.getItem(environment.MembershipID);
    this.OrderDeliveryService.GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(Number(membershipID), this.year, this.month, this.day, this.searchString).subscribe(
      res => {
        this.OrderDeliveryService.list = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list);
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
}
