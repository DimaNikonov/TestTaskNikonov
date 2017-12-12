import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Application } from './Application';

@Injectable()
export class DataService {
    private url = "api/angular";
    constructor(private http: HttpClient) { }

    getApplications() {
        return this.http.get(this.url)
    }
}