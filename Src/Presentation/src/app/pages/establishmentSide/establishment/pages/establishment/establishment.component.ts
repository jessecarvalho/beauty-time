import { Component } from '@angular/core';
import {FaIconComponent} from "@fortawesome/angular-fontawesome";
import {FooterComponent} from "../../components/footer/footer.component";
import {HeaderComponent} from "../../components/header/header.component";
import {LeftSidebarComponent} from "../../components/left-sidebar/left-sidebar.component";
import {faPersonDigging} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-establishmentSide',
  standalone: true,
    imports: [
        FaIconComponent,
        FooterComponent,
        HeaderComponent,
        LeftSidebarComponent
    ],
  templateUrl: './establishment.component.html',
  styleUrl: './establishment.component.scss'
})
export class EstablishmentComponent {

  protected readonly faPersonDigging = faPersonDigging;
}
