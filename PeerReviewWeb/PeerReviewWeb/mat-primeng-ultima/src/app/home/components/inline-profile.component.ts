import { Component, Input, OnInit, EventEmitter, ViewChild, trigger, state, transition, style, animate, Inject, forwardRef } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/primeng';
import { AppState } from '../../app.service';

@Component({
    selector: 'inline-profile',
    templateUrl: './inline-profile.template.html'
})
export class InlineProfileComponent {
}
