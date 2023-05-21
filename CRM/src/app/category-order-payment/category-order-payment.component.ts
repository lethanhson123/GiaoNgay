import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryOrderPayment } from 'src/app/shared/CategoryOrderPayment.model';
import { CategoryOrderPaymentService } from 'src/app/shared/CategoryOrderPayment.service';
import { CategoryOrderPaymentDetailComponent } from './category-order-payment-detail/category-order-payment-detail.component';


@Component({
  selector: 'app-category-order-payment',
  templateUrl: './category-order-payment.component.html',
  styleUrls: ['./category-order-payment.component.css']
})
export class CategoryOrderPaymentComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Display', 'Active'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public CategoryOrderPaymentService: CategoryOrderPaymentService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.CategoryOrderPaymentService.GetAllToListAsync().subscribe(
      res => {        
        this.CategoryOrderPaymentService.list = res as CategoryOrderPayment[];        
        this.dataSource = new MatTableDataSource(this.CategoryOrderPaymentService.list.sort((a, b) => (a.Code > b.Code ? 1 : -1)));
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
    if (this.searchString.length > 0) {
      this.dataSource.filter = this.searchString.toLowerCase();
    }
    else {
      this.getToList();
    }
  }
  onAdd(ID: any) {
    this.CategoryOrderPaymentService.GetByIDAsync(ID).subscribe(
      res => {
        this.CategoryOrderPaymentService.formData = res as CategoryOrderPayment;
        console.log(this.CategoryOrderPaymentService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(CategoryOrderPaymentDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
}