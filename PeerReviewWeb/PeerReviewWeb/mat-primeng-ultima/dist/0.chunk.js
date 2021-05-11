webpackJsonpac__name_([0],{

/***/ 459:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__(3);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__(6);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_core__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__home_routes__ = __webpack_require__(470);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__home_component__ = __webpack_require__(461);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__components_topbar_component__ = __webpack_require__(469);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__components_footer_component__ = __webpack_require__(465);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__components_inline_profile_component__ = __webpack_require__(466);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__components_menu_component__ = __webpack_require__(467);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__components_submenu_component__ = __webpack_require__(468);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeModule", function() { return HomeModule; });












var HomeModule = (function () {
    function HomeModule() {
    }
    return HomeModule;
}());
HomeModule = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_3__angular_core__["NgModule"])({
        declarations: [
            // Components / Directives/ Pipes
            __WEBPACK_IMPORTED_MODULE_6__home_component__["a" /* HomeComponent */],
            __WEBPACK_IMPORTED_MODULE_7__components_topbar_component__["a" /* TopbarComponent */],
            __WEBPACK_IMPORTED_MODULE_8__components_footer_component__["a" /* FooterBarComponent */],
            __WEBPACK_IMPORTED_MODULE_10__components_menu_component__["a" /* MenuBarComponent */],
            __WEBPACK_IMPORTED_MODULE_11__components_submenu_component__["a" /* SubMenuComponent */],
            __WEBPACK_IMPORTED_MODULE_9__components_inline_profile_component__["a" /* InlineProfileComponent */]
        ],
        imports: [
            __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
            __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormsModule"],
            __WEBPACK_IMPORTED_MODULE_4__angular_router__["RouterModule"].forChild(__WEBPACK_IMPORTED_MODULE_5__home_routes__["a" /* routes */]),
        ],
    })
], HomeModule);



/***/ }),

/***/ 461:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomeComponent; });


var HomeComponent = (function () {
    function HomeComponent() {
    }
    return HomeComponent;
}());
HomeComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        selector: 'home',
        template: __webpack_require__(487)
    })
], HomeComponent);



/***/ }),

/***/ 465:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FooterBarComponent; });


var FooterBarComponent = (function () {
    function FooterBarComponent() {
    }
    return FooterBarComponent;
}());
FooterBarComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        selector: 'app-footer',
        template: __webpack_require__(482)
    })
], FooterBarComponent);



/***/ }),

/***/ 466:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return InlineProfileComponent; });


var InlineProfileComponent = (function () {
    function InlineProfileComponent() {
    }
    return InlineProfileComponent;
}());
InlineProfileComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        selector: 'inline-profile',
        template: __webpack_require__(483)
    })
], InlineProfileComponent);



/***/ }),

/***/ 467:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MenuBarComponent; });


var MenuBarComponent = (function () {
    function MenuBarComponent() {
    }
    return MenuBarComponent;
}());
MenuBarComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        selector: 'app-menu',
        template: __webpack_require__(484)
    })
], MenuBarComponent);



/***/ }),

/***/ 468:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SubMenuComponent; });


var SubMenuComponent = (function () {
    function SubMenuComponent() {
    }
    return SubMenuComponent;
}());
SubMenuComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["Component"])({
        selector: '[app-submenu]',
        template: __webpack_require__(485)
    })
], SubMenuComponent);



/***/ }),

/***/ 469:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_tslib__ = __webpack_require__(11);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_core__ = __webpack_require__(2);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TopbarComponent; });



var TopbarComponent = (function () {
    function TopbarComponent(activatedRoute) {
        this.activatedRoute = activatedRoute;
    }
    TopbarComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.queryParam = this.activatedRoute.queryParams.subscribe(function (params) {
            _this.userName = params['userName'];
        });
        var date = new Date();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        var mins = minutes < 10 ? '0' + minutes : minutes;
        var strTime = '' + hours + ':' + mins + ' ' + ampm;
        if (ampm === 'am') {
            this.userName = 'Hi, ' + this.userName + ' - Good Morning!';
        }
        else {
            if (hours <= 5) {
                this.userName = 'Hi, ' + this.userName + ' - Good Afternoon!';
            }
            else {
                this.userName = 'Hi, ' + this.userName + ' - Good Evening!';
            }
        }
    };
    TopbarComponent.prototype.ngOnDestroy = function () {
        this.queryParam.unsubscribe();
    };
    return TopbarComponent;
}());
TopbarComponent = __WEBPACK_IMPORTED_MODULE_0_tslib__["a" /* __decorate */]([
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_2__angular_core__["Component"])({
        selector: 'app-topbar',
        template: __webpack_require__(486)
    }),
    __WEBPACK_IMPORTED_MODULE_0_tslib__["b" /* __metadata */]("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["ActivatedRoute"]])
], TopbarComponent);



/***/ }),

/***/ 470:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__home_component__ = __webpack_require__(461);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return routes; });

var routes = [
    {
        path: '', component: __WEBPACK_IMPORTED_MODULE_0__home_component__["a" /* HomeComponent */], children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'peerreview', loadChildren: function() { return __webpack_require__.e/* import() */(3).then(__webpack_require__.bind(null, 480))  .then( function(module) { return module['PeerReviewModule']; } ); } }
        ]
    }
];


/***/ }),

/***/ 482:
/***/ (function(module, exports) {

module.exports = "<div class=\"footer\">\r\n    <div class=\"card clearfix\">\r\n        <span class=\"footer-text-left\">Miracle Advanced Technology</span>\r\n        <span class=\"footer-text-right\"><span class=\"ui-icon ui-icon-copyright\"></span> <span>All Rights Reserved</span></span>\r\n    </div>\r\n</div>"

/***/ }),

/***/ 483:
/***/ (function(module, exports) {

module.exports = "<div></div>"

/***/ }),

/***/ 484:
/***/ (function(module, exports) {

module.exports = "<div></div>"

/***/ }),

/***/ 485:
/***/ (function(module, exports) {

module.exports = "<div></div>"

/***/ }),

/***/ 486:
/***/ (function(module, exports) {

module.exports = "<div class=\"topbar clearfix\">\r\n     <div class=\"topbar-left\">\r\n       <!--<div class=\"logo\"></div>-->\r\n    </div>\r\n    <table>\r\n      <tr>\r\n        <td>\r\n          <font color=\"white\">{{userName}}</font>\r\n        </td>\r\n        <td align=\"right\"><font color=\"white\"><h3>Welcome To Envision Peer Review App</h3></font></td>\r\n      </tr>\r\n    </table>\r\n    <div class=\"topbar-right\">     \r\n    </div>\r\n</div>"

/***/ }),

/***/ 487:
/***/ (function(module, exports) {

module.exports = "<div class=\"layout-wrapper\">\r\n\r\n    <div #layoutContainer class=\"layout-container\">\r\n\r\n        <app-topbar></app-topbar>\r\n\r\n       <!-- <div class=\"layout-menu\" [ngClass]=\"{'layout-menu-dark':darkMenu}\" (click)=\"onMenuClick($event)\">\r\n            <div #layoutMenuScroller class=\"nano\">\r\n                <div class=\"nano-content menu-scroll-content\">\r\n                    <inline-profile *ngIf=\"profileMode=='inline'&&!isHorizontal()\"></inline-profile>\r\n                    <app-menu [reset]=\"resetMenu\"></app-menu>\r\n                </div>\r\n            </div>\r\n        </div>-->\r\n\r\n        <div class=\"layout-main\">\r\n            <router-outlet></router-outlet>\r\n\r\n            <app-footer></app-footer>\r\n        </div>\r\n        <div class=\"layout-mask\"></div>\r\n</div>\r\n\r\n</div>"

/***/ })

});
//# sourceMappingURL=0.chunk.js.map