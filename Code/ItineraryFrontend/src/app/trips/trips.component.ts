import { Component, OnInit } from '@angular/core';
import { Trip } from '../create-trip/create-trip.component';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  trips: Array<Trip>;

  constructor() {
    this.trips = new Array<Trip>();
  }

  ngOnInit() {
    let tempTrip = new Trip();
    tempTrip.title = "Test Trip 1";
    tempTrip.description = "Test description here.";
    tempTrip.address = "San Juan, Puerto Rico";
    
    this.trips.push(tempTrip);
    

    console.log(this.trips);

    let tempTrip2 = new Trip();
    tempTrip2.title = "Test Trip 2";
    tempTrip2.description = "Test description here!!!";
    tempTrip2.address = "Cape Town, South Africa";
    
    this.trips.push(tempTrip2);
    console.log(this.trips);
  }

}
