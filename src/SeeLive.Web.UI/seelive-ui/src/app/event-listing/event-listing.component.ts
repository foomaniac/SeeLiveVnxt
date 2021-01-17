import { Component, OnInit } from '@angular/core';
import {
  Location,
  LocationStrategy,
  PathLocationStrategy,
} from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-event-listing',
  templateUrl: './event-listing.component.html',
  styleUrls: ['./event-listing.component.css'],
  providers: [
    Location,
    { provide: LocationStrategy, useClass: PathLocationStrategy },
  ],
})
//Regarding use of location, see source article: https://blexin.com/en/blog-en/angular-microservices-and-authentication/
export class EventListingComponent implements OnInit {
  constructor(location: Location, private httpClient: HttpClient) {
    location.replaceState('/');
  }

  ngOnInit(): void {}

  getAllEvents() {
    this.httpClient.get(environment.seeLiveApi).subscribe(
      (data) => alert('SUCCESS: ' + JSON.stringify(data)),
      (error) => alert('ERROR: ' + JSON.stringify(error))
    );
  }
}
