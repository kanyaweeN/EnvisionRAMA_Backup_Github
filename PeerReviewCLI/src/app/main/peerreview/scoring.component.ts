import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Study, Score, PeerStatus, PeerGblEnv, PeerReview } from './models';
import { ConfirmationService, Message } from 'primeng/api';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { StudyService } from './services/study.service';
import { UtilitiesService } from 'src/app/services/common/utilities.service';

@Component({
  selector: 'app-peerreview-scoring',
  templateUrl: './scoring.component.html',
  styleUrls: ['./scoring.component.scss']
})
export class ScoringComponent implements OnInit, OnDestroy {
  public isLoading = true;

  public msgs: Message[] = [];
  public selectedTab = 0;
  public reportTab = 'Write Review';
  public myReport: string;
  public finalizeReport: string;
  public displayScoring: boolean;
  public scores: Score[];
  public scoreValue: string;
  public myComment: string;
  public ifFinal: boolean;
  public tabDisable = true;
  public skipHide = true;

  public sTxtHN: string;
  public sTxtPATIENTNAME: string;
  public sTxtACCESSIONNO: string;
  public sTxtEXAMNAME: string;
  public sTxtTYPENAMEALIAS: string;
  public sDateORDERDT: Date;

  private userID: number;
  private study: Study;
  constructor(
    public studyService: StudyService,
    private route: ActivatedRoute,
    private routerService: Router,
    private confirmationService: ConfirmationService,
    private utilities: UtilitiesService
  ) {
  }

  public ngOnInit() {
    const assignID = this.route.snapshot.params['id'];
    this.userID = Number(this.route.snapshot.params['userid']);
    console.log('assignID :', assignID);
    console.log('userID :', this.userID);
    const unGetScore = this.studyService.getScore(assignID).subscribe((res) => {
      this.isLoading = false;
      const obj: Score[] = res;
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        this.isLoading = true;
        const unStudy = this.studyService.getStudy(this.userID).subscribe((resStudy) => {
          this.isLoading = false;
          this.study = resStudy.filter((f) => f.ACCESSION_NO === obj[0].ACCESSION_NO)[0];
          this.bindingPatient(this.study);
          this.myReport = '';
          this.finalizeReport = '';
          this.displayScoring = true;
          this.clearTabSelection();
          const leftwin: number = window.screenX + 200;
          this.utilities.OpenPACS(obj[0].ACCESSION_NO);

          this.scores = obj;
          this.finalizeReport = obj[0].RESULT_TEXT_HTML;
          this.myReport = obj[0].REPORT_TEXT_HTML;
          this.scoreValue = obj[0].REVIEW_SCORE;
          this.myComment = obj[0].COMMENT;
          if (obj[0].REPORT_STATUS === 'F') {
            this.ifFinal = true;
          } else { this.ifFinal = false; }
          if (this.myReport != null) {
            this.reportTab = 'My Review';
          } else { this.reportTab = 'Write Review'; }
          if (this.myReport != null) {
            this.tabDisable = false;
            this.skipHide = false;
          } else {
            this.tabDisable = true;
            this.skipHide = true;
          }
          if (unStudy) {
            unStudy.unsubscribe();
          }
        });

      }

      if (unGetScore) {
        unGetScore.unsubscribe();
      }
    });
  }
  public ngOnDestroy() {
  }
  public changeTab(index: number) {
    this.selectedTab = index;
  }
  public saveAsDraft(assignID: string) {
    if (this.myReport != null) {
      const prReview: PeerReview = {
        ACTION_TYPE: 1,
        ASSIGNMENT_ID: assignID,
        CREATED_BY: this.userID,
        REPORT_STATUS: 'D',
        REPORT_TEXT_HTML: this.myReport
      };
      this.studyService.insertPeerReviewReport(prReview).subscribe((res) => {
        if (res === null) {
          this.msgs = [];
          this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
          return;
        } else {
          this.msgs = [];
          this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Draft' });
          this.tabDisable = false;
          this.skipHide = false;
        }
      });
    } else {
      this.confirmationService.confirm({
        message: 'Your review report is empty!',
        accept: () => {
        }
      });
    }
  }
  public saveAsFinal(assignID: string) {
    if (this.myReport != null) {
      const prReview: PeerReview = {
        ACTION_TYPE: 1,
        ASSIGNMENT_ID: assignID,
        CREATED_BY: this.userID,
        REPORT_STATUS: 'F',
        REPORT_TEXT_HTML: this.myReport
      };

      this.studyService.insertPeerReviewReport(prReview).subscribe((res) => {
        if (res === null) {
          this.msgs = [];
          this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
          return;
        } else {
          this.msgs = [];
          this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Final Report' });
          this.tabDisable = false;
          this.skipHide = false;
        }
      });
    } else {
      this.confirmationService.confirm({
        message: 'Your review report is empty!',
        accept: () => {
        }
      });
    }
  }

  public saveScore(assignID: string) {
    if (this.scoreValue != null) {

      const prReview: PeerReview = {
        ACTION_TYPE: 2,
        ASSIGNMENT_ID: assignID,
        CREATED_BY: this.userID,
        REVIEW_SCORE: this.scoreValue,
        COMMENT: this.myComment
      };

      this.studyService.insertPeerReviewScore(prReview).subscribe((res) => {
        console.log('res', res);
        if (res === null) {
          this.msgs = [];
          this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
          return;
        } else {
          this.msgs = [];
          this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Score' });
          this.study.REVIEW_SCORE = this.scoreValue;
          this.study.STATUS = 'Reviewed';
        }
      });
    } else {
      this.confirmationService.confirm({
        message: 'Please select a score!',
        accept: () => {
        }
      });
    }
  }
  public skipToFinalReport() {
    this.tabDisable = false;
    this.selectedTab = 1;
    this.skipHide = false;
  }
  public backPeerreview() {
    this.routerService.navigate(['/home'], {
      queryParams: {
        userId: this.route.snapshot.params['userid'],
        userName: this.route.snapshot.params['username'],
        orgId: this.route.snapshot.params['orgid'],
        menuName: 'review'
      }
    });
  }
  private clearTabSelection() {
    this.selectedTab = 0;
  }
  private bindingPatient(study: Study) {
    this.sTxtHN = study.HN;
    this.sTxtPATIENTNAME = study.PATIENT_NAME;
    this.sTxtACCESSIONNO = study.ACCESSION_NO;
    this.sTxtEXAMNAME = study.EXAM_NAME;
    this.sTxtTYPENAMEALIAS = study.TYPE_NAME_ALIAS;
    this.sDateORDERDT = new Date(study.ORDER_DT);
  }
}
