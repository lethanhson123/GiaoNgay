import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  registerURL: string = environment.RegisterURL;
  isShowLoading: boolean = false;
  queryString: string = '0';
  email: string = environment.InitializationString;
  password: string = environment.InitializationString;
  urlDestination: string | undefined = environment.InitializationString;

  constructor(
    public router: Router,
    public notificationService: NotificationService,
    public MembershipService: MembershipService,
  ) {
    this.getByQueryString();
  }
  ngOnInit() {
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.MembershipService.GetByIDAsync(0).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.MembershipService.Authentication(form.value).subscribe(
      res => {
        this.isShowLoading = false;
        this.MembershipService.formData = res as Membership;
        console.log(this.MembershipService.formData);
        if (this.MembershipService.formData) {
          if (this.MembershipService.formData.Code) {
            if (this.MembershipService.formData.Description) {
              if (this.MembershipService.formData.ParentID == environment.ShopID) {
                window.location.href = environment.ShopURL + "?AuthenticationToken=" + this.MembershipService.formData.Note;
              }
              if (this.MembershipService.formData.ParentID == environment.ShipperID) {
                window.location.href = environment.ShipperURL + "?AuthenticationToken=" + this.MembershipService.formData.Note;
              }
            }
            else {
              this.notificationService.success(environment.LoginNotSuccess);
            }
          }
          else {
            this.notificationService.success(environment.LoginNotSuccess);
          }
        }
      },
      err => {
        this.notificationService.warn(environment.LoginNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
}
