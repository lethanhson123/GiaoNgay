import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderReceive } from 'src/app/shared/OrderReceive.model';
import { OrderReceiveService } from 'src/app/shared/OrderReceive.service';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-order-receive',
  templateUrl: './order-receive.component.html',
  styleUrls: ['./order-receive.component.css']
})
export class OrderReceiveComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderReceiveInfo";
  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'DateCreated', 'Name', 'Note'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;

  dateTimeBegin: Date = new Date();
  dateTimeEnd: Date = new Date();
  id: any;
  constructor(
    public OrderReceiveService: OrderReceiveService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,    
  ) { }

  ngOnInit(): void {
    this.onSearch();   
  }
  ngOnDestroy() {
    if (this.id) {
      clearInterval(this.id);
    }
  }
  onChangeDateTimeBegin(value) {
    this.dateTimeBegin = new Date(value);
  }
  onChangeDateTimeEnd(value) {
    this.dateTimeEnd = new Date(value);
  }
  getToList() {
    this.isShowLoading = true;
    this.OrderReceiveService.GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
      res => {        
        this.OrderReceiveService.list = res as OrderReceive[];        
        this.dataSource = new MatTableDataSource(this.OrderReceiveService.list.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
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
  onDelete(element: OrderReceive) {
    if (confirm(environment.DeleteConfirm)) {
      element.Active = false;
      this.OrderReceiveService.RemoveAsync(element.ID).subscribe(
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
