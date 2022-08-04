using Module_12.Models.Clients;
using System.Collections.Generic;

namespace Module_12.Models.Repositories
{
    internal interface IClientsRepo
    {
        IEnumerable<RealClient> GetClients();
    }
}