import { House } from "./house";
import { Review } from "./review";

export interface HouseReviews {
    house: House;
    reviews: Review[];
}