import { Injectable } from '@angular/core';
import { PeerReview } from '../models';
import { ApiService } from 'src/app/services/api.service';

@Injectable()
export class StudyService {

    constructor(private api: ApiService) { }

    public getGblEnv(orgId: number) {
        return this.api.GET('peerreview/gblenv/' + orgId);
    }

    public getStudy(myId: number) {
        return this.api.GET('peerreview/' + myId);
    }

    public getScore(assignID: string) {
        return this.api.GET('peerreview/score/' + assignID);
    }

    public insertPeerReviewReport(prReview: PeerReview) {
        return this.api.POST('peerreview/report', prReview);
    }

    public insertPeerReviewScore(prReview: PeerReview) {
        return this.api.POST('peerreview/score', prReview);
    }

    public automaticAssignment(actionType: number, fromDt: string, toDt: string, createdBy: number) {
        const param = { ACTION_TYPE: actionType, FROM_DT: fromDt, TO_DATE: toDt, CREATED_BY: createdBy };
        return this.api.POST('peerstudy/autoassign', param);
    }

    public getAllSubspecialty(actionType: number) {
        return this.api.GET('peerstudy/' + actionType);
    }

    public getAllRadiologist(actionType: number, subspecialtyId: number) {
        return this.api.GET('peerstudy/radiologist/' + actionType + '/' + subspecialtyId);
    }

    public getAllRadAssignments(actionType: number, empId: number, subId: number) {
        return this.api.GET('peerstudy/radassignment/' + actionType + '/' + empId + '/' + subId);
    }

    public getAllRadAssignmentsCount(actionType: number) {
        return this.api.GET('peerstudy/studycount/' + actionType);
    }

    public getAllAssignmentsDate(actionType: number) {
        return this.api.GET('peerstudy/assignmentdate/' + actionType);
    }

    public getAllReviewHistory(actionType: number, formdate: string, todate: string) {
        const param = { ACTION_TYPE: actionType, FROM_DATE: formdate, TO_DATE: todate };
        return this.api.POST('peerstudy/reviewhistory', param);
    }

    public getAllReviewHistoryDtl(actionType: number, formdate: string, todate: string, subid: number, empid: number) {
        const param = { ACTION_TYPE: actionType, FROM_DATE: formdate, TO_DATE: todate, SUB_ID: subid, EMP_ID: empid };
        return this.api.POST('peerstudy/reviewhistorydtl', param);
    }

    public getAlgorithm() {
        return this.api.GET('peerstudy/peeralgorithm/');
    }

    public saveChangesAlgorithm(algorithmID: number, valPer: number, valMax: number) {
        const param = { ALGORITHM_ID: algorithmID, VAL_PER: valPer, VAL_MAX: valMax };
        return this.api.POST('peerstudy/changesalgorithm', param);
    }
}
