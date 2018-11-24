export class Vehicle {
  id: number;
  status: string;
  licensePlate: string;
  yearOfManufacture: string;
  chassisCode: string;
  locationCode: string;
  canBeBookedUntil: Date;

  // Auditable:
  addedBy: string;
  addedOn: Date;
  modifiedBy: string;
  modifiedOn: Date;

  // CostGenerating:
  cost: number;
  fuelConsumed: number;
  mileage: number;

  // VehicleModel:
  vehicleModelId: number;
  manufacturer: string;
  model: string;
  horsepower: number;
  seats: number;
  engine: string;
}
