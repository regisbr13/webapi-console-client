import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavComponent } from './shared/nav/nav.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ComputersComponent } from './computers/computers.component';
import { TitleComponent } from './shared/title/title.component';
import { UserComponent } from './user/user.component';
import { SchedulingsComponent } from './schedulings/schedulings.component';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule, TooltipModule, ModalModule } from 'ngx-bootstrap';
import { NgxNavbarModule } from 'ngx-bootstrap-navbar';
import { AuthGuard } from './auth/auth.guard';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    UserComponent,
    TitleComponent,
    RegistrationComponent,
    ComputersComponent,
    SchedulingsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'computadores', component: ComputersComponent, canActivate: [AuthGuard]},
      { path: 'schedulings/:computerId', component: SchedulingsComponent, canActivate: [AuthGuard]},
      { path: 'comandos', component: SchedulingsComponent, canActivate: [AuthGuard] },
  { path: 'user/login', component: LoginComponent },
  { path: 'user/registration', component: RegistrationComponent },
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: '**', component: LoginComponent, pathMatch: 'full' }
    ]),
    ToastrModule.forRoot({
      progressBar: true
    }),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,
    NgxNavbarModule,
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
