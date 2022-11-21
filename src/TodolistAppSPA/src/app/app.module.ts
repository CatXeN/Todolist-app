import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './core/layouts/main-layout/main-layout.component';
import { MenuComponent } from './core/menu/menu.component';
import { CoreModule } from './core/core.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';



@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    DashboardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
