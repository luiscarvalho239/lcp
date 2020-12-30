import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';

import { RadioWidgetComponent } from './features';
import { FooterComponent, HeaderComponent } from './parts';
import { 
  HomeModule, LoginModule, RegisterModule, 
  MainModule, VideosModule, NewsModule, NewsdetModule,
  ListsModule, UsersModule
} from './pages';

const aryFeatures = [
  RadioWidgetComponent
];

const aryPagesModules = [
  HomeModule, LoginModule, RegisterModule,
  MainModule, VideosModule, NewsModule,
  NewsdetModule, ListsModule, UsersModule
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    aryFeatures
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    aryPagesModules
  ],
  exports: [],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
