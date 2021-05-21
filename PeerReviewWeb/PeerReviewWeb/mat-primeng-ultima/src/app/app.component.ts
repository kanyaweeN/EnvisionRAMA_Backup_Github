import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppState } from './app.service';

declare var $: any;

@Component({
  selector: 'app-root',
  encapsulation: ViewEncapsulation.None,
  template: `<router-outlet></router-outlet>`
})
export class AppComponent implements OnInit {
  constructor(public appState: AppState) { }

  public ngOnInit() {
    console.log('Initial App State', this.appState.state);
    // tslint:disable-next-line:one-variable-per-declaration
    let ink, d, x, y;
    $(document.body).off('mousedown.ripple', '.ripplelink,.ui-button:enabled,.ui-listbox-item')
      // tslint:disable-next-line:only-arrow-functions
      .on('mousedown.ripple', '.ripplelink,.ui-button:enabled,.ui-listbox-item', null, function (e) {
        let element = $(this);

        if (element.find('.ink').length === 0) {
          if (element.hasClass('ripplelink'))
            element.children('span').after("<span class='ink'></span>");
          else
            element.append("<span class='ink'></span>");
        }

        ink = $(this).find('.ink');
        ink.removeClass('ripple-animate');

        if (!ink.height() && !ink.width()) {
          d = Math.max($(this).outerWidth(), $(this).outerHeight());
          ink.css({ height: d, width: d });
        }

        x = e.pageX - $(this).offset().left - ink.width() / 2;
        y = e.pageY - $(this).offset().top - ink.height() / 2;
        ink.css({ 'top': y + 'px', 'left': x + 'px', 'pointer-events': 'none' }).addClass('ripple-animate');
      });
  }
}
