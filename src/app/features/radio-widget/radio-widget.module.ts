import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RadioWidgetComponent } from './radio-widget.component';
import { MaterialModule } from '@app/material.module';

@NgModule({
  declarations: [
    RadioWidgetComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [RadioWidgetComponent],
  providers: [],
  bootstrap: [RadioWidgetComponent]
})
export class RadioWidgetModule { }