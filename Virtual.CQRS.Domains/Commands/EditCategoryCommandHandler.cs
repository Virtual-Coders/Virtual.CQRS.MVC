using MediatR;
using Virtual.CQRS.Data;
using Virtual.CQRS.Domains.Services;
using Virtual.CQRS.Models;

namespace Virtual.CQRS.Domains.Commands;

public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, CategoryModel>
{
    private ApplicationDbContext _Context;
    public EditCategoryCommandHandler(ApplicationDbContext Context)
    {
        _Context = Context;
    }

    public async Task<CategoryModel> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _Context.Categories.FirstOrDefault(p => p.Id == request.Id);

        if (category is null)
            return default;


        category.Name = request.Name;
        category.Code = request.Code;
        category.IsActive = request.IsActive;
        category.IsDelete = request.IsDelete;

        await _Context.SaveChangesAsync(cancellationToken);
        return CategoryFactory.ConvertToCategoryModel(category);
    }
}
