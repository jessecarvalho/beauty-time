import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, RouterLink} from "@angular/router";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-third-step',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule
  ],
  templateUrl: './third-step.component.html',
  styleUrl: './third-step.component.scss'
})
export class ThirdStepComponent implements OnInit
{
  businessName: string = '';
  businessAddress: string = '';
  businessCity: string = '';
  businessState: string = '';
  businessZipCode: string = '';
  businessType: string = '';
  email: string = '';
  password: string = '';
  inputValidated: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params["businessName"])
      {
       this.businessName = params["businessName"];
      }
      if (params["businessAddress"])
      {
       this.businessAddress = params["businessAddress"];
      }
      if (params["businessCity"])
      {
       this.businessCity = params["businessCity"];
      }
      if (params["businessState"])
      {
       this.businessState = params["businessState"];
      }
         // Aqui você pode adicionar o código para realizar a ação desejada quando o formulário for válido.
   if (params["businessZipCode"])
      {
       this.businessZipCode = params["businessZipCode"];
      }
      if (params["email"])
      {
       this.email = params["email"];
      }
      if (params["businessType"])
      {
       this.businessType = params["businessType"];
      }
    })
  }
  onInputChange()
  {
    if (this.businessName && this.businessAddress && this.businessCity && this.businessState && this.businessZipCode && this.email && this.password)
    {
      this.inputValidated = true;
    }
    else
    {
      this.inputValidated = false;
    }
  }
  register() {
    if (this.inputValidated) {
      console.log('Formulário válido, realizando ação...');
    } else {
      console.log('Formulário inválido, por favor preencha todos os campos necessários.');
    }
  }
}
