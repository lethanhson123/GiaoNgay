import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';

@Component({
  selector: 'app-membership-total-debt',
  templateUrl: './membership-total-debt.component.html',
  styleUrls: ['./membership-total-debt.component.css']
})
export class MembershipTotalDebtComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "MembershipTotalDebtInfo";
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'FullName', 'Phone', 'TotalDebt'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public MembershipService: MembershipService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.MembershipService.GetByTotalDebtGreaterThanZeroToListAsync().subscribe(
      res => {        
        this.MembershipService.list = res as Membership[];
        this.dataSource = new MatTableDataSource(this.MembershipService.list.sort((a, b) => (a.TotalDebt > b.TotalDebt ? 1 : -1)));
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
}
