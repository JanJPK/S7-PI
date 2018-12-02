import { Auditable } from '../base/auditable';

export class Insurance extends Auditable {
  id: number;
  vehicleId: number;
  startDate: Date;
  endDate: Date;
  cost: number;
  insurer: string;
  insuranceId: string;
  mileage: number;

  constructor(id?: number) {
    super();
    this.id = id;
  }
}
