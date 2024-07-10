using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Brand.Commands.GetBrands
{
    public class GetBrandsCommandRequest:IRequest<List<GetBrandsCommandResponse>>
    {
    }
}
