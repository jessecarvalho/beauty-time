import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { faHome, faUser, faSignOutAlt, faCalendar, faStar, faPerson, faCheck, faChair, faShop, faBell } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-left-sidebar',
  standalone: true,
  imports: [
    RouterLink,
    FontAwesomeModule,
  ],
  templateUrl: './left-sidebar.component.html',
  styleUrl: './left-sidebar.component.scss'
})
export class LeftSidebarComponent {
  faHome = faHome;
  faUser = faUser;
  faSignOutAlt = faSignOutAlt;
  faCalendar = faCalendar;
  faStar = faStar;
  faPerson = faPerson;
  faCheck = faCheck;
  faChair = faChair;
  faShop = faShop;
  faBell = faBell;
  constructor() { }

}
