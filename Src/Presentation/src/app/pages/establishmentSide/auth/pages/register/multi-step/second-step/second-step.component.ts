import {Component, OnInit} from '@angular/core';
import {FileUploadModule} from "primeng/fileupload";
import {ActivatedRoute, RouterLink} from "@angular/router";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-second-step',
  standalone: true,
  imports: [
    FileUploadModule,
    RouterLink,
    FormsModule
  ],
  templateUrl: './second-step.component.html',
  styleUrl: './second-step.component.scss'
})
export class SecondStepComponent implements OnInit
{
  businessName: string = '';
  businessAddress: string = '';
  businessCity: string = '';
  businessState: string = '';
  businessZipCode: string = '';
  businessType: string = '';
  email: string = '';
  inputValidated: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void
  {
    this.route.queryParams.subscribe(params => {
      if (params['businessType'])
      {
        this.businessType = params['businessType'];
      }
      if (params['businessName'])
      {
        this.businessName = params['businessName'];
      }
      if (params['businessAddress'])
      {
        this.businessAddress = params['businessAddress'];
      }
      if (params['businessCity'])
      {
        this.businessCity = params['businessCity'];
      }
      if (params['businessState'])
      {
        this.businessState = params['businessState'];
      }
      if (params['businessZipCode'])
      {
        this.businessZipCode = params['businessZipCode'];
      }
      if (params['email'])
      {
        this.email = params['email'];
      }
      if (this.businessName && this.businessAddress && this.businessCity && this.businessState && this.businessZipCode)
      {
        this.inputValidated = true;
      }
    });
  }

  onInputChange()
  {
    if (this.businessName && this.businessAddress && this.businessCity && this.businessState && this.businessZipCode)
    {
      this.inputValidated = true;
    }
    else
    {
      this.inputValidated = false;
    }
  }
}
