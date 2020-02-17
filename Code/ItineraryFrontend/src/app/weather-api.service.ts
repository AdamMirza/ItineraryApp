import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpRequest, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WeatherApiService {

  weatherUrl = environment.baseUrl + "/weatherforecast";
  httpOptions = { 
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    }),
    observe: 'response'
  };

  constructor(private http:HttpClient) { }

  getWeather(address: string) {
    let url = this.getUrlFromAddress(address);
    
    let response = this.http.post<IWeatherForecast>(url, this.httpOptions);

    return response;
  }

  private getUrlFromAddress(address: string) {
    return this.weatherUrl + '?address=' + address;
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