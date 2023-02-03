using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class ProntuarioDTO
    {
        public int id { get; set; }
        public int pacienteId { get; set; }
        public IEnumerable<ProntuarioParcialDTO> ProntuariosParciais { get; set; }

        public ProntuarioDTO mapToDTO(Prontuario prontuario)
        {
            return new ProntuarioDTO()
            {
                id = prontuario.Id,
                pacienteId = prontuario.PacienteId,

            };
        }

        public Prontuario mapToEntity()
        {
            return new Prontuario()
            {
                Id = id,
                PacienteId = pacienteId,

            };
        }
    }
}
