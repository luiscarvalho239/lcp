import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UploadModule } from '@app/features/upload/upload.module';
import { ChartsModule } from 'ng2-charts';
import { MaterialModule } from 'src/app/material.module';
import { AdminComponent } from './admin.component';
import { AdminUsersComponent, AdminNewsComponent, AdminVideosComponent } from './adm_pages';

@NgModule({
  declarations: [
    AdminComponent,
    AdminUsersComponent,
    AdminNewsComponent,
    AdminVideosComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    MaterialModule,
    ChartsModule,
    UploadModule
  ],
  exports: [],
  providers: [],
  bootstrap: [AdminComponent]
})
export class AdminModule { }