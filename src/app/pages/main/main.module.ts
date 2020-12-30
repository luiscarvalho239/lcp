import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material.module';
import { NewsModule } from '../news/news.module';
import { MainComponent } from './main.component';

@NgModule({
  declarations: [
    MainComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    NewsModule
  ],
  exports: [NewsModule],
  providers: [],
  bootstrap: [MainComponent]
})
export class MainModule { }
