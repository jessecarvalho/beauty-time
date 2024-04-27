import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, RouterLink} from "@angular/router";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit
{
  email: string = '';
  password: string = '';
  inputValidated: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['email'])
      {
        this.email = params['email'];
      }
      if (params['password'])
      {
        this.password = params['password'];
      }
    })
  }

  onInputChange(): void {
    if (this.email && this.password)
    {
      this.inputValidated = true;
    }
    else
    {
      this.inputValidated = false;
    }
  }
}
