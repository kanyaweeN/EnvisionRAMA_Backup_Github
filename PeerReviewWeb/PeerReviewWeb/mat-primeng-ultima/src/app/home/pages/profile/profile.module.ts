import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { routes } from './profile.routes';
import { ProfileComponent } from './profile.component';

@NgModule({
  declarations: [
    // Components / Directives/ Pipes
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
  ],
})
export class ProfileModule {
  public static routes = routes;
}
