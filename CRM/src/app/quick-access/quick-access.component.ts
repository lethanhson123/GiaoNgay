import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { QuickAccess } from 'src/app/shared/QuickAccess.model';
import { QuickAccessService } from 'src/app/shared/QuickAccess.service';
import { QuickAccessDetailComponent } from './quick-access-detail/quick-access-detail.component';


@Component({
  selector: 'app-quick-access',
  templateUrl: './quick-access.component.html',
  styleUrls: ['./quick-access.component.css']
})
export class QuickAccessComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'ParentID', 'Name', 'Display', 'SortOrder'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public QuickAccessService: QuickAccessService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.QuickAccessService.GetAllToListAsync().subscribe(
      res => {        
        this.QuickAccessService.list = res as QuickAccess[];        
        this.dataSource = new MatTableDataSource(this.QuickAccessService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
    this.QuickAccessService.GetByIDAsync(ID).subscribe(
      res => {
        this.QuickAccessService.formData = res as QuickAccess;
        console.log(this.QuickAccessService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(QuickAccessDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );
  }
}
