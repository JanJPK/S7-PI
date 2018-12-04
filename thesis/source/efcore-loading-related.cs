public override Task<Booking> GetById(int id)
{
    return Set
          .Include(b => b.Vehicle)
          .AsNoTracking()
          .SingleOrDefaultAsync(b => b.Id == id);
}