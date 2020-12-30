import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { of as observableOf } from 'rxjs';

import { AdminVideosComponent } from './videos.component';

xdescribe('AdminVideosComponent', () => {
  let component;
  let fixture;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminVideosComponent ],
      imports: [FormsModule, ReactiveFormsModule],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminVideosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  // new test by ngentest
  it('should run GetterDeclaration #f', async () => {
    component.regVideosDataForm = component.regVideosDataForm || {};
    component.regVideosDataForm.controls = 'controls';
    const f = component.f;
    
  });
    
  // new test by ngentest
  it('should run #ngOnInit()', async () => {
    component.formBuilder = component.formBuilder || {};
    spyOn(component.formBuilder, 'group');
    component.f = component.f || {};
    component.f.src = {
      value: {}
    };
    component.fobj = component.fobj || {};
    component.fobj.src = 'src';
    spyOn(component, 'loadPlayer');
    component.ngOnInit();
    // expect(component.formBuilder.group).toHaveBeenCalled();
    // expect(component.loadPlayer).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #loadPlayer()', async () => {
    component.target = component.target || {};
    component.target.nativeElement = 'nativeElement';
    component.f = component.f || {};
    component.f.type = {
      value: {}
    };
    component.f.src = {
      value: {}
    };
    component.loadPlayer();
    
  });
    
  // new test by ngentest
  it('should run #ngOnDestroy()', async () => {
    component.player = component.player || {};
    spyOn(component.player, 'dispose');
    component.ngOnDestroy();
    // expect(component.player.dispose).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #changeFile()', async () => {
    component.f = component.f || {};
    component.f.src = {
      setValue: function() {}
    };
    component.changeFile({}, {
      src: {}
    });
    
  });
    
  // new test by ngentest
  it('should run #resetForm()', async () => {
    component.regVideosDataForm = component.regVideosDataForm || {};
    spyOn(component.regVideosDataForm, 'reset');
    spyOn(component.regVideosDataForm, 'clearValidators');
    spyOn(component.regVideosDataForm, 'markAsPristine');
    component.f = component.f || {};
    component.f.src = {
      setValue: function() {},
      value: {}
    };
    component.f.type = {
      setValue: function() {}
    };
    component.resetForm({
      preventDefault: function() {}
    });
    // expect(component.regVideosDataForm.reset).toHaveBeenCalled();
    // expect(component.regVideosDataForm.clearValidators).toHaveBeenCalled();
    // expect(component.regVideosDataForm.markAsPristine).toHaveBeenCalled();
  });
    
  // new test by ngentest
  it('should run #onSubmit()', async () => {
    component.f = component.f || {};
    component.f.src = {
      value: {}
    };
    component.f.type = {
      value: {}
    };
    component.vidsSrv = component.vidsSrv || {};
    spyOn(component.vidsSrv, 'addVideos').and.returnValue(observableOf({}));
    component.onSubmit({
      preventDefault: function() {}
    });
    // expect(component.vidsSrv.addVideos).toHaveBeenCalled();
  });
});
