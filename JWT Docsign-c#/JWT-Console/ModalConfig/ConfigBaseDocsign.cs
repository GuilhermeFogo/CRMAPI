using System;
using System.Collections.Generic;
using System.Text;

namespace JWT_Console.ModalConfig
{
    public class ConfigBaseDocsign
    {
        public string ClientId { get; set; }
        public string AuthServer { get; set; }

        public string ImpersonatedUserID { get; set; }
        public string PrivateKeyFile { get; set; }
    }
}
