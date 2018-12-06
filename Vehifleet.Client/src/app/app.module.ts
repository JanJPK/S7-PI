import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardLoginComponent } from './components/dashboard/dashboard-login/dashboard-login.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DashboardUserDetailsComponent } from './components/dashboard/dashboard-user-details/dashboard-user-details.component';
import { ConsoleLoggerService } from './shared/logger/console-logger.service';
import { LoggerService } from './shared/logger/logger.service';
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
import { VehicleListFilterComponent } from './components/vehicle/vehicle-list-filter/vehicle-list-filter.component';
import { BoolYesNoPipe } from './shared/pipes/bool-yes-no.pipe';
import { VehicleModelListFilterComponent } from './components/vehicle-model/vehicle-model-list-filter/vehicle-model-list-filter.component';
import { BookingListFilterComponent } from './components/booking/booking-list-filter/booking-list-filter.component';
import { NavbarComponent } from './components/navbar/navbar/navbar.component';
import { YesNoModalComponent } from './shared/modal/yes-no-modal/yes-no-modal.component';
import { ConfirmModalComponent } from './shared/modal/confirm-modal/confirm-modal.component';
import { InfoModalComponent } from './shared/modal/info-modal/info-modal.component';
import { AuditFooterComponent } from './components/shared/audit-footer/audit-footer.component';
import { ErrorModalComponent } from './shared/modal/error-modal/error-modal.component';
import { SuccessModalComponent } from './shared/modal/success-modal/success-modal.component';
import { VehicleListBookingFilterComponent } from './components/vehicle/vehicle-list-booking-filter/vehicle-list-booking-filter.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { BookingListPersonalFilterComponent } from './components/bookings/booking-list-personal-filter/booking-list-personal-filter.component';
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    DashboardLoginComponent,
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
    MaintenanceDetailComponent,
    VehicleListFilterComponent,
    BoolYesNoPipe,
    VehicleModelListFilterComponent,
    BookingListFilterComponent,
    NavbarComponent,
    YesNoModalComponent,
    ConfirmModalComponent,
    InfoModalComponent,
    AuditFooterComponent,
    ErrorModalComponent,
    SuccessModalComponent,
    VehicleListBookingFilterComponent,
    LoadingComponent,
    BookingListPersonalFilterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule.forRoot()
  ],
  providers: [
    { provide: LoggerService, useClass: ConsoleLoggerService },
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }
  ],
  entryComponents: [
    ConfirmModalComponent,
    InfoModalComponent,
    ErrorModalComponent,
    SuccessModalComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
