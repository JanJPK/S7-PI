import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehicleComponent } from './components/vehicle/vehicle.component';
import { VehicleListComponent } from './components/vehicle/vehicle-list/vehicle-list.component';
import { VehicleDetailComponent } from './components/vehicle/vehicle-detail/vehicle-detail.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { VehicleSpecificationComponent } from './components/vehicle-specification/vehicle-specification.component';
import { DashboardLoginComponent } from './components/dashboard/dashboard-login/dashboard-login.component';
import { DashboardRegisterComponent } from './components/dashboard/dashboard-register/dashboard-register.component';

@NgModule({
  declarations: [
    AppComponent,
    VehicleListComponent,
    DashboardComponent,
    VehicleComponent,
    VehicleDetailComponent,
    VehicleSpecificationComponent,
    DashboardLoginComponent,
    DashboardRegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
