import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { MailService } from 'src/app/shared/Mail.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  loginURL: string = environment.LoginURL;
  isShowLoading: boolean = false;
  queryString: string = '0';
  email: string = environment.InitializationString;
  password: string = environment.InitializationString;
  urlDestination: string | undefined = environment.InitializationString;

  constructor(
    public router: Router,
    public notificationService: NotificationService,
    public MembershipService: MembershipService,
    public MailService: MailService,
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
        if (this.MembershipService.formData) {
          this.MembershipService.formData.ParentID = environment.ShopID;
        }
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.MembershipService.SaveAsync(form.value).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        let message = environment.SaveSuccess;
        switch (this.MembershipService.formData.RowVersion) {
          case 1: {
            message = environment.SaveSuccess;
            console.log(message);
            this.MailService.SendMailWhenMembershipChange(this.MembershipService.formData.ID).then(
              res => {
              }
            );
            if (this.MembershipService.formData.ParentID == environment.ShopID) {
              window.location.href = environment.LoginURL;
            }
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
}