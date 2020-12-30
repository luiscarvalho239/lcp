import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { of as observableOf } from 'rxjs';

import { AdminUsersComponent } from './users.component';

xdescribe('AdminUsersComponent', () => {
  let component;
  let fixture;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminUsersComponent ],
      imports: [FormsModule, ReactiveFormsModule],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  // new test by ngentest
  it('should run GetterDeclaration #f', async () => {
    component.regUsersDataForm = component.regUsersDataForm || {};
    component.regUsersDataForm.controls = 'controls';
    const f = component.f;
    
  });
    
  // new test by ngentest
  it('should run #ngOnInit()', async () => {
    component.formBuilder = component.formBuilder || {};
    spyOn(component.formBuilder, 'group');
    component.f = component.f || {};
    component.f.image = {
      value: {}
    };
    component.fobj = component.fobj || {};
    component.fobj.src = 'src';
    component.ngOnInit();
    // expect(component.formBuilder.group).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #changeFile()', async () => {
    component.f = component.f || {};
    component.f.image = {
      setValue: function() {}
    };
    component.changeFile({}, {
      src: {}
    });
    
  });
    
  // new test by ngentest
  it('should run #resetForm()', async () => {
    component.regUsersDataForm = component.regUsersDataForm || {};
    spyOn(component.regUsersDataForm, 'reset');
    spyOn(component.regUsersDataForm, 'clearValidators');
    spyOn(component.regUsersDataForm, 'markAsPristine');
    component.f = component.f || {};
    component.f.image = {
      setValue: function() {},
      value: {}
    };
    component.resetForm({
      preventDefault: function() {}
    });
    // expect(component.regUsersDataForm.reset).toHaveBeenCalled();
    // expect(component.regUsersDataForm.clearValidators).toHaveBeenCalled();
    // expect(component.regUsersDataForm.markAsPristine).toHaveBeenCalled();
  });
    
  // new test by ngentest
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
      preventDefault: function() {}
    });
    // expect(component.authenticationService.register).toHaveBeenCalled();
  });
});
