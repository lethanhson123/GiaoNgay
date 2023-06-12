import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderReceive } from 'src/app/shared/OrderReceive.model';
import { OrderReceiveService } from 'src/app/shared/OrderReceive.service';
import { OrderCall } from 'src/app/shared/OrderCall.model';
import { OrderCallService } from 'src/app/shared/OrderCall.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatCheckboxChange } from '@angular/material/checkbox';

@Component({
  selector: 'app-order-receive-info',
  templateUrl: './order-receive-info.component.html',
  styleUrls: ['./order-receive-info.component.css']
})
export class OrderReceiveInfoComponent implements OnInit {

  URLOrderCallInfo: string = environment.DomainDestination + "OrderCallInfo";
  URLSub: string = environment.DomainDestination + "OrderReceiveInfo";
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Active', 'ShipperFullName', 'ShopFullName', 'ShopAddress', 'Note'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public router: Router,
    public OrderReceiveService: OrderReceiveService,
    public OrderCallService: OrderCallService,
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
    this.OrderReceiveService.formData.DateCreated = new Date(value);
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
    this.OrderCallService.GetByOrderReceiveIDToListAsync(this.OrderReceiveService.formData.ID).subscribe(
      res => {
        this.OrderCallService.list = res as OrderCall[];
        this.dataSource = new MatTableDataSource(this.OrderCallService.list.sort((a, b) => (a.ShopFullName < b.ShopFullName ? 1 : -1)));
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
  onActiveChange(element: OrderCall) {
    this.OrderCallService.UpdateByIDAndActiveAndOrderReceiveIDAsync(element.ID, element.Active, this.OrderReceiveService.formData.ID).subscribe(
      res => {
        this.GetByOrderReceiveIDToListAsync();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onSelectAllChange(event: MatCheckboxChange) {
    this.OrderCallService.list.forEach(item => {
      this.OrderCallService.UpdateByIDAndActiveAndOrderReceiveIDAsync(item.ID, event.checked, this.OrderReceiveService.formData.ID).subscribe(
        res => {
          this.GetByOrderReceiveIDToListAsync();
        },
        err => {
        }
      );
    });
  }
}