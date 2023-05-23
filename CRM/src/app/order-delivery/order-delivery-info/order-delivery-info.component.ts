import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { OrderDeliveryDetail } from 'src/app/shared/OrderDeliveryDetail.model';
import { OrderDeliveryDetailService } from 'src/app/shared/OrderDeliveryDetail.service';
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-order-delivery-info',
  templateUrl: './order-delivery-info.component.html',
  styleUrls: ['./order-delivery-info.component.css']
})
export class OrderDeliveryInfoComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  BarcodeURL: string = environment.APIRootURL + environment.Barcode;
  QRcodeURL: string = environment.APIRootURL + environment.QRcode;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Name', 'Quantity', 'Price', 'Note', 'Total', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public router: Router,
    public DownloadService: DownloadService,
    public OrderDeliveryService: OrderDeliveryService,
    public OrderDeliveryDetailService: OrderDeliveryDetailService,
    public WardService: WardService,
    public DistrictService: DistrictService,
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
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderDeliveryService.formData = res as OrderDelivery;      
      if (this.OrderDeliveryService.formData) {
        this.GetByParentIDToListAsync();
        this.getShopToList();
        this.getShipperToList();
        this.getDistrictToList();
      }
      this.isShowLoading = false;
    });
  }
  GetByQueryString001() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderDeliveryService.formData = res as OrderDelivery;      
      if (this.OrderDeliveryService.formData) {
        this.GetByParentIDToListAsync();
      }
      this.isShowLoading = false;
    });
  }
  getShopToList() {
    this.MembershipService.GetByParentIDToListAsync(environment.ShopID).subscribe(
      res => {
        this.MembershipService.listShop = (res as Membership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.MembershipService.listShop) {
          if (this.MembershipService.listShop.length > 0) {
            if (this.OrderDeliveryService.formData.ID == 0) {
              this.OrderDeliveryService.formData.ShopID = this.MembershipService.listShop[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  getShipperToList() {
    this.MembershipService.GetByParentIDToListAsync(environment.ShipperID).subscribe(
      res => {
        this.MembershipService.listShipper = (res as Membership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.MembershipService.listShipper) {
          if (this.MembershipService.listShipper.length > 0) {
            if (this.OrderDeliveryService.formData.ID == 0) {
              this.OrderDeliveryService.formData.ShipperID = this.MembershipService.listShipper[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  getDistrictToList() {
    this.DistrictService.GetByParentIDToListAsync(1).subscribe(
      res => {
        this.DistrictService.list = (res as District[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.DistrictService.list) {
          if (this.DistrictService.list.length > 0) {
            if (this.OrderDeliveryService.formData.ID == 0) {
              this.OrderDeliveryService.formData.DeliveryDistrictID = this.DistrictService.list[0].ID;
            }
          }
        }
        this.getWardToList();
      },
      err => {
      }
    );
  }
  getWardToList() {
    this.WardService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.DeliveryDistrictID).subscribe(
      res => {
        this.WardService.list = (res as Ward[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.WardService.list) {
          if (this.WardService.list.length > 0) {
            if (this.OrderDeliveryService.formData.ID == 0) {
              this.OrderDeliveryService.formData.DeliveryWardID = this.WardService.list[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  GetByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryDetailService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryDetailService.list = res as OrderDeliveryDetail[];
        console.log(this.OrderDeliveryDetailService.list);
        this.dataSource = new MatTableDataSource(this.OrderDeliveryDetailService.list.sort((a, b) => (a.CreatedDate > b.CreatedDate ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onChangeDistrictID($event) {
    this.getWardToList();
  }
  onSubmit(form: NgForm) {
    this.OrderDeliveryService.Save01Async(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.OrderDeliveryService.formData = res as OrderDelivery;
        window.location.href = this.URLSub + "/" + this.OrderDeliveryService.formData.ID;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onOrderDeliveryDetailAdd() {
    this.OrderDeliveryDetailService.AddEmptyAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.GetByQueryString001();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onOrderDeliveryDetailDelete(element: OrderDeliveryDetail) {
    if (confirm(environment.DeleteConfirm)) {
      this.OrderDeliveryDetailService.RemoveAsync(element.ID).subscribe(
        res => {
          this.GetByQueryString001();
        },
        err => {
          this.notificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  onOrderDeliveryDetailSave(element: OrderDeliveryDetail) {
    this.OrderDeliveryDetailService.SaveAsync(element).subscribe(
      res => {
        this.GetByQueryString001();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onPrint() {
    this.isShowLoading = true;
    this.DownloadService.OrderDeliveryByIDToHTML(this.OrderDeliveryService.formData.ID).then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
}