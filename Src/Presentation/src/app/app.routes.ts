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
import {ReviewsComponent} from "./pages/establishmentSide/establishment/pages/reviews/reviews.component";
import {ServicesComponent as HomeServiceComponent} from "./pages/establishmentSide/establishment/pages/services/services.component";
import {BusinessComponent} from "./pages/establishmentSide/establishment/pages/business/business.component";
import {AppointmentsComponent} from "./pages/establishmentSide/establishment/pages/appointments/appointments.component";
import {PasswordRecoverComponent} from "./pages/establishmentSide/auth/pages/password-recover/password-recover.component";
import {ForgetPasswordComponent} from "./pages/establishmentSide/auth/pages/forget-password/forget-password.component";


export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'establishment',
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: FirstStepComponent },
      { path: 'password-recover', component: PasswordRecoverComponent },
      { path: 'forget-password', component: ForgetPasswordComponent },
      { path: 'register/second-step', component: SecondStepComponent },
      { path: 'register/third-step', component: ThirdStepComponent },
      { path: '' , component: HomeEstablishmentComponent },
      { path: 'business', component: BusinessComponent},
      { path: 'appointments', component: AppointmentsComponent},
      { path: 'calendar' , component: CalendarComponent },
      { path: 'clients', component: ClientsComponent},
      { path: 'reviews', component: ReviewsComponent},
      { path: 'services', component: HomeServiceComponent},
      { path: 'services/:serviceId' , component: ServiceComponent },
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
