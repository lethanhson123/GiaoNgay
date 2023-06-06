import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { MembershipAuthenticationToken } from 'src/app/shared/MembershipAuthenticationToken.model';
import { MembershipAuthenticationTokenService } from 'src/app/shared/MembershipAuthenticationToken.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  domainName = environment.DomainDestination;
  queryString: string = environment.InitializationString;
  authenticationToken: string = environment.InitializationString;
  MembershipID: number = environment.InitializationNumber;
  constructor(
    public router: Router,
    public MembershipAuthenticationTokenService: MembershipAuthenticationTokenService,
    public MembershipService: MembershipService,
  ) {
    this.getByQueryString();
  }
  getByQueryString() {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        if (this.queryString.indexOf(environment.AuthenticationToken) > -1) {
          localStorage.setItem(environment.AuthenticationToken, this.queryString.split('=')[this.queryString.split('=').length - 1]);
        }
        this.checkAuthenticationToken();
      }
    });
  }
  onNavigationToLogin() {
    window.location.href = environment.LoginURL;
  }
  checkAuthenticationToken() {
    let authenticationToken = localStorage.getItem(environment.AuthenticationToken);
    if (authenticationToken == null) {
      this.onNavigationToLogin();
    }
    else {      
      this.MembershipAuthenticationTokenService.GetByAuthenticationToken(authenticationToken).subscribe(
        res => {
          this.MembershipAuthenticationTokenService.formData = res as MembershipAuthenticationToken;
          if (this.MembershipAuthenticationTokenService.formData != null) {
            if (this.MembershipAuthenticationTokenService.formData.ParentID > 0) {
              localStorage.setItem(environment.MembershipID, this.MembershipAuthenticationTokenService.formData.ParentID.toString());
              this.MembershipService.GetByIDAsync(this.MembershipAuthenticationTokenService.formData.ParentID).subscribe(
                res => {
                  this.MembershipService.formData = res as Membership;
                  if (this.MembershipService.formData) {
                  }
                  else {
                    this.onNavigationToLogin();
                  }
                },
                err => {
                  this.onNavigationToLogin();
                }
              );
            }
            else {
              this.onNavigationToLogin();
            }
          }
          else {
            this.onNavigationToLogin();
          }
        },
        err => {
          this.onNavigationToLogin();
        }
      );
    }
  }
  onLogout() {
    this.MembershipService.GetByIDAsync(0).subscribe(
      res => {
        this.MembershipService.formData = res as Membership;
        if (this.MembershipService.formData) {
          localStorage.setItem(environment.AuthenticationToken, environment.InitializationString);
          localStorage.setItem(environment.MembershipID, environment.InitializationString);
          this.onNavigationToLogin();
        }
      },
      err => {
        this.onNavigationToLogin();
      }
    );
  }
}
