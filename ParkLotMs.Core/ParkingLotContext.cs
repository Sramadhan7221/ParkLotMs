using Microsoft.EntityFrameworkCore;
using ParkLotMs.Core.Entities;

namespace ParkLotMs.Core;

public class ParkingLotContext: DbContext
{
	public ParkingLotContext(DbContextOptions<ParkingLotContext> options): base(options)
	{

	}

	public DbSet<VehicleType> VehicleTypes { get; set; }
	public DbSet<ParkingArea> ParkingAreas { get; set; }
	public DbSet<ParkingSlot> ParkingSlots { get; set; }
	public DbSet<ParkingBilling> ParkingBillings { get; set; }
	public DbSet<Payment> Payments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
