import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-main-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  private router: Router;
  private paramUrl: string;
  private queryParam: any;

  constructor(
    public _router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  public ngOnInit() {
    this.router = this._router;
    this.queryParam = this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.paramUrl = '?userId=' + params['userId'];
      this.paramUrl += '&userName=' + params['userName'];
      this.paramUrl += '&orgId=' + params['orgId'];

      console.log('this.paramUrl', this.paramUrl);
      console.log('menuName', params['menuName']);
      if (params['menuName'] === 'review') {
        this.router.navigateByUrl('/peerreview' + this.paramUrl);
      } else if (params['menuName'] === 'assign') {
        this.router.navigateByUrl('/studyassign' + this.paramUrl);
      } else if (params['menuName'] === 'history') {
        this.router.navigateByUrl('/reviewhistory' + this.paramUrl);
      } else {
        this.router.navigateByUrl('/home');
      }
    });
  }
  public ngOnDestroy() {
    this.queryParam.unsubscribe();
  }
}
