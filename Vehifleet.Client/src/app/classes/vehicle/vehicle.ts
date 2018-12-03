import { CostGenerating } from '../base/cost-generating';

export class Vehicle extends CostGenerating {
  id: number;
  status: string;
  licensePlate: string;
  yearOfManufacture: string;
  chassisCode: string;
  locationCode: string;
  canBeBookedUntil: Date;
  hasBookings: boolean;
  inspectionValidUntil: Date;
  // VehicleModel:
  vehicleModelId: number;
  manufacturer: string;
  model: string;
  horsepower: number;
  seats: number;
  engine: string;

  constructor(id?: number) {
    super();
    this.id = id;
  }
}
