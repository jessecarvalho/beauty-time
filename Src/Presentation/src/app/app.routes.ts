import { Routes } from '@angular/router';
import {HomeComponent} from "./pages/institucional/home.component";
import {ServiceComponent} from "./pages/clientSide/service/service.component";
import {ScheduleComponent} from "./pages/clientSide/schedule/schedule.component";
import {ConfirmationComponent} from "./pages/clientSide/confirmation/confirmation.component";
import {HomeComponent as HomeEstablishmentComponent} from "./pages/establishmentSide/establishment/pages/home/home.component";
import {LoginComponent} from "./pages/establishmentSide/auth/pages/login/login.component";
import {FirstStepComponent} from "./pages/establishmentSide/auth/pages/register/multi-step/first-step/first-step.component";
import {SecondStepComponent} from "./pages/establishmentSide/auth/pages/register/multi-step/second-step/second-step.component";
import {ThirdStepComponent} from "./pages/establishmentSide/auth/pages/register/multi-step/third-step/third-step.component";
import {CalendarComponent} from "./pages/establishmentSide/establishment/pages/calendar/calendar.component";
import {ClientsComponent} from "./pages/establishmentSide/establishment/pages/clients/clients.component";


export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'establishment',
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: FirstStepComponent },
      { path: 'register/second-step', component: SecondStepComponent },
      { path: 'register/third-step', component: ThirdStepComponent },
      { path: '' , component: HomeEstablishmentComponent },
      { path: 'business', component: HomeEstablishmentComponent},
      { path: 'appointments', component: HomeEstablishmentComponent},
      { path: 'services' , component: ServiceComponent },
      { path: 'services/:serviceId' , component: ServiceComponent },
      { path: 'calendar' , component: CalendarComponent },
      { path: 'clients', component: ClientsComponent}

  ]},
  {
    path: 'client',
    children: [
      { path: ':establishmentPermalink/:serviceId' , component: ServiceComponent },
      { path: ':establishmentPermalink/:serviceId/schedule' , component: ScheduleComponent },
      { path: ':establishmentPermalink/:serviceId/confirmation' , component: ConfirmationComponent}
    ]
  },
];
