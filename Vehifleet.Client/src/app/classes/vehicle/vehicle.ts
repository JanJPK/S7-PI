import { CostGenerating } from '../base/cost-generating';

export class Vehicle extends CostGenerating {
  id: number;
  status: string;
  licensePlate: string;
  yearOfManufacture: string;
  chassisCode: string;
  locationCode: string;
  canBeBookedUntil: Date;
  // VehicleModel:
  vehicleModelId: number;
  manufacturer: string;
  model: string;
  horsepower: number;
  seats: number;
  engine: string;

  constructor() {
    super();
    this.id = 0;
  }
}
