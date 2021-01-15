import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationComponent } from './navigation/navigation.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [AppComponent, NavigationComponent],
  imports: [BrowserModule, BrowserAnimationsModule, MatToolbarModule, MatButtonModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
