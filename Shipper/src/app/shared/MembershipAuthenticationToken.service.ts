import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MembershipAuthenticationToken } from 'src/app/shared/MembershipAuthenticationToken.model';
@Injectable({
    providedIn: 'root'
})
export class MembershipAuthenticationTokenService {
    list: MembershipAuthenticationToken[] | undefined;  
    formData!: MembershipAuthenticationToken;
    aPIURL: string = environment.APIURL;
    controller: string = "MembershipAuthenticationToken";
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
    Authentication(model: MembershipAuthenticationToken) {
        let url = this.aPIURL + this.controller + '/Authentication';
        const uploadData = JSON.stringify(model);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
    GetByAuthenticationToken(authenticationToken: string) {
        let url = this.aPIURL + this.controller + '/GetByAuthenticationToken';
        const uploadData = JSON.stringify(authenticationToken);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
}

