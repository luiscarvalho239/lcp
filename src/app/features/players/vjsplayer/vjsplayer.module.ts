import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VjsplayerComponent } from './vjsplayer.component';
import { MaterialModule } from '@app/material.module';

@NgModule({
  declarations: [
    VjsplayerComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [VjsplayerComponent],
  providers: [],
  bootstrap: [VjsplayerComponent]
})
export class VjsplayerModule { }
