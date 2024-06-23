import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordRecoverComponent } from './password-recover.component';

describe('PasswordRecoverComponent', () => {
  let component: PasswordRecoverComponent;
  let fixture: ComponentFixture<PasswordRecoverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PasswordRecoverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PasswordRecoverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
