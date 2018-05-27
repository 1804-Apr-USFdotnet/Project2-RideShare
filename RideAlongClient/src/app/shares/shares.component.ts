import { SharesService } from './../shared/shares.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-shares',
  templateUrl: './shares.component.html',
  styleUrls: ['./shares.component.css']
})
export class SharesComponent implements OnInit {
  shares: any[];
  isRoot: boolean;

  constructor(private sharesService: SharesService,
              private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.sharesService.getAllShares().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    );
  }

  SortSeat() {
    this.sharesService.DescendingSeatShare().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    );
  }

  SortDate() {
    this.sharesService.DescendingDateShare().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    );
  }

  MostDepartCity() {
    this.sharesService.MostDepartingCity().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    );
  }

  MostDestinationCity() {
    this.sharesService.MostDestCity().subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    );
  }

  Search(desiredText: string) {
    this.sharesService.SearchFor(desiredText).subscribe(
      (response: any[]) => {
        this.shares = response;
        console.log(response);
      },
      (error) => console.log(error)
    );

  }
}
