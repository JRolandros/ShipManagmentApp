import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule,ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { ShipMaterialModule } from './ship-materiel/ship-material.module';
import { LoginComponent } from './login/login.component';
import { ShipListComponent } from './ship-list/ship-list.component';
import { AddShipDialogComponent } from './dialogs/add-ship-dialog/add-ship-dialog.component';
import { EditShipDialogComponent } from './dialogs/edit-ship-dialog/edit-ship-dialog.component';
import { DeleteShipDialogComponent } from './dialogs/delete-ship-dialog/delete-ship-dialog.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HttpRequestInterceptor } from './helpers/http-request.interceptor';
import { JwtModule } from '@auth0/angular-jwt';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    ShipListComponent,
    AddShipDialogComponent,
    EditShipDialogComponent,
    DeleteShipDialogComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    HttpClientModule,
    JwtModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ShipMaterialModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
