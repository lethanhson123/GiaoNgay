import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
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
  selector: 'app-membership',
  templateUrl: './membership.component.html',
  styleUrls: ['./membership.component.css']
})
export class MembershipComponent implements OnInit {

  isShowLoading: boolean = false;
  constructor(
    public BankService: BankService,
    public DistrictService: DistrictService,
    public WardService: WardService,
    public MembershipService: MembershipService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.GetByIDAsync();
  }
  GetByIDAsync() {
    this.isShowLoading = true;
    let membershipID = localStorage.getItem(environment.MembershipID);
    this.MembershipService.GetByIDAsync(Number(membershipID)).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        if (this.MembershipService.formData) {
          if (this.MembershipService.formData.ID > 0) {
            this.getBankToList();
            this.getDistrictToList();
          }
        }
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
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
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
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
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
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
