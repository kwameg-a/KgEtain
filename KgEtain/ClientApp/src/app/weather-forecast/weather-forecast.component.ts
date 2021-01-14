import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(
    private route: ActivatedRoute,
    private weatherForecastService: WeatherForecastService) { }

  ngOnInit() {
    this.weatherForecasts = this.route.snapshot.data['apiResponseWeather'].consolidatedWeatherList;
  }

  updateWeather(): void {
    this.isRefreshing = true;
    this.weatherForecastService.getWeatherForecast().subscribe((apiResponseWeather: ApiResponseWeather) => {
      this.weatherForecasts = apiResponseWeather.consolidatedWeatherList;
      this.isRefreshing = false;
    }, error => console.error(error));
  }
}
