// tslint:disable
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Pipe, PipeTransform, Injectable, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, Directive, Input, Output } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of as observableOf, of, throwError } from 'rxjs';

import { Component } from '@angular/core';
import { VjsplayerComponent } from './vjsplayer.component';
import { VideosService } from 'src/app/services/videos.service';

@Injectable()
class MockVideosService {
  getVideos() {};
}

xdescribe('VjsplayerComponent', () => {
  let fixture;
  let component;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, ReactiveFormsModule ],
      declarations: [VjsplayerComponent],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA ],
      providers: [
        { provide: VideosService, useClass: MockVideosService }
      ]
    }).overrideComponent(VjsplayerComponent, {

    }).compileComponents();
    fixture = TestBed.createComponent(VjsplayerComponent);
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
    spyOn(component, 'loadDataVideos');
    component.ngOnInit();
    expect(component.loadDataVideos).toHaveBeenCalled();
  });

  it('should run #loadDataVideos()', async () => {
    component.vidsServ = component.vidsServ || {};
    spyOn(component.vidsServ, 'getVideos').and.returnValue(observableOf({
      length: {}
    }));
    component.ary_videos = component.ary_videos || {};
    spyOn(component.ary_videos, 'push');
    spyOn(component, 'loadPlayer');
    component.loadDataVideos();
    expect(component.vidsServ.getVideos).toHaveBeenCalled();
    expect(component.ary_videos.push);
    expect(component.loadPlayer).toHaveBeenCalled();
  });

  it('should run #loadPlayer()', async () => {
    component.target = component.target || {};
    component.target.nativeElement = 'nativeElement';
    spyOn(component, 'setVideo');
    component.loadPlayer();
    expect(component.setVideo).toHaveBeenCalled();
  });

  it('should run #setVideo()', async () => {
    component.player = component.player || {};
    spyOn(component.player, 'src');
    component.ary_videos = component.ary_videos || {};
    component.ary_videos.id = {
      type: {},
      src: {}
    };
    component.setVideo();
    expect(component.player.src).toHaveBeenCalled();
  });

  it('should run #ngOnDestroy()', async () => {
    component.player = component.player || {};
    spyOn(component.player, 'dispose');
    component.ngOnDestroy();
    expect(component.player.dispose).toHaveBeenCalled();
  });

});
