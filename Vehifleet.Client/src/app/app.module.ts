import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardLoginComponent } from './components/dashboard/dashboard-login/dashboard-login.component';
import { DashboardRegisterComponent } from './components/dashboard/dashboard-register/dashboard-register.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DashboardUserDetailsComponent } from './components/dashboard/dashboard-user-details/dashboard-user-details.component';
import { ConsoleLoggerService } from './utility/logger/console-logger.service';
import { LoggerService } from './utility/logger/logger.service';
import {
  NgbModule,
  NgbDateAdapter,
  NgbDateNativeAdapter
} from '@ng-bootstrap/ng-bootstrap';
import { BookingListComponent } from './components/booking/booking-list/booking-list.component';
import { BookingListPersonalComponent } from './components/booking/booking-list-personal/booking-list-personal.component';
import { BookingDetailComponent } from './components/booking/booking-detail/booking-detail.component';
import { VehicleListComponent } from './components/vehicle/vehicle-list/vehicle-list.component';
import { VehicleListBookingComponent } from './components/vehicle/vehicle-list-booking/vehicle-list-booking.component';
import { VehicleDetailComponent } from './components/vehicle/vehicle-detail/vehicle-detail.component';
import { VehicleListBookingDetailsComponent } from './components/vehicle/vehicle-list-booking/vehicle-list-booking-details/vehicle-list-booking-details.component';
import { VehicleModelListComponent } from './components/vehicle-model/vehicle-model-list/vehicle-model-list.component';
import { VehicleModelDetailComponent } from './components/vehicle-model/vehicle-model-detail/vehicle-model-detail.component';
import { InsuranceListComponent } from './components/insurance/insurance-list/insurance-list.component';
import { InsuranceDetailComponent } from './components/insurance/insurance-detail/insurance-detail.component';
import { MaintenanceListComponent } from './components/maintenance/maintenance-list/maintenance-list.component';
import { MaintenanceDetailComponent } from './components/maintenance/maintenance-detail/maintenance-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    DashboardLoginComponent,
    DashboardRegisterComponent,
    DashboardUserDetailsComponent,
    BookingListComponent,
    BookingListPersonalComponent,
    BookingDetailComponent,
    VehicleListComponent,
    VehicleListBookingComponent,
    VehicleDetailComponent,
    VehicleListBookingDetailsComponent,
    VehicleModelListComponent,
    VehicleModelDetailComponent,
    InsuranceListComponent,
    InsuranceDetailComponent,
    MaintenanceListComponent,
    MaintenanceDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule
  ],
  providers: [
    { provide: LoggerService, useClass: ConsoleLoggerService },
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
