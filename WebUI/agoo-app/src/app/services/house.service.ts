import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { House } from '../models/house';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class HouseService {

  apiUrl = environment.apiURL;

  constructor(private httpClient: HttpClient) { }

  public Get(): Observable<House[]> {
    return this.httpClient.get<House[]>(this.apiUrl + '/api/House');
  }
}