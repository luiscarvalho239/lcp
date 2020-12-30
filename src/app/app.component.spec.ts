// tslint:disable
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, throwError } from 'rxjs';

import { Component } from '@angular/core';
import { AppComponent } from './app.component';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Injectable()
class MockRouter {
  navigate() {};
}

@Injectable()
class MockAuthenticationService {
  logout() {};
  currentUser = observableOf({});
}

describe('AppComponent', () => {
  let fixture;
  let component;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, ReactiveFormsModule ],
      declarations: [AppComponent],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ],
      providers: [
        Location,
        { provide: Router, useClass: MockRouter },
        { provide: AuthenticationService, useClass: MockAuthenticationService }
      ]
    }).overrideComponent(AppComponent, {

    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;

  });

  afterEach(() => {
    component.ngOnDestroy = function() {};
    fixture.destroy();
  });

  it('should run #constructor()', async () => {
    expect(component).toBeTruthy();
  });

  it('should run #ngOnInit()', async () => {

    component.ngOnInit();

  });

  it('should run #ngOnDestroy()', async () => {

    component.ngOnDestroy();

  });

  it('should run #setPartsAllowed()', async () => {
    component.router = component.router || {};
    component.router.config = {
      0: {
        path: {}
      },
      map: function() {
        return [
          {
            "path": {}
          }
        ];
      }
    };
    component.setPartsAllowed();

  });

  it('should run #logout()', async () => {
    component.authenticationService = component.authenticationService || {};
    spyOn(component.authenticationService, 'logout');
    component.router = component.router || {};
    spyOn(component.router, 'navigate');
    component.logout();
    expect(component.authenticationService.logout).toHaveBeenCalled();
    expect(component.router.navigate).toHaveBeenCalled();
  });

});
