using System;

namespace FreeTime.Web.Application.Models.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedOn { get;}
    }
}
