using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Core.Entities;

public class RoleAccess : BaseEntityClass
{
    [ForeignKey("UserRole")]
    public Guid RoleId {get;set;}
    public bool CanCreate { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
    public virtual UserRole Role { get; set; }
}
