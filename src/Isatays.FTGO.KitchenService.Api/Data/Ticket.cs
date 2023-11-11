using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isatays.FTGO.KitchenService.Api.Data;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }
    
    public DateTime UpdatedDate { get; set; }
}
