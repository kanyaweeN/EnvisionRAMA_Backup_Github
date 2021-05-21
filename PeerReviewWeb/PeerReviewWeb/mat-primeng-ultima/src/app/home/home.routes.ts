import { Routes } from '@angular/router';
import { HomeComponent } from './home.component';

export const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'peerreview', loadChildren: './pages/peerreview/peerreview.module#PeerReviewModule' }
    ]
  }
];
