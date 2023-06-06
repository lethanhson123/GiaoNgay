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
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { Province } from 'src/app/shared/Province.model';
import { ProvinceService } from 'src/app/shared/Province.service';

@Component({
  selector: 'app-category-order-detail',
  templateUrl: './category-order-detail.component.html',
  styleUrls: ['./category-order-detail.component.css']
})
export class CategoryOrderDetailComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Name', 'Price', 'ProvinceID', 'DistrictID', 'WardID', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public CategoryOrderDetailService: CategoryOrderDetailService,
    public WardService: WardService,
    public DistrictService: DistrictService,
    public ProvinceService: ProvinceService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.GetProvinceToList();
    this.GetDistrictToList();
    this.GetWardToList();
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
  GetProvinceToList() {
    this.ProvinceService.GetAllToListAsync().subscribe(
      res => {
        this.ProvinceService.list = (res as Province[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetDistrictToList() {
    this.DistrictService.GetAllToListAsync().subscribe(
      res => {
        this.DistrictService.list = (res as District[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetWardToList() {
    this.WardService.GetAllToListAsync().subscribe(
      res => {
        this.WardService.list = (res as Ward[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  onDelete(element: CategoryOrderDetail) {
    if (confirm(environment.DeleteConfirm)) {
      this.CategoryOrderDetailService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearch();
        },
        err => {
          this.NotificationService.warn(environment.SaveNotSuccess);
        }
      );
    }
  }
}