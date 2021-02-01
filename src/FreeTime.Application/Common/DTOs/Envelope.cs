using System.Collections.Generic;
using System.Linq;

namespace FreeTime.Application.Common.DTOs
{
    public class Envelope<T>
    {
        public T Data { get; }
        public int Page { get; }
        public int Total { get; }
        public int PerPage { get; }

        public Envelope(int page, int total, int perPage, T data)
        {
            Data = data;
            Page = page;
            Total = total;
            PerPage = perPage;
        }

        public static Envelope<T> New(int page, int total, int perPage, T data)
        {
            return new Envelope<T>(page, total, perPage, data);
        }

        public static Envelope<IEnumerable<T>> Empty()
        {
            return new Envelope<IEnumerable<T>>(0, 0, 0, Enumerable.Empty<T>());
        }

    }
}
