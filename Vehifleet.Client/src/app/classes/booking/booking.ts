export class Booking {
  id: number;
  vehicleId: number;
  employeeId: number;
  managerId: number;
  status: string;
  startDate: Date;
  endDate: Date;
  purpose: string;
  notes: string;

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
