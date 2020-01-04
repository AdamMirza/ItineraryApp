import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpRequest, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WeatherApiService {

  weatherUrl = "https://localhost:44322/weatherforecast";
  httpOptions = { 
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    }),
    observe: 'response'
  };

  constructor(private http:HttpClient) { }

  getWeather(address: string) {
    return this.http.post<IWeatherForecast>(this.weatherUrl + '?address=' + address, this.httpOptions);
  }
}

export interface IWeatherForecast {
  forecast: Array<IForecast>;
}

export interface IForecast {
  date: Date;
  maxTemperatureC: number;
  maxTemperatureF: number;
  minTemperatureC: number;
  minTemperatureF: number;
  icon: string;
}