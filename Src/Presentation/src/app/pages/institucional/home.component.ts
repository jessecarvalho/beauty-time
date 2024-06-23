import { Component } from '@angular/core';
import { HeaderComponent } from "../../components/header/header.component";
import { FooterComponent } from "../../components/footer/footer.component";
import { ButtonModule } from 'primeng/button';
import {FaIconComponent} from "@fortawesome/angular-fontawesome";
import { faCalendar, faHandshake } from "@fortawesome/free-regular-svg-icons";
import { faRankingStar } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-institucional',
  standalone: true,
    imports: [
        HeaderComponent,
        FooterComponent,
        ButtonModule,
        FaIconComponent
    ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
    faCalendar = faCalendar;
    faHandshake = faHandshake;
    faRankingStar = faRankingStar;
}
