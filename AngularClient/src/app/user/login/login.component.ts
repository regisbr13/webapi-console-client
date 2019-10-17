import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/Login.service';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  title = 'Login';
  user: User = {login: "", password: "", id: 0, computer: null};
  constructor(private loginService: LoginService, public router: Router, private toastr: ToastrService, private titleService: Title) { this.titleService.setTitle("Access Console"); }

  ngOnInit() {
    if (this.loginService.loggedIn()) {
      this.router.navigate(['/computadores']);
    } else {
      localStorage.removeItem('userId');
      this.router.navigate(['/user/login']);
    }
  }

  login() {
    this.loginService.login(this.user).subscribe(
      () => {
        this.router.navigate(['/computadores']);
      }, error => {
        this.toastr.error("Usuário ou senha inválidos"); ;
      }
    );
  }

}
