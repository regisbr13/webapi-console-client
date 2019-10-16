import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ComputersComponent } from './computers/computers.component';
import { SchedulingsComponent } from './schedulings/schedulings.component';


const routes: Routes = [
  { path: 'computadores', component: ComputersComponent },
  { path: 'schedulings/:computerId', component: SchedulingsComponent},
  { path: 'comandos', component: SchedulingsComponent },
  { path: 'user/login', component: LoginComponent },
  { path: 'user/registration', component: RegistrationComponent },
  { path: '', redirectTo: 'user/login', pathMatch: 'full' },
  { path: '**', redirectTo: 'user/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

