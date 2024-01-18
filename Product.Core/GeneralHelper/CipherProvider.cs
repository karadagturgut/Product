using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Product.Core.GeneralHelper
{
    public class CipherProvider
    {
        private const string Key = "bu-bir-sifreleme-key-string-metnidir";
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public CipherProvider(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider.CreateProtector(Key);
        }

        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }

        public string Decrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(input);
        }
    }
}
