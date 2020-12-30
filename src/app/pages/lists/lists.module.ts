import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import { ListsApiModule } from 'src/app/features/lists_api/lists_api.module';
import { MaterialModule } from 'src/app/material.module';
import { ListsComponent } from './lists.component';

@NgModule({
  declarations: [
    ListsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    ListsApiModule
  ],
  exports: [ListsApiModule],
  providers: [],
  bootstrap: [ListsComponent]
})
export class ListsModule { }
