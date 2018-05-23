import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SharesService {
  private readonly rootUrl: string = 'http://localhost:50235/api/shares';

  constructor(private http: HttpClient) { }

  getAllShares() {
    return this.http.get(this.rootUrl);
  }
}
