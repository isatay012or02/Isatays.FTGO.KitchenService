using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isatays.FTGO.KitchenService.Api.Data;

[Table("Ticket")]
public class Ticket : IEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
    
    public DateTime? UpdatedDate { get; set; }
}
