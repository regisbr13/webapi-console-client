import { Injectable } from '@angular/core';
import { Scheduling } from '../models/Scheduling';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchedulingService {
  baseURL = 'http://localhost:5000/api/schedulings/';
  constructor(private http: HttpClient) { }

  postScheduling(scheduling: Scheduling) {
    return this.http.post(this.baseURL, scheduling);
  }

  getScheduling(id: number): Observable<Scheduling> {
    return this.http.get<Scheduling>(`${this.baseURL}getbyid/${id}`);
  }

  getSchedulings(computerId: number): Observable<Scheduling[]> {
    return this.http.get<Scheduling[]>(`${this.baseURL}${computerId}`);
  }

  deleteScheduling(id: number) {
    return this.http.delete(`${this.baseURL}${id}`);  
  }
}
