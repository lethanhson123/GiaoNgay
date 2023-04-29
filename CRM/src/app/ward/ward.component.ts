import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';
import { WardDetailComponent } from './ward-detail/ward-detail.component';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';

@Component({
  selector: 'app-ward',
  templateUrl: './ward.component.html',
  styleUrls: ['./ward.component.css']
})
export class WardComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Display', 'Active'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  parentID: number = environment.InitializationNumber;
  constructor(
    public DistrictService: DistrictService,
    public WardService: WardService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getDistrictToList();    
  }
  getDistrictToList() {
    this.isShowLoading = true;
    this.DistrictService.GetByParentIDToListAsync(1).subscribe(
      res => {
        this.isShowLoading = false;
        this.DistrictService.list = (res as District[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.DistrictService.list) {
          if (this.DistrictService.list.length) {
            this.parentID = this.DistrictService.list[0].ID;
            this.getToList();
          }
        }
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  getToList() {
    this.isShowLoading = true;
    this.WardService.GetByParentIDToListAsync(this.parentID).subscribe(
      res => {
        this.isShowLoading = false;
        this.WardService.list = res as Ward[];
        this.dataSource = new MatTableDataSource(this.WardService.list.sort((a, b) => (a.Display > b.Display ? 1 : -1)));
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
    this.WardService.GetByIDAsync(ID).subscribe(
      res => {
        this.WardService.formData = res as Ward;
        console.log(this.WardService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(WardDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );

  }
}

