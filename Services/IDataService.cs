using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumeThirdPartyApisDemo.Models;

namespace ConsumeThirdPartyApisDemo.Services
{
    public interface IDataService
    {
        Task<List<DataModel>> GetData();
    }
}
