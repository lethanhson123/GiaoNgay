import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { NhanVien } from './NhanVien.model';

@Injectable({
    providedIn: 'root'
})
export class NhanVienService {
    list: NhanVien[] | undefined;
    formDataLogin!: NhanVien;
    formData!: NhanVien;
    aPIURL: string = environment.APIURL;
    controller: string = "NhanVien";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    save(formData: NhanVien) {
        var membershipID = localStorage.getItem(environment.MembershipID);
        if (membershipID) {
            formData.UserUpdated = Number(membershipID);
        }        
        let url = this.aPIURL + this.controller + '/Save';
        return this.httpClient.post(url, formData);
    }
    authentication(formData: NhanVien) {        
        let url = this.aPIURL + this.controller + '/Authentication';
        return this.httpClient.post(url, formData);
    }
    remove(ID: number) {
        let url = this.aPIURL + this.controller + '/Remove';
        const params = new HttpParams()
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByID(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByID';
        const params = new HttpParams()
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByIDString(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDString';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';
        return this.httpClient.get(url).toPromise();
    }
    getByParentIDToList(parentID: number) {
        let url = this.aPIURL + this.controller + '/GetByParentIDToList';
        const params = new HttpParams()
            .set('parentID', JSON.stringify(parentID));
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByActiveToList(active: boolean) {
        let url = this.aPIURL + this.controller + '/GetByActiveToList';
        const params = new HttpParams()
            .set('active', JSON.stringify(active));
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByParentIDAndActiveToList(parentID: number, active: boolean) {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveToList';
        const params = new HttpParams()
            .set('parentID', JSON.stringify(parentID))
            .set('active', JSON.stringify(active));
        return this.httpClient.get(url, { params }).toPromise();
    }

}

