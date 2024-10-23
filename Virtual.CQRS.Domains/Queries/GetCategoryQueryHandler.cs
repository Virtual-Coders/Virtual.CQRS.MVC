using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Virtual.CQRS.Data;
using Virtual.CQRS.Domains.Services;
using Virtual.CQRS.Models;

namespace Virtual.CQRS.Domains.Queries;
public class GetCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryModel>>
{
    private readonly ApplicationDbContext _context;
 
    public GetCategoryQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var  data= await _context.Categories.ToListAsync(cancellationToken);

        return CategoryFactory.ConvertToCategoryListModel(data);

    }
}
