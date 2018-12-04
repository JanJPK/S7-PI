public class VehicleModelFilter : IQueryFilter<VehicleModel>
{
    public string Manufacturer { get; set; }

    public IQueryable<VehicleModel> Filter(IQueryable<VehicleModel> query)
    {
        if (Manufacturer.NotNullOrEmpty())
        {
            query = query.Where(vm =>
                        vm.Manufacturer == Manufacturer);
        }

        return query;
    }
}