import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderShipper } from 'src/app/shared/OrderShipper.model';
import { OrderShipperService } from 'src/app/shared/OrderShipper.service';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-order-shipper-info',
  templateUrl: './order-shipper-info.component.html',
  styleUrls: ['./order-shipper-info.component.css']
})
export class OrderShipperInfoComponent implements OnInit {

  URLOrderDeliveryInfo: string = environment.DomainDestination + "OrderDeliveryInfo";
  URLSub: string = environment.DomainDestination + "OrderShipperInfo";
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Active', 'ShipperFullName', 'Barcode', 'ShopFullName', 'CustomerAddress', 'Note'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public router: Router,
    public OrderShipperService: OrderShipperService,
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
  onChangeDateCreated(value) {
    this.OrderShipperService.formData.DateCreated = new Date(value);
  }
  getShipperToList() {
    this.MembershipService.GetByParentIDToListAsync(environment.ShipperID).subscribe(
      res => {
        this.MembershipService.listShipper = (res as Membership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.MembershipService.listShipper) {
          if (this.MembershipService.listShipper.length > 0) {
            if (this.OrderShipperService.formData.ID == 0) {
              this.OrderShipperService.formData.ShipperID = this.MembershipService.listShipper[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  GetByOrderShipperIDToListAsync() {
    this.OrderDeliveryService.GetByOrderShipperIDToListAsync(this.OrderShipperService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryService.list = res as OrderDelivery[];
        console.log(this.OrderDeliveryService.list);
        this.dataSource = new MatTableDataSource(this.OrderDeliveryService.list.sort((a, b) => (a.ShopFullName < b.ShopFullName ? 1 : -1)));
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
    this.OrderShipperService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderShipperService.formData = res as OrderShipper;
      if (this.OrderShipperService.formData) {
        if (this.OrderShipperService.formData.ID > 0) {
          this.GetByOrderShipperIDToListAsync();
        }
      }
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.OrderShipperService.SaveAsync(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        if (this.OrderShipperService.formData.ID == 0) {
          this.OrderShipperService.formData = res as OrderShipper;
          window.location.href = this.URLSub + "/" + this.OrderShipperService.formData.ID;
        }
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onActiveChange(element: OrderDelivery) {
    this.OrderDeliveryService.UpdateByIDAndActiveAndOrderShipperIDAsync(element.ID, element.Active, this.OrderShipperService.formData.ID).subscribe(
      res => {
        this.GetByOrderShipperIDToListAsync();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}
