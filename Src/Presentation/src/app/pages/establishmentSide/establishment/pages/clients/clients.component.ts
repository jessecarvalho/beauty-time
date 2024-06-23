import { Component } from '@angular/core';
import {FooterComponent} from "../../components/footer/footer.component";
import {HeaderComponent} from "../../components/header/header.component";
import {LeftSidebarComponent} from "../../components/left-sidebar/left-sidebar.component";
import {SharedModule} from "primeng/api";
import {TableModule} from "primeng/table";
import {FaIconComponent} from "@fortawesome/angular-fontawesome";
import {faPersonDigging} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-clients',
  standalone: true,
    imports: [
        FooterComponent,
        HeaderComponent,
        LeftSidebarComponent,
        SharedModule,
        TableModule,
        FaIconComponent
    ],
  templateUrl: './clients.component.html',
  styleUrl: './clients.component.scss'
})
export class ClientsComponent {

  protected readonly faPersonDigging = faPersonDigging;
}
