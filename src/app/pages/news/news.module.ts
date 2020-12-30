import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material.module';
import { NewsComponent } from './news.component';
import { NgxPaginationModule } from 'ngx-pagination';


@NgModule({
  declarations: [
    NewsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgxPaginationModule,
    MaterialModule
  ],
  exports: [NewsComponent],
  providers: [],
  bootstrap: [NewsComponent]
})
export class NewsModule { }
