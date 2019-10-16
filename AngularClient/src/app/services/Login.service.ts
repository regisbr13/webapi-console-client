import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { map } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class LoginService {
    baseURL = 'http://localhost:5000/api/users/';
    constructor(private http: HttpClient) { }

    login(user: User) {
    return this.http.post(`${this.baseURL}login`, user).pipe(
            map((response: any) => {
                if (response) {
                    localStorage.setItem('username', user.login)
                    localStorage.setItem('userId', response);
                    console.log(user);
                }
            })
        );
    }

    register(user: User) {
        return this.http.post(`${this.baseURL}register`, user);
      }

    loggedIn() {
        const userId = localStorage.getItem('userId');
        if (userId != null) { return true; }
        return false;
      }
}
