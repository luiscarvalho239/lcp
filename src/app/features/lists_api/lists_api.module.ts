import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { MaterialModule } from '@app/material.module';
import { ListsApiComponent } from './lists_api.component';

@NgModule({
  declarations: [
    ListsApiComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    MaterialModule,
    HttpClientModule
  ],
  exports: [ListsApiComponent],
  providers: [],
  bootstrap: [ListsApiComponent]
})
export class ListsApiModule { }