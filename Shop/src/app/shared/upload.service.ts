import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  aPIURL: string = environment.APIURL;
  controller: string = "Upload";
  constructor(private httpClient: HttpClient) {
  }
  PostBankListByExcelFile(fileToUpload: File) {
    let url = this.aPIURL + this.controller + '/PostBankListByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  PostDistrictListByExcelFile(fileToUpload: File) {
    let url = this.aPIURL + this.controller + '/PostDistrictListByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  PostWardListByExcelFile(fileToUpload: File) {
    let url = this.aPIURL + this.controller + '/PostWardListByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  PostOrderDeliveryListByExcelFile(membershipID:number, fileToUpload: File) {
    let url = this.aPIURL + this.controller + '/PostOrderDeliveryListByExcelFile';
    const membershipIDData = JSON.stringify(membershipID);
    const formUpload: FormData = new FormData();
    formUpload.append('membershipID', membershipIDData);
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
}

