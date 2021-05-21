import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'notfound',
  templateUrl: './notfound.template.html'
})
export class NotFoundComponent {
  constructor(private router: Router) { }

  public backToHomePage() {
    this.router.navigate(['/']);
  }
}
