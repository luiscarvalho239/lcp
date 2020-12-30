import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SaveGames } from '@app/classes/savegames';
import { environment } from 'src/environments/environment';

/* istanbul ignore next */
@Injectable({
  providedIn: 'root'
})
export class SavegamesService {

  constructor(private http: HttpClient) { }

  getSaveGames() {
    return this.http.get<SaveGames[]>(`${environment.apiUrl}/api/save_games`);
  }
}
