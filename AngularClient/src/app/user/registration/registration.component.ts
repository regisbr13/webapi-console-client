import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/User';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoginService } from 'src/app/services/Login.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registerForm: FormGroup;
  user: User = new User();              

  constructor(private formBuilder: FormBuilder, private loginService: LoginService, public router: Router, private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.validation();
  }

  validation() {
    this.registerForm = this.formBuilder.group({
      login: ['', Validators.required],
      passwords: this.formBuilder.group({    
        password: ['', [Validators.required, Validators.minLength(4)]],
        confirmPassword: ['', Validators.required]
      }, { validator: this.compararSenhas })
    });
  }

  compararSenhas(fb: FormGroup) {                          
    const testarSenha = fb.get('confirmPassword');         
    if (testarSenha.errors == null || 'mismatch' in testarSenha.errors) {     
      if (fb.get('password').value !== testarSenha.value) { 
        testarSenha.setErrors({ mismatch: true});           
      } else {
        testarSenha.setErrors(null);    
      }
    }
  }

  cadastrarUsuario() {
    if (this.registerForm.valid) {
      this.user.login = this.registerForm.get('login').value;
      this.user.password = this.registerForm.get('passwords.password').value;
      this.loginService.register(this.user).subscribe(   
        () => {
          this.loginService.login(this.user);
          this.router.navigate(['/computers']); 
          this.toastr.success('Cadastro realizado com sucesso');         
        }, response => {                                     
            this.toastr.error(response.error); 
        }
      );
    }
  }
}

