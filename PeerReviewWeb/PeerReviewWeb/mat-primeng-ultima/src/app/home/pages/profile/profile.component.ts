import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'profile',
  templateUrl: './profile.template.html'
})
export class ProfileComponent implements OnInit {

  public ngOnInit() {
    console.log('hello `Profile` component');
  }

}
