import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { Users } from '@app/classes/users';
import { Router } from '@angular/router';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

/* istanbul ignore next */
@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    
    private currentUserSubject: BehaviorSubject<Users>;
    public currentUser: Observable<Users>;

    constructor(private http: HttpClient, private myroute: Router) {
        this.currentUserSubject = new BehaviorSubject<Users>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): Users {
        return this.currentUserSubject.value;
    }

    getUsersAuthList(): any {
        return this.http.get<any>(`${environment.apiUrl}/api/ApiAuth/getAuthUsers`, httpOptions);
    }

    login(username: string, password: string) {
        const obj = { username: username, password: password };
        return this.http.post<any>(`${environment.apiUrl}/api/ApiAuth`, obj, httpOptions)
            .pipe(
                tap(user => {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.currentUserSubject.next(user);
                    return user;
                }),
                catchError(this.handleError<any>('login'))
            );
    }

    register(objReg: any) {
        return this.http.post<any>(`${environment.apiUrl}/api/users`, objReg, httpOptions)
            .pipe(
                tap(user => {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.currentUserSubject.next(user);
                    return user;
                }),
                catchError(this.handleError<any>('register'))
            );
    }

    logout() {
        localStorage.clear();
        location.href = '/login';
        this.currentUserSubject.next(null);
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            console.error(error);
            console.log(`${operation} failed: ${error.message}`);
            return of(result as T);
        };
    }
}