import { PeerReviewComponent } from './peerreview.component';
import { AssignmentComponent } from './assignment.component';
import { ReviewHistoryComponent } from './reviewhistory.component';

export const routes = [
  { path: '', component: PeerReviewComponent, pathMatch: 'full' },
  { path: 'studyassign', component: AssignmentComponent },
  { path: 'reviewhistory', component: ReviewHistoryComponent },
];
