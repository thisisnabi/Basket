﻿using Basket.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Basket.Subscription.CatalogItemRemoved;

public class CatalogItemRemovedConsumer(BasketDbContext dbContext) : IConsumer<CatalogItemRemovedEvent>
{
    private readonly BasketDbContext _dbContext = dbContext;

    public async Task Consume(ConsumeContext<CatalogItemRemovedEvent> context)
    {
       await _dbContext.BasketCatalogItems
                       .Where(d => d.Slug == context.Message.Slug)
                       .ExecuteDeleteAsync();
    }
}
