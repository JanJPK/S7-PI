import { Component, OnInit, Input } from '@angular/core';
import { InsuranceService } from 'src/app/services/insurance.service';
import { Insurance } from 'src/app/classes/insurance/insurance';
import { Router } from '@angular/router';

@Component({
  selector: 'app-insurance-list',
  templateUrl: './insurance-list.component.html',
  styleUrls: ['./insurance-list.component.scss']
})
export class InsuranceListComponent implements OnInit {
  @Input()
  set selectedVehicleId(vehicleId: number) {
    this.vehicleId = vehicleId;
  }
  @Input()
  isBooked: boolean;

  vehicleId: number;
  insurances: Insurance[];

  constructor(
    private insuranceService: InsuranceService,
    private router: Router
  ) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.insuranceService
      .getByVehicleId(this.vehicleId)
      .subscribe(insurances => {
        this.insurances = insurances;
      });
  }

  select(id: number) {
    this.router.navigate([`/vehicles/${this.vehicleId}/insurances/${id}`]);
  }
}
