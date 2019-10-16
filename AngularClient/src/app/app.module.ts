import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { NavComponent } from './shared/nav/nav.component';
import { LoginComponent } from './user/login/login.component';
import { UserComponent } from './user/user.component';
import { TitleComponent } from './shared/title/title.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ComputersComponent } from './computers/computers.component';
import { SchedulingsComponent } from './schedulings/schedulings.component';
import { BsDatepickerModule, ModalModule, TooltipModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxNavbarModule } from 'ngx-bootstrap-navbar';

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
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      ToastrModule.forRoot(),
      BsDatepickerModule.forRoot(),
      BrowserAnimationsModule,
      NgxNavbarModule,
      ModalModule.forRoot(),
      TooltipModule.forRoot(),
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
