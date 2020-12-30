import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '@app/material.module';
import { UploadComponent } from './upload.component';

@NgModule({
  declarations: [
    UploadComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [UploadComponent],
  providers: [],
  bootstrap: [UploadComponent]
})
export class UploadModule { }
