import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryOrderStatus } from 'src/app/shared/CategoryOrderStatus.model';
import { CategoryOrderStatusService } from 'src/app/shared/CategoryOrderStatus.service';
import { CategoryOrderStatusDetailComponent } from './category-order-status-detail/category-order-status-detail.component';


@Component({
  selector: 'app-category-order-status',
  templateUrl: './category-order-status.component.html',
  styleUrls: ['./category-order-status.component.css']
})
export class CategoryOrderStatusComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Display', 'Active'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public CategoryOrderStatusService: CategoryOrderStatusService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.CategoryOrderStatusService.GetAllToListAsync().subscribe(
      res => {
        this.isShowLoading = false;
        this.CategoryOrderStatusService.list = res as CategoryOrderStatus[];        
        this.dataSource = new MatTableDataSource(this.CategoryOrderStatusService.list.sort((a, b) => (a.Code > b.Code ? 1 : -1)));
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
    this.CategoryOrderStatusService.GetByIDAsync(ID).subscribe(
      res => {
        this.CategoryOrderStatusService.formData = res as CategoryOrderStatus;
        console.log(this.CategoryOrderStatusService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(CategoryOrderStatusDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
}
