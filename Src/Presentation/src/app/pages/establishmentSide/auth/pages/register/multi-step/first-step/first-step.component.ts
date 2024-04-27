import { Component } from '@angular/core';
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-first-step',
  standalone: true,
  templateUrl: './first-step.component.html',
  imports: [
    RouterLink,
    FormsModule
  ],
  styleUrls: ['./first-step.component.scss']
})
export class FirstStepComponent {
  businessType: string = '';
  businessName: string = '';
  businessAddress: string = '';
  businessCity: string = '';
  businessState: string = '';
  businessZipCode: string = '';
  email: string = '';
  isNextButtonDisabled: boolean = true;

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() : void {
    this.route.queryParams.subscribe(params => {
      if (params['businessType']) {
        this.businessType = params['businessType'];
      }
      if (params['businessName']) {
        this.businessName = params['businessName'];
      }
      if (params['businessAddress']) {
        this.businessAddress = params['businessAddress'];
      }
      if (params['businessCity']) {
        this.businessCity = params['businessCity'];
      }
      if (params['businessState']) {
        this.businessState = params['businessState'];
      }
      if (params['businessZipCode']) {
        this.businessZipCode = params['businessZipCode'];
      }
      if (params['email']) {
        this.email = params['email'];
      }

    })
  }

  onSelectionChange() {
    this.isNextButtonDisabled = !this.businessType;
  }
  navigateToNextPage() {
    if (this.businessType) {
      this.router.navigate(['/establishment/register/second-step'], { queryParams: { businessType: this.businessType } });
    }
  }
}
