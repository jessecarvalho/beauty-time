import { Component } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { FooterComponent } from '../../components/footer/footer.component';
import { LeftSidebarComponent} from "../../components/left-sidebar/left-sidebar.component";
import {TableModule} from "primeng/table";

@Component({
  selector: 'app-institucional',
  standalone: true,
  imports: [
    HeaderComponent,
    FooterComponent,
    LeftSidebarComponent,
    TableModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {

}
