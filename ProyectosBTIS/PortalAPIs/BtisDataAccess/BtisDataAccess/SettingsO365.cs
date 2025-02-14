using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisDataAccess
{
    public class SettingsO365
    {
        private static IConfiguration _configuration;

        public static void token(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string GraphResourceRoot
        {
            get { return "https://graph.microsoft.com/v1.0"; }
        }


        public static string GraphResourceUrl
        {
            get { return "https://graph.microsoft.com/v1.0/users"; }
        }


        public static string GraphEndpointResourceURL
        {
            get { return "https://graph.microsoft.com/"; }
        }


        public static string GraphScopeResourceUrl
        {
            get { return "https://graph.microsoft.com/.default"; }
        }


        public static string ClientInstance
        {
            get { return _configuration.GetConnectionString("AADInstanceO365"); }
        }


        public static string GraphUriToken
        {
            get { return _configuration.GetConnectionString("UriTokenO365"); }
        }


        public static string ClientDomain
        {
            get { return _configuration.GetConnectionString("ClientDomainO365"); }

        }


        public static string ClientTenantID
        {
            get { return _configuration.GetConnectionString("ClientTenantIdO365"); }
        }


        public static string ClientID
        {
            get { return _configuration.GetConnectionString("ClientIdO365"); }
        }


        public static string ClientKey
        {


            get { return _configuration.GetConnectionString("ClientKeyO365"); }
        }


        public static string ClientUserID
        {
            get { return _configuration.GetConnectionString("ClientMailUserO365"); }
        }


        public static string AzureAdAuthority
        {
            get { return ClientInstance + ClientTenantID; }
        }


        public static string ClaimTypeObjectIdentifier
        {
            get { return "http://schemas.microsoft.com/identity/claims/objectidentifier"; }
        }


    }
}
