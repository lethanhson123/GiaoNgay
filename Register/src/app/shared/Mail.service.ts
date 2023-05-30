import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class MailService {   
    aPIURL: string = environment.APIURL;
    controller: string = "Mail";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
    }        
    SendMailWhenOrderDeliveryCreate(orderDeliveryID: number) {
        let url = this.aPIURL + this.controller + '/SendMailWhenOrderDeliveryCreate';
        const params = new HttpParams()
            .set('orderDeliveryID', JSON.stringify(orderDeliveryID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    SendMailWhenOrderDeliveryComplete(orderDeliveryID: number) {
        let url = this.aPIURL + this.controller + '/SendMailWhenOrderDeliveryComplete';
        const params = new HttpParams()
            .set('orderDeliveryID', JSON.stringify(orderDeliveryID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    SendMailWhenMembershipChange(membershipID: number) {
        let url = this.aPIURL + this.controller + '/SendMailWhenMembershipChange';
        const params = new HttpParams()
            .set('membershipID', JSON.stringify(membershipID))
        return this.httpClient.get(url, { params }).toPromise();
    }    
}

