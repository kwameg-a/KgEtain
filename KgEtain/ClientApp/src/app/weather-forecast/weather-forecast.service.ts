import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponseWeather } from '../models/api-response-weather';
import { WeatherForecast } from '../models/weather-forecast';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getWeatherForecast(): Observable<ApiResponseWeather> {
    return this.http.get<ApiResponseWeather>(this.baseUrl + 'api/belfastweather');      
  }
}
