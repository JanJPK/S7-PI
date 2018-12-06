import { CostGenerating } from '../base/cost-generating';

export class Booking extends CostGenerating {
  id: number;
  vehicleId: number;
  employeeId: number;
  status: string;
  startDate: Date;
  endDate: Date;
  purpose: string;
  notes: string;

  constructor(id?: number) {
    super();
    this.id = id;
    this.cost = 0;
    this.fuelConsumed = 0;
    this.mileage = 0;
  }
}
