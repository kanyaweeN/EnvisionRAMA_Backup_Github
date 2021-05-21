import { Component, Input, OnInit, EventEmitter, ViewChild, trigger, state, transition, style, animate, Inject, forwardRef } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/primeng';
import { HomeComponent } from '../home.component';

@Component({
    selector: '[app-submenu]',
    templateUrl: './submenu.template.html'
})
export class SubMenuComponent {
}
