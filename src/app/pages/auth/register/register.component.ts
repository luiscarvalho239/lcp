import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '@app/services/authentication.service';

/* istanbul ignore next */
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  regForm: FormGroup;
  submitted: boolean;
  msg: string;
  fobj: any = {type: 'image', src: ''};

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.regForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      email: [''],
      firstName: [''],
      lastName: [''],
      image: ['guest.png']
    });

    this.fobj.src = this.f.image.value;
  }

  get f() { 
    if (this.regForm) {
      return this.regForm.controls; 
    }
  }

  changeFile(event: any) {
    this.fobj = event;
    this.f.image.setValue(this.fobj.src);
  }

  resetForm(event: any) {
    event.preventDefault();

    this.regForm.reset();
    this.regForm.clearValidators();
    this.regForm.markAsPristine();
    this.f.image.setValue('guest.png');
    this.fobj = {type: 'image', src: this.f.image.value};
  }

  onSubmit(event: any) {
    event.preventDefault();
    this.submitted = true;

    const obj = { 
      username: this.f.username.value, 
      password: this.f.password.value, 
      email: this.f.email.value, 
      role: 'user', 
      firstName: this.f.firstName.value, 
      lastName: this.f.lastName.value,
      image: 'https://localhost:5001/resources/images/'+this.f.image.value
    };

    this.authenticationService.register(obj).subscribe(res => {
      this.msg = 'User ' + this.f.username.value + ' has been registered';
      setTimeout(() => {
        location.href = '/login';
      }, 0.5 * 1000);
    }, (err) => { this.msg = err; });
  }
}
