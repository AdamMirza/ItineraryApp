import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-create-trip',
  templateUrl: './create-trip.component.html',
  styleUrls: ['./create-trip.component.css']
})
export class CreateTripComponent implements OnInit {

  tripForm;

  constructor(private trip: Trip,
              private formBuilder: FormBuilder) {
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