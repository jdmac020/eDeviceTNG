using System;

namespace EDeviceClaims.Core
{
    public static class Constants
    {
        public static readonly DateTime SQL_CE_MIN_DATE = new DateTime(1753, 1, 1);

        public const string GLOBAL_TEST_GUID = "bc7bbe46-8556-4f76-bd06-23ba8bf1ea22";

        public const string ROLE_POLICYHOLDER = "policyHolder";

        public static string ROLE_UNDERWRITER = "underwriter";

        public static string ROLE_ADMIN = "admin";
    }
}