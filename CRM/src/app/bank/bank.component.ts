import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Bank } from 'src/app/shared/Bank.model';
import { BankService } from 'src/app/shared/Bank.service';
import { BankDetailComponent } from './bank-detail/bank-detail.component';

@Component({
  selector: 'app-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.css']
})
export class BankComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ID', 'Name', 'Display', 'Code', 'Active', 'actions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public BankService: BankService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.BankService.GetAllToListAsync().subscribe(
      res => {
        this.isShowLoading = false;
        this.BankService.list = res as Bank[];
        console.log(this.BankService.list);
        this.dataSource = new MatTableDataSource(this.BankService.list.sort((a, b) => (a.Name > b.Name ? 1 : -1)));
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
    this.BankService.GetByIDAsync(ID).subscribe(
      res => {
        this.BankService.formData = res as Bank;
        console.log(this.BankService.formData);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(BankDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.getToList();
        });
      },
      err => {
      }
    );

  }
}
