import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class MazeApiService {

  private apiUrl = 'https://localhost:7291/api/Maze/';
  constructor(private http: HttpClient) { }
  GetLaserTrajectory(inputText: string[]): Observable<any> {
    return this.http.post(this.apiUrl, inputText);
  }
}
