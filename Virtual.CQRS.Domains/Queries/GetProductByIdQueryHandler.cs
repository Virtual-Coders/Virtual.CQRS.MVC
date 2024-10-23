using Virtual.CQRS.Data;
using Virtual.CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Virtual.CQRS.Domains.Services;

namespace Virtual.CQRS.Domains.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryModel>
{
    
    private readonly ApplicationDbContext _Context;

    public GetProductByIdQueryHandler(ApplicationDbContext context)
    {
        _Context = context;
    }

    public async Task<CategoryModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var response =  await _Context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
        return CategoryFactory.ConvertToCategoryModel(response);
    }
}
