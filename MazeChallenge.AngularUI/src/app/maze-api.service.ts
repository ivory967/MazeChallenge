import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MazeApiService {

  private apiUrl = 'https://localhost:7291/api/Maze/GetLaserTrajectory';
  constructor(private http: HttpClient) { }
  GetLaserTrajectory(inputText: string[]): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.apiUrl, inputText, { headers });
  }
}
