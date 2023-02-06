using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class RecepcionistaDTO : PessoaDTO
    {
        public int id { get; set; }
        public int pessoaId { get; set; }
        public string bloco { get; set; }
        public virtual PessoaDTO? pessoa { get; set; }

        public RecepcionistaDTO mapToDTO(Recepcionista recepcionista)
        {
            return new RecepcionistaDTO()
            {
                id = recepcionista.Id,
                pessoaId = recepcionista.PessoaId,
                bloco = recepcionista.Bloco,
                
            };
        }

        public Recepcionista mapToEntity()
        {
            return new Recepcionista()
            {
                Id = id,
                PessoaId = pessoaId,
                Bloco = bloco,

            };
        }
    }
}
