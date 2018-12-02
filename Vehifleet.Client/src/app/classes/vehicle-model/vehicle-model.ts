import { CostGenerating } from '../base/cost-generating';

export class VehicleModel extends CostGenerating {
  id: number;
  manufacturer: string;
  model: string;
  configurationCode: string;
  engine: string;
  horsepower: number;
  seats: number;
  weight: number;
  purchaseCost: number;
  hasVehicles: boolean;

  constructor(id?: number) {
    super();
    this.id = id;
  }
}
