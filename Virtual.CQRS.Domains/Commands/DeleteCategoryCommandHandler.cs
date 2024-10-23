using MediatR;
using Virtual.CQRS.Data;
using Virtual.CQRS.Domains.Services;
using Virtual.CQRS.Models;

namespace Virtual.CQRS.Domains.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryModel>
{
    //public async Task<Categories> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    //{
    //    var data = new Categories { Id = request.Id };
    //    CategoryList.RemoveData(data);
    //    return data;
    //}

    private readonly ApplicationDbContext _Context;
    public DeleteCategoryCommandHandler(ApplicationDbContext context)
    {
        _Context = context; 
    }

    public async Task<CategoryModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var data = _Context.Categories.FirstOrDefault(p => p.Id == request.Id);

        if (data is null)
            return default;

        _Context.Remove(data);
        await _Context.SaveChangesAsync(cancellationToken);
        return CategoryFactory.ConvertToCategoryModel(data);
    }
}
