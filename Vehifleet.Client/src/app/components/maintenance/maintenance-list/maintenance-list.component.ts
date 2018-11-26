import { Component, OnInit, Input } from '@angular/core';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { Maintenance } from 'src/app/classes/maintenance/maintenance';
import { MaintenanceFilter } from 'src/app/classes/maintenance/maintenance-filter';

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

  vehicleId: number;
  maintenances: Maintenance[];

  constructor(private maintenanceService: MaintenanceService) {}

  ngOnInit() {
    this.getMaintenances();
  }

  getMaintenances() {
    this.maintenanceService
      .getByVehicleId(this.vehicleId)
      .subscribe(maintenances => {
        this.maintenances = maintenances;
        console.log(this.maintenances);
      });
  }

  selectMaintenance(id: number) {
    console.log(id);
  }
}
