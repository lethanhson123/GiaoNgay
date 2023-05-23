import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = '0';
  email: string = environment.InitializationString;
  password: string = environment.InitializationString;
  urlDestination: string | undefined = environment.InitializationString;

  constructor(
    public router: Router,
    public notificationService: NotificationService,
    public nhanVienService: NhanVienService,
  ) {
    this.getByQueryString();
  }
  ngOnInit() {
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.nhanVienService.getByIDString(this.queryString).then(res => {
      this.nhanVienService.formData = res as NhanVien;      
      this.isShowLoading = false;
    });
    this.isShowLoading = true;
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        localStorage.setItem('URL', this.queryString);
        this.isShowLoading = false;
      }
    });
  }
  onSubmit(form: NgForm) {
    if (localStorage.getItem('URL') != null) {
      form.value.Description = localStorage.getItem('URL')?.toString();
    }
    else {
      form.value.Description = environment.CRMURL;
    }
    if (form.value.Description) {
      form.value.Description = localStorage.getItem('URL')?.toString();
      this.isShowLoading = true;
      this.nhanVienService.authentication(form.value).subscribe(
        res => {
          this.isShowLoading = false;
          this.nhanVienService.formData = res as NhanVien;
          if (this.nhanVienService.formData) {
            if (this.nhanVienService.formData.Code) {
              if (this.nhanVienService.formData.Description) {                
                window.location.href = environment.CRMURL + "?AuthenticationToken=" + this.nhanVienService.formData.Note;
                this.notificationService.success(environment.LoginSuccess);
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
}