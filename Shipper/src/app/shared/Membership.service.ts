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
    MembershipID!: number;
    aPIURL: string = environment.APIURL;
    controller: string = "Membership";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.MembershipID = Number(localStorage.getItem(environment.MembershipID));
        this.formData = {
        }
    }
    Save(formData: Membership) {        
        let url = this.aPIURL + this.controller + '/Save';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    SaveAsync(formData: Membership) {        
        let url = this.aPIURL + this.controller + '/SaveAsync';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    Remove(ID: number) {        
        let url = this.aPIURL + this.controller + '/Remove';
        const uploadData = JSON.stringify(ID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    RemoveAsync(ID: number) {        
        let url = this.aPIURL + this.controller + '/RemoveAsync';
        const uploadData = JSON.stringify(ID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    GetByID(ID: number) {        
        let url = this.aPIURL + this.controller + '/GetByID';
        const uploadData = JSON.stringify(ID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    GetByIDAsync(ID: number) {        
        let url = this.aPIURL + this.controller + '/GetByIDAsync';
        const uploadData = JSON.stringify(ID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    } 
    GetAllToList() {        
        let url = this.aPIURL + this.controller + '/GetAllToList';     
        const formUpload: FormData = new FormData();   
        return this.httpClient.post(url, formUpload);
    }  
    GetAllToListAsync() {        
        let url = this.aPIURL + this.controller + '/GetAllToListAsync';        
        const formUpload: FormData = new FormData();        
        return this.httpClient.post(url, formUpload);
    } 
    GetByParentIDToListAsync(parentID: number) {        
        let url = this.aPIURL + this.controller + '/GetByParentIDToListAsync';
        const uploadData = JSON.stringify(parentID);
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

