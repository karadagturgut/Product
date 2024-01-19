using Microsoft.Extensions.DependencyInjection;
using Product.Core.GeneralHelper;
using Product.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service
{
    internal class CipherHelper
    {
        internal string Encrypt(string input)
        {
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<CipherProvider>(LockerKey);
            return locker.Encrypt(input);
        }

        internal string Decrypt(string input)
        {

            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<CipherProvider>(LockerKey);
            return locker.Decrypt(input);
        }

        internal List<ResourceDTO> DecryptByList(List<ResourceDTO> list)
        {
            var returnlist = new List<ResourceDTO>();
            if (list.Any())
            {   
                try
                {
                    foreach (var item in list)
                    {
                        item.Value = Decrypt(item.Value);
                        returnlist.Add(item);   
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }   
            }
            return returnlist;

        }

    }
}
