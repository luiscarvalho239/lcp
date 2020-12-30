import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material.module';
import { NewsdetComponent } from './newsdet.component';
import { SafehtmlPipe } from 'src/app/pipes/safehtml.pipe';


@NgModule({
  declarations: [
    NewsdetComponent,
    SafehtmlPipe
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule
  ],
  exports: [],
  providers: [],
  bootstrap: [NewsdetComponent]
})
export class NewsdetModule { }
