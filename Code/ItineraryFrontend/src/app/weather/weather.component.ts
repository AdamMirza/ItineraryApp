import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IWeatherForecast, WeatherApiService, IForecast } from '../weather-api.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  public weatherSearchForm: FormGroup;
  public weatherForecast: WeatherForecast;

  constructor(private formBuilder: FormBuilder, private weatherServiceApi: WeatherApiService) {
    this.weatherForecast = new WeatherForecast();
    this.weatherForecast.forecast = new Array<Forecast>();
  }

  ngOnInit() {
    this.weatherSearchForm = this.formBuilder.group({
      location: ['']
    });

    let weatherCall = this.weatherServiceApi.getWeather('San Juan, Puerto Rico');

    weatherCall.subscribe((resp: WeatherForecast) => {
      resp.forecast.forEach(element => {
        this.weatherForecast.forecast.push(element);
      });
    });

    this.populateWeather();
  }

  sendToAPI(formValues) {
    //console.log(formValues);
  }

  populateWeather() {
    
  }

}

export class WeatherForecast implements IWeatherForecast {
  forecast: import("../weather-api.service").IForecast[];
}

export class Forecast implements IForecast {
  date: Date;
  maxTemperatureC: number;
  maxTemperatureF: number;
  minTemperatureC: number;
  minTemperatureF: number;
  icon: string;
}
