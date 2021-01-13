import { Component, OnInit } from '@angular/core';
import { ApiResponseWeather } from '../models/api-response-weather';
import { WeatherForecast } from '../models/weather-forecast';
import { WeatherForecastService } from './weather-forecast.service';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.css']
})
export class WeatherForecastComponent implements OnInit {
  weatherForecasts: WeatherForecast[];
  isRefreshing: boolean;

  constructor(private weatherForecastService: WeatherForecastService) { }

  ngOnInit() {
    this.setWeatherForecasts(false);
  }

  updateWeather(): void {
    this.setWeatherForecasts(true);
  }

  private setWeatherForecasts(isRefreshing): void {
        this.isRefreshing = isRefreshing;
        this.weatherForecastService.getWeatherForecast().subscribe((apiResponseWeather: ApiResponseWeather) => {
            this.weatherForecasts = apiResponseWeather.consolidatedWeatherList;
          this.isRefreshing = false;
        }, error => console.error(error));
    }
}
