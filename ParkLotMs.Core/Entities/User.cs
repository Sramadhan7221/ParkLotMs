using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Core.Entities;
public enum Role { Admin };
public class User : BaseEntityClass
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    [ForeignKey("UserRole")]
    public string UserRoleId { get;set; }
    public virtual UserRole UserRole { get; set; }
    public virtual Role Role { get; set; }

}
