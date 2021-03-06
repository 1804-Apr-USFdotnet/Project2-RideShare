import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SharesService {
  private readonly rootUrl: string = `http://localhost:50235/api/shares`;
  private readonly custDateUrl: string = `http://localhost:50235/api/Shares-ByDate-Descending`;
  private readonly custSeatUrl: string = `http://localhost:50235/api/Shares-Seats-Descending`;
  private readonly custDepartUrl: string = `http://localhost:50235/api/Shares-Most-Departing-City`;
  private readonly custDestUrl: string = `http://localhost:50235/api/Shares-Most-Destination-City`;
  private readonly SearchUrl: string = `http://localhost:50235/api/Shares-Search-Conditions-City/`;
  private readonly SetUpUrl: string = `http://localhost:50235/api/Shares-Setup-Ride/`;
  private readonly myShares: string = `http://localhost:50235/api/my-shares/`;

  constructor(private http: HttpClient) { }

  getAllShares() {
    return this.http.get(this.rootUrl);
  }

  getShare(id: number) {
    return this.http.get(`${this.rootUrl}/${id}`);
  }

  createShare(share: any) {
    return this.http.post(this.rootUrl, share);
  }

  updateShare(id: number, share: any) {
    return this.http.put(`${this.rootUrl}/${id}`, share);
  }

  deleteShare(id: number) {
    return this.http.delete(`${this.rootUrl}/${id}`);
  }

  DescendingSeatShare() {
    return this.http.get(this.custSeatUrl);
  }

  DescendingDateShare() {
    return this.http.get(this.custDateUrl);
  }

  MostDepartingCity() {
    return this.http.get(this.custDepartUrl);
  }

  MostDestCity() {
    return this.http.get(this.custDestUrl);
  }

  SearchFor(desiredText: string) {
    return this.http.get(`${this.SearchUrl}/${desiredText}`);
  }

  SetUpRide(departingCity: string, arrivingCity: string ) {
    return this.http.get(`${this.SetUpUrl}/${departingCity}/${arrivingCity}`);
  }

  getMyShares() {
    return this.http.get(this.myShares);
  }
}
