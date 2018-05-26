import { User } from "./user.model";

export class Share {
    Seats: number;
    DestinationCity: string;
    DepartureCity: string;
    DepartureDate: string;
    Driver?: User;
    Users?: User[];
}