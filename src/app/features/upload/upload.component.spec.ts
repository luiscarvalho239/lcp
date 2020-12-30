import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, throwError } from 'rxjs';

import { UploadComponent } from './upload.component';

xdescribe('UploadComponent', () => {
  let component;
  let fixture;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ FormsModule, ReactiveFormsModule ],
      declarations: [UploadComponent],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  // new test by ngentest
  it('should run #ngOnInit()', async () => {
    spyOn(component, 'emitData');
    component.fobjvar = component.fobjvar || {};
    component.fobjvar.type = 'type';
    component.fobjvar.src = 'src';
    component.ngOnInit();
    // expect(component.emitData).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #emitData()', async () => {
    component.changeFile = component.changeFile || {};
    spyOn(component.changeFile, 'emit');
    component.emitData({}, {});
    // expect(component.changeFile.emit).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #onFileSelect()', async () => {
    spyOn(component, 'emitData');
    component.fobjvar = component.fobjvar || {};
    component.fobjvar.type = 'type';
    spyOn(component, 'upload');
    component.onFileSelect({
      target: {
        files: {
          0: {},
          length: {}
        }
      }
    });
    // expect(component.emitData).toHaveBeenCalled();
    // expect(component.upload).toHaveBeenCalled();
  });
});
