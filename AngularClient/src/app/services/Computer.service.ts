import { Injectable } from '@angular/core';
import { Computer } from '../models/Computer';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {

  baseURL = 'api/computers/';
  constructor(private http: HttpClient) { }

  getAllComputers(): Observable<Computer[]> {	
    const userId = localStorage.getItem('userId'); 			  		
    return this.http.get<Computer[]>(`${this.baseURL}${userId}`);       
  }

  deleteComputer(id: number) {
    return this.http.delete(`${this.baseURL}${id}`);  
  }
}
