using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public T? Data { get; set; }
    public int HttpStatusCode { get; set; }
    public string Messenge { get; set; }


    public Response(T data)
    {
        Data = data;
        HttpStatusCode = 200;
        Messenge="";
    }

    public Response(HttpStatusCode statusCode, string messenge)
    {
        HttpStatusCode = (int)statusCode;
        Messenge = messenge;
    }
    
    
}