import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { of as observableOf } from 'rxjs';

import { AdminNewsComponent } from './news.component';

xdescribe('AdminNewsComponent', () => {
  let component;
  let fixture;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminNewsComponent ],
      imports: [FormsModule, ReactiveFormsModule],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  // new test by ngentest
  it('should run GetterDeclaration #f', async () => {
    component.newsDataForm = component.newsDataForm || {};
    component.newsDataForm.controls = 'controls';
    const f = component.f;
    
  });
    
  // new test by ngentest
  it('should run #ngOnInit()', async () => {
    spyOn(component, 'initNewsData');
    component.ngOnInit();
    // expect(component.initNewsData).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #getDateToday()', async () => {
    
    component.getDateToday();
    
  });
    
  // new test by ngentest
  it('should run #initNewsData()', async () => {
    component.fb = component.fb || {};
    spyOn(component.fb, 'group');
    spyOn(component, 'getDateToday');
    component.f = component.f || {};
    component.f.cover = {
      value: {}
    };
    component.f.source = {
      setValue: function() {}
    };
    component.fobj = component.fobj || {};
    component.fobj.src = 'src';
    component.newsSrv = component.newsSrv || {};
    spyOn(component.newsSrv, 'ObsGetNews').and.returnValue(observableOf({
      length: {}
    }));
    component.initNewsData();
    // expect(component.fb.group).toHaveBeenCalled();
    // expect(component.getDateToday).toHaveBeenCalled();
    // expect(component.newsSrv.ObsGetNews).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #changeFile()', async () => {
    component.f = component.f || {};
    component.f.cover = {
      setValue: function() {}
    };
    component.changeFile({}, {
      src: {}
    });
    
  });
    
  // new test by ngentest
  it('should run #onSubmit()', async () => {
    component.f = component.f || {};
    component.f.title = {
      value: {}
    };
    component.f.desc = {
      value: {}
    };
    component.f.date = {
      value: {}
    };
    component.f.cover = {
      value: {}
    };
    component.f.category = {
      value: {}
    };
    component.f.text = {
      value: {}
    };
    component.f.source = {
      value: {}
    };
    component.f.usersId = {
      value: {}
    };
    component.newsSrv = component.newsSrv || {};
    spyOn(component.newsSrv, 'insertNews').and.returnValue(observableOf({}));
    component.onSubmit({
      preventDefault: function() {}
    });
    // expect(component.newsSrv.insertNews).toHaveBeenCalled();
  });
});
