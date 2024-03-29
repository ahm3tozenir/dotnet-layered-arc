﻿using System;
using Core.Repository;

namespace Entities.Models;

public class Category:Entity<Guid>
{
    public required string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
    }
}

