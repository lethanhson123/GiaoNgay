import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { DistrictDetailComponent } from './district-detail/district-detail.component';

@Component({
  selector: 'app-district',
  templateUrl: './district.component.html',
  styleUrls: ['./district.component.css']
})
export class DistrictComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Display', 'Active'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public DistrictService: DistrictService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.DistrictService.GetByParentIDToListAsync(1).subscribe(
      res => {
        this.isShowLoading = false;
        this.DistrictService.list = res as District[];        
        this.dataSource = new MatTableDataSource(this.DistrictService.list.sort((a, b) => (a.Display > b.Display ? 1 : -1)));
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
    this.DistrictService.GetByIDAsync(ID).subscribe(
      res => {
        this.DistrictService.formData = res as District;
        console.log(this.DistrictService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DistrictDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );

  }
}
