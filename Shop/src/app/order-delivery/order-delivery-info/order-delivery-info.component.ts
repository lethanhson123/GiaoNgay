import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
import { OrderDeliveryDetail } from 'src/app/shared/OrderDeliveryDetail.model';
import { OrderDeliveryDetailService } from 'src/app/shared/OrderDeliveryDetail.service';
import { OrderDeliveryReturn } from 'src/app/shared/OrderDeliveryReturn.model';
import { OrderDeliveryReturnService } from 'src/app/shared/OrderDeliveryReturn.service';
import { OrderDeliveryFile } from 'src/app/shared/OrderDeliveryFile.model';
import { OrderDeliveryFileService } from 'src/app/shared/OrderDeliveryFile.service';
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { Province } from 'src/app/shared/Province.model';
import { ProvinceService } from 'src/app/shared/Province.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { DownloadService } from 'src/app/shared/Download.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MailService } from 'src/app/shared/Mail.service';

@Component({
  selector: 'app-order-delivery-info',
  templateUrl: './order-delivery-info.component.html',
  styleUrls: ['./order-delivery-info.component.css']
})
export class OrderDeliveryInfoComponent implements OnInit {

  imageURL: string = environment.APIRootURL + "" + environment.Image + "/" + environment.OrderDelivery + "/";
  URLSub: string = environment.DomainDestination + "OrderDeliveryInfo";
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  BarcodeURL: string = environment.APIRootURL + environment.Barcode;
  QRcodeURL: string = environment.APIRootURL + environment.QRcode;
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Name', 'Quantity', 'Price', 'Note', 'Total', 'Save'];

  dataSourceFile: MatTableDataSource<any>;
  displayColumnsFile: string[] = ['Note', 'actions'];

  dataSourceReturn: MatTableDataSource<any>;
  displayColumnsReturn: string[] = ['Name', 'Quantity', 'Active'];

  fileToUpload: any;
  fileToUpload0: File = null;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public router: Router,
    public DownloadService: DownloadService,
    public OrderDeliveryService: OrderDeliveryService,
    public OrderDeliveryDetailService: OrderDeliveryDetailService,
    public OrderDeliveryReturnService: OrderDeliveryReturnService,
    public OrderDeliveryFileService: OrderDeliveryFileService,
    public WardService: WardService,
    public DistrictService: DistrictService,
    public ProvinceService: ProvinceService,
    public MembershipService: MembershipService,
    public MailService: MailService,
    public notificationService: NotificationService,
    private dialog: MatDialog
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
  onChangeDateCreated(value) {
    this.OrderDeliveryService.formData.DateCreated = new Date(value);
  }
  onChangeProvinceID($event) {
    this.getDistrictToList();
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderDeliveryService.formData = res as OrderDelivery;
      if (this.OrderDeliveryService.formData) {
        let membershipID = localStorage.getItem(environment.MembershipID);
        this.OrderDeliveryService.formData.ShopID = Number(membershipID);
        if (this.OrderDeliveryService.formData.ID > 0) {
          //this.GetOrderDeliveryDetailByParentIDToListAsync();
          this.GetOrderDeliveryReturnByParentIDToListAsync();
          this.GetOrderDeliveryFileByParentIDToListAsync();
        }
        this.GetProvinceToList();
      }
      this.isShowLoading = false;
    });
  }
  GetByQueryString001() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderDeliveryService.formData = res as OrderDelivery;
      if (this.OrderDeliveryService.formData) {
        if (this.OrderDeliveryService.formData.ID > 0) {
          //this.GetOrderDeliveryDetailByParentIDToListAsync();
          this.GetOrderDeliveryReturnByParentIDToListAsync();
          this.GetOrderDeliveryFileByParentIDToListAsync();
        }
      }
      this.isShowLoading = false;
    });
  }
  GetProvinceToList() {
    this.ProvinceService.GetAllToListAsync().subscribe(
      res => {
        this.ProvinceService.list = (res as Province[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.ProvinceService.list) {
          if (this.ProvinceService.list.length > 0) {
            if (this.OrderDeliveryService.formData.ID == 0) {
              this.OrderDeliveryService.formData.DeliveryProvinceID = this.ProvinceService.list[0].ID;
            }
          }
        }
        this.getDistrictToList();
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
  GetOrderDeliveryDetailByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryDetailService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryDetailService.list = res as OrderDeliveryDetail[];
        this.dataSource = new MatTableDataSource(this.OrderDeliveryDetailService.list.sort((a, b) => (a.CreatedDate > b.CreatedDate ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
    this.OrderDeliveryDetailService.GetByIDAsync(0).subscribe(
      res => {
        this.OrderDeliveryDetailService.formData = res as OrderDeliveryDetail;
        console.log(this.OrderDeliveryDetailService.formData);
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
    let membershipID = localStorage.getItem(environment.MembershipID);
    this.OrderDeliveryService.formData.ShopID = Number(membershipID);
    this.OrderDeliveryService.SaveShopAsync(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        if (this.OrderDeliveryService.formData.ID == 0) {
          this.OrderDeliveryService.formData = res as OrderDelivery;
          this.MailService.SendMailWhenOrderDeliveryCreate(this.OrderDeliveryService.formData.ID).then(
            res => {
            }
          );
          let url = this.URLSub + "/" + this.OrderDeliveryService.formData.ID;
          window.location.href = this.URLSub + "/" + this.OrderDeliveryService.formData.ID;
        }
        else {
          this.OrderDeliveryDetailService.formData.ParentID = this.OrderDeliveryService.formData.ID;
          this.onOrderDeliveryDetailSave(this.OrderDeliveryDetailService.formData);
        }
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
  changeImage(files: FileList) {
    if (files) {
      this.fileToUpload = files;
    }
  }
  GetOrderDeliveryFileByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryFileService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryFileService.list = res as OrderDeliveryFile[];
        this.dataSourceFile = new MatTableDataSource(this.OrderDeliveryFileService.list.sort((a, b) => (a.CreatedDate > b.CreatedDate ? 1 : -1)));
        this.dataSourceFile.sort = this.sort;
        this.dataSourceFile.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onOrderDeliveryFileAdd() {
    this.OrderDeliveryFileService.SaveAndUploadFiles(this.OrderDeliveryService.formData.ID, this.fileToUpload).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.GetOrderDeliveryFileByParentIDToListAsync();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onOrderDeliveryFileDelete(element: OrderDeliveryFile) {
    if (confirm(environment.DeleteConfirm)) {
      this.OrderDeliveryFileService.RemoveAsync(element.ID).subscribe(
        res => {
          this.GetOrderDeliveryFileByParentIDToListAsync();
        },
        err => {
          this.notificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  GetOrderDeliveryReturnByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryReturnService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryReturnService.list = res as OrderDeliveryReturn[];
        this.dataSourceReturn = new MatTableDataSource(this.OrderDeliveryReturnService.list.sort((a, b) => (a.CreatedDate > b.CreatedDate ? 1 : -1)));
        this.dataSourceReturn.sort = this.sort;
        this.dataSourceReturn.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
}