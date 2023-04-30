import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryMembership } from 'src/app/shared/CategoryMembership.model';
import { CategoryMembershipService } from 'src/app/shared/CategoryMembership.service';
import { CategoryMembershipDetailComponent } from './category-membership-detail/category-membership-detail.component';

@Component({
  selector: 'app-category-membership',
  templateUrl: './category-membership.component.html',
  styleUrls: ['./category-membership.component.css']
})
export class CategoryMembershipComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Display', 'Active'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public CategoryMembershipService: CategoryMembershipService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.CategoryMembershipService.GetAllToListAsync().subscribe(
      res => {
        this.isShowLoading = false;
        this.CategoryMembershipService.list = res as CategoryMembership[];        
        this.dataSource = new MatTableDataSource(this.CategoryMembershipService.list.sort((a, b) => (a.Code > b.Code ? 1 : -1)));
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
    this.CategoryMembershipService.GetByIDAsync(ID).subscribe(
      res => {
        this.CategoryMembershipService.formData = res as CategoryMembership;
        console.log(this.CategoryMembershipService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(CategoryMembershipDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
}
