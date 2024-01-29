using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TService.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
