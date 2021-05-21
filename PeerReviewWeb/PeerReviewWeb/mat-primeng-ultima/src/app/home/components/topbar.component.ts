import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, Inject, forwardRef, OnInit, OnDestroy } from '@angular/core';
import { HomeComponent } from '../home.component';
import { AppState } from '../../app.service';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.template.html'
})
export class TopbarComponent implements OnInit, OnDestroy {
  public userName: string;
  private queryParam: any;

  constructor(private activatedRoute: ActivatedRoute) { }

  public ngOnInit() {
    this.queryParam = this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.userName = params['userName'];
    });

    let date = new Date();
    let hours = date.getHours();
    let minutes = date.getMinutes();
    let ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    let mins = minutes < 10 ? '0' + minutes : minutes;
    let strTime = '' + hours + ':' + mins + ' ' + ampm;

    if (ampm === 'am') {
      this.userName = 'Hi, ' + this.userName + ' - Good Morning!';
    } else {
      if (hours <= 5) {
        this.userName = 'Hi, ' + this.userName + ' - Good Afternoon!';
      } else {
        this.userName = 'Hi, ' + this.userName + ' - Good Evening!';
      }
    }
  }

  public ngOnDestroy() {
    this.queryParam.unsubscribe();
  }
}
