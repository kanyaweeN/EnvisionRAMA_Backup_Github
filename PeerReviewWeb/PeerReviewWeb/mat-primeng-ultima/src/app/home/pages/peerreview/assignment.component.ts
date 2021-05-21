import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subspecialty, SubspecialtyLookup, Radiologist, Study, Algorithm, PeerGblEnv } from './models';
import { StudyService } from './services/study.service';
import { LoadingComponent } from './loading.component';
import { ConfirmationService } from 'primeng/primeng';

@Component({
  templateUrl: './assignment.template.html',
  selector: 'peer-assignment'
})

export class AssignmentComponent implements OnInit, OnDestroy {
  public fromDate: Date;
  public toDate: Date;
  public msgs: any;
  public subspecialty: SubspecialtyLookup[];
  public selectedSub: string;
  public selectedSubId: number;
  public radiologists: Radiologist[];
  public radiologistsCount: Radiologist[];
  public selectedradiologist: Radiologist;
  public studies: Study[];
  public selectedstudy: Study;
  public study: Study;
  public radname: string;
  public working: boolean;
  public displayAllRadiologist: boolean;
  public btnAutoStart: string;
  public algorithmID: number;
  public valPer: number;
  public valMax: number;
  public gblEnv: PeerGblEnv;

  constructor(public studyService: StudyService, private confirmationService: ConfirmationService, private activatedRoute: ActivatedRoute) {
  }

  public ngOnInit() {
    this.fromDate = new Date();
    this.toDate = new Date();
    this.btnAutoStart = 'Start Auto Assign';

    this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.gblEnv.USER_ID = params['userId'];
      this.gblEnv.USER_NAME = params['userName'];
      this.gblEnv.ORG_ID = params['orgId'];
    });

    this.studyService.getAllSubspecialty(1).subscribe((res: Subspecialty[]) => {
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        let obj: Subspecialty[] = res;
        this.subspecialty = [];
        for (let i = 0; obj.length > i; i++) {
          this.subspecialty.push({ id: obj[i].SUB_SPECIALTY_ID, label: obj[i].SUB_SPECIALTY_NAME, value: '' + obj[i].SUB_SPECIALTY_NAME });
        }
      }
    });

    this.studyService.getAlgorithm().subscribe((res: Algorithm[]) => {
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        let obj: Algorithm[] = res;
        for (let i = 0; obj.length > i; i++) {
          this.algorithmID = obj[i].PR_ALGORITHM_ID;
          this.valPer = obj[i].PERCENTAGE_PER_RAD;
          this.valMax = obj[i].MAX_ASSIGNMENT_PER_RAD;
        }
      }
    });
  }

  public startAutoAssign() {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to perform auto assignment action?',
      accept: () => {
        let param = 1;
        let confirmMsg = 'Temporarily assgined studies among radiologists';
        if (this.btnAutoStart === 'Confirm') {
          param = 2;
          confirmMsg = 'Permanently distributed studies among radiologists!';
        }
        this.working = true;
        this.studyService.automaticAssignment(param, this.fromDate.toDateString(), this.toDate.toDateString(), this.gblEnv.USER_ID).subscribe((res) => {
          if (res === null) {
            this.msgs = [];
            this.msgs.push({ severity: 'error', summary: 'Error :', detail: 'Failed to assign!' });
            return;
          } else {
            this.msgs = [];
            this.msgs.push({ severity: 'success', summary: 'Success :', detail: confirmMsg });
            this.working = false;
            if (this.btnAutoStart === 'Confirm')
              this.btnAutoStart = 'Start Auto Assign';
            else
              this.btnAutoStart = 'Confirm';
          }
        });
      }
    });
  }

  public deleteAutoAssign() {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to delete recent assignments?',
      accept: () => {
        this.working = true;
        this.studyService.automaticAssignment(3, this.fromDate.toDateString(), this.toDate.toDateString(), this.gblEnv.USER_ID).subscribe((res) => {
          if (res === null) {
            this.msgs = [];
            this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to delete!' });
            return;
          } else {
            this.msgs = [];
            this.msgs.push({ severity: 'warn', summary: 'Successfully', detail: 'Deleted Your Recent Assignments!' });
            this.working = false;
            this.btnAutoStart = 'Start Auto Assign';
          }
        });
      }
    });
  }

  public onChangeSub(event) {
    for (let i = 0; this.subspecialty.length > i; i++) {
      if (this.subspecialty[i].value === this.selectedSub) {
        this.selectedSubId = this.subspecialty[i].id;
        this.studies = [];
        this.radname = '';
        this.studyService.getAllRadiologist(2, this.subspecialty[i].id).subscribe((res) => {
          if (res === null) {
            console.log('NOTHING FROM WEB API...');
            return;
          } else {
            this.radiologists = res;
          }
        });
      }
    }
  }

  public onRowSelect(event) {
    this.studyService.getAllRadAssignments(3, this.selectedradiologist.EMP_ID, this.selectedSubId).subscribe((res) => {
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        this.studies = res;
        this.radname = this.selectedradiologist.RAD_NAME;
      }
    });
  }

  public allRadiologists() {
    this.working = true;
    this.studyService.getAllRadAssignmentsCount(4).subscribe((res) => {
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        this.radiologistsCount = res;
        this.working = false;
        this.displayAllRadiologist = true;
      }
    });
  }

  public changeAlgorithm() {
    this.studyService.saveChangesAlgorithm(this.algorithmID, this.valPer, this.valMax).subscribe((res) => {
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        this.msgs = [];
        this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Updated Algorithms!' });
      }
    });
  }

  public ngOnDestroy() {
    console.log('destroy');
  }
}
