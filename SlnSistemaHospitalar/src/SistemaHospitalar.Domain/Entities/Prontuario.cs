using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.Entities
{
    public class Prontuario
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public IEnumerable<ProntuarioParcial> ProntuariosParciais { get; set; }
    }
}
