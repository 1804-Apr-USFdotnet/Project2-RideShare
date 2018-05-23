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
      (response: Response) => console.log(response.json()),
      (error) => console.log(error)
    )
  }
}
