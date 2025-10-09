namespace G1Emergency2025.Servicio.ServiciosHttp
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<TResp>> Post<T, TResp>(string url, T entidad);
    }
}