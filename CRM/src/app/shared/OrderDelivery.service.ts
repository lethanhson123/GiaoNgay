import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
@Injectable({
    providedIn: 'root'
})
export class OrderDeliveryService {
    list01: OrderDelivery[] | undefined;
    list02: OrderDelivery[] | undefined;
    list03: OrderDelivery[] | undefined;
    formData!: OrderDelivery;
    aPIURL: string = environment.APIURL;
    controller: string = "OrderDelivery";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    Save(formData: OrderDelivery) {
        let url = this.aPIURL + this.controller + '/Save';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
    SaveAsync(formData: OrderDelivery) {
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
    Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(year: number, month: number, day: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/Get01ByYearAndMonthAndDayAndSearchStringToLisAsync';
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
    Get02ByYearAndMonthAndDayAndSearchStringToLisAsync(year: number, month: number, day: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/Get02ByYearAndMonthAndDayAndSearchStringToLisAsync';
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
    Get03ByYearAndMonthAndDayAndSearchStringToLisAsync(year: number, month: number, day: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/Get03ByYearAndMonthAndDayAndSearchStringToLisAsync';
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
}

