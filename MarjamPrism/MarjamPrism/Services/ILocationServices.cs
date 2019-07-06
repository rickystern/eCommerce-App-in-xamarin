using MarjamPrism.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarjamPrism.Services
{
    public interface ILocationServices
    {
        Task<List<Store>> getStores(string qsku);

    }
}
