namespace FreeTime.Web.Application.Models
{
    public class Envelope<T>
    {

        public Envelope(int page,int total,int perPage,T data)
        {
            Data = data;
            Page = page;
            Total = total;
            PerPage = perPage;
        }
        public T Data { get; }
        public int Page { get;}
        public int Total { get; }
        public int PerPage { get;}

    }
}
