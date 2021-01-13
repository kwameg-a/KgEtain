import { WeatherForecast } from "./weather-forecast";

export interface ApiResponseWeather {
  consolidatedWeatherList: WeatherForecast[];
  whereOnEarthID: number;
}
