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
import { OrderDeliveryHistory } from 'src/app/shared/OrderDeliveryHistory.model';
import { OrderDeliveryHistoryService } from 'src/app/shared/OrderDeliveryHistory.service';
import { CategoryOrderStatus } from 'src/app/shared/CategoryOrderStatus.model';
import { CategoryOrderStatusService } from 'src/app/shared/CategoryOrderStatus.service';
import { OrderDeliveryPaymentHistory } from 'src/app/shared/OrderDeliveryPaymentHistory.model';
import { OrderDeliveryPaymentHistoryService } from 'src/app/shared/OrderDeliveryPaymentHistory.service';
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
import { OrderDeliveryPaymentHistoryDetailComponent } from 'src/app/order-delivery-payment-history/order-delivery-payment-history-detail/order-delivery-payment-history-detail.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MailService } from 'src/app/shared/Mail.service';
import { OrderDeliveryHistoryDetailComponent } from 'src/app/order-delivery-history/order-delivery-history-detail/order-delivery-history-detail.component';

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

  dataSourcePayment: MatTableDataSource<any>;
  displayColumnsPayment: string[] = ['ID', 'PaymentDate', 'PaymentAmount', 'actions'];

  dataSourceReturn: MatTableDataSource<any>;
  displayColumnsReturn: string[] = ['Name', 'Quantity', 'Active'];

  dataSourceHistory: MatTableDataSource<any>;
  displayColumnsHistory: string[] = ['DateCreated', 'ShipperFullName'];


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
    public OrderDeliveryHistoryService: OrderDeliveryHistoryService,
    public CategoryOrderStatusService: CategoryOrderStatusService,
    public OrderDeliveryPaymentHistoryService: OrderDeliveryPaymentHistoryService,
    public WardService: WardService,
    public DistrictService: DistrictService,
    public ProvinceService: ProvinceService,
    public MembershipService: MembershipService,
    public MailService: MailService,
    public NotificationService: NotificationService,
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
  getByQueryString() {
    this.isShowLoading = true;
    this.OrderDeliveryService.GetByIDStringAsync(this.queryString).then(res => {
      this.OrderDeliveryService.formData = res as OrderDelivery;
      if (this.OrderDeliveryService.formData) {
        this.GetOrderDeliveryDetailByParentIDToListAsync();
        this.GetOrderDeliveryReturnByParentIDToListAsync();
        this.GetOrderDeliveryFileByParentIDToListAsync();
        this.GetOrderDeliveryHistoryByParentIDToListAsync();
        this.GetOrderDeliveryPaymentHistoryByParentIDToListAsync();
        this.getShopToList();
        this.getShipperToList();
        this.getCategoryOrderStatusToList();
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
        this.GetOrderDeliveryDetailByParentIDToListAsync();
        this.GetOrderDeliveryReturnByParentIDToListAsync();
        this.GetOrderDeliveryFileByParentIDToListAsync();
        this.GetOrderDeliveryHistoryByParentIDToListAsync();
        this.GetOrderDeliveryPaymentHistoryByParentIDToListAsync();
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
              this.OrderDeliveryService.formData.ReceiveID = this.MembershipService.listShipper[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  getCategoryOrderStatusToList() {
    this.CategoryOrderStatusService.GetAllToListAsync().subscribe(
      res => {
        this.CategoryOrderStatusService.list = (res as CategoryOrderStatus[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.CategoryOrderStatusService.list) {
          if (this.CategoryOrderStatusService.list.length > 0) {
            if (this.OrderDeliveryService.formData.ID == 0) {
              this.OrderDeliveryService.formData.CategoryOrderStatusID = this.CategoryOrderStatusService.list[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
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
    this.DistrictService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.DeliveryProvinceID).subscribe(
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
  onChangeDateCreated(value) {
    this.OrderDeliveryService.formData.DateCreated = new Date(value);
  }
  onChangeProvinceID($event) {
    this.getDistrictToList();
  }
  onChangeDistrictID($event) {
    this.getWardToList();
  }
  onSubmit(form: NgForm) {
    this.OrderDeliveryService.Save01Async(form.value).subscribe(
      res => {
        this.NotificationService.success(environment.SaveSuccess);
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
          if (this.OrderDeliveryService.formData.IsCompleteShop == true) {
            this.MailService.SendMailWhenOrderDeliveryComplete(this.OrderDeliveryService.formData.ID).then(
              res => {
              }
            );
          }
        }
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onOrderDeliveryDetailAdd() {
    this.OrderDeliveryDetailService.AddEmptyAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.GetByQueryString001();
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
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
          this.NotificationService.warn(environment.SaveNotSuccess);
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
        this.NotificationService.warn(environment.SaveNotSuccess);
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
  GetOrderDeliveryHistoryByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryHistoryService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryHistoryService.list = res as OrderDeliveryHistory[];
        this.dataSourceHistory = new MatTableDataSource(this.OrderDeliveryHistoryService.list.sort((a, b) => (a.DateCreated > b.DateCreated ? 1 : -1)));
        this.dataSourceHistory.sort = this.sort;
        this.dataSourceHistory.paginator = this.paginator;
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
        this.NotificationService.success(environment.SaveSuccess);
        this.GetOrderDeliveryFileByParentIDToListAsync();
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
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
          this.NotificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  GetOrderDeliveryPaymentHistoryByParentIDToListAsync() {
    this.isShowLoading = true;
    this.OrderDeliveryPaymentHistoryService.GetByParentIDToListAsync(this.OrderDeliveryService.formData.ID).subscribe(
      res => {
        this.OrderDeliveryPaymentHistoryService.list = res as OrderDeliveryPaymentHistory[];
        this.dataSourcePayment = new MatTableDataSource(this.OrderDeliveryPaymentHistoryService.list.sort((a, b) => (a.PaymentDate > b.PaymentDate ? 1 : -1)));
        this.dataSourcePayment.sort = this.sort;
        this.dataSourcePayment.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onOrderDeliveryPaymentHistoryDelete(element: OrderDeliveryPaymentHistory) {
    if (confirm(environment.DeleteConfirm)) {
      this.OrderDeliveryPaymentHistoryService.RemoveAsync(element.ID).subscribe(
        res => {
          this.GetOrderDeliveryPaymentHistoryByParentIDToListAsync();
        },
        err => {
          this.NotificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
  onPaymentAdd(ID: any) {
    this.OrderDeliveryPaymentHistoryService.GetByIDAsync(ID).subscribe(
      res => {
        this.OrderDeliveryPaymentHistoryService.formData = res as OrderDeliveryPaymentHistory;
        if (this.OrderDeliveryPaymentHistoryService.formData) {
          this.OrderDeliveryPaymentHistoryService.formData.ParentID = this.OrderDeliveryService.formData.ID;
        }
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(OrderDeliveryPaymentHistoryDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.GetByQueryString001();
        });
      },
      err => {
      }
    );
  }
  onOrderDeliveryReturnActiveChange(element: OrderDeliveryReturn) {
    this.OrderDeliveryReturnService.SaveAsync(element).subscribe(
      res => {
        this.NotificationService.warn(environment.SaveSuccess);
        this.GetOrderDeliveryReturnByParentIDToListAsync();
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onOrderDeliveryHistoryAdd(ID: any) {
    this.OrderDeliveryHistoryService.GetByIDAsync(ID).subscribe(
      res => {
        this.OrderDeliveryHistoryService.formData = res as OrderDeliveryHistory;
        if (this.OrderDeliveryHistoryService.formData) {
          this.OrderDeliveryHistoryService.formData.ParentID = this.OrderDeliveryService.formData.ID;
        }
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(OrderDeliveryHistoryDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.GetByQueryString001();
        });
      },
      err => {
      }
    );
  }
}