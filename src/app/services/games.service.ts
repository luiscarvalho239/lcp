import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Games } from '@app/classes/games';
import { environment } from 'src/environments/environment';

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private http: HttpClient) { }

  getGames() {
    return this.http.get<Games[]>(`${environment.apiUrl}/api/games`);
  }
}
