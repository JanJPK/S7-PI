import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardLoginComponent } from './components/dashboard/dashboard-login/dashboard-login.component';
import { DashboardRegisterComponent } from './components/dashboard/dashboard-register/dashboard-register.component';
import { VehicleBookingComponent } from './components/vehicle/vehicle-booking/vehicle-booking.component';
import { VehicleManagementComponent } from './components/vehicle/vehicle-management/vehicle-management.component';
import { VehicleManagementEditComponent } from './components/vehicle/vehicle-management-edit/vehicle-management-edit.component';
import { VehicleManagementAddComponent } from './components/vehicle/vehicle-management-add/vehicle-management-add.component';
import { BookingPersonalComponent } from './components/booking/booking-personal/booking-personal.component';
import { BookingManagementComponent } from './components/booking/booking-management/booking-management.component';
import { BookingEditComponent } from './components/booking/booking-edit/booking-edit.component';
import { BookingAddComponent } from './components/booking/booking-add/booking-add.component';
import { VehicleSpecificationAddComponent } from './components/vehicle-specification/vehicle-specification-add/vehicle-specification-add.component';
import { VehicleSpecificationEditComponent } from './components/vehicle-specification/vehicle-specification-edit/vehicle-specification-edit.component';
import { VehicleSpecificationComponent } from './components/vehicle-specification/vehicle-specification/vehicle-specification.component';
import { AuthGuardService as AuthGuard } from './auth-guard.service';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'dashboard/login', component: DashboardLoginComponent },
  { path: 'dashboard/register', component: DashboardRegisterComponent },
  {
    path: 'vehicles/booking',
    component: VehicleBookingComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: [] }
  },
  {
    path: 'vehicles/manage',
    component: VehicleManagementComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehicles/manage/:id',
    component: VehicleManagementEditComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehicles/manage/add',
    component: VehicleManagementAddComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehiclespecs/manage',
    component: VehicleSpecificationComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehiclespecs/manage/:id',
    component: VehicleSpecificationEditComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'vehiclespecs/manage/add',
    component: VehicleSpecificationAddComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'bookings/personal',
    component: BookingPersonalComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: [] }
  },
  {
    path: 'bookings/manage',
    component: BookingManagementComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'bookings/manage/:id',
    component: BookingEditComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: ['Administrator', 'Manager'] }
  },
  {
    path: 'bookings/manage/add/:vehicleId',
    component: BookingAddComponent,
    canActivate: [AuthGuard],
    data: { expectedRoles: [] }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
