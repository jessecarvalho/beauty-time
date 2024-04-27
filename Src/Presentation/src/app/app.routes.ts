import { Routes } from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {ServiceComponent} from "./pages/appointments/service/service.component";
import {ScheduleComponent} from "./pages/appointments/schedule/schedule.component";
import {ConfirmationComponent} from "./pages/appointments/confirmation/confirmation.component";
import {HomeComponent as HomeEstablishmentComponent} from "./pages/establishment/management/pages/home/home.component";
import {LoginComponent} from "./pages/establishment/auth/login/login.component";
import {FirstStepComponent} from "./pages/establishment/auth/register/multi-step/first-step/first-step.component";
import {SecondStepComponent} from "./pages/establishment/auth/register/multi-step/second-step/second-step.component";
import {ThirdStepComponent} from "./pages/establishment/auth/register/multi-step/third-step/third-step.component";


export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'establishment',
    children: [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: FirstStepComponent },
    { path: 'register/second-step', component: SecondStepComponent },
    { path: 'register/third-step', component: ThirdStepComponent },
    { path: '' , component: HomeEstablishmentComponent },

  ]},
  {
    path: 'appointments',
    children: [
      { path: ':establishmentPermalink/:serviceId' , component: ServiceComponent },
      { path: ':establishmentPermalink/:serviceId/schedule' , component: ScheduleComponent },
      { path: ':establishmentPermalink/:serviceId/confirmation' , component: ConfirmationComponent}
    ]
  },
];
