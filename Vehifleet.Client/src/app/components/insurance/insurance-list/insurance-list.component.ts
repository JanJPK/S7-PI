import { Component, OnInit, Input } from '@angular/core';
import { InsuranceService } from 'src/app/services/insurance.service';
import { Insurance } from 'src/app/classes/insurance/insurance';
import { InsuranceFilter } from 'src/app/classes/insurance/insurance-filter';

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

  vehicleId: number;
  insurances: Insurance[];

  constructor(private insuranceService: InsuranceService) {}

  ngOnInit() {
    this.getInsurances();
  }

  getInsurances() {
    this.insuranceService
      .getByVehicleId(this.vehicleId)
      .subscribe(insurances => {
        this.insurances = insurances;
      });
  }

  selectInsurance(id: number) {
    console.log(id);
  }
}
