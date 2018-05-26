import { Component, OnInit } from '@angular/core';
import { SharesService } from '../shares.service';

@Component({
  selector: 'app-shares',
  templateUrl: './shares.component.html',
  styleUrls: ['./shares.component.css']
})
export class SharesComponent implements OnInit {
  shares: any[];

  constructor(private sharesService: SharesService) { }

  ngOnInit() {
    this.sharesService.getAllShares().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    )
  }

  SortSeat(){
    this.sharesService.DescendingSeatShare().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    )
  }

  SortDate(){
    this.sharesService.DescendingDateShare().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    )
  }

  MostDepartingCity(){
    this.sharesService.MostDepartingCity().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    )
  }

  MostDestinationCity(){
    this.sharesService.MostDestCity().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    )
  }
}
