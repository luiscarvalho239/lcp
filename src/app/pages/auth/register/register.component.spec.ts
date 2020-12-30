// tslint:disable
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, throwError } from 'rxjs';

import { Component } from '@angular/core';
import { RegisterComponent } from './register.component';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '@app/services/authentication.service';
import { HttpClientModule } from '@angular/common/http';

@Injectable()
class MockRouter {
  navigate = function () { };
}

@Injectable()
class MockFB {
  group() { };
}

@Injectable()
class MockAuthService {
}

xdescribe('RegisterComponent', () => {
  let fixture;
  let component;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
      declarations: [RegisterComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
      providers: [
        { provide: FormBuilder, useClass: MockFB },
        { provide: Router, useClass: MockRouter },
        { provide: AuthenticationService, useClass: MockAuthService }
      ]
    }).overrideComponent(RegisterComponent, {

    }).compileComponents();
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
  });

  afterEach(() => {
    component.ngOnDestroy = function () { };
    fixture.destroy();
  });

  it('should run #constructor()', async () => {
    expect(component).toBeTruthy();
  });

  it('should run GetterDeclaration #f', async () => {
    component.regForm = component.regForm || {};
    component.regForm.controls = 'controls';
    let f = component.f || {};
    f = {
      get: function () { }
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

  it('should run #resetForm()', async () => {
    component.regForm = {
      reset: function () { },
      clearValidators: function () { },
      markAsPristine: function () { }
    };
    spyOn(component.regForm, 'reset');
    spyOn(component.regForm, 'clearValidators');
    spyOn(component.regForm, 'markAsPristine');

    component.f = component.f || {};
    component.f.image = {
      setValue: function () { }
    };
    component.resetForm({
      preventDefault: function () { }
    });
    expect(component.regForm.reset).toHaveBeenCalled();
    expect(component.regForm.clearValidators).toHaveBeenCalled();
    expect(component.regForm.markAsPristine).toHaveBeenCalled();
  });

  it('should run #onSubmit()', async () => {
    component.f = component.f || {};
    component.f.username = {
      value: {}
    };
    component.f.password = {
      value: {}
    };
    component.f.email = {
      value: {}
    };
    component.f.firstName = {
      value: {}
    };
    component.f.lastName = {
      value: {}
    };
    component.f.image = {
      value: {}
    };
    component.authenticationService = component.authenticationService || {};
    spyOn(component.authenticationService, 'register').and.returnValue(observableOf({}));
    component.onSubmit({
      preventDefault: function () { }
    });
    expect(component.authenticationService.register).toHaveBeenCalled();
  });

});
