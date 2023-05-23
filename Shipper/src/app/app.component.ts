import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CRM';
  domainName = environment.DomainDestination;
  queryString: string = environment.InitializationString;
  constructor(
    public router: Router,
  ) {    
  }
}
