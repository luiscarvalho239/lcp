import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '@app/services/authentication.service';

/* istanbul ignore next */
@Component({
  selector: 'app-ausers',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class AdminUsersComponent implements OnInit {
  regUsersDataForm: FormGroup;
  submitted: boolean;
  msg: string;
  fobj: any = {type: 'image', src: ''};

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService
  ) {
  }

  ngOnInit() {
    this.regUsersDataForm = this.formBuilder.group({
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
    if (this.regUsersDataForm) {
      return this.regUsersDataForm.controls; 
    }
  }

  changeFile(event: any) {
    this.fobj = event;
    this.f.image.setValue(this.fobj.src);
  }

  resetForm(event: any) {
    event.preventDefault();

    this.regUsersDataForm.reset();
    this.regUsersDataForm.clearValidators();
    this.regUsersDataForm.markAsPristine();
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
        location.href = location.href;
      }, 60 * 2 * 1000);
    }, (err) => { this.msg = err; });
  }
}
