
using MediatR;
using Virtual.CQRS.Models;


namespace Virtual.CQRS.Domains.Queries;

public class GetAllCategoryQuery : IRequest<IEnumerable<CategoryModel>>
{
    public GetAllCategoryQuery()
    {
    }
}
