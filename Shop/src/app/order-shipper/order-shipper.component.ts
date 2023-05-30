import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { OrderShipper } from 'src/app/shared/OrderShipper.model';
import { OrderShipperService } from 'src/app/shared/OrderShipper.service';
import { DateHelper } from 'src/app/shared/DateHelper.model';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-order-shipper',
  templateUrl: './order-shipper.component.html',
  styleUrls: ['./order-shipper.component.css']
})
export class OrderShipperComponent implements OnInit {

  URLSub: string = environment.DomainDestination + "OrderShipperInfo";
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
    public OrderShipperService: OrderShipperService,
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
    this.OrderShipperService.GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(this.dateTimeBegin, this.dateTimeEnd, this.searchString).subscribe(
      res => {        
        this.OrderShipperService.list = res as OrderShipper[];        
        this.dataSource = new MatTableDataSource(this.OrderShipperService.list.sort((a, b) => (a.DateCreated < b.DateCreated ? 1 : -1)));
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
    this.getToList();
  }
}
