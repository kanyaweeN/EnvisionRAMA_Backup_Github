/**
 * @fileoverview This file is generated by the Angular 2 template compiler.
 * Do not edit.
 * @suppress {suspiciousCode,uselessCode,missingProperties}
 */
 /* tslint:disable */

import * as import0 from '../../../../../src/app/home/components/footer.component';
import * as import1 from '@angular/core/src/linker/view';
import * as import2 from '@angular/core/src/render/api';
import * as import3 from '@angular/core/src/linker/view_utils';
import * as import4 from '@angular/core/src/metadata/view';
import * as import5 from '@angular/core/src/linker/view_type';
import * as import6 from '@angular/core/src/change_detection/constants';
import * as import7 from '@angular/core/src/linker/component_factory';
export class Wrapper_FooterBarComponent {
  /*private*/ _eventHandler:Function;
  context:import0.FooterBarComponent;
  /*private*/ _changed:boolean;
  constructor() {
    this._changed = false;
    this.context = new import0.FooterBarComponent();
  }
  ngOnDetach(view:import1.AppView<any>,componentView:import1.AppView<any>,el:any):void {
  }
  ngOnDestroy():void {
  }
  ngDoCheck(view:import1.AppView<any>,el:any,throwOnChange:boolean):boolean {
    var changed:any = this._changed;
    this._changed = false;
    return changed;
  }
  checkHost(view:import1.AppView<any>,componentView:import1.AppView<any>,el:any,throwOnChange:boolean):void {
  }
  handleEvent(eventName:string,$event:any):boolean {
    var result:boolean = true;
    return result;
  }
  subscribe(view:import1.AppView<any>,_eventHandler:any):void {
    this._eventHandler = _eventHandler;
  }
}
var renderType_FooterBarComponent_Host:import2.RenderComponentType = import3.createRenderComponentType('',0,import4.ViewEncapsulation.None,([] as any[]),{});
class View_FooterBarComponent_Host0 extends import1.AppView<any> {
  _el_0:any;
  compView_0:import1.AppView<import0.FooterBarComponent>;
  _FooterBarComponent_0_3:Wrapper_FooterBarComponent;
  constructor(viewUtils:import3.ViewUtils,parentView:import1.AppView<any>,parentIndex:number,parentElement:any) {
    super(View_FooterBarComponent_Host0,renderType_FooterBarComponent_Host,import5.ViewType.HOST,viewUtils,parentView,parentIndex,parentElement,import6.ChangeDetectorStatus.CheckAlways);
  }
  createInternal(rootSelector:string):import7.ComponentRef<any> {
    this._el_0 = import3.selectOrCreateRenderHostElement(this.renderer,'app-footer',import3.EMPTY_INLINE_ARRAY,rootSelector,(null as any));
    this.compView_0 = new View_FooterBarComponent0(this.viewUtils,this,0,this._el_0);
    this._FooterBarComponent_0_3 = new Wrapper_FooterBarComponent();
    this.compView_0.create(this._FooterBarComponent_0_3.context);
    this.init(this._el_0,((<any>this.renderer).directRenderer? (null as any): [this._el_0]),(null as any));
    return new import7.ComponentRef_<any>(0,this,this._el_0,this._FooterBarComponent_0_3.context);
  }
  injectorGetInternal(token:any,requestNodeIndex:number,notFoundResult:any):any {
    if (((token === import0.FooterBarComponent) && (0 === requestNodeIndex))) { return this._FooterBarComponent_0_3.context; }
    return notFoundResult;
  }
  detectChangesInternal(throwOnChange:boolean):void {
    this._FooterBarComponent_0_3.ngDoCheck(this,this._el_0,throwOnChange);
    this.compView_0.internalDetectChanges(throwOnChange);
  }
  destroyInternal():void {
    this.compView_0.destroy();
  }
  visitRootNodesInternal(cb:any,ctx:any):void {
    cb(this._el_0,ctx);
  }
}
export const FooterBarComponentNgFactory:import7.ComponentFactory<import0.FooterBarComponent> = new import7.ComponentFactory<import0.FooterBarComponent>('app-footer',View_FooterBarComponent_Host0,import0.FooterBarComponent);
const styles_FooterBarComponent:any[] = ([] as any[]);
var renderType_FooterBarComponent:import2.RenderComponentType = import3.createRenderComponentType('',0,import4.ViewEncapsulation.None,styles_FooterBarComponent,{});
export class View_FooterBarComponent0 extends import1.AppView<import0.FooterBarComponent> {
  _el_0:any;
  _text_1:any;
  _el_2:any;
  _text_3:any;
  _el_4:any;
  _text_5:any;
  _text_6:any;
  _el_7:any;
  _el_8:any;
  _text_9:any;
  _el_10:any;
  _text_11:any;
  _text_12:any;
  _text_13:any;
  constructor(viewUtils:import3.ViewUtils,parentView:import1.AppView<any>,parentIndex:number,parentElement:any) {
    super(View_FooterBarComponent0,renderType_FooterBarComponent,import5.ViewType.COMPONENT,viewUtils,parentView,parentIndex,parentElement,import6.ChangeDetectorStatus.CheckAlways);
  }
  createInternal(rootSelector:string):import7.ComponentRef<any> {
    const parentRenderNode:any = this.renderer.createViewRoot(this.parentElement);
    this._el_0 = import3.createRenderElement(this.renderer,parentRenderNode,'div',new import3.InlineArray2(2,'class','footer'),(null as any));
    this._text_1 = this.renderer.createText(this._el_0,'\n    ',(null as any));
    this._el_2 = import3.createRenderElement(this.renderer,this._el_0,'div',new import3.InlineArray2(2,'class','card clearfix'),(null as any));
    this._text_3 = this.renderer.createText(this._el_2,'\n        ',(null as any));
    this._el_4 = import3.createRenderElement(this.renderer,this._el_2,'span',new import3.InlineArray2(2,'class','footer-text-left'),(null as any));
    this._text_5 = this.renderer.createText(this._el_4,'Miracle Advanced Technology',(null as any));
    this._text_6 = this.renderer.createText(this._el_2,'\n        ',(null as any));
    this._el_7 = import3.createRenderElement(this.renderer,this._el_2,'span',new import3.InlineArray2(2,'class','footer-text-right'),(null as any));
    this._el_8 = import3.createRenderElement(this.renderer,this._el_7,'span',new import3.InlineArray2(2,'class','ui-icon ui-icon-copyright'),(null as any));
    this._text_9 = this.renderer.createText(this._el_7,' ',(null as any));
    this._el_10 = import3.createRenderElement(this.renderer,this._el_7,'span',import3.EMPTY_INLINE_ARRAY,(null as any));
    this._text_11 = this.renderer.createText(this._el_10,'All Rights Reserved',(null as any));
    this._text_12 = this.renderer.createText(this._el_2,'\n    ',(null as any));
    this._text_13 = this.renderer.createText(this._el_0,'\n',(null as any));
    this.init((null as any),((<any>this.renderer).directRenderer? (null as any): [
      this._el_0,
      this._text_1,
      this._el_2,
      this._text_3,
      this._el_4,
      this._text_5,
      this._text_6,
      this._el_7,
      this._el_8,
      this._text_9,
      this._el_10,
      this._text_11,
      this._text_12,
      this._text_13
    ]
    ),(null as any));
    return (null as any);
  }
}