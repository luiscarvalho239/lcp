// tslint:disable
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, throwError } from 'rxjs';

import { Component } from '@angular/core';
import { ListsApiComponent } from './lists_api.component';
import { GeralService } from 'src/app/services/geral.service';

@Injectable()
class MockGeralService {
  getInfoByApi() {};
  getAllInfo() {};
}

describe('ListsApiComponent', () => {
  let fixture;
  let component;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, ReactiveFormsModule ],
      declarations: [ListsApiComponent],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ],
      providers: [
        { provide: GeralService, useClass: MockGeralService }
      ]
    }).overrideComponent(ListsApiComponent, {

    }).compileComponents();
    fixture = TestBed.createComponent(ListsApiComponent);
    component = fixture.componentInstance;
  });

  afterEach(() => {
    component.ngOnDestroy = function() {};
    fixture.destroy();
  });

  it('should run #constructor()', async () => {
    expect(component).toBeTruthy();
  });

  it('should run #ngAfterViewInit()', async () => {

    component.ngAfterViewInit();

  });

  it('should run #ngOnInit()', async () => {
    component.myServsServ = component.myServsServ || {};
    spyOn(component.myServsServ, 'getAllInfo').and.returnValue(observableOf({}));
    component.apiItemsAry = component.apiItemsAry || {};
    spyOn(component.apiItemsAry, 'push');
    component.ngOnInit();
    expect(component.myServsServ.getAllInfo).toHaveBeenCalled();
    expect(component.apiItemsAry.push);
  });

  it('should run #onChangeApiSel()', async () => {
    component.myServsServ = component.myServsServ || {};
    spyOn(component.myServsServ, 'getInfoByApi').and.returnValue(observableOf({}));
    component.dataSource = component.dataSource || {};
    component.dataSource.sort = 'sort';
    component.dataSource.paginator = 'paginator';
    component.dsApiCols = component.dsApiCols || {};
    spyOn(component.dsApiCols, 'push');
    component.onChangeApiSel({
      value: {}
    });
    expect(component.myServsServ.getInfoByApi).toHaveBeenCalled();
    expect(component.dsApiCols.push);
  });

});
