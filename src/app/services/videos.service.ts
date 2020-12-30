import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Videos } from '@app/classes/videos';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class VideosService {
  constructor(private http: HttpClient) {
  }

  getVideos() {
    return this.http.get<Videos[]>(`${environment.apiUrl}/api/videos`);
  }

  addVideos(objVideos: any) {
    return this.http.post<any>(`${environment.apiUrl}/api/videos`, objVideos, httpOptions)
    .pipe(
      tap(v => v),
      catchError(this.handleError<any>('addVideos'))
    );
  }

  uploadVideos(frmData: any) {
    return this.http.post(`${environment.apiUrl}/api/upload/videos`, frmData);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
