import { Component } from '@angular/core';
import { House } from './models/house';
import { HouseService } from './services/house.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'agoo-app';

  houses!: House[];
  constructor(private houseService: HouseService) {

    this.GetLastHouses();

  }
  GetLastHouses() {
    this.houseService.Get().subscribe((data) => {
      this.houses = data;
    });
  }
}
