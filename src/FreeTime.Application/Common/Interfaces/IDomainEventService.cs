using FreeTime.Domain.Common;
using System.Threading.Tasks;

namespace FreeTime.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
