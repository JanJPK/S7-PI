import { Auditable } from '../base/auditable';

export class Maintenance extends Auditable {
  id: number = 0;
  vehicleId: number;
  startDate: Date;
  endDate: Date;
  description: string;
  mileage: number;
  regular: boolean;
  completed: boolean;
  cost: number;

  constructor(id?: number) {
    super();
    this.id = id;
  }
}
