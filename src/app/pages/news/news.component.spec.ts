// tslint:disable
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, throwError } from 'rxjs';

import { Component } from '@angular/core';
import { NewsComponent } from './news.component';
import { NewsService } from 'src/app/services/news.service';
import { Router } from '@angular/router';

@Injectable()
class MockNewsService {
  ObsGetNews() {};
}

@Injectable()
class MockRouter {
  navigate() {};
}

describe('NewsComponent', () => {
  let fixture;
  let component;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, ReactiveFormsModule ],
      declarations: [NewsComponent],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ],
      providers: [
        { provide: NewsService, useClass: MockNewsService },
        { provide: Router, useClass: MockRouter }
      ]
    }).overrideComponent(NewsComponent, {

    }).compileComponents();
    fixture = TestBed.createComponent(NewsComponent);
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
    component.newsServ = component.newsServ || {};
    spyOn(component.newsServ, 'ObsGetNews');
    component.ngOnInit();
    // expect(component.newsServ.ObsGetNews).toHaveBeenCalled();
  });

  it('should run #gotoItems()', async () => {
    component.router = component.router || {};
    spyOn(component.router, 'navigate');
    component.gotoItems({});
    // expect(component.router.navigate).toHaveBeenCalled();
  });

});
