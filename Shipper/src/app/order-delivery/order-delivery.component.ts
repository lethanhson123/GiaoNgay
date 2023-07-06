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
import { MembershipService } from 'src/app/shared/Membership.service';
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
  displayColumns: string[] = ['Barcode'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public OrderDeliveryService: OrderDeliveryService,
    public DownloadService: DownloadService,
    public MembershipService: MembershipService,
    public NotificationService: NotificationService,
  ) {

  }
  onChangeDateTimeBegin(value) {
    this.dateTimeBegin = new Date(value);
  }
  onChangeDateTimeEnd(value) {
    this.dateTimeEnd = new Date(value);
  }
  ngOnInit(): void {

    this.onSearch();
    this.id = setInterval(() => {
      this.onSearch();
    }, 60000);
  }

  onSearch() {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetByShipperIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.MembershipService.MembershipID, 2, this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
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
}
