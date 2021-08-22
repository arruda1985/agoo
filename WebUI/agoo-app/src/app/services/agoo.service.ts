import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { House } from '../models/house';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Review } from '../models/review';
import { HouseReviews } from '../models/house-reviews';
@Injectable({
  providedIn: 'root'
})
export class AgooService {

  private apiUrl = environment.apiURL;

  constructor(private httpClient: HttpClient) { }

  public GetHousesReviews(): Observable<HouseReviews[]> {
    return this.httpClient.get<HouseReviews[]>(this.apiUrl + '/api/House');
  }

  public AddHouse(house: House) {
    this.httpClient.post(this.apiUrl + '/api/House', house);
  }

  public AddReview(review: Review) {
    this.httpClient.post(this.apiUrl + '/api/Review', review);
  }
}