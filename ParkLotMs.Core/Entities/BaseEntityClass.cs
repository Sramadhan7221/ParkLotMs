using System.ComponentModel.DataAnnotations;

namespace ParkLotMs.Core.Entities;

public class BaseEntityClass
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string DeletedBy { get; set; }
}
