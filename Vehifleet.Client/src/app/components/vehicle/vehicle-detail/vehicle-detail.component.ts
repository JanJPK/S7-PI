import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.scss']
})
export class VehicleDetailComponent implements OnInit {

  @Input() vehicle: Vehicle;

  constructor() { }

  ngOnInit() {
  }

}
