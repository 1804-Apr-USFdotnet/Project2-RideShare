import { UserService } from './shared/user.service';
import { Router } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  userClaims: any;
  title = 'app';
  localStorage = localStorage;

  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.userClaims = data;
 
    });
  }
 
  logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['user', 'sign-in']);
  }
}
