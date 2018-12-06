import { Component, OnInit, Input } from '@angular/core';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { Maintenance } from 'src/app/classes/maintenance/maintenance';
import { MaintenanceFilter } from 'src/app/classes/maintenance/maintenance-filter';
import { Router } from '@angular/router';

@Component({
  selector: 'app-maintenance-list',
  templateUrl: './maintenance-list.component.html',
  styleUrls: ['./maintenance-list.component.scss']
})
export class MaintenanceListComponent implements OnInit {
  @Input()
  set selectedVehicleId(vehicleId: number) {
    this.vehicleId = vehicleId;
  }
  @Input()
  isBooked: boolean;

  vehicleId: number;
  maintenances: Maintenance[];

  constructor(
    private maintenanceService: MaintenanceService,
    private router: Router
  ) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.maintenanceService
      .getByVehicleId(this.vehicleId)
      .subscribe(maintenances => {
        this.maintenances = maintenances;
      });
  }

  select(id: number) {
    this.router.navigate([`/vehicles/${this.vehicleId}/maintenances/${id}`]);
  }
}
