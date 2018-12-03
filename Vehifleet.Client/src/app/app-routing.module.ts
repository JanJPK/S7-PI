import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardLoginComponent } from './components/dashboard/dashboard-login/dashboard-login.component';
import { AuthGuardService as AuthGuard } from './auth-guard.service';
import { VehicleListBookingComponent } from './components/vehicle/vehicle-list-booking/vehicle-list-booking.component';
import { VehicleListComponent } from './components/vehicle/vehicle-list/vehicle-list.component';
import { VehicleDetailComponent } from './components/vehicle/vehicle-detail/vehicle-detail.component';
import { BookingListPersonalComponent } from './components/booking/booking-list-personal/booking-list-personal.component';
import { BookingListComponent } from './components/booking/booking-list/booking-list.component';
import { BookingDetailComponent } from './components/booking/booking-detail/booking-detail.component';
import { VehicleModelListComponent } from './components/vehicle-model/vehicle-model-list/vehicle-model-list.component';
import { VehicleModelDetailComponent } from './components/vehicle-model/vehicle-model-detail/vehicle-model-detail.component';
import { MaintenanceDetailComponent } from './components/maintenance/maintenance-detail/maintenance-detail.component';
import { InsuranceDetailComponent } from './components/insurance/insurance-detail/insurance-detail.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  {
    path: 'vehicles/booking',
    component: VehicleListBookingComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: [] }
  },
  {
    path: 'vehicles',
    component: VehicleListComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehicles/:id',
    component: VehicleDetailComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehicles/:vehicleId/insurances/:id',
    component: InsuranceDetailComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehicles/:vehicleId/maintenances/:id',
    component: MaintenanceDetailComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'bookings/personal',
    component: BookingListPersonalComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: [] }
  },
  {
    path: 'bookings',
    component: BookingListComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'bookings/:id',
    component: BookingDetailComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: [] }
  },
  {
    path: 'vehicle-models',
    component: VehicleModelListComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehicle-models/:id',
    component: VehicleModelDetailComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
