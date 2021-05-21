import 'rxjs/Rx';
import 'rxjs/add/observable/throw';
import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ApiService {
    // private APIUrl: string = 'https://localhost:44300/';
    private APIUrl: string = 'http://miracleonline/PeerReviewService/';

    constructor(private http: Http) { }

    public GET(path: string): Observable<any> {
        return this.http.get(`${this.APIUrl}${path}`, { headers: this.getCustomHeader() })
            .map(this.checkForError)
            .catch((err) => Observable.throw(err))
            .map(this.getJson);
    }

    public POST(path: string, body): Observable<any> {
        return this.http.post(
            `${this.APIUrl}${path}`,
            JSON.stringify(body),
            { headers: this.getCustomHeader() }
        )
            .map(this.checkForError)
            .catch((err) => Observable.throw(err))
            .map(this.getJson);
    }

    private getCustomHeader() {
        let hd = new Headers({
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });
        hd.append('Authorization', 'Basic '); // 'Authorization': 'Bearer '
        return hd;
    }
    private getJson(response: Response) {
        return response.json();
    }

    private checkForError(response: Response): Response | Observable<any> {
        if (response.status >= 200 && response.status < 300) {
            return response;
        } else {
            let error = new Error(response.statusText);
            error['response'] = response;
            console.error(error);
            throw error;
        }
    }
}
