import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Response } from "@angular/http";
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = `${this.domain}/api`;
  private readonly domain: string = 'http://ec2-18-222-157-137.us-east-2.compute.amazonaws.com/RideAlongAPI';

  constructor(private http: HttpClient) { }
 
  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }

    const httpOptions = {
      headers: new HttpHeaders({
        'No-Auth': 'True'
      })
    };

    return this.http.post(this.rootUrl + '/Account/register-user', body, httpOptions);
  }

  userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
  }

  getUserClaims() {
    return this.http.get(this.rootUrl + '/Account/get-user-claims');
  }
}
