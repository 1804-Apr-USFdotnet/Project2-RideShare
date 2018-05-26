import { User } from './../../shared/user.model';
import { SharesService } from './../../shared/shares.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Share } from '../../shared/share.model';

@Component({
  selector: 'app-add-share',
  templateUrl: './add-share.component.html',
  styleUrls: ['./add-share.component.css']
})
export class AddShareComponent implements OnInit {
  share: Share;

  constructor(private SharesService: SharesService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.share = {
      DepartureCity: '',
      DestinationCity: '',
      DepartureDate: '',
      Seats: 0
    }
  }

  onSubmit(form: NgForm) {
    this.SharesService.createShare(form.value)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      )
  }
}
