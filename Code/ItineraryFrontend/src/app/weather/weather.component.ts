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

  address: string = 'San Juan, Puerto Rico';

  constructor(private formBuilder: FormBuilder, private weatherServiceApi: WeatherApiService) {
    this.weatherForecast = new WeatherForecast();
    this.weatherForecast.forecast = new Array<Forecast>();
  }

  ngOnInit() {
    this.weatherSearchForm = this.formBuilder.group({
      location: ['']
    });

    let weatherCall = this.weatherServiceApi.getWeather(this.address);

    weatherCall.subscribe((resp: WeatherForecast) => {
      resp.forecast.forEach(element => {
        this.weatherForecast.forecast.push(this.mapIcon(element));
      });
    });

    console.log(this.weatherForecast.forecast);

    this.populateWeather();
  }

  sendToAPI(formValues) {
    //console.log(formValues);
  }

  populateWeather() {
    
  }

  mapIcon(element: Forecast) {
    switch (element.icon) {
      case 'clear-day': {
        element.icon = 'sun';
        break;
      }
      case 'clear-night': {
        element.icon = 'moon';
        break;
      }
      case 'rain': {
        element.icon = 'cloud-rain';
        break;
      }
      case 'snow': {
        element.icon = 'snowflake';
        break;
      }
      case 'sleet': {
        element.icon = 'cloud-rain';
        break;
      }
      case 'wind': {
        element.icon = 'wind';
        break;
      }
      case 'fog': {
        element.icon = 'smog';
        break;
      }
      case 'cloudy': {
        element.icon = 'cloud';
        break;
      }
      case 'partly-cloudy-day': {
        element.icon = 'cloud-sun';
        break;
      }
      case 'partly-cloudy-night': {
        element.icon = 'cloud-moon';
        break;
      }
      case 'thunderstorm': {
        element.icon = 'bolt';
        break;
      }
      default: {
        element.icon = 'poo';
        break;
      }
    }

    return element;
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
