using System.ComponentModel.DataAnnotations;

namespace ParkLotMs.Core.Entities;

public class UserRole:BaseEntityClass
{
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual RoleAccess RoleAccess { get; set; }
}
