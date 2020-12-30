import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private http: HttpClient) { }

  upload(frmData: any, type: string = 'image') {
    let type_url = "";
    var myheaders = new HttpHeaders();
    myheaders.append('Content-Type', 'multipart/form-data');

    if (type == 'image') {
      type_url = 'upload/images';
    } else if (type == 'video') {
      type_url = 'upload/videos';
    } else {
      type_url = 'upload';
    }

    return this.http.post(`${environment.apiUrl}/api/${type_url}`, frmData, { headers: myheaders, responseType: 'text' });
  }
}
