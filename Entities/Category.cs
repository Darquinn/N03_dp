using fastwebsite.CompositePattern;
using System;
using System.Collections.Generic;

namespace fastwebsite.Entities;

public partial class Category : ICatalogComponent
{
    public int CateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    // Composite - Lân
    private List<ICatalogComponent> _children = new();

    public void Add(ICatalogComponent component)
    {
        _children.Add(component);
    }

    public void Remove(ICatalogComponent component)
    {
        _children.Remove(component);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + $" [Category] {Name}");
        foreach (var child in _children)
        {
            child.Display(depth + 2);
        }
    }
}
