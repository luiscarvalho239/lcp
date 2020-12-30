// tslint:disable
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, throwError } from 'rxjs';

import { Component } from '@angular/core';
import { LoginComponent } from './login.component';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '@app/services/authentication.service';
import { HttpClientModule } from '@angular/common/http';

@Injectable()
class MockRouter {
  navigate = function() {};
}

xdescribe('LoginComponent', () => {
  let fixture;
  let component;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, ReactiveFormsModule, HttpClientModule ],
      declarations: [LoginComponent],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ],
      providers: [
        FormBuilder,
        { provide: Router, useClass: MockRouter },
        AuthenticationService
      ]
    }).overrideComponent(LoginComponent, {

    }).compileComponents();
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
  });

  afterEach(() => {
    component.ngOnDestroy = function() {};
    fixture.destroy();
  });

  it('should run #constructor()', async () => {
    expect(component).toBeTruthy();
  });

  it('should run GetterDeclaration #f', async () => {
    component.loginForm = component.loginForm || {};
    component.loginForm.controls = 'controls';
    let f = component.f || {};
    f = {
      get: function() {}
    };
    spyOn(f, 'get');
    expect(f);
  });

  it('should run #ngOnInit()', async () => {
    component.formBuilder = component.formBuilder || {};
    spyOn(component.formBuilder, 'group');
    component.ngOnInit();
    expect(component.formBuilder.group).toHaveBeenCalled();
  });

  it('should run #onSubmit()', async () => {
    component.loginForm = component.loginForm || {};
    component.loginForm.invalid = 'invalid';
    component.authenticationService = component.authenticationService || {};
    spyOn(component.authenticationService, 'login').and.returnValue(observableOf({}));
    component.f = component.f || {};
    component.f.username = {
      value: {}
    };
    component.f.password = {
      value: {}
    };
    component.onSubmit({
      preventDefault: function() {}
    });
    expect(component.authenticationService.login).toHaveBeenCalled();
  });

});
