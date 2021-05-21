import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Study, Score, PeerReview, PeerStatus, PeerGblEnv } from './models';
import { StudyService } from './services/study.service';
import { ConfirmationService } from 'primeng/primeng';

@Component({
    templateUrl: './peerreview.template.html',
    selector: 'peer-worklist'
})

export class PeerReviewComponent implements OnInit, OnDestroy {
    public selectedTab = 0;
    public reportTab: string = 'Write Review';
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
    public tabDisable: boolean = true;
    public skipHide: boolean = true;
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
        public studyService: StudyService,
        private confirmationService: ConfirmationService,
        private activatedRoute: ActivatedRoute) {
    }

    public ngOnInit() {
        this.gblEnv = [];
        this.filterText = 'Pending';
        this.selectedFilter = 'Pending';
        this.prStatus = [];
        this.prStatus.push({ label: 'All', value: '' });
        this.prStatus.push({ label: 'Reviewed', value: 'Reviewed' });
        this.prStatus.push({ label: 'Pending', value: 'Pending' });
        this.queryParam = this.activatedRoute.queryParams.subscribe((params: Params) => {
            let env: PeerGblEnv = {
                USER_ID: params['userId'],
                USER_NAME: params['userName'],
                ORG_ID: params['orgId']
            };
            this.gblEnv.push(env);
            let unEnv = this.studyService.getGblEnv(this.gblEnv[0].ORG_ID).subscribe(
                (resEnv: PeerGblEnv[]) => {
                    if (!resEnv) {
                        console.log('NOTHING FROM WEB API...');
                        return;
                    } else {
                        this.gblEnv[0].ORG_NAME = resEnv[0].ORG_NAME;
                        this.gblEnv[0].PACS_URL1 = resEnv[0].PACS_URL1;
                    }
                    let unStudy = this.studyService.getStudy(this.gblEnv[0].USER_ID).subscribe(
                        (resStudy) => {
                            if (!resStudy) {
                                console.log('NOTHING FROM WEB API...');
                                return;
                            } else {
                                this.studies = resStudy;
                                this.study = resStudy[0];
                                this.sTxtHN = this.study.HN;
                                this.sTxtPATIENTNAME = this.study.PATIENT_NAME;
                                this.sTxtACCESSIONNO = this.study.ACCESSION_NO;
                                this.sTxtEXAMNAME = this.study.EXAM_NAME;
                                this.sTxtTYPENAMEALIAS = this.study.TYPE_NAME_ALIAS;
                                this.sDateORDERDT = new Date(this.study.ORDER_DT);
                                let len: number = this.studies.length;
                                let count: number = 0;
                                this.noOfStudies = '' + len;
                                for (let i = 0; len > i; i++) {
                                    if (resStudy[i].STATUS === 'Pending') {
                                        count++;
                                    }
                                }
                                this.noOfReviewing = '' + count;
                                this.noOfReviewed = '' + (len - count);
                            }
                            if (unStudy) {
                                unStudy.unsubscribe();
                            }
                        });
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
        // this.study;
        this.displayDialog = true;
    }

    public save() {
        if (this.newStudy)
            this.studies.push(this.study);
        else
            this.study[this.findSelectedStudyIndex()] = this.study;
        this.study = null;
        this.displayDialog = false;
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

        if (this.selectedStudy.IS_COMMENTED === 'Yes')
            this.hideComment = true;
        else
            this.hideComment = false;
    }

    public onRowDoubleClick(event) {
        this.dblclick = true;
        this.selectScore(this.study.ASSIGNMENT_ID);
    }

    public cloneStudy(c: Study): Study {
        let study: Study;
        study = c;
        return study;
    }
    public selectStudy(study: Study) {
        this.newStudy = false;
        this.study = study;
        this.selectScore(study.ASSIGNMENT_ID);
        this.dblclick = false;
    }

    public selectScore(assignID: string) {
        this.studyService.getScore(assignID).subscribe((res) => {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            } else {
                this.myReport = '';
                this.finalizeReport = '';
                this.displayScoring = true;
                this.clearTabSelection();
                let leftwin: number = window.screenX + 200;
                let trackWindo = window.open('http://ramapacs%5Cpeerreview:1234@synapse:80/explore.asp?path=/All%20Studies./AccessionNumber=' + this.study.ACCESSION_NO, 'pacsurl', 'location=0, left=' + leftwin);
                trackWindo.focus();
                let obj: Score[] = res;
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

            }
        });
    }

    public saveAsDraft(assignID: string) {
        if (this.myReport != null) {
            let prReview = new PeerReview();
            prReview.ACTION_TYPE = 1;
            prReview.ASSIGNMENT_ID = assignID;
            prReview.CREATED_BY = this.gblEnv[0].USER_ID;
            prReview.REPORT_STATUS = 'D';
            prReview.REPORT_TEXT_HTML = this.myReport;

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
            let prReview = new PeerReview();
            prReview.ACTION_TYPE = 1;
            prReview.ASSIGNMENT_ID = assignID;
            prReview.CREATED_BY = this.gblEnv[0].USER_ID;
            prReview.REPORT_STATUS = 'F';
            prReview.REPORT_TEXT_HTML = this.myReport;

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
            let prReview = new PeerReview();
            prReview.ACTION_TYPE = 2;
            prReview.ASSIGNMENT_ID = assignID;
            prReview.CREATED_BY = this.gblEnv[0].USER_ID;
            prReview.REVIEW_SCORE = this.scoreValue;
            prReview.COMMENT = this.myComment;
            this.studyService.insertPeerReviewScore(prReview).subscribe((res) => {
                if (res === null) {
                    this.msgs = [];
                    this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
                    return;
                } else {
                    this.msgs = [];
                    this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Score' });
                    this.study.REVIEW_SCORE = this.scoreValue;
                    this.study.STATUS = 'Reviewed';
                    this.studies[this.findSelectedStudyIndex()] = this.study;
                    let len: number = this.studies.length;
                    let count: number = 0;
                    this.noOfStudies = '' + len;
                    for (let i = 0; len > i; i++) {
                        if (this.studies[i].STATUS === 'Pending') {
                            count++;
                        }
                    }
                    this.noOfReviewing = '' + count;
                    this.noOfReviewed = '' + (len - count);
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

    public clearTabSelection() {
        this.msgs = [];
        this.selectedTab = 0;
    }

    public changeTab(index: number) {
        this.selectedTab = index;
    }

    public findSelectedStudyIndex(): number {
        return this.studies.indexOf(this.selectedStudy);
    }

    public onChangeStatus(event) {
        if (this.selectedFilter === 'Pending') {
            this.filterText = 'Pending';
        } else {
            this.filterText = this.selectedFilter;
        }
        this.studies = [];
        this.studyService.getStudy(this.gblEnv[0].USER_ID).subscribe((res: Study[]) => {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            } else {
                let obj: Study[] = res;
                this.studies = obj;
                let len: number = this.studies.length;
                let count: number = 0;
                this.noOfStudies = '' + len;
                for (let i = 0; len > i; i++) {
                    if (obj[i].STATUS === 'Pending') {
                        count++;
                    }
                }
                this.noOfReviewing = '' + count;
                this.noOfReviewed = '' + (len - count);
            }
        });
    }

    public skipToFinalReport() {
        this.tabDisable = false;
        this.selectedTab = 1;
        this.skipHide = false;
    }

    public ngOnDestroy() {
        this.queryParam.unsubscribe();
    }
}
