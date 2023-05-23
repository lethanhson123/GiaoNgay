import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderReceive } from 'src/app/shared/OrderReceive.model';
import { OrderReceiveService } from 'src/app/shared/OrderReceive.service';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-order-receive-info',
  templateUrl: './order-receive-info.component.html',
  styleUrls: ['./order-receive-info.component.css']
})
export class OrderReceiveInfoComponent implements OnInit {

  URLOrderDeliveryInfo: string = environment.DomainDestination + "OrderDeliveryInfo";
  URLSub: string = environment.DomainDestination + "OrderReceiveInfo";
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Active', 'ReceiveFullName', 'Barcode', 'CustomerAddress', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public router: Router,
    public OrderReceiveService: OrderReceiveService,
    public OrderDeliveryService: OrderDeliveryService,
    public MembershipService: MembershipService,
    public notificationService: NotificationService,
  ) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.getByQueryString();
      }
    });
  }

  ngOnInit(): void {
    this.getShipperToList();
  }
  getShipperToList() {
    this.MembershipService.GetByParentIDToListAsync(environment.ShipperID).subscribe(
      res => {
        this.MembershipService.listShipper = (res as Membership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.MembershipService.listShipper) {
          if (this.MembershipService.listShipper.length > 0) {
            if (this.OrderReceiveService.formData.ID == 0) {
              this.OrderReceiveService.formData.ReceiveID = this.MembershipService.listShipper[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  GetByOrderReceiveIDToListAsync() {
    this.OrderDeliveryService.GetByOrderReceiveIDToListAsync(this.OrderReceiveService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryService.list = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list);
        this.dataSource = new MatTableDataSource(this.OrderDeliveryService.list.sort((a, b) => (a.CustomerAddress < b.CustomerAddress ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
      }
    );
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.OrderReceiveService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderReceiveService.formData = res as OrderReceive;
      if (this.OrderReceiveService.formData) {
        if (this.OrderReceiveService.formData.ID > 0) {
          this.GetByOrderReceiveIDToListAsync();
        }
      }
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.OrderReceiveService.SaveAsync(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        if (this.OrderReceiveService.formData.ID == 0) {
          this.OrderReceiveService.formData = res as OrderReceive;
          window.location.href = this.URLSub + "/" + this.OrderReceiveService.formData.ID;
        }
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onActiveChange(element: OrderDelivery) {
    this.OrderDeliveryService.UpdateByIDAndActiveAndOrderReceiveIDAsync(element.ID, element.Active, this.OrderReceiveService.formData.ID).subscribe(
      res => {
        this.GetByOrderReceiveIDToListAsync();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}