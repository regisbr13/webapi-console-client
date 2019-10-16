import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/Login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public loginService: LoginService, public router: Router) { }

  ngOnInit() {
  }

  loggedIn() {
    return this.loginService.loggedIn();
  }

  logout() {
    localStorage.removeItem('userId');
    localStorage.removeItem('username');
    this.router.navigate(['/user/login']);
  }

  registrar() {
    this.router.navigate(['/user/registration']);
  }

  entrar() {
    this.router.navigate(['/user/login']);
  }

  userName() {
    return localStorage.getItem('username');
  }

}
