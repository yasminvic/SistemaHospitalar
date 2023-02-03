using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.DTO
{
    public class ConvenioDTO
    {
        public int id { get; set; }
        public string nome { get; set; }

        public ConvenioDTO mapToDTO(Convenio convenio)
        {
            return new ConvenioDTO()
            {
                id = convenio.Id,
                nome = convenio.Nome
            };
        }

        public Convenio mapToEntity()
        {
            return new Convenio()
            {
                Id = id,
                Nome = nome
            };
        }
    }
}
