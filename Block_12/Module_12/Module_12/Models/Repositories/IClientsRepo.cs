using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12.Models.Repositories
{
    internal interface IClientsRepo
    {
        IEnumerable<RealClient> GetClients();
    }
}