using System.Text.Encodings.Web;
using Clerk.BackendAPI.Helpers.Jwks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication
{
    public class ClerkAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly IConfiguration _configuration;

        [Obsolete]
        public ClerkAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IConfiguration configuration) : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Context.Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }

            string? bearerToken = Context.Request.Headers["Authorization"];

            if (bearerToken == null || !bearerToken.StartsWith("Bearer"))
            {
                return AuthenticateResult.Fail("Invalid token");
            }

            var secretKey = _configuration["CLERK_SECRET_KEY"];

            if (string.IsNullOrEmpty(secretKey))
            {
                Logger.LogError("CLERK_SECRET_KEY is not configured");
                return AuthenticateResult.Fail("Server authentication configuration is missing.");
            }

            var options = new AuthenticateRequestOptions(
            secretKey: secretKey,
            authorizedParties: new[] { "https://learning-spaniel-88.accounts.dev", "http://localhost:3000" }
        );

            RequestState requestState;

            try
            {
                requestState = await AuthenticateRequest.AuthenticateRequestAsync(Context.Request, options);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Clerk authentication request failed");
                return AuthenticateResult.Fail("Authentication request failed.");
            }

            var isSignedIn = requestState.IsAuthenticated;

            if (!isSignedIn)
            {
                Logger.LogDebug("Authentication failed: {ErrorReasonId} - {ErrorReasonMessage}", requestState.ErrorReason?.Id, requestState.ErrorReason?.Message);
                return AuthenticateResult.NoResult();
            }

            var ticket = new AuthenticationTicket(requestState.Claims!, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}