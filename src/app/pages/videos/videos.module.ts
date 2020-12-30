import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import { VjsplayerModule } from 'src/app/features/players/vjsplayer/vjsplayer.module';
import { MaterialModule } from 'src/app/material.module';
import { VideosComponent } from './videos.component';

@NgModule({
  declarations: [
    VideosComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    VjsplayerModule
  ],
  exports: [VjsplayerModule],
  providers: [],
  bootstrap: [VideosComponent]
})
export class VideosModule { }