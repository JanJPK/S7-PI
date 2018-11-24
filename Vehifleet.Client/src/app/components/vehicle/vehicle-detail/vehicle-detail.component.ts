import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.scss']
})
export class VehicleDetailComponent implements OnInit {
  vehicle: Vehicle;

  constructor(
    private vehicleService: VehicleService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.getVehicle();
  }

  getVehicle() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.vehicleService.getById(id).subscribe(vehicle => {
      this.vehicle = vehicle;
    });
    console.log(this.vehicle);
  }
}
