import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { OrderShipper } from 'src/app/shared/OrderShipper.model';
@Injectable({
    providedIn: 'root'
})
export class OrderShipperService {
    list: OrderShipper[] | undefined;
    formData!: OrderShipper;
    aPIURL: string = environment.APIURL;
    controller: string = "OrderShipper";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    Save(formData: OrderShipper) {        
        let url = this.aPIURL + this.controller + '/Save';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        return this.httpClient.post(url, formUpload);
    }  
    SaveAsync(formData: OrderShipper) {        
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
    GetByYearAndMonthAndDayAndSearchStringToLisAsync(year: number, month: number, day: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByYearAndMonthAndDayAndSearchStringToLisAsync';
        const yearData = JSON.stringify(year);
        const monthData = JSON.stringify(month);
        const dayData = JSON.stringify(day);
        const formUpload: FormData = new FormData();
        formUpload.append('year', yearData);
        formUpload.append('month', monthData);
        formUpload.append('day', dayData);
        formUpload.append('searchString', searchString);
        return this.httpClient.post(url, formUpload);
    } 
    GetByIDStringAsync(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(dateTimeBegin: Date, dateTimeEnd: Date, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync';             
        const formUpload: FormData = new FormData();
        formUpload.append('dateTimeBegin', JSON.stringify(dateTimeBegin));
        formUpload.append('dateTimeEnd', JSON.stringify(dateTimeEnd));        
        formUpload.append('searchString', searchString);
        return this.httpClient.post(url, formUpload);
    }
}

