import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { routes } from './peerreview.routes';
import { PeerReviewComponent } from './peerreview.component';
import { AssignmentComponent } from './assignment.component';
import { ReviewHistoryComponent } from './reviewhistory.component';
import { LoadingComponent } from './loading.component';
import { StudyService } from './services/study.service';
import {
  DataTableModule, RadioButtonModule, ButtonModule,
  DialogModule, PanelModule, TabViewModule,
  EditorModule, SharedModule, MessagesModule,
  CalendarModule, FieldsetModule, ConfirmDialogModule,
  ConfirmationService, DropdownModule, SpinnerModule,
  CheckboxModule, TooltipModule
} from 'primeng/primeng';

@NgModule({
  declarations: [
    // Components / Directives/ Pipes
    PeerReviewComponent,
    AssignmentComponent,
    ReviewHistoryComponent,
    LoadingComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    DataTableModule,
    ButtonModule,
    DialogModule,
    PanelModule,
    TabViewModule,
    EditorModule,
    SharedModule,
    RadioButtonModule,
    MessagesModule,
    CalendarModule,
    FieldsetModule,
    ConfirmDialogModule,
    DropdownModule,
    SpinnerModule,
    ButtonModule,
    CheckboxModule,
    DataTableModule,
    DialogModule,
    SharedModule,
    TooltipModule,
    RouterModule.forChild(routes),
  ],
  providers: [ // expose our Services and Providers into Angular's dependency injection
    StudyService, ConfirmationService
  ]
})
export class PeerReviewModule {
  public static routes = routes;
}
