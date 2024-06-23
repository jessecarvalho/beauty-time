import { Component } from '@angular/core';
import {FooterComponent} from "../../components/footer/footer.component";
import {HeaderComponent} from "../../components/header/header.component";
import {LeftSidebarComponent} from "../../components/left-sidebar/left-sidebar.component";
import {SharedModule} from "primeng/api";
import {TableModule} from "primeng/table";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import { faPersonDigging } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-appointments',
  standalone: true,
    imports: [
        FooterComponent,
        HeaderComponent,
        LeftSidebarComponent,
        SharedModule,
        TableModule,
        FontAwesomeModule
    ],
  templateUrl: './appointments.component.html',
  styleUrl: './appointments.component.scss'
})
export class AppointmentsComponent {
  faPersonDigging = faPersonDigging;
  constructor() { }

}
