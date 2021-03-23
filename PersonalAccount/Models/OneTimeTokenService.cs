//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PersonalAccount.Models
//{
//    public class OneTimeTokenService
//    {
//        private readonly IAdminStore<OneTimeToken> _store; // this my service calling the API
//        private readonly AuthenticationStateProvider _stateProvider;
//        private readonly IAccessTokenProvider _provider;
//        private readonly IOptions<RemoteAuthenticationOptions<OidcProviderOptions>> _options;

//        public OneTimeTokenService(IAdminStore<OneTimeToken> store,
//            AuthenticationStateProvider state,
//            IAccessTokenProvider provider,
//            IOptions<RemoteAuthenticationOptions<OidcProviderOptions>> options)
//        {
//            _store = store ?? throw new ArgumentNullException(nameof(store));
//            _stateProvider = state ?? throw new ArgumentNullException(nameof(state));
//            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
//            _options = options ?? throw new ArgumentNullException(nameof(options));
//        }

//        public async Task<string> GetOneTimeToken()
//        {
//            // gets the user access token
//            var tokenResult = await _provider.RequestAccessToken().ConfigureAwait(false);
//            tokenResult.TryGetToken(out AccessToken token);
//            // gets the authentication state
//            var state = await _stateProvider.GetAuthenticationStateAsync().ConfigureAwait(false);
//            // creates a one time token
//            var oneTimeToken = await _store.CreateAsync(new OneTimeToken
//            {
//                ClientId = _options.Value.ProviderOptions.ClientId,
//                UserId = state.User.Claims.First(c => c.Type == "sub").Value,
//                Expiration = DateTime.UtcNow.AddMinutes(1),
//                Data = token.Value
//            }).ConfigureAwait(false);

//            return oneTimeToken.Id;
//        }
//    }
//}
