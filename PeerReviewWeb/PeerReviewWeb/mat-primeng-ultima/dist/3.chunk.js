webpackJsonpac__name_([3],{

/***/ 460:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__(24);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__(491);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__services_api_service__ = __webpack_require__(23);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return StudyService; });





var StudyService = (function () {
    function StudyService(http, api) {
        this.http = http;
        this.api = api;
    }
    StudyService.prototype.getGblEnv = function (orgId) {
        return this.api.GET('peerreview/gblenv/' + orgId);
    };
    StudyService.prototype.getStudy = function (myId) {
        return this.api.GET('peerreview/' + myId);
    };
    StudyService.prototype.getScore = function (assignID) {
        return this.api.GET('peerreview/score/' + assignID);
    };
    StudyService.prototype.insertPeerReviewReport = function (prReview) {
        return this.api.POST('peerreview/report', prReview);
    };
    StudyService.prototype.insertPeerReviewScore = function (prReview) {
        return this.api.POST('peerreview/score', prReview);
    };
    StudyService.prototype.automaticAssignment = function (actionType, fromDt, toDt, createdBy) {
        var param = { ACTION_TYPE: actionType, FROM_DT: fromDt, TO_DATE: toDt, CREATED_BY: createdBy };
        return this.api.POST('peerstudy/autoassign', param);
    };
    StudyService.prototype.getAllSubspecialty = function (actionType) {
        return this.api.GET('peerstudy/' + actionType);
    };
    StudyService.prototype.getAllRadiologist = function (actionType, subspecialtyId) {
        return this.api.GET('peerstudy/radiologist/' + actionType + '/' + subspecialtyId);
    };
    StudyService.prototype.getAllRadAssignments = function (actionType, empId, subId) {
        return this.api.GET('peerstudy/radassignment/' + actionType + '/' + empId + '/' + subId);
    };
    StudyService.prototype.getAllRadAssignmentsCount = function (actionType) {
        return this.api.GET('peerstudy/studycount/' + actionType);
    };
    StudyService.prototype.getAllAssignmentsDate = function (actionType) {
        return this.api.GET('peerstudy/assignmentdate/' + actionType);
    };
    StudyService.prototype.getAllReviewHistory = function (actionType, formdate, todate) {
        var param = { ACTION_TYPE: actionType, FROM_DATE: formdate, TO_DATE: todate };
        return this.api.POST('peerstudy/reviewhistory', param);
    };
    StudyService.prototype.getAllReviewHistoryDtl = function (actionType, formdate, todate, subid, empid) {
        var param = { ACTION_TYPE: actionType, FROM_DATE: formdate, TO_DATE: todate, SUB_ID: subid, EMP_ID: empid };
        return this.api.POST('peerstudy/reviewhistorydtl', param);
    };
    StudyService.prototype.getAlgorithm = function () {
        return this.api.GET('peerstudy/peeralgorithm/');
    };
    StudyService.prototype.saveChangesAlgorithm = function (algorithmID, valPer, valMax) {
        var param = { ALGORITHM_ID: algorithmID, VAL_PER: valPer, VAL_MAX: valMax };
        return this.api.POST('peerstudy/changesalgorithm', param);
    };
    return StudyService;
}());
StudyService = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Injectable"])(),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_http__["Http"], __WEBPACK_IMPORTED_MODULE_4__services_api_service__["a" /* ApiService */]])
], StudyService);



/***/ }),

/***/ 462:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_core__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__services_study_service__ = __webpack_require__(460);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_primeng_primeng__ = __webpack_require__(187);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_primeng_primeng___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4_primeng_primeng__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AssignmentComponent; });





var AssignmentComponent = (function () {
    function AssignmentComponent(studyService, confirmationService, activatedRoute) {
        this.studyService = studyService;
        this.confirmationService = confirmationService;
        this.activatedRoute = activatedRoute;
    }
    AssignmentComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.fromDate = new Date();
        this.toDate = new Date();
        this.btnAutoStart = 'Start Auto Assign';
        this.activatedRoute.queryParams.subscribe(function (params) {
            _this.gblEnv.USER_ID = params['userId'];
            _this.gblEnv.USER_NAME = params['userName'];
            _this.gblEnv.ORG_ID = params['orgId'];
        });
        this.studyService.getAllSubspecialty(1).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                var obj = res;
                _this.subspecialty = [];
                for (var i = 0; obj.length > i; i++) {
                    _this.subspecialty.push({ id: obj[i].SUB_SPECIALTY_ID, label: obj[i].SUB_SPECIALTY_NAME, value: '' + obj[i].SUB_SPECIALTY_NAME });
                }
            }
        });
        this.studyService.getAlgorithm().subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                var obj = res;
                for (var i = 0; obj.length > i; i++) {
                    _this.algorithmID = obj[i].PR_ALGORITHM_ID;
                    _this.valPer = obj[i].PERCENTAGE_PER_RAD;
                    _this.valMax = obj[i].MAX_ASSIGNMENT_PER_RAD;
                }
            }
        });
    };
    AssignmentComponent.prototype.startAutoAssign = function () {
        var _this = this;
        this.confirmationService.confirm({
            message: 'Are you sure that you want to perform auto assignment action?',
            accept: function () {
                var param = 1;
                var confirmMsg = 'Temporarily assgined studies among radiologists';
                if (_this.btnAutoStart === 'Confirm') {
                    param = 2;
                    confirmMsg = 'Permanently distributed studies among radiologists!';
                }
                _this.working = true;
                _this.studyService.automaticAssignment(param, _this.fromDate.toDateString(), _this.toDate.toDateString(), _this.gblEnv.USER_ID).subscribe(function (res) {
                    if (res === null) {
                        _this.msgs = [];
                        _this.msgs.push({ severity: 'error', summary: 'Error :', detail: 'Failed to assign!' });
                        return;
                    }
                    else {
                        _this.msgs = [];
                        _this.msgs.push({ severity: 'success', summary: 'Success :', detail: confirmMsg });
                        _this.working = false;
                        if (_this.btnAutoStart === 'Confirm')
                            _this.btnAutoStart = 'Start Auto Assign';
                        else
                            _this.btnAutoStart = 'Confirm';
                    }
                });
            }
        });
    };
    AssignmentComponent.prototype.deleteAutoAssign = function () {
        var _this = this;
        this.confirmationService.confirm({
            message: 'Are you sure that you want to delete recent assignments?',
            accept: function () {
                _this.working = true;
                _this.studyService.automaticAssignment(3, _this.fromDate.toDateString(), _this.toDate.toDateString(), _this.gblEnv.USER_ID).subscribe(function (res) {
                    if (res === null) {
                        _this.msgs = [];
                        _this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to delete!' });
                        return;
                    }
                    else {
                        _this.msgs = [];
                        _this.msgs.push({ severity: 'warn', summary: 'Successfully', detail: 'Deleted Your Recent Assignments!' });
                        _this.working = false;
                        _this.btnAutoStart = 'Start Auto Assign';
                    }
                });
            }
        });
    };
    AssignmentComponent.prototype.onChangeSub = function (event) {
        var _this = this;
        for (var i = 0; this.subspecialty.length > i; i++) {
            if (this.subspecialty[i].value === this.selectedSub) {
                this.selectedSubId = this.subspecialty[i].id;
                this.studies = [];
                this.radname = '';
                this.studyService.getAllRadiologist(2, this.subspecialty[i].id).subscribe(function (res) {
                    if (res === null) {
                        console.log('NOTHING FROM WEB API...');
                        return;
                    }
                    else {
                        _this.radiologists = res;
                    }
                });
            }
        }
    };
    AssignmentComponent.prototype.onRowSelect = function (event) {
        var _this = this;
        this.studyService.getAllRadAssignments(3, this.selectedradiologist.EMP_ID, this.selectedSubId).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                _this.studies = res;
                _this.radname = _this.selectedradiologist.RAD_NAME;
            }
        });
    };
    AssignmentComponent.prototype.allRadiologists = function () {
        var _this = this;
        this.working = true;
        this.studyService.getAllRadAssignmentsCount(4).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                _this.radiologistsCount = res;
                _this.working = false;
                _this.displayAllRadiologist = true;
            }
        });
    };
    AssignmentComponent.prototype.changeAlgorithm = function () {
        var _this = this;
        this.studyService.saveChangesAlgorithm(this.algorithmID, this.valPer, this.valMax).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                _this.msgs = [];
                _this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Updated Algorithms!' });
            }
        });
    };
    AssignmentComponent.prototype.ngOnDestroy = function () {
        console.log('destroy');
    };
    return AssignmentComponent;
}());
AssignmentComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2__angular_core__["Component"])({
        template: __webpack_require__(488),
        selector: 'peer-assignment'
    }),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__services_study_service__["a" /* StudyService */], __WEBPACK_IMPORTED_MODULE_4_primeng_primeng__["ConfirmationService"], __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"]])
], AssignmentComponent);



/***/ }),

/***/ 463:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_core__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__models__ = __webpack_require__(473);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__services_study_service__ = __webpack_require__(460);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_primeng_primeng__ = __webpack_require__(187);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_primeng_primeng___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5_primeng_primeng__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PeerReviewComponent; });






var PeerReviewComponent = (function () {
    function PeerReviewComponent(studyService, confirmationService, activatedRoute) {
        this.studyService = studyService;
        this.confirmationService = confirmationService;
        this.activatedRoute = activatedRoute;
        this.selectedTab = 0;
        this.reportTab = 'Write Review';
        this.tabDisable = true;
        this.skipHide = true;
        this.gblEnv = [];
    }
    PeerReviewComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.gblEnv = [];
        this.filterText = 'Pending';
        this.selectedFilter = 'Pending';
        this.prStatus = [];
        this.prStatus.push({ label: 'All', value: '' });
        this.prStatus.push({ label: 'Reviewed', value: 'Reviewed' });
        this.prStatus.push({ label: 'Pending', value: 'Pending' });
        this.queryParam = this.activatedRoute.queryParams.subscribe(function (params) {
            var env = {
                USER_ID: params['userId'],
                USER_NAME: params['userName'],
                ORG_ID: params['orgId']
            };
            _this.gblEnv.push(env);
            var unEnv = _this.studyService.getGblEnv(_this.gblEnv[0].ORG_ID).subscribe(function (resEnv) {
                if (!resEnv) {
                    console.log('NOTHING FROM WEB API...');
                    return;
                }
                else {
                    _this.gblEnv[0].ORG_NAME = resEnv[0].ORG_NAME;
                    _this.gblEnv[0].PACS_URL1 = resEnv[0].PACS_URL1;
                }
                var unStudy = _this.studyService.getStudy(_this.gblEnv[0].USER_ID).subscribe(function (resStudy) {
                    if (!resStudy) {
                        console.log('NOTHING FROM WEB API...');
                        return;
                    }
                    else {
                        _this.studies = resStudy;
                        _this.study = resStudy[0];
                        _this.sTxtHN = _this.study.HN;
                        _this.sTxtPATIENTNAME = _this.study.PATIENT_NAME;
                        _this.sTxtACCESSIONNO = _this.study.ACCESSION_NO;
                        _this.sTxtEXAMNAME = _this.study.EXAM_NAME;
                        _this.sTxtTYPENAMEALIAS = _this.study.TYPE_NAME_ALIAS;
                        _this.sDateORDERDT = new Date(_this.study.ORDER_DT);
                        var len = _this.studies.length;
                        var count = 0;
                        _this.noOfStudies = '' + len;
                        for (var i = 0; len > i; i++) {
                            if (resStudy[i].STATUS === 'Pending') {
                                count++;
                            }
                        }
                        _this.noOfReviewing = '' + count;
                        _this.noOfReviewed = '' + (len - count);
                    }
                    if (unStudy) {
                        unStudy.unsubscribe();
                    }
                });
                if (unEnv) {
                    unEnv.unsubscribe();
                }
            });
            if (_this.queryParam) {
                _this.queryParam.unsubscribe();
            }
        });
    };
    PeerReviewComponent.prototype.showDialogToAdd = function () {
        this.newStudy = true;
        // this.study;
        this.displayDialog = true;
    };
    PeerReviewComponent.prototype.save = function () {
        if (this.newStudy)
            this.studies.push(this.study);
        else
            this.study[this.findSelectedStudyIndex()] = this.study;
        this.study = null;
        this.displayDialog = false;
    };
    PeerReviewComponent.prototype.delete = function () {
        this.studies.splice(this.findSelectedStudyIndex(), 1);
        this.study = null;
        this.displayDialog = false;
    };
    PeerReviewComponent.prototype.onRowSelect = function (event) {
        this.newStudy = false;
        this.study = this.cloneStudy(event.data);
        this.comment = this.selectedStudy.COMMENT;
        if (this.selectedStudy.IS_COMMENTED === 'Yes')
            this.hideComment = true;
        else
            this.hideComment = false;
    };
    PeerReviewComponent.prototype.onRowDoubleClick = function (event) {
        this.dblclick = true;
        this.selectScore(this.study.ASSIGNMENT_ID);
    };
    PeerReviewComponent.prototype.cloneStudy = function (c) {
        var study;
        study = c;
        return study;
    };
    PeerReviewComponent.prototype.selectStudy = function (study) {
        this.newStudy = false;
        this.study = study;
        this.selectScore(study.ASSIGNMENT_ID);
        this.dblclick = false;
    };
    PeerReviewComponent.prototype.selectScore = function (assignID) {
        var _this = this;
        this.studyService.getScore(assignID).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                _this.myReport = '';
                _this.finalizeReport = '';
                _this.displayScoring = true;
                _this.clearTabSelection();
                var leftwin = window.screenX + 200;
                var trackWindo = window.open('http://ramapacs%5Cpeerreview:1234@synapse:80/explore.asp?path=/All%20Studies./AccessionNumber=' + _this.study.ACCESSION_NO, 'pacsurl', 'location=0, left=' + leftwin);
                trackWindo.focus();
                var obj = res;
                _this.scores = obj;
                _this.finalizeReport = obj[0].RESULT_TEXT_HTML;
                _this.myReport = obj[0].REPORT_TEXT_HTML;
                _this.scoreValue = obj[0].REVIEW_SCORE;
                _this.myComment = obj[0].COMMENT;
                if (obj[0].REPORT_STATUS === 'F') {
                    _this.ifFinal = true;
                }
                else {
                    _this.ifFinal = false;
                }
                if (_this.myReport != null) {
                    _this.reportTab = 'My Review';
                }
                else {
                    _this.reportTab = 'Write Review';
                }
                if (_this.myReport != null) {
                    _this.tabDisable = false;
                    _this.skipHide = false;
                }
                else {
                    _this.tabDisable = true;
                    _this.skipHide = true;
                }
            }
        });
    };
    PeerReviewComponent.prototype.saveAsDraft = function (assignID) {
        var _this = this;
        if (this.myReport != null) {
            var prReview = new __WEBPACK_IMPORTED_MODULE_3__models__["a" /* PeerReview */]();
            prReview.ACTION_TYPE = 1;
            prReview.ASSIGNMENT_ID = assignID;
            prReview.CREATED_BY = this.gblEnv[0].USER_ID;
            prReview.REPORT_STATUS = 'D';
            prReview.REPORT_TEXT_HTML = this.myReport;
            this.studyService.insertPeerReviewReport(prReview).subscribe(function (res) {
                if (res === null) {
                    _this.msgs = [];
                    _this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
                    return;
                }
                else {
                    _this.msgs = [];
                    _this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Draft' });
                    _this.tabDisable = false;
                    _this.skipHide = false;
                }
            });
        }
        else {
            this.confirmationService.confirm({
                message: 'Your review report is empty!',
                accept: function () {
                }
            });
        }
    };
    PeerReviewComponent.prototype.saveAsFinal = function (assignID) {
        var _this = this;
        if (this.myReport != null) {
            var prReview = new __WEBPACK_IMPORTED_MODULE_3__models__["a" /* PeerReview */]();
            prReview.ACTION_TYPE = 1;
            prReview.ASSIGNMENT_ID = assignID;
            prReview.CREATED_BY = this.gblEnv[0].USER_ID;
            prReview.REPORT_STATUS = 'F';
            prReview.REPORT_TEXT_HTML = this.myReport;
            this.studyService.insertPeerReviewReport(prReview).subscribe(function (res) {
                if (res === null) {
                    _this.msgs = [];
                    _this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
                    return;
                }
                else {
                    _this.msgs = [];
                    _this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Final Report' });
                    _this.tabDisable = false;
                    _this.skipHide = false;
                }
            });
        }
        else {
            this.confirmationService.confirm({
                message: 'Your review report is empty!',
                accept: function () {
                }
            });
        }
    };
    PeerReviewComponent.prototype.saveScore = function (assignID) {
        var _this = this;
        if (this.scoreValue != null) {
            var prReview = new __WEBPACK_IMPORTED_MODULE_3__models__["a" /* PeerReview */]();
            prReview.ACTION_TYPE = 2;
            prReview.ASSIGNMENT_ID = assignID;
            prReview.CREATED_BY = this.gblEnv[0].USER_ID;
            prReview.REVIEW_SCORE = this.scoreValue;
            prReview.COMMENT = this.myComment;
            this.studyService.insertPeerReviewScore(prReview).subscribe(function (res) {
                if (res === null) {
                    _this.msgs = [];
                    _this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Failed to save' });
                    return;
                }
                else {
                    _this.msgs = [];
                    _this.msgs.push({ severity: 'success', summary: 'Successfully', detail: 'Saved Your Score' });
                    _this.study.REVIEW_SCORE = _this.scoreValue;
                    _this.study.STATUS = 'Reviewed';
                    _this.studies[_this.findSelectedStudyIndex()] = _this.study;
                    var len = _this.studies.length;
                    var count = 0;
                    _this.noOfStudies = '' + len;
                    for (var i = 0; len > i; i++) {
                        if (_this.studies[i].STATUS === 'Pending') {
                            count++;
                        }
                    }
                    _this.noOfReviewing = '' + count;
                    _this.noOfReviewed = '' + (len - count);
                }
            });
        }
        else {
            this.confirmationService.confirm({
                message: 'Please select a score!',
                accept: function () {
                }
            });
        }
    };
    PeerReviewComponent.prototype.clearTabSelection = function () {
        this.msgs = [];
        this.selectedTab = 0;
    };
    PeerReviewComponent.prototype.changeTab = function (index) {
        this.selectedTab = index;
    };
    PeerReviewComponent.prototype.findSelectedStudyIndex = function () {
        return this.studies.indexOf(this.selectedStudy);
    };
    PeerReviewComponent.prototype.onChangeStatus = function (event) {
        var _this = this;
        if (this.selectedFilter === 'Pending') {
            this.filterText = 'Pending';
        }
        else {
            this.filterText = this.selectedFilter;
        }
        this.studies = [];
        this.studyService.getStudy(this.gblEnv[0].USER_ID).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                var obj = res;
                _this.studies = obj;
                var len = _this.studies.length;
                var count = 0;
                _this.noOfStudies = '' + len;
                for (var i = 0; len > i; i++) {
                    if (obj[i].STATUS === 'Pending') {
                        count++;
                    }
                }
                _this.noOfReviewing = '' + count;
                _this.noOfReviewed = '' + (len - count);
            }
        });
    };
    PeerReviewComponent.prototype.skipToFinalReport = function () {
        this.tabDisable = false;
        this.selectedTab = 1;
        this.skipHide = false;
    };
    PeerReviewComponent.prototype.ngOnDestroy = function () {
        this.queryParam.unsubscribe();
    };
    return PeerReviewComponent;
}());
PeerReviewComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2__angular_core__["Component"])({
        template: __webpack_require__(489),
        selector: 'peer-worklist'
    }),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_4__services_study_service__["a" /* StudyService */],
        __WEBPACK_IMPORTED_MODULE_5_primeng_primeng__["ConfirmationService"],
        __WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"]])
], PeerReviewComponent);



/***/ }),

/***/ 464:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_study_service__ = __webpack_require__(460);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ReviewHistoryComponent; });



var ReviewHistoryComponent = (function () {
    function ReviewHistoryComponent(studyService) {
        this.studyService = studyService;
    }
    ReviewHistoryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.studyService.getAllAssignmentsDate(1).subscribe(function (resAssign) {
            if (resAssign === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                var obj = resAssign;
                _this.assignDate = [];
                obj.forEach(function (forAss) {
                    _this.assignDate.push({ label: forAss.ASSIGNMENT_DATE, value: '' + forAss.ASSIGNMENT_DATE });
                });
                if (obj.length > 0) {
                    _this.fromDate = obj[0].ASSIGNMENT_DATE;
                    _this.toDate = obj[0].ASSIGNMENT_DATE;
                    _this.studyService.getAllReviewHistory(2, _this.fromDate, _this.toDate).subscribe(function (resReview) {
                        if (resReview === null) {
                            return;
                        }
                        else {
                            _this.reviewHistory = resReview;
                        }
                    });
                }
            }
        });
    };
    ReviewHistoryComponent.prototype.getReviewHistory = function () {
        var _this = this;
        this.studyService.getAllReviewHistory(2, this.fromDate, this.toDate).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                console.log('result ws');
                _this.reviewHistory = res;
            }
        });
    };
    ReviewHistoryComponent.prototype.onRowSelect = function (event) {
        this.subID = this.selectedHistory.SUB_SPECIALTY_ID;
        this.empID = this.selectedHistory.EMP_ID;
        this.radName = '' + this.selectedHistory.RAD_NAME;
    };
    ReviewHistoryComponent.prototype.onRowDoubleClick = function (event) {
        var _this = this;
        this.studyService.getAllReviewHistoryDtl(3, this.fromDate, this.toDate, this.subID, this.empID).subscribe(function (res) {
            if (res === null) {
                console.log('NOTHING FROM WEB API...');
                return;
            }
            else {
                console.log('result ws');
                _this.studies = res;
                _this.displayHistory = true;
            }
        });
    };
    ReviewHistoryComponent.prototype.cloneHistory = function (c) {
        var history = this.selectedHistory;
        history = c;
        return history;
    };
    return ReviewHistoryComponent;
}());
ReviewHistoryComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        template: __webpack_require__(490),
        selector: 'review-history'
    }),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__services_study_service__["a" /* StudyService */]])
], ReviewHistoryComponent);



/***/ }),

/***/ 471:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoadingComponent; });


var LoadingComponent = (function () {
    function LoadingComponent() {
        this.size = 25;
        this.tickness = 2;
        this.color = '#4f6aa7';
        this.opacity = '.1';
        this.secondColor = '';
    }
    LoadingComponent.prototype.ngOnInit = function () {
        var c = this.hexToRgb(this.color);
        this.secondColor = 'rgba(' + c.r + ',' + c.g + ',' + c.b + ', ' + this.opacity + ')';
    };
    LoadingComponent.prototype.hexToRgb = function (hex) {
        var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
        return result ? {
            r: parseInt(result[1], 16),
            g: parseInt(result[2], 16),
            b: parseInt(result[3], 16)
        } : null;
    };
    return LoadingComponent;
}());
__WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Input"])(),
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.width.px'),
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.height.px'),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:type", Object)
], LoadingComponent.prototype, "size", void 0);
__WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Input"])(),
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.borderWidth.px'),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:type", Object)
], LoadingComponent.prototype, "tickness", void 0);
__WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Input"])(),
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.borderTopColor'),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:type", Object)
], LoadingComponent.prototype, "color", void 0);
__WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Input"])(),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:type", Object)
], LoadingComponent.prototype, "opacity", void 0);
__WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.borderBottomColor'),
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.borderLeftColor'),
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["HostBinding"])('style.borderRightColor'),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:type", Object)
], LoadingComponent.prototype, "secondColor", void 0);
LoadingComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        selector: 'spinner',
        template: '',
        styles: ["\n    @keyframes spin {\n      from {transform: rotate(0deg);}\n      to {transform: rotate(360deg);}\n    }\n    :host {\n      position:relative;\n      box-sizing: border-box;\n      display:inline-block;\n      padding:0px;\n      border-radius:100%;\n      border-style:solid;\n      animation: spin 0.8s linear infinite;\n    }\n    :host .margins {\n        margin: 0px 10px;\n    }\n  "]
    })
], LoadingComponent);



/***/ }),

/***/ 472:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export Assignment */
var Assignment = (function () {
    function Assignment() {
    }
    return Assignment;
}());



/***/ }),

/***/ 473:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__peerreview__ = __webpack_require__(474);
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "a", function() { return __WEBPACK_IMPORTED_MODULE_0__peerreview__["a"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__subspecialty__ = __webpack_require__(478);
/* unused harmony namespace reexport */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__subspecialtylookup__ = __webpack_require__(479);
/* unused harmony namespace reexport */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__radiologist__ = __webpack_require__(476);
/* unused harmony namespace reexport */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__prstatus__ = __webpack_require__(475);
/* unused harmony namespace reexport */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__assignment__ = __webpack_require__(472);
/* unused harmony namespace reexport */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__reviewhistory__ = __webpack_require__(477);
/* unused harmony namespace reexport */









/***/ }),

/***/ 474:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PeerReview; });
var PeerReview = (function () {
    function PeerReview() {
    }
    return PeerReview;
}());



/***/ }),

/***/ 475:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export PeerStatus */
var PeerStatus = (function () {
    function PeerStatus() {
    }
    return PeerStatus;
}());



/***/ }),

/***/ 476:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export Radiologist */
var Radiologist = (function () {
    function Radiologist() {
    }
    return Radiologist;
}());



/***/ }),

/***/ 477:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export ReviewHistory */
var ReviewHistory = (function () {
    function ReviewHistory() {
    }
    return ReviewHistory;
}());



/***/ }),

/***/ 478:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export Subspecialty */
var Subspecialty = (function () {
    function Subspecialty() {
    }
    return Subspecialty;
}());



/***/ }),

/***/ 479:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export SubspecialtyLookup */
var SubspecialtyLookup = (function () {
    function SubspecialtyLookup() {
    }
    return SubspecialtyLookup;
}());



/***/ }),

/***/ 480:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__(3);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__(6);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_core__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__peerreview_routes__ = __webpack_require__(481);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__peerreview_component__ = __webpack_require__(463);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__assignment_component__ = __webpack_require__(462);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__reviewhistory_component__ = __webpack_require__(464);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__loading_component__ = __webpack_require__(471);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__services_study_service__ = __webpack_require__(460);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__ = __webpack_require__(187);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11_primeng_primeng___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_11_primeng_primeng__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PeerReviewModule", function() { return PeerReviewModule; });












var PeerReviewModule = (function () {
    function PeerReviewModule() {
    }
    return PeerReviewModule;
}());
PeerReviewModule.routes = __WEBPACK_IMPORTED_MODULE_5__peerreview_routes__["a" /* routes */];
PeerReviewModule = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_3__angular_core__["NgModule"])({
        declarations: [
            // Components / Directives/ Pipes
            __WEBPACK_IMPORTED_MODULE_6__peerreview_component__["a" /* PeerReviewComponent */],
            __WEBPACK_IMPORTED_MODULE_7__assignment_component__["a" /* AssignmentComponent */],
            __WEBPACK_IMPORTED_MODULE_8__reviewhistory_component__["a" /* ReviewHistoryComponent */],
            __WEBPACK_IMPORTED_MODULE_9__loading_component__["a" /* LoadingComponent */],
        ],
        imports: [
            __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
            __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormsModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["DataTableModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["ButtonModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["DialogModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["PanelModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["TabViewModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["EditorModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["SharedModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["RadioButtonModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["MessagesModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["CalendarModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["FieldsetModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["ConfirmDialogModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["DropdownModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["SpinnerModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["ButtonModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["CheckboxModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["DataTableModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["DialogModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["SharedModule"],
            __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["TooltipModule"],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["RouterModule"].forChild(__WEBPACK_IMPORTED_MODULE_5__peerreview_routes__["a" /* routes */]),
        ],
        providers: [
            __WEBPACK_IMPORTED_MODULE_10__services_study_service__["a" /* StudyService */], __WEBPACK_IMPORTED_MODULE_11_primeng_primeng__["ConfirmationService"]
        ]
    })
], PeerReviewModule);



/***/ }),

/***/ 481:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__peerreview_component__ = __webpack_require__(463);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__assignment_component__ = __webpack_require__(462);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__reviewhistory_component__ = __webpack_require__(464);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return routes; });



var routes = [
    { path: '', component: __WEBPACK_IMPORTED_MODULE_0__peerreview_component__["a" /* PeerReviewComponent */], pathMatch: 'full' },
    { path: 'studyassign', component: __WEBPACK_IMPORTED_MODULE_1__assignment_component__["a" /* AssignmentComponent */] },
    { path: 'reviewhistory', component: __WEBPACK_IMPORTED_MODULE_2__reviewhistory_component__["a" /* ReviewHistoryComponent */] },
];


/***/ }),

/***/ 488:
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <p-messages [value]=\"msgs\"></p-messages>\r\n    <p-confirmDialog header=\"Confirmation\" icon=\"fa fa-question-circle\" width=\"425\"></p-confirmDialog>\r\n    <p-panel>\r\n        <p-header>\r\n            Automatic Study Assignment\r\n        </p-header>\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <p-fieldset legend=\"Automatic Process\">\r\n                        <font color=\"red\">Please be patient when automatic study assignment task started!</font><br><br>\r\n                        From Date: <p-calendar [(ngModel)]=\"fromDate\" [showIcon]=\"true\"></p-calendar>\r\n                        To Date :<p-calendar [(ngModel)]=\"toDate\" [showIcon]=\"true\"></p-calendar> <br><br><br>\r\n                        <button pButton type=\"button\" class=\"ui-button-warning\" (click)=\"startAutoAssign()\"\r\n                            [label]=\"btnAutoStart\" [disabled]=\"\"></button>\r\n                        <button pButton type=\"button\" class=\"ui-button-danger\" (click)=\"deleteAutoAssign()\"\r\n                            label=\"Delete Recent Assignments\"></button>\r\n                        <spinner *ngIf='working' [size]=\"50\" [tickness]=\"2\">surajit</spinner>\r\n                    </p-fieldset>\r\n                </td>\r\n                <td>\r\n                    <p-fieldset legend=\"Algorithm\">\r\n                        <p-spinner size=\"3\" [(ngModel)]=\"valPer\" [min]=\"1\" [max]=\"100\"></p-spinner>\r\n                        <font color=\"orange\"><b>% From Each Radiologist's Finalized Studies</b></font> <br><br>\r\n                        <p-spinner size=\"3\" [(ngModel)]=\"valMax\" [min]=\"1\" [max]=\"100\"></p-spinner>\r\n                        <font color=\"orange\"><b>Max Assignment Quota For Each Radiologist</b></font><br><br><br>\r\n                        <button pButton type=\"button\" class=\"ui-button-success\" (click)=\"changeAlgorithm()\"\r\n                            label=\"Save Changes\"></button>\r\n                    </p-fieldset>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n        <p-fieldset legend=\"Assignment History\" [toggleable]=\"true\" collapsed=\"true\">\r\n            <table>\r\n                <tr>\r\n                    <td>\r\n                        <p-dropdown [options]=\"subspecialty\" [(ngModel)]=\"selectedSub\" [style]=\"{'width':'350px'}\"\r\n                            editable=\"editable\" placeholder=\"Select a Subspecialty\" (onChange)=\"onChangeSub($event)\">\r\n                        </p-dropdown>\r\n                    </td>\r\n                    <td>\r\n                        <button pButton type=\"button\" class=\"ui-button-success\" (click)=\"allRadiologists()\"\r\n                            label=\"All Radiologists\"></button>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n            <br><br>\r\n            <table style=\"height:150px;text-align:left;\">\r\n                <tr style=\"background-color:#3CBC3C;color:white;\">\r\n                    <th>All Radiologists From {{selectedSub}}</th>\r\n                </tr>\r\n                <tr>\r\n                    <p-dataTable [value]=\"radiologists\" selectionMode=\"single\" [(selection)]=\"selectedradiologist\"\r\n                        [rows]=\"10\" [responsive]=\"true\" (onRowSelect)=\"onRowSelect($event)\" tableStyleClass=\"table\">\r\n                        <p-column field=\"EMP_ID\" header=\"EMP_ID\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                            [hidden]=\"true\"></p-column>\r\n                        <p-column field=\"RAD_NAME\" header=\"Name\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                            [hidden]=\"false\"></p-column>\r\n                        <p-column field=\"GENDER\" header=\"Gender\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\"></p-column>\r\n                        <p-column field=\"DOB\" header=\"Date of birth\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\" [hidden]=\"true\"></p-column>\r\n                        <p-column field=\"EMAIL\" header=\"Email\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\">\r\n                        </p-column>\r\n                    </p-dataTable>\r\n                </tr>\r\n            </table>\r\n            <br><br>\r\n            <table style=\"height:150px;text-align:left;\">\r\n                <tr style=\"background-color:#3CBC3C;color:white;\">\r\n                    <th>Assigned Studies For {{radname}}</th>\r\n                </tr>\r\n                <tr>\r\n                    <p-dataTable [value]=\"studies\" selectionMode=\"single\" [(selection)]=\"selectedstudy\" [rows]=\"5\"\r\n                        [responsive]=\"true\" tableStyleClass=\"table\">\r\n                        <p-column field=\"HN\" header=\"HN\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                            [hidden]=\"false\"></p-column>\r\n                        <p-column field=\"PATIENT_NAME\" header=\"Name\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\"></p-column>\r\n                        <p-column field=\"ACCESSION_NO\" header=\"Accession No\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\" [hidden]=\"false\"></p-column>\r\n                        <p-column field=\"EXAM_NAME\" header=\"Exam Name\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\" [hidden]=\"false\"></p-column>\r\n                        <p-column field=\"ORDER_DT\" header=\"Study Date\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\">\r\n                            <template let-study=\"rowData\" pTemplate type=\"body\">\r\n                                <span>{{study.ORDER_DT | date:'dd/MM/yyyy'}}</span>\r\n                            </template>\r\n                        </p-column>\r\n                        <p-column field=\"TYPE_NAME_ALIAS\" header=\"Modality\" [sortable]=\"false\" [filter]=\"true\"\r\n                            filterPlaceholder=\"\"></p-column>\r\n                    </p-dataTable>\r\n                </tr>\r\n            </table>\r\n        </p-fieldset>\r\n    </p-panel>\r\n    <p-dialog header=\"Radiologist's Assignment Details\" [(visible)]=\"displayAllRadiologist\" [responsive]=\"true\"\r\n        showEffect=\"fade\" [modal]=\"true\" width=\"1024\" height=\"850\">\r\n        <p-panel>\r\n            <p-header>\r\n                Study Count :\r\n            </p-header>\r\n            <p-dataTable [value]=\"radiologistsCount\" selectionMode=\"single\" [paginator]=\"true\" [rows]=\"10\"\r\n                [responsive]=\"true\" tableStyleClass=\"table\">\r\n                <p-column field=\"EMP_ID\" header=\"EMP_ID\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                    [hidden]=\"true\"></p-column>\r\n                <p-column field=\"RAD_NAME\" header=\"Name\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                    [hidden]=\"false\"></p-column>\r\n                <p-column field=\"GENDER\" header=\"Gender\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\">\r\n                </p-column>\r\n                <p-column field=\"DOB\" header=\"Date of birth\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                    [hidden]=\"true\"></p-column>\r\n                <p-column field=\"EMAIL\" header=\"Email\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\">\r\n                </p-column>\r\n                <p-column field=\"STUDY_COUNT\" header=\"Total\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\">\r\n                </p-column>\r\n            </p-dataTable>\r\n        </p-panel>\r\n    </p-dialog>\r\n</div>"

/***/ }),

/***/ 489:
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <p-confirmDialog header=\"Confirmation\" icon=\"fa fa-question-circle\" width=\"425\" #cd>\r\n        <p-footer>\r\n            <button type=\"button\" pButton icon=\"fa-check\" label=\"Ok\" (click)=\"cd.accept()\"></button>\r\n        </p-footer>\r\n    </p-confirmDialog>\r\n    <p-panel>\r\n        <p-header>\r\n            Summary :\r\n        </p-header>\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <b>Total Assigned Cases :</b> {{noOfStudies}} <br>\r\n                    <b>Reviewed :</b> {{noOfReviewed}} <br>\r\n                    <b>Pending :</b> {{noOfReviewing}} <br>\r\n                    <p-dropdown [options]=\"prStatus\" [(ngModel)]=\"selectedFilter\" [style]=\"{'width':'350px'}\"\r\n                        editable=\"editable\" placeholder=\"Filter Status\" (onChange)=\"onChangeStatus($event)\">\r\n                    </p-dropdown>\r\n                    <input #gb type=\"text\" [value]=\"filterText\" pInputText size=\"50\" placeholder=\"Global Filter\"\r\n                        hidden=\"true\">\r\n                </td>\r\n                <td></td>\r\n                <td>\r\n                    <p-fieldset *ngIf=\"hideComment\" legend=\"Comments\" [toggleable]=\"true\" [collapsed]=\"true\">\r\n                        <textarea rows=\"10\" cols=\"60\" pInputTextarea [(ngModel)]=\"comment\" disabled=\"true\"></textarea>\r\n                    </p-fieldset>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </p-panel>\r\n    <p-dataTable [value]=\"studies\" selectionMode=\"single\" [(selection)]=\"selectedStudy\"\r\n        (onRowSelect)=\"onRowSelect($event)\" (onRowDblclick)=\"onRowDoubleClick($event)\" [paginator]=\"true\" [rows]=\"10\"\r\n        [responsive]=\"true\" [globalFilter]=\"gb\" tableStyleClass=\"table\">\r\n        <p-header>PEER REVIEW WORKLIST</p-header>\r\n        <p-column field=\"ASSIGNMENT_ID\" header=\"ASSIGNMENT_ID\" [sortable]=\"false\" [filter]=\"true\"\r\n            filterPlaceholder=\"Search\" [hidden]=\"true\"></p-column>\r\n        <p-column field=\"HN\" header=\"HN\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\" [hidden]=\"false\">\r\n        </p-column>\r\n        <p-column field=\"PATIENT_NAME\" header=\"Name\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\">\r\n        </p-column>\r\n        <p-column field=\"ACCESSION_NO\" header=\"Accession No\" [sortable]=\"false\" [filter]=\"true\"\r\n            filterPlaceholder=\"Search\"></p-column>\r\n        <p-column field=\"EXAM_NAME\" header=\"Exam Name\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\">\r\n        </p-column>\r\n        <p-column field=\"ORDER_DT\" header=\"Study Date\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\">\r\n            <template let-study=\"rowData\" pTemplate=\"body\">\r\n                <span>{{study.ORDER_DT | date:'dd/MM/yyyy'}}</span>\r\n            </template>\r\n        </p-column>\r\n        <p-column field=\"TYPE_NAME_ALIAS\" header=\"Modality\" [sortable]=\"false\" [filter]=\"true\"\r\n            filterPlaceholder=\"Search\"></p-column>\r\n        <p-column field=\"REVIEW_SCORE\" header=\"Score\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\">\r\n        </p-column>\r\n        <p-column field=\"STATUS\" header=\"Status\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\"\r\n            filterMatchMode=\"equals\"></p-column>\r\n        <p-column field=\"IS_COMMENTED\" header=\"Comment\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\"\r\n            filterMatchMode=\"equals\"></p-column>\r\n        <p-column field=\"COMMENT\" header=\"Comment\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\"\r\n            filterMatchMode=\"equals\" [hidden]=\"true\"></p-column>\r\n        <p-column field=\"REVIEW_DT\" header=\"Review Date\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\"\r\n            filterMatchMode=\"equals\">\r\n            <template let-study=\"rowData\"  pTemplate=\"body\">\r\n                <span>{{study.REVIEW_DT | date:'dd/MM/yyyy'}}</span>\r\n            </template>\r\n        </p-column>\r\n        <p-column styleClass=\"col-button\">\r\n            <template let-study=\"rowData\" pTemplate=\"body\">\r\n                <button type=\"button\" pButton (click)=\"selectStudy(study)\" icon=\"ui-icon-pencil\"></button>\r\n            </template>\r\n        </p-column>\r\n\r\n    </p-dataTable>\r\n\r\n\r\n\r\n    <p-dialog header=\"Peer Review Details\" [(visible)]=\"displayScoring\" [responsive]=\"true\" showEffect=\"fade\"\r\n        [modal]=\"true\" [resizable]=\"true\" positionTop=\"5\" width=\"1024\" height=\"auto\">\r\n        <p-panel [toggleable]=\"true\">\r\n            <p-header>\r\n                Selected Study :\r\n            </p-header>\r\n            <table>\r\n                <tr>\r\n                    <td>\r\n                        <b>HN</b>\r\n                    </td>\r\n                    <td>\r\n                        :\r\n                    </td>\r\n                    <td>\r\n                        {{sTxtHN}}\r\n                    </td>\r\n                    <td>\r\n                        <b>Name </b>\r\n                    </td>\r\n                    <td>\r\n                        :\r\n                    </td>\r\n                    <td>\r\n                        {{sTxtPATIENTNAME}}\r\n                    </td>\r\n                    <td>\r\n                        <b>Accession </b>\r\n                    </td>\r\n                    <td>\r\n                        :\r\n                    </td>\r\n                    <td>\r\n                        {{sTxtACCESSIONNO}}\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        <b>Exam </b>\r\n                    </td>\r\n                    <td>\r\n                        :\r\n                    </td>\r\n                    <td>\r\n                        {{sTxtEXAMNAME}}\r\n                    </td>\r\n                    <td>\r\n                        <b>Modality </b>\r\n                    </td>\r\n                    <td>\r\n                        :\r\n                    </td>\r\n                    <td>\r\n                        {{sTxtTYPENAMEALIAS}}\r\n                    </td>\r\n                    <td>\r\n                        <b>Study Date </b>\r\n                    </td>\r\n                    <td>\r\n                        :\r\n                    </td>\r\n                    <td>\r\n                        {{sDateORDERDT | date:'MM/dd/yyyy'}}\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n\r\n        </p-panel>\r\n        <p-messages [value]=\"msgs\"></p-messages>\r\n        <p-tabView (onChange)=\"changeTab($event.index)\">\r\n\r\n            <p-tabPanel header={{reportTab}} [selected]=\"selectedTab === 0\">\r\n                <button pButton type=\"button\" class=\"ui-button-warning\" label=\"Save as draft\" [disabled]=\"ifFinal\"\r\n                    (click)=\"saveAsDraft(study.ASSIGNMENT_ID)\"></button>\r\n                <button pButton type=\"button\" class=\"ui-button-success\" label=\"Save as final\" [disabled]=\"ifFinal\"\r\n                    (click)=\"saveAsFinal(study.ASSIGNMENT_ID)\"></button>\r\n                <p-editor [(ngModel)]=\"myReport\" [readOnly]=\"false\" [style]=\"{'height':'300px'}\">\r\n                    <p-header>\r\n                        <span class=\"ql-formats\">\r\n                            <button class=\"ql-bold\"></button>\r\n                            <button class=\"ql-italic\"></button>\r\n                            <button class=\"ql-underline\"></button>\r\n                        </span>\r\n                    </p-header>\r\n                </p-editor>\r\n                <table align=\"right\">\r\n                    <tr>\r\n                        <button *ngIf=\"skipHide\" pButton type=\"button\" class=\"ui-button-danger\" label=\"Skip >>\"\r\n                            [disabled]=\"ifFinal\" (click)=\"skipToFinalReport()\"></button>\r\n                    </tr>\r\n                </table>\r\n            </p-tabPanel>\r\n            <p-tabPanel header=\"Finalized Report\" [selected]=\"selectedTab === 1\" [disabled]=\"tabDisable\">\r\n                <p-editor [(ngModel)]=\"finalizeReport\" [style]=\"{'height':'300px'}\" [readOnly]=\"true\">\r\n                    <p-header>\r\n                        <span class=\"ql-formats\">\r\n                            <button class=\"ql-bold\"></button>\r\n                            <button class=\"ql-italic\"></button>\r\n                            <button class=\"ql-underline\"></button>\r\n                        </span>\r\n                    </p-header>\r\n                </p-editor>\r\n            </p-tabPanel>\r\n            <p-tabPanel header=\"Scoring\" [selected]=\"selectedTab === 2\" [disabled]=\"tabDisable\">\r\n                <table>\r\n                    <tr>\r\n                        <td>\r\n                            <p-panel [toggleable]=\"true\">\r\n                                <p-header>\r\n                                    Score:\r\n                                </p-header>\r\n                                <table width>\r\n                                    <tr>\r\n                                        <td>\r\n                                            1. Concur with interpretation\r\n                                        </td>\r\n                                    </tr>\r\n                                    <div>\r\n                                        <hr style=\"background: green; border: none; height: 2px;\" />\r\n                                    </div>\r\n                                    <tr>\r\n                                        <td>\r\n                                            2. Discrepancy in Interpretation/not <br>\r\n                                            ordinarily expected to be <br>\r\n                                            made (understandable miss)\r\n                                        </td>\r\n                                    </tr>\r\n                                    <div>\r\n                                        <hr style=\"background: green; border: none; height: 2px;\" />\r\n                                    </div>\r\n                                    <tr>\r\n                                        <td>\r\n                                            3. Discrepancy in Interpretation/ should <br>\r\n                                            be made most of the time\r\n                                        </td>\r\n                                    </tr>\r\n                                    <!-- <div>\r\n                                        <hr style=\"background: green; border: none; height: 2px;\" />\r\n                                    </div>\r\n                                    <tr>\r\n                                        <td>\r\n                                            4. Discrepancy in Interpretation/ should be<br>\r\n                                            made almost every time – misinterpretation <br>\r\n                                            of finding\r\n                                        </td>\r\n                                    </tr> -->\r\n\r\n                                </table>\r\n                            </p-panel>\r\n                        </td>\r\n                        <td>\r\n                            <p-panel [toggleable]=\"true\">\r\n                                <p-header>\r\n                                    Clinical Significance:\r\n                                </p-header>\r\n                                <table>\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"1\" [(ngModel)]=\"scoreValue\" label=\"\">\r\n                                            </p-radioButton>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <div>\r\n                                        <hr style=\"background: green; border: none; height: 2px;\" />\r\n                                    </div>\r\n\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"2a\" [(ngModel)]=\"scoreValue\"\r\n                                                label=\"2a. Unlikely to be clinically significant\"></p-radioButton>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"2b\" [(ngModel)]=\"scoreValue\"\r\n                                                label=\"2b. Likely to be clinically significant\"></p-radioButton>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <div>\r\n                                        <hr style=\"background: green; border: none; height: 2px;\" />\r\n                                    </div>\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"3a\" [(ngModel)]=\"scoreValue\"\r\n                                                label=\"3a. Unlikely to be clinically significant\"></p-radioButton>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"3b\" [(ngModel)]=\"scoreValue\"\r\n                                                label=\"3b. Likely to be clinically significant\"></p-radioButton>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <!-- <div>\r\n                                        <hr style=\"background: green; border: none; height: 2px;\" />\r\n                                    </div>\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"4a\" [(ngModel)]=\"scoreValue\"\r\n                                                label=\"4a. Unlikely to be clinically significant\"></p-radioButton>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>\r\n                                            <p-radioButton name=\"groupname\" value=\"4b\" [(ngModel)]=\"scoreValue\"\r\n                                                label=\"4b. Likely to be clinically significant\"></p-radioButton>\r\n                                        </td>\r\n                                    </tr> -->\r\n                                    <br>\r\n                                </table>\r\n\r\n                            </p-panel>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n                <h3 class=\"first\">Comments</h3>\r\n                <textarea rows=\"10\" cols=\"90\" pInputTextarea [(ngModel)]=\"myComment\"></textarea>\r\n                <table>\r\n                    <tr>\r\n                        <td>\r\n                            <button pButton type=\"button\" class=\"ui-button-success\" label=\"Save Changes\"\r\n                                (click)=\"saveScore(study.ASSIGNMENT_ID)\"></button>\r\n                        </td>\r\n                        <td>\r\n                            <button pButton type=\"button\" class=\"ui-button-warning\" label=\"Reset\"></button>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </p-tabPanel>\r\n        </p-tabView>\r\n    </p-dialog>\r\n\r\n</div>"

/***/ }),

/***/ 490:
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <p-panel>\r\n        <p-header>\r\n            Review History\r\n        </p-header>\r\n        <p-fieldset>\r\n            <b>From Assign Date :</b>\r\n            <p-dropdown [options]=\"assignDate\" [(ngModel)]=\"fromDate\" [style]=\"{'width':'350px'}\" editable=\"editable\"\r\n                placeholder=\"Select a assign date\"></p-dropdown>\r\n            <b>To Assign Date :</b>\r\n            <p-dropdown [options]=\"assignDate\" [(ngModel)]=\"toDate\" [style]=\"{'width':'350px'}\" editable=\"editable\"\r\n                placeholder=\"Select a assign date\"></p-dropdown>\r\n            <button pButton type=\"button\" class=\"ui-button-success\" (click)=\"getReviewHistory()\"\r\n                label=\"  Find  \"></button>\r\n        </p-fieldset>\r\n        <hr>\r\n        <p-dataTable [value]=\"reviewHistory\" selectionMode=\"single\" [(selection)]=\"selectedHistory\" [rows]=\"5\"\r\n            [responsive]=\"true\" tableStyleClass=\"table\" (onRowSelect)=\"onRowSelect($event)\"\r\n            (onRowDblclick)=\"onRowDoubleClick($event)\">\r\n            <p-header></p-header>\r\n            <p-column field=\"SUB_SPECIALTY_NAME\" header=\"Subspecialty\" [sortable]=\"false\" [filter]=\"true\"\r\n                filterPlaceholder=\"\" [hidden]=\"false\"></p-column>\r\n            <p-column field=\"RAD_NAME\" header=\"Radiologist\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                [hidden]=\"false\"></p-column>\r\n            <p-column field=\"TOTAL\" header=\"Assigned\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                [hidden]=\"false\"></p-column>\r\n            <p-column field=\"REVIEWED\" header=\"Reviewed\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\">\r\n            </p-column>\r\n            <p-column field=\"PENDING\" header=\"Pending\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"\"\r\n                [hidden]=\"false\"></p-column>\r\n        </p-dataTable>\r\n    </p-panel>\r\n    <p-dialog header=\"Peer Review History Details\" [(visible)]=\"displayHistory\" [responsive]=\"true\" showEffect=\"fade\"\r\n        [modal]=\"true\" width=\"1400\" height=\"900\">\r\n        <p-panel>\r\n            <p-header>\r\n                Radiologist's NAME : {{radName}}\r\n            </p-header>\r\n        </p-panel>\r\n        <p-dataTable [value]=\"studies\" selectionMode=\"single\" [paginator]=\"true\" [rows]=\"10\" [responsive]=\"true\"\r\n            tableStyleClass=\"table\">\r\n            <p-header></p-header>\r\n            <p-column field=\"HN\" header=\"HN\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\"\r\n                [hidden]=\"false\"></p-column>\r\n            <p-column field=\"PATIENT_NAME\" header=\"Name\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\">\r\n            </p-column>\r\n            <p-column field=\"ACCESSION_NO\" header=\"Accession No\" [sortable]=\"false\" [filter]=\"true\"\r\n                filterPlaceholder=\"Search\"></p-column>\r\n            <p-column field=\"EXAM_NAME\" header=\"Exam Name\" [sortable]=\"false\" [filter]=\"true\"\r\n                filterPlaceholder=\"Search\"></p-column>\r\n            <p-column field=\"ORDER_DT\" header=\"Study Date\" [sortable]=\"false\" [filter]=\"true\"\r\n                filterPlaceholder=\"Search\">\r\n                <template let-study=\"rowData\" pTemplate type=\"body\">\r\n                    <span>{{study.ORDER_DT | date:'dd/MM/yyyy'}}</span>\r\n                </template>\r\n            </p-column>\r\n            <p-column field=\"TYPE_NAME_ALIAS\" header=\"Modality\" [sortable]=\"false\" [filter]=\"true\"\r\n                filterPlaceholder=\"Search\"></p-column>\r\n            <p-column field=\"REVIEW_SCORE\" header=\"Score\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\">\r\n            </p-column>\r\n            <p-column field=\"STATUS\" header=\"Status\" [sortable]=\"false\" [filter]=\"true\" filterPlaceholder=\"Search\"\r\n                filterMatchMode=\"equals\"></p-column>\r\n            <p-column field=\"REVIEW_DT\" header=\"Review Date\" [sortable]=\"false\" [filter]=\"true\"\r\n                filterPlaceholder=\"Search\" filterMatchMode=\"equals\">\r\n                <template let-study=\"rowData\" pTemplate type=\"body\">\r\n                    <span>{{study.REVIEW_DT | date:'dd/MM/yyyy'}}</span>\r\n                </template>\r\n            </p-column>\r\n        </p-dataTable>\r\n    </p-dialog>\r\n\r\n</div>"

/***/ }),

/***/ 491:
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(9))(819);

/***/ })

});
//# sourceMappingURL=3.chunk.js.map