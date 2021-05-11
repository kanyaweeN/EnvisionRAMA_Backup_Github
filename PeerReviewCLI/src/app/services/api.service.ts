import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable()
export class ApiService {
    private APIUrl = 'https://localhost:44300/';
    // private APIUrl = 'http://miracleonline/PeerReviewService/';

    constructor(private http: HttpClient) { }

    public GET(path: string): Observable<any> {
        return this.http.get(`${this.APIUrl}${path}`).
            pipe(
                map((data: any[]) => {
                    return data;
                }), catchError(error => {
                    return throwError('Something went wrong!');
                })
            );
    }

    public POST(path: string, body): Observable<any> {
        const headers = { 'Authorization': 'Bearer my-token', 'My-Custom-Header': 'foobar' };
        return this.http.post<any>(`${this.APIUrl}${path}`, body, { headers });
    }
}
