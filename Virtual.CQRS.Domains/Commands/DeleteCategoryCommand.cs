using MediatR;
using Virtual.CQRS.Models;

namespace Virtual.CQRS.Domains.Commands
{
    public class DeleteCategoryCommand : IRequest<CategoryModel>
    {
        public int Id { get; set; }
    }
}
