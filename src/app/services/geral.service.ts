import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class GeralService {

  constructor(private http: HttpClient) { }

  getInfoByApi(item = 'users') {
    return this.http.get<any>(`${environment.apiUrl}/api/${item}`);
  }

  getAllInfo() {
    return this.http.get<any>(`${environment.apiUrl}/api`);
  }
}
