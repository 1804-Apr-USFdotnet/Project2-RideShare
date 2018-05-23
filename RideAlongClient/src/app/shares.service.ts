import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SharesService {
  private readonly rootUrl: string = 'url';

  constructor(private http: HttpClient) { }

  getAllShares() {
    return this.http.get(this.rootUrl);
  }
}
