import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { routes } from './main.routes';
import {
  TableModule, ButtonModule, DialogModule,
  PanelModule, TabViewModule, EditorModule,
  SharedModule, RadioButtonModule, MessagesModule,
  CalendarModule, FieldsetModule, ConfirmDialogModule,
  DropdownModule, SpinnerModule, CheckboxModule,
  TooltipModule,
  ConfirmationService,
  ProgressSpinnerModule
} from 'primeng';
import { MainComponent } from './main.component';
import { PeerreviewComponent } from './peerreview/peerreview.component';
import { ScoringComponent } from './peerreview/scoring.component';
import { FormsModule } from '@angular/forms';
import { StudyService } from './peerreview/services/study.service';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';
import { UtilitiesService } from '../services/common/utilities.service';

@NgModule({
  declarations: [
    MainComponent,
    PeerreviewComponent,
    ScoringComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ProgressSpinnerModule,
    TableModule,
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
    DialogModule,
    SharedModule,
    TooltipModule,
    RouterModule.forChild(routes),
  ],
  providers: [ApiService,
    StudyService,
    ConfirmationService,
    UtilitiesService],
  bootstrap: [MainComponent]
})
export class MainModule { }
