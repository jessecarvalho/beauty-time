import {Component, OnInit} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {ActivatedRoute, RouterLink} from "@angular/router";

@Component({
  selector: 'app-forget-password',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './forget-password.component.html',
  styleUrl: './forget-password.component.scss'
})
export class ForgetPasswordComponent implements OnInit
{
  email: string = '';
  inputValidated: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
  this.route.queryParams.subscribe(params => {
    if (params['email'])
    {
      this.email = params['password'];
    }
  })
}

  onInputChange(): void {
  if (this.email)
  {
    this.inputValidated = true;
  }
else
  {
    this.inputValidated = false;
  }
}
}

