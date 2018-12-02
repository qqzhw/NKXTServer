using System.Collections.Generic;

namespace ICIMS.Models.TokenAuth
{
    public class AuthenticateResultModel
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }
        public long? UnitId { get; set; }
        public string UnitName { get; set; }
        public string Name { get; set; }
        public IList<string> RolesName { get; set; }
        public string UserName { get; set; }
    }
}
