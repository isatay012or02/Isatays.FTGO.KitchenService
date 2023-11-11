using System.ComponentModel.DataAnnotations;

namespace Isatays.FTGO.KitchenService.Api.Data;

public class IEntity
{
    [Key]
    public int Id { get; set; }
}
