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
}
