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
import { DashboardComponent } from './dashboard/dashboard.component';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { CreateTripComponent } from './create-trip/create-trip.component';
import { TripsComponent } from './trips/trips.component';
import { OktaAuthModule, OktaCallbackComponent } from '@okta/okta-angular';
import { environment } from 'src/environments/environment';
import { HomeComponent } from './home/home.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'dashboard', component: DashboardComponent},
  { path: 'trips', component: TripsComponent},
  { path: 'implicit/callback', component: OktaCallbackComponent },
  { path: 'home', component: HomeComponent }
];

const config = {
  issuer: 'https://dev-666959.okta.com/oauth2/default',
  redirectUri: environment.baseUrl+'/implicit/callback',
  clientId: '0oa2ao91pfslRV45u4x6',
  pkce: true
}

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
    DashboardComponent,
    CreateTripComponent,
    TripsComponent,
    HomeComponent
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
    OktaAuthModule.initAuth(config)
  ],
  providers: [WeatherApiService],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(private library: FaIconLibrary) {
    library.addIconPacks(fas);
  }
}
