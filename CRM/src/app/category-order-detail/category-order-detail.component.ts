import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryOrderDetail } from 'src/app/shared/CategoryOrderDetail.model';
import { CategoryOrderDetailService } from 'src/app/shared/CategoryOrderDetail.service';
import { CategoryOrderDetailDetailComponent } from './category-order-detail-detail/category-order-detail-detail.component';


@Component({
  selector: 'app-category-order-detail',
  templateUrl: './category-order-detail.component.html',
  styleUrls: ['./category-order-detail.component.css']
})
export class CategoryOrderDetailComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Name', 'Price', 'Quantity', 'Active'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public CategoryOrderDetailService: CategoryOrderDetailService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.CategoryOrderDetailService.GetAllToListAsync().subscribe(
      res => {        
        this.CategoryOrderDetailService.list = res as CategoryOrderDetail[];        
        this.dataSource = new MatTableDataSource(this.CategoryOrderDetailService.list.sort((a, b) => (a.Name > b.Name ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );

    // this.CategoryOrderDetailService.GetAllToListAsync2023().then(res => {
    //   this.CategoryOrderDetailService.list = res as CategoryOrderDetail[];
    //   this.dataSource = new MatTableDataSource(this.CategoryOrderDetailService.list.sort((a, b) => (a.Name > b.Name ? 1 : -1)));
    //   this.dataSource.sort = this.sort;
    //   this.dataSource.paginator = this.paginator;
    //   this.isShowLoading = false;
    // });
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
    this.CategoryOrderDetailService.GetByIDAsync(ID).subscribe(
      res => {
        this.CategoryOrderDetailService.formData = res as CategoryOrderDetail;
        console.log(this.CategoryOrderDetailService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(CategoryOrderDetailDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
}