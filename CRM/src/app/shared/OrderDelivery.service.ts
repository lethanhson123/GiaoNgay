import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { OrderDelivery } from 'src/app/shared/OrderDelivery.model';
@Injectable({
    providedIn: 'root'
})
export class OrderDeliveryService {
    displayColumns: string[] = ['DateCreated', 'Barcode', 'ShopFullName', 'ReceiveFullName', 'ShipperFullName', 'CustomerFullName', 'CustomerAddress', 'CategoryOrderStatusID', 'IsCompleteShop', 'TotalBeforeTax', 'Save'];
    isShowDateCreated: boolean = true;
    isShowShopFullName: boolean = true;
    isShowReceiveFullName: boolean = true;
    isShowShipperFullName: boolean = true;
    isShowCustomerFullName: boolean = true;
    isShowCustomerAddress: boolean = true;
    isShowCategoryOrderStatusID: boolean = true;
    isShowIsCompleteShop: boolean = true;
    isShowTotalBeforeTax: boolean = true;
    
    list: OrderDelivery[] | undefined;
    list01: OrderDelivery[] | undefined;
    list02: OrderDelivery[] | undefined;
    list03: OrderDelivery[] | undefined;
    list04: OrderDelivery[] | undefined;
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
    Save01Async(formData: OrderDelivery) {
        let url = this.aPIURL + this.controller + '/Save01Async';
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
    GetByIDStringAsync(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    GetCRMByShopIDAndIsCompleteShopListAsync(shopID: string) {
        let url = this.aPIURL + this.controller + '/GetCRMByShopIDAndIsCompleteShopListAsync';
        const params = new HttpParams()
            .set('shopID', shopID)
        return this.httpClient.get(url, { params }).toPromise();
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
    GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(dateTimeBegin: Date, dateTimeEnd: Date, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('dateTimeBegin', JSON.stringify(dateTimeBegin));
        formUpload.append('dateTimeEnd', JSON.stringify(dateTimeEnd));
        formUpload.append('searchString', searchString);
        return this.httpClient.post(url, formUpload);
    }
    GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(provinceID: number, dateTimeBegin: Date, dateTimeEnd: Date, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('provinceID', JSON.stringify(provinceID));
        formUpload.append('dateTimeBegin', JSON.stringify(dateTimeBegin));
        formUpload.append('dateTimeEnd', JSON.stringify(dateTimeEnd));
        formUpload.append('searchString', searchString);
        return this.httpClient.post(url, formUpload);
    }
    GetByOrderShipperIDToListAsync(orderShipperID: number) {
        let url = this.aPIURL + this.controller + '/GetByOrderShipperIDToListAsync';
        const uploadData = JSON.stringify(orderShipperID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
    UpdateByIDAndActiveAndOrderShipperIDAsync(ID: number, active: boolean, orderShipperID: number) {
        let url = this.aPIURL + this.controller + '/UpdateByIDAndActiveAndOrderShipperIDAsync';
        const IDData = JSON.stringify(ID);
        const activeData = JSON.stringify(active);
        const orderShipperIDData = JSON.stringify(orderShipperID);
        const formUpload: FormData = new FormData();
        formUpload.append('ID', IDData);
        formUpload.append('active', activeData);
        formUpload.append('orderShipperID', orderShipperIDData);
        return this.httpClient.post(url, formUpload);
    }
    GetByOrderReceiveIDToListAsync(orderReceiveID: number) {
        let url = this.aPIURL + this.controller + '/GetByOrderReceiveIDToListAsync';
        const uploadData = JSON.stringify(orderReceiveID);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        return this.httpClient.post(url, formUpload);
    }
    UpdateByIDAndActiveAndOrderReceiveIDAsync(ID: number, active: boolean, orderReceiveID: number) {
        let url = this.aPIURL + this.controller + '/UpdateByIDAndActiveAndOrderReceiveIDAsync';
        const IDData = JSON.stringify(ID);
        const activeData = JSON.stringify(active);
        const orderReceiveIDData = JSON.stringify(orderReceiveID);
        const formUpload: FormData = new FormData();
        formUpload.append('ID', IDData);
        formUpload.append('active', activeData);
        formUpload.append('orderReceiveID', orderReceiveIDData);
        return this.httpClient.post(url, formUpload);
    }
}

