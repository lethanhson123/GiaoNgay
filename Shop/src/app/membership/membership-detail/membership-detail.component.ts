import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { District } from 'src/app/shared/District.model';
import { DistrictService } from 'src/app/shared/District.service';
import { Ward } from 'src/app/shared/Ward.model';
import { WardService } from 'src/app/shared/Ward.service';
import { Bank } from 'src/app/shared/Bank.model';
import { BankService } from 'src/app/shared/Bank.service';

@Component({
  selector: 'app-membership-detail',
  templateUrl: './membership-detail.component.html',
  styleUrls: ['./membership-detail.component.css']
})
export class MembershipDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public BankService: BankService,
    public DistrictService: DistrictService,
    public WardService: WardService,
    public MembershipService: MembershipService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<MembershipDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }
  ngOnInit(): void {
    this.getBankToList();
    this.getDistrictToList();
  }
  getBankToList() {
    this.BankService.GetAllToListAsync().subscribe(
      res => {
        this.BankService.list = (res as Bank[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.BankService.list) {
          if (this.BankService.list.length > 0) {
            if (this.MembershipService.formData.ID == 0) {
              this.MembershipService.formData.BankID = this.BankService.list[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  getDistrictToList() {
    this.DistrictService.GetByParentIDToListAsync(1).subscribe(
      res => {
        this.DistrictService.list = (res as District[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.DistrictService.list) {
          if (this.DistrictService.list.length > 0) {
            if (this.MembershipService.formData.ID == 0) {
              this.MembershipService.formData.DistrictID = this.DistrictService.list[0].ID;
            }
          }
        }
        this.getWardToList();
      },
      err => {
      }
    );
  }
  getWardToList() {
    this.WardService.GetByParentIDToListAsync(this.MembershipService.formData.DistrictID).subscribe(
      res => {
        this.WardService.list = (res as Ward[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.WardService.list) {
          if (this.WardService.list.length > 0) {
            if (this.MembershipService.formData.ID == 0) {
              this.MembershipService.formData.WardID = this.WardService.list[0].ID;
            }
          }
        }
      },
      err => {
      }
    );
  }
  onClose() {
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {
    this.MembershipService.SaveAsync(form.value).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        console.log(this.MembershipService.formData);
        let message = environment.SaveSuccess;
        switch (this.MembershipService.formData.RowVersion) {
          case 1: {
            message = environment.SaveSuccess;
            console.log(message);
            break;
          }
          case 11: {
            message = environment.UserNameRequired;
            console.log(message);
            break;
          }
          case 110: {
            message = environment.UserNameExists;
            console.log(message);
            break;
          }
        }
        this.notificationService.success(message);
        this.onClose();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.onClose();
      }
    );
  }
  onKeyupPhone() {
    if (this.MembershipService.formData.ID == 0) {
      this.MembershipService.formData.UserName = this.MembershipService.formData.Phone;
    }
  }
  onChangeDistrictID($event) {
    this.getWardToList();
  }
}
