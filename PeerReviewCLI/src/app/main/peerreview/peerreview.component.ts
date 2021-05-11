import { Component, OnInit, OnDestroy } from '@angular/core';
import { Study, Score, PeerStatus, PeerGblEnv, PeerReview } from './models';
import { ConfirmationService } from 'primeng/api';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { StudyService } from './services/study.service';

declare var jQuery: any;
@Component({
  selector: 'app-main-peerreview',
  templateUrl: './peerreview.component.html',
  styleUrls: ['./peerreview.component.scss']
})
export class PeerreviewComponent implements OnInit, OnDestroy {
  public isLoading = true;
  public lblLoadingText: any;

  public selectedTab = 0;
  public reportTab = 'Write Review';
  public finalizeReport: string;
  public myReport: string;
  public myComment: string;
  public noOfStudies: string;
  public noOfReviewed: string;
  public noOfReviewing: string;
  public scoreValue: string;
  public ifFinal: boolean;
  public displayDialog: boolean;
  public displayScoring: boolean;
  public study: Study;
  public selectedStudy: Study;
  public newStudy: boolean;
  public studies: Study[];
  public scores: Score[];
  public msgs: any;
  public dblclick: boolean;
  public prStatus: PeerStatus[];
  public selectedFilter: string;
  public filterText: string;
  public tabDisable = true;
  public skipHide = true;
  public gblEnv: PeerGblEnv[] = [];
  public comment: string;
  public hideComment: boolean;

  public sTxtHN: string;
  public sTxtPATIENTNAME: string;
  public sTxtACCESSIONNO: string;
  public sTxtEXAMNAME: string;
  public sTxtTYPENAMEALIAS: string;
  public sDateORDERDT: Date;

  private queryParam: any;

  constructor(
    private routerService: Router,
    public studyService: StudyService,
    private activatedRoute: ActivatedRoute) {
  }

  public ngOnInit() {
    this.isLoading = true;
    this.lblLoadingText = 'Loading Data...';
    this.gblEnv = [];
    this.filterText = 'Pending';
    this.selectedFilter = 'Pending';
    this.prStatus = [];
    this.prStatus.push({ label: 'All', value: '' });
    this.prStatus.push({ label: 'Reviewed', value: 'Reviewed' });
    this.prStatus.push({ label: 'Pending', value: 'Pending' });
    this.queryParam = this.activatedRoute.queryParams.subscribe((params: Params) => {
      const env: PeerGblEnv = {
        USER_ID: params['userId'],
        USER_NAME: params['userName'],
        ORG_ID: params['orgId']
      };
      this.gblEnv.push(env);
      const unEnv = this.studyService.getGblEnv(this.gblEnv[0].ORG_ID).subscribe(
        (resEnv: PeerGblEnv[]) => {
          if (!resEnv) {
            console.log('NOTHING FROM WEB API...');
            return;
          } else {
            this.gblEnv[0].ORG_NAME = resEnv[0].ORG_NAME;
            this.gblEnv[0].PACS_URL1 = resEnv[0].PACS_URL1;
          }
          this.getStudiesData();
          if (unEnv) {
            unEnv.unsubscribe();
          }
        });
      if (this.queryParam) {
        this.queryParam.unsubscribe();
      }
    });
  }
  public showDialogToAdd() {
    this.newStudy = true;
    this.displayDialog = true;
  }

  public delete() {
    this.studies.splice(this.findSelectedStudyIndex(), 1);
    this.study = null;
    this.displayDialog = false;
  }

  public onRowSelect(event) {
    this.newStudy = false;
    this.study = this.cloneStudy(event.data);
    this.comment = this.selectedStudy.COMMENT;

    if (this.selectedStudy.IS_COMMENTED === 'Yes') {
      this.hideComment = true;
    } else {
      this.hideComment = false;
    }
  }

  public cloneStudy(c: Study): Study {
    let study: Study;
    study = c;
    return study;
  }
  public selectStudy(study: Study) {
    this.newStudy = false;
    this.study = study;
    this.routerService.navigate(['./scoring/'
      + study.ASSIGNMENT_ID
      + '/' + this.gblEnv[0].USER_ID
      + '/' + this.gblEnv[0].USER_NAME
      + '/' + this.gblEnv[0].ORG_ID
    ]);
    this.dblclick = false;
  }

  public clearTabSelection() {
    this.msgs = [];
    this.selectedTab = 0;
  }

  public findSelectedStudyIndex(): number {
    return this.studies.indexOf(this.selectedStudy);
  }

  public onChangeStatus(event) {
    this.getStudiesData();
  }

  public ngOnDestroy() {
    this.queryParam.unsubscribe();
  }

  private getStudiesData() {
    this.studies = [];
    const unsub = this.studyService.getStudy(this.gblEnv[0].USER_ID).subscribe((res: Study[]) => {
      if (res) {
        const len: number = res.length;
        let count = 0;
        this.noOfStudies = '' + len;
        res.forEach((forStudy) => {
          if (forStudy.STATUS === 'Pending') {
            count++;
          }
        });
        this.noOfReviewing = '' + count;
        this.noOfReviewed = '' + (len - count);
        if (this.selectedFilter === '') {
          this.studies = res;
        } else {
          this.studies = res.filter((f) => f.STATUS === this.selectedFilter);
        }
        if (this.studies.length > 0) {
          this.study = this.studies[0];
          this.sTxtHN = this.study.HN;
          this.sTxtPATIENTNAME = this.study.PATIENT_NAME;
          this.sTxtACCESSIONNO = this.study.ACCESSION_NO;
          this.sTxtEXAMNAME = this.study.EXAM_NAME;
          this.sTxtTYPENAMEALIAS = this.study.TYPE_NAME_ALIAS;
          this.sDateORDERDT = new Date(this.study.ORDER_DT);
        }
      }
      this.isLoading = false;
      if (unsub) {
        unsub.unsubscribe();
      }
    });
  }
}
