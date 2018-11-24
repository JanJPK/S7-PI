export class VehicleModel {
  id: number;
  manufacturer: string;
  model: string;
  configurationCode: string;
  engine: string;
  horsepower: number;
  seats: number;
  weight: number;

  // Auditable:
  addedBy: string;
  addedOn: Date;
  modifiedBy: string;
  modifiedOn: Date;

  // CostGenerating:
  cost: number;
  fuelConsumed: number;
  mileage: number;
}
