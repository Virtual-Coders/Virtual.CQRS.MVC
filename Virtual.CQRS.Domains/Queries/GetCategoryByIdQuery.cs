
using MediatR;
using Virtual.CQRS.Models;

namespace Virtual.CQRS.Domains.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryModel>
{

    public GetCategoryByIdQuery(int Id)
    {
        this.Id = Id;
            
    }
    public int Id { get; set; }
}
