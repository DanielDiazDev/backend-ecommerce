﻿using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;

namespace EcommerceProject.Data.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return true;
    }
}