import { Component } from '@angular/core';
import { HouseReviews } from './models/house-reviews';
import { AgooService } from './services/agoo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'agoo-app';

  houses!: HouseReviews[];

  constructor(private agooService: AgooService) {

    this.GetLastHouses();

  }
  GetLastHouses() {
    this.agooService.GetHousesReviews().subscribe((data) => {
      this.houses = data;
    });
  }
}
