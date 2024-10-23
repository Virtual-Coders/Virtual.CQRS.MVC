
using MediatR;
using Virtual.CQRS.Data;
using Virtual.CQRS.Domains.Services;
using Virtual.CQRS.Models;

namespace Virtual.CQRS.Domains.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryModel>
{
    
    private readonly ApplicationDbContext _Context;
    public CreateCategoryCommandHandler(ApplicationDbContext context)
    {
        _Context = context;
    }

    public async Task<CategoryModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var data = new Category { Id = request.Id, Name = request.Name, Code = request.Code, IsActive = request.IsActive, IsDelete = request.IsDelete };
        _Context.Categories.Add(data);
        await _Context.SaveChangesAsync(cancellationToken);
        return CategoryFactory.ConvertToCategoryModel(data);
    }
}
