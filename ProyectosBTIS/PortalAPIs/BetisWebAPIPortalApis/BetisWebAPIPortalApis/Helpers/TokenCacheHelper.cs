namespace BetisWebAPIPortalApis.Helpers
{
    public class TokenCacheHelper
    {
        private static readonly object LockObject = new object();
        private static byte[] tokenCache;

        // Método para recuperar el token cache desde el almacenamiento
        public async Task<byte[]> RetrieveTokenCacheAsync()
        {
            // Implementa la lógica para recuperar el token cache desde tu almacenamiento
            lock (LockObject)
            {
                return tokenCache;
            }
        }

        // Método para guardar el token cache en el almacenamiento
        public async Task PersistTokenCacheAsync(byte[] cache)
        {
            // Implementa la lógica para guardar el token cache en tu almacenamiento
            lock (LockObject)
            {
                tokenCache = cache;
            }
        }
    }
}
