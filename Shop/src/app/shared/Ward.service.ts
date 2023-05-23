import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Ward } from 'src/app/shared/Ward.model';
@Injectable({
    providedIn: 'root'
})
export class WardService {
    list: Ward[] | undefined;
    formData!: Ward;
    aPIURL: string = environment.APIURL;
    controller: string = "Ward";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    Save(formData: Ward) {        
        let url = this.aPIURL + this.controller + '/Save';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    SaveAsync(formData: Ward) {        
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
}

