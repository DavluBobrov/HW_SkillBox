using Module_12.Models.Dtos;
using System.Collections.Generic;

namespace Module_12.Models
{
    public class Departament
    {
        public Departament(string name)
        {
            Name = name;
            Clients = new();
        }

        public string Name { get; set; }
        public List<ClientDto> Clients { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}