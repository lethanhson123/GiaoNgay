import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { UploadService } from 'src/app/shared/upload.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { Bank } from 'src/app/shared/Bank.model';
import { BankService } from 'src/app/shared/Bank.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  isShowLoading: boolean = false;

  isBank: boolean = false;
  excelTemplateBankURL: string = environment.APIRootURL + environment.Download + "/Bank.xlsx";
  @ViewChild('uploadBank') uploadBank!: ElementRef;
  dataSourceBank: MatTableDataSource<any>;
  displayColumnsBank: string[] = ['Display'];
  @ViewChild(MatSort) sortBank: MatSort;
  @ViewChild(MatPaginator) paginatorBank: MatPaginator;

  isDistrict: boolean = false;
  excelTemplateDistrictURL: string = environment.APIRootURL + environment.Download + "/District.xlsx";
  @ViewChild('uploadDistrict') uploadDistrict!: ElementRef;
  dataSourceDistrict: MatTableDataSource<any>;
  displayColumnsDistrict: string[] = ['Display'];
  @ViewChild(MatSort) sortDistrict: MatSort;
  @ViewChild(MatPaginator) paginatorDistrict: MatPaginator;

  isWard: boolean = false;
  excelTemplateWardURL: string = environment.APIRootURL + environment.Download + "/Ward.xlsx";
  @ViewChild('uploadWard') uploadWard!: ElementRef;
  dataSourceWard: MatTableDataSource<any>;
  displayColumnsWard: string[] = ['Display'];
  @ViewChild(MatSort) sortWard: MatSort;
  @ViewChild(MatPaginator) paginatorWard: MatPaginator;

  constructor(    
    public UploadService: UploadService,
    public NotificationService: NotificationService,
    public BankService: BankService,
    public DistrictService: DistrictService,
    public WardService: WardService,
  ) { }

  ngOnInit(): void {
  }
  onSubmitBank() {
    let fileToUpload: File;
    fileToUpload = this.uploadBank.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostBankListByExcelFile(fileToUpload).subscribe(
      data => {
        this.isShowLoading = false;
        this.BankService.list = data as Bank[];
        this.dataSourceBank = new MatTableDataSource(this.BankService.list.sort((a, b) => (a.Display > b.Display ? 1 : -1)));
        this.dataSourceBank.sort = this.sortBank;
        this.dataSourceBank.paginator = this.paginatorBank;
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  changeBank(files: FileList) {
    if (files) {
      this.isBank = true;
    }
  }
  onSubmitDistrict() {
    let fileToUpload: File;
    fileToUpload = this.uploadDistrict.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostDistrictListByExcelFile(fileToUpload).subscribe(
      data => {
        this.isShowLoading = false;
        this.DistrictService.list = data as District[];
        this.dataSourceDistrict = new MatTableDataSource(this.DistrictService.list.sort((a, b) => (a.Display > b.Display ? 1 : -1)));
        this.dataSourceDistrict.sort = this.sortDistrict;
        this.dataSourceDistrict.paginator = this.paginatorDistrict;
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  changeDistrict(files: FileList) {
    if (files) {
      this.isDistrict = true;
    }
  }
  onSubmitWard() {
    let fileToUpload: File;
    fileToUpload = this.uploadWard.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostWardListByExcelFile(fileToUpload).subscribe(
      data => {
        this.isShowLoading = false;
        this.WardService.list = data as Ward[];
        this.dataSourceWard = new MatTableDataSource(this.WardService.list.sort((a, b) => (a.Display > b.Display ? 1 : -1)));
        this.dataSourceWard.sort = this.sortWard;
        this.dataSourceWard.paginator = this.paginatorWard;
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  changeWard(files: FileList) {
    if (files) {
      this.isWard = true;
    }
  }
}
