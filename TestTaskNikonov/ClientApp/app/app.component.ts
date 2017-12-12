import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Application } from './Application';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {
    applications: Application[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadApplications();
    }

    loadApplications() {
        this.dataService.getApplications()
            .subscribe((data: Application[]) => this.applications = data);
    }
}