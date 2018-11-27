import { Auditable } from './auditable';

export abstract class CostGenerating extends Auditable {
  mileage: number;
  fuelConsumed: number;
  cost: number;
}
