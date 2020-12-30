import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Users } from '@app/classes/users';

// const httpOptions = {
//   headers: new HttpHeaders({ 
//     'Content-Type': 'multipart/form-data',
//     'Accept': 'text/plain' 
//   })
// };

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  getUsers(id = -1) {
    const urlp = (id == -1) ? '' : id;
    return this.http.get<Users[]>(`${environment.apiUrl}/api/users/${urlp}`);
  }

  uploadImage(frmData: any) {
    var myheaders = new HttpHeaders();
    myheaders.append('Content-Type', 'multipart/form-data');
    return this.http.post(`${environment.apiUrl}/api/upload/images`, frmData, { headers: myheaders, responseType: 'text' });
  }
}
