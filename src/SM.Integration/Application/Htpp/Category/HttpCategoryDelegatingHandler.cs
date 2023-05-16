namespace SM.Integration.Application.Htpp.Category
{
    public class HttpCategoryDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
