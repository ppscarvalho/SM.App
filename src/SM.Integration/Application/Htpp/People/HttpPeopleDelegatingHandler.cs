namespace SM.Integration.Application.Htpp.People
{
    public class HttpPeopleDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
