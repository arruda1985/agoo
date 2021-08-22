import { Review } from "./review";

export interface House {
   
    id: string;
    postalCode: string;
    streetName: string;
    number: string;
    complement: string;
    neighborhood: string;
    city: string;
    country: string;
    reviews: Review[];
}