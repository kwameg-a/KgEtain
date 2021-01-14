import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResponseWeather } from '../models/api-response-weather';
import { WeatherForecastService } from './weather-forecast.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastResolver implements Resolve<ApiResponseWeather> {

  constructor(private weatherForecastService: WeatherForecastService) { }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ApiResponseWeather> {
      return this.weatherForecastService.getWeatherForecast();
    }  
}
