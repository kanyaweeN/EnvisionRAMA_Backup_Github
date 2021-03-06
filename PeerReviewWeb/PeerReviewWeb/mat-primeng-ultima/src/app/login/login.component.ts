import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { UserInfo } from '../model/user-info';

@Component({
  selector: 'login',
  templateUrl: './login.template.html'
})
export class LoginComponent implements OnInit, OnDestroy {
  private router: Router;
  private paramUrl: string;
  private queryParam: any;

  constructor(public _router: Router, private activatedRoute: ActivatedRoute) { }

  public ngOnInit() {
    this.router = this._router;
    this.queryParam = this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.paramUrl = '?userId=' + params['userId'];
      this.paramUrl += '&userName=' + params['userName'];
      this.paramUrl += '&orgId=' + params['orgId'];

      console.log('this.paramUrl', this.paramUrl);
      console.log('menuName', params['menuName']);
      if (params['menuName'] === 'review')
        this.router.navigateByUrl('/home/peerreview' + this.paramUrl);
      else if (params['menuName'] === 'assign')
        this.router.navigateByUrl('/home/peerreview/studyassign' + this.paramUrl);
      else
        this.router.navigateByUrl('/home/peerreview/reviewhistory' + this.paramUrl);
    });

  }

  public ngOnDestroy() {
    this.queryParam.unsubscribe();
  }

}
