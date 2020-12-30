import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '@app/services/authentication.service';

/* istanbul ignore next */
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted: boolean;
  msg: string;
  uName: string = localStorage.getItem('currentUser');

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/main']);
    }
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get f() { 
    if (this.loginForm) {
      return this.loginForm.controls;
    }
  }

  onSubmit(event: any) {
    event.preventDefault();
    this.submitted = true;

    if (this.loginForm.invalid) {
      console.log('invalid')
      return;
    }

    this.authenticationService.login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe({
        next: (r) => {
          if (r) {
            if (r.username == this.f.username.value) {
              this.msg = 'Logged as ' + r.username;
              setTimeout(() => {
                location.href = '/main';
              }, 0.5 * 1000);
            } else {
              this.msg = 'Error: The account of user ' + this.f.username.value + ' does not exist!';
            }
          } else {
            this.msg = 'Error: The account of user ' + this.f.username.value + ' does not exist!';
          }
        },
        error: (error) => {
          this.msg = 'Error: ' + error;
        }
      });
  }
}
