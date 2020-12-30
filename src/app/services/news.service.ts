import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { News } from '../classes/news';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http: HttpClient) { }

  ObsGetNews(id: number = -1): Observable<News[]> {
    const urlid = (id == -1) ? '' : `${id}`;

    return this.http.get<News[]>(`${environment.apiUrl}/api/news/`+urlid).pipe(
      map(x => {
        let ary: any = [];
        if (typeof x === 'object') {
          ary.push(x);
        }
        return !Array.isArray(x) ? ary : x;
      }),
      tap(_ => console.log(`fetched news id ${id}`)),
      catchError(this.handleError<News[]>('ObsGetNews', []))
    );
  }

  insertNews(body: News) {
    return this.http.post<News>(`${environment.apiUrl}/api/news`, body, httpOptions).pipe(
      tap(newsx => newsx),
      catchError(this.handleError<News>('insertNews'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
