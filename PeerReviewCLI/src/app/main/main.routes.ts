import { Routes } from '@angular/router';
import { MainComponent } from './main.component';
import { HomeComponent } from './home/home.component';
import { PeerreviewComponent } from './peerreview/peerreview.component';
import { ScoringComponent } from './peerreview/scoring.component';

export const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'peerreview', component: PeerreviewComponent },
      { path: 'scoring/:id/:userid/:username/:orgid', component: ScoringComponent },
      { path: 'studyassign', component: PeerreviewComponent },
      { path: 'reviewhistory', component: PeerreviewComponent }
    ]
  }
];
