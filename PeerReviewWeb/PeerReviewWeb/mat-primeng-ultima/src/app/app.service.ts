import { Injectable } from '@angular/core';
import { UserInfo } from './model/user-info';
import { AuthService } from './services/auth.service';

export type InternalStateType = {
  [key: string]: any
};

@Injectable()
export class AppState {

  public _state: InternalStateType = {};

  // already return a clone of the current state
  public get state() {
    return this._state = this._clone(this._state);
  }
  // never allow mutation
  public set state(value) {
    throw new Error('do not mutate the `.state` directly');
  }

  public get(prop?: any) {
    // use our state getter for the clone
    const state = this.state;
    return state.hasOwnProperty(prop) ? state[prop] : state;
  }

  public set(prop: string, value: any) {
    // internally mutate our state
    return this._state[prop] = value;
  }

  public get userInfo(): UserInfo {
    let objRaw =  localStorage.getItem(AuthService.UID_KEY);
    let obj = <UserInfo> JSON.parse(objRaw);
    return obj;
  }

  private _clone(object: InternalStateType) {
    // simple object clone
    return JSON.parse(JSON.stringify(object));
  }
}
