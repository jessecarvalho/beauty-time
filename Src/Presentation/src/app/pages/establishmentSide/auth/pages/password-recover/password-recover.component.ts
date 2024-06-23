import {Component, OnInit} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {ActivatedRoute, RouterLink} from "@angular/router";

@Component({
  selector: 'app-password-recover',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    RouterLink,
    FormsModule
  ],
  templateUrl: './password-recover.component.html',
  styleUrl: './password-recover.component.scss'
})

export class PasswordRecoverComponent implements OnInit
{
  password_confirmation: string = '';
  password: string = '';
  inputValidated: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['password_confirmation'])
      {
        this.password_confirmation = params['password_confirmation'];
      }
      if (params['password'])
      {
        this.password = params['password'];
      }
    })
  }

  onInputChange(): void {
    if (this.password_confirmation && this.password)
    {
      this.inputValidated = true;
    }
    else
    {
      this.inputValidated = false;
    }
  }
}
