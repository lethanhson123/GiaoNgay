import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DateHelper } from 'src/app/shared/DateHelper.model';
@Injectable({
    providedIn: 'root'
})
export class DownloadService {
    listYear: DateHelper[] | undefined;
    listMonth: DateHelper[] | undefined;
    listDay: DateHelper[] | undefined;
    formData!: DateHelper;
    aPIURL: string = environment.APIURL;
    controller: string = "Download";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    GetYear() {        
        let url = this.aPIURL + this.controller + '/GetYear';     
        const formUpload: FormData = new FormData();   
        return this.httpClient.post(url, formUpload);
    }      
    GetMonth() {        
        let url = this.aPIURL + this.controller + '/GetMonth';     
        const formUpload: FormData = new FormData();   
        return this.httpClient.post(url, formUpload);
    }   
    GetDay() {        
        let url = this.aPIURL + this.controller + '/GetDay';     
        const formUpload: FormData = new FormData();   
        return this.httpClient.post(url, formUpload);
    }   
    OrderDeliveryByIDToHTML(ID: number) {
        let url = this.aPIURL + this.controller + '/OrderDeliveryByIDToHTML';
        const params = new HttpParams()
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
}

