import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpRequest, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { of, Observable, EMPTY } from 'rxjs';
import { catchError, shareReplay } from 'rxjs/operators';
import { StorageMap } from '@ngx-pwa/local-storage';


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

  constructor(private http:HttpClient,
              private storage: StorageMap) { }

  getWeather(address: string) {

  }

  hasWeather(address: string) {
    let url = this.getUrlFromAddress(address);
    
    return this.storage.has(url);
  }

  getWeatherFromCache(address: string) {
    let url = this.getUrlFromAddress(address);

    console.log("Returning stored value!");
    
    return this.storage.get(url);
  }

  getWeatherFromServer(address: string) {
    let url = this.getUrlFromAddress(address);
    console.log("Returning server value!");
    
    let response = this.http.post<IWeatherForecast>(url, this.httpOptions).pipe(
      shareReplay(1),
      catchError(err => {
        this.storage.delete(url);
        return EMPTY;
      })
    );

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