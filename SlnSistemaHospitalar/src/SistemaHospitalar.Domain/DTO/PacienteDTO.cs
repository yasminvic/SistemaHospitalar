using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class PacienteDTO
    {
        public int id { get; set; }
        public int pessoaId { get; set; }
        public int convenioId { get; set; }
        public SituacaoEnum situacao { get; set; }
        public virtual PessoaDTO? pessoa { get; set; }
        public virtual ConvenioDTO? convenio { get; set; }

        public PacienteDTO mapToDTO(Paciente paciente)
        {
            return new PacienteDTO()
            {
                id = paciente.Id,
                pessoaId = paciente.PessoaId,
                convenioId = paciente.ConvenioId,
                situacao = paciente.Situacao,
            };
        }

        public Paciente mapToEntity()
        {
            return new Paciente()
            {
                Id = id,
                PessoaId = pessoaId,
                ConvenioId = convenioId,
                Situacao = situacao,
            };
        }
    }
}
