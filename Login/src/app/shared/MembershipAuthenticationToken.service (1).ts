import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Membership } from 'src/app/shared/Membership.model';
@Injectable({
    providedIn: 'root'
})
export class MembershipService {
    list: Membership[] | undefined;
    listDieuHanh: Membership[] | undefined;
    listShop: Membership[] | undefined;
    listShipper: Membership[] | undefined;
    formData!: Membership;
    aPIURL: string = environment.APIURL;
    controller: string = "Membership";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    GetByIDAsync(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByIDAsync';
        const uploadData = JSON.stringify(ID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
    Authentication(model: Membership) {
        let url = this.aPIURL + this.controller + '/Authentication';
        const uploadData = JSON.stringify(model);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
}

