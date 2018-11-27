import { CostGenerating } from '../base/cost-generating';

export class Booking extends CostGenerating {
  id: number;
  vehicleId: number;
  employeeId: number;
  managerId: number;
  status: string;
  startDate: Date;
  endDate: Date;
  purpose: string;
  notes: string;
}
