import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardLoginComponent } from './components/dashboard/dashboard-login/dashboard-login.component';
import { DashboardRegisterComponent } from './components/dashboard/dashboard-register/dashboard-register.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { VehicleBookingComponent } from './components/vehicle/vehicle-booking/vehicle-booking.component';
import { VehicleBookingDetailComponent } from './components/vehicle/vehicle-booking/vehicle-booking-details/vehicle-booking-details.component';
import { VehicleManagementComponent } from './components/vehicle/vehicle-management/vehicle-management.component';
import { VehicleManagementEditComponent } from './components/vehicle/vehicle-management-edit/vehicle-management-edit.component';
import { VehicleManagementAddComponent } from './components/vehicle/vehicle-management-add/vehicle-management-add.component';
import { VehicleSpecificationComponent } from './components/vehicle-specification/vehicle-specification/vehicle-specification.component';
import { VehicleSpecificationEditComponent } from './components/vehicle-specification/vehicle-specification-edit/vehicle-specification-edit.component';
import { VehicleSpecificationAddComponent } from './components/vehicle-specification/vehicle-specification-add/vehicle-specification-add.component';
import { BookingAddComponent } from './components/booking/booking-add/booking-add.component';
import { BookingEditComponent } from './components/booking/booking-edit/booking-edit.component';
import { BookingPersonalComponent } from './components/booking/booking-personal/booking-personal.component';
import { BookingManagementComponent } from './components/booking/booking-management/booking-management.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    DashboardLoginComponent,
    DashboardRegisterComponent,
    VehicleBookingComponent,
    VehicleBookingDetailComponent,
    VehicleManagementComponent,
    VehicleManagementEditComponent,
    VehicleManagementAddComponent,
    VehicleSpecificationComponent,
    VehicleSpecificationEditComponent,
    VehicleSpecificationAddComponent,
    BookingAddComponent,
    BookingEditComponent,
    BookingPersonalComponent,
    BookingManagementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
