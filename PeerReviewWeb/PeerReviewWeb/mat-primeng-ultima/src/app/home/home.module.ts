import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { MenuItem } from 'primeng/primeng';
import { routes } from './home.routes';
import { HomeComponent } from './home.component';
import { TopbarComponent } from './components/topbar.component';
import { FooterBarComponent } from './components/footer.component';
import { InlineProfileComponent } from'./components/inline-profile.component';
import { MenuBarComponent } from './components/menu.component';
import { SubMenuComponent } from './components/submenu.component';

@NgModule({
  declarations: [
    // Components / Directives/ Pipes
    HomeComponent,
    TopbarComponent,
    FooterBarComponent,
    MenuBarComponent,
    SubMenuComponent,
    InlineProfileComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
  ],
})
export class HomeModule {
}
