import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router, CanActivate } from '@angular/router';
import { ApiService } from './api.service';
import { UserInfo } from '../model/user-info';

@Injectable()
export class AuthService implements CanActivate {
    public static UID_KEY: string = '_APP_USER_KEY_';
    private JWT_KEY: string = '_APP_KEY_TOKEN_';
    private apiPATH = 'api/Authen/';

    constructor(private router: Router, private api: ApiService) {
        const token = localStorage.getItem(this.JWT_KEY);
        if (token) {
            this.setTokenKey(token);
        }
    }

    public isAuthorized(): boolean {
        return Boolean(localStorage.getItem(this.JWT_KEY));
    }

    public canActivate(): boolean {
        const isAuth = this.isAuthorized();
        if (!isAuth) {
            this.router.navigate(['', 'home']);
        }
        return isAuth;
    }

    public authenticate(uid: string, password: string): Observable<any> {
        let creds = { userName: uid, pwd: password };
        return this.api.POST(`${this.apiPATH}Token`, creds);
    }
    public storeUserInfo(obj: UserInfo) {
        this.setTokenKey(obj.Token);
        localStorage.setItem(AuthService.UID_KEY, JSON.stringify(obj));
    }
    public signout() {
        localStorage.removeItem(this.JWT_KEY);
        this.router.navigate(['', 'login']);
    }

    private setTokenKey(key: string) {
        localStorage.setItem(this.JWT_KEY, key);
    }
}
