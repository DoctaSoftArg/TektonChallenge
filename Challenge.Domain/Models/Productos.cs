using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Models;

public partial class Productos
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? StatusName { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? FinalPrice { get; set; }
    [NotMapped]
    public int StatusKey { get; set; }
}
