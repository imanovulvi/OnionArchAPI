using MediatR;

namespace OnionArchAPI.Application.Features.Brand.Commands.AddBrands
{
    public class AddBrandCommandRequest:IRequest<AddBrandCommandResponse>
    {
       
        public string Name { get; set; }
    }
}
