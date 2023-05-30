import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { MembershipService } from 'src/app/shared/Membership.service';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-membership-total-debt',
  templateUrl: './membership-total-debt.component.html',
  styleUrls: ['./membership-total-debt.component.css']
})
export class MembershipTotalDebtComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'DateCreated', 'Barcode', 'CustomerFullName', 'TotalBeforeTax', 'CategoryOrderStatusID', 'IsCompleteShop', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  queryString: string = environment.InitializationString;
  constructor(
    public router: Router,    
    public OrderDeliveryService: OrderDeliveryService,
    public MembershipService: MembershipService,
    public DownloadService: DownloadService,
  ) { 
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.getByQueryString();
      }
    });
  }

  ngOnInit(): void {
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetShopByShopIDAndIsCompleteShopListAsync(this.MembershipService.MembershipID).then(res => {
      this.OrderDeliveryService.list = res as OrderDelivery[];     
      this.dataSource = new MatTableDataSource(this.OrderDeliveryService.list.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator; 
      this.isShowLoading = false;
    });
  }
  onSearch() {
    this.getByQueryString();
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