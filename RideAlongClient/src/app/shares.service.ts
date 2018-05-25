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
}
