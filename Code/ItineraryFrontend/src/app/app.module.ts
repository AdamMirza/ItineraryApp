import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { WeatherApiService } from "./weather-api.service";
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { TripCardComponent } from './trip-card/trip-card.component';
import { TripFeaturedComponent } from './trip-featured/trip-featured.component';
import { TaskListComponent } from './task-list/task-list.component';
import { WeatherComponent } from './weather/weather.component';
import { CalendarComponent } from './calendar/calendar.component';
import { EventComponent } from './event/event.component';
import { HomeComponent } from './home/home.component';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { CreateTripComponent } from './create-trip/create-trip.component';
import { TripsComponent } from './trips/trips.component';
import { StorageModule } from '@ngx-pwa/local-storage';

const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'home', component: HomeComponent},
  { path: 'trips', component: TripsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    TripCardComponent,
    TripFeaturedComponent,
    TaskListComponent,
    WeatherComponent,
    CalendarComponent,
    EventComponent,
    HomeComponent,
    CreateTripComponent,
    TripsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule,
    RouterModule.forRoot(
      appRoutes,
      {enableTracing: false}
    ),
    StorageModule.forRoot({ IDBNoWrap: true })
  ],
  providers: [WeatherApiService],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(private library: FaIconLibrary) {
    library.addIconPacks(fas);
  }
}
