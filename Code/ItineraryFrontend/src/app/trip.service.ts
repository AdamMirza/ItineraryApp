import { Injectable } from '@angular/core';
import { Trip } from './create-trip/create-trip.component';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  constructor() { }

  createTrip(trip: Trip) {
    console.log(trip);
  }
}
