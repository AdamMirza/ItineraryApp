import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { TripService } from '../trip.service';

@Component({
  selector: 'app-create-trip',
  templateUrl: './create-trip.component.html',
  styleUrls: ['./create-trip.component.css']
})
export class CreateTripComponent implements OnInit {

  tripForm;

  constructor(private trip: Trip,
              private formBuilder: FormBuilder,
              private tripService: TripService) {
    this.tripForm = this.formBuilder.group({
      id: '',
      title: '',
      description: '',
      address: '',
      startDate: new Date(),
      endDate: new Date(),
      eventIds: new Array<string>()
    });
  }

  ngOnInit() {
  }

  onSubmit(tripData) {
    let trip = new Trip();
    trip.title = tripData.title;
    trip.description = tripData.description;
    trip.address = tripData.address;
    trip.startDate = tripData.startDate;
    trip.endDate = tripData.endDate;
    trip.eventIds = new Array<string>();

    this.tripService.createTrip(trip);
  }

}

export class Trip {
  id: string;
  title: string;
  description: string;
  address: string;
  startDate: Date;
  endDate: Date;
  eventIds: Array<string>;
}