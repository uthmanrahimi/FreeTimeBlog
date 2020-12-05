using FreeTime.Web.Application.Core;
using MediatR;

namespace FreeTime.Web.Application.Commands
{
    public class DeletePostCommand:IRequest<OperationResult>
    {
        public int Id { get; set; }
       
    }
}
