import { Component, OnInit } from '@angular/core';
import { Assignment, ReviewHistory, Study } from './models';
import { StudyService } from './services/study.service';
import { LoadingComponent } from './loading.component';
import { SelectItem } from 'primeng/primeng';

@Component({
  templateUrl: './reviewhistory.template.html',
  selector: 'review-history'
})

export class ReviewHistoryComponent implements OnInit {
  public assignDate: SelectItem[];
  public fromDate: string;
  public toDate: string;
  public reviewHistory: ReviewHistory[];
  public selectedHistory: ReviewHistory;
  public displayHistory: boolean;
  public subID: number;
  public empID: number;
  public radName: string;
  public study: Study;
  public studies: Study[];

  constructor(public studyService: StudyService) {

  }

  public ngOnInit() {
    this.studyService.getAllAssignmentsDate(1).subscribe((resAssign) => {
      if (resAssign === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        let obj: Assignment[] = resAssign;
        this.assignDate = [];
        obj.forEach((forAss) => {
          this.assignDate.push({ label: forAss.ASSIGNMENT_DATE, value: '' + forAss.ASSIGNMENT_DATE });
        });

        if (obj.length > 0) {
          this.fromDate = obj[0].ASSIGNMENT_DATE;
          this.toDate = obj[0].ASSIGNMENT_DATE;

          this.studyService.getAllReviewHistory(2, this.fromDate, this.toDate).subscribe(
            (resReview) => {
              if (resReview === null) {
                return;
              } else {
                this.reviewHistory = resReview;
              }
            });
        }
      }
    });
  }

  public getReviewHistory() {
    this.studyService.getAllReviewHistory(2, this.fromDate, this.toDate).subscribe((res: ReviewHistory[]) => {
      if (res === null) {
        console.log('NOTHING FROM WEB API...');
        return;
      } else {
        console.log('result ws');
        this.reviewHistory = res;
      }

    });
  }

  public onRowSelect(event) {
    this.subID = this.selectedHistory.SUB_SPECIALTY_ID;
    this.empID = this.selectedHistory.EMP_ID;
    this.radName = '' + this.selectedHistory.RAD_NAME;
  }

  public onRowDoubleClick(event) {

    this.studyService.getAllReviewHistoryDtl(3, this.fromDate, this.toDate, this.subID, this.empID).subscribe(
      (res: Study[]) => {
        if (res === null) {
          console.log('NOTHING FROM WEB API...');
          return;
        } else {
          console.log('result ws');
          this.studies = res;
          this.displayHistory = true;
        }

      });

  }

  public cloneHistory(c: ReviewHistory): ReviewHistory {
    let history = this.selectedHistory;
    history = c;
    return history;
  }
}
