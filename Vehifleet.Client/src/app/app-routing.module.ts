import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { DashboardLoginComponent } from "./components/dashboard/dashboard-login/dashboard-login.component";
import { DashboardRegisterComponent } from "./components/dashboard/dashboard-register/dashboard-register.component";
import { VehicleComponent } from "./components/vehicle/vehicle.component";
import { VehicleSpecificationComponent } from "./components/vehicle-specification/vehicle-specification.component";

const routes: Routes = [
  { path: "", redirectTo: "/dashboard", pathMatch: "full" },
  { path: "dashboard", component: DashboardComponent },
  { path: "dashboard/login", component: DashboardLoginComponent },
  { path: "dashboard/register", component: DashboardRegisterComponent },
  { path: "vehicles", component: VehicleComponent },
  { path: "vehiclespecifications", component: VehicleSpecificationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
