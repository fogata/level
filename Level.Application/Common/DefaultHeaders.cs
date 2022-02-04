namespace Level.Application.Common
{
    public class DefaultHeaders
    {
        //
        // Summary:
        //     Bearer token that identifies and authorize the user
        public string Authorization
        {
            get;
            set;
        }

        //
        // Summary:
        //     User's Person Id
        public string ClientId
        {
            get;
            set;
        }

        //
        // Summary:
        //     User's Country (Iso country code format. Ex: AR)
        public string Country
        {
            get;
            set;
        }

        //
        // Summary:
        //     User's Language (Ex: es_AR)
        public string Language
        {
            get;
            set;
        }

        //
        // Summary:
        //     User's platform (Ex: Mobile.Android)
        public string Platform
        {
            get;
            set;
        }

        //
        // Summary:
        //     User's device version
        public string Version
        {
            get;
            set;
        }

        //
        // Summary:
        //     Page Size (for paginated APIs)
        public int? PageSize
        {
            get;
            set;
        }

        //
        // Summary:
        //     Page Number (for paginated APIs)
        public int? PageNumber
        {
            get;
            set;
        }
    }
}
