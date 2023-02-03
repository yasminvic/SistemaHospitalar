using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class ProntuarioParcialDTO
    {
        public int id { get; set; }
        public int prontuarioId { get; set; }
        public int medicoId { get; set; }
        public string queixaPrincipal { get; set; }
        public string descricao { get; set; }
        public string historicoFamiliar { get; set; }
        public string exameFisico { get; set; }
        public string condutas { get; set; }
        public string hipoteseDiagnostica { get; set; }
        public string prescricao { get; set; }
        public DateTime createdOn { get; set; }

        public virtual MedicoDTO? medico { get; set; }

        public ProntuarioParcialDTO mapToDTO(ProntuarioParcial prontuario)
        {
            return new ProntuarioParcialDTO()
            {
                id = prontuario.Id,
                prontuarioId = prontuario.ProntuarioId,
                medicoId = prontuario.MedicoId,
                queixaPrincipal = prontuario.QueixaPrincipal,
                descricao = prontuario.Descricao,
                historicoFamiliar = prontuario.HistoricoFamiliar,
                exameFisico = prontuario.ExameFisico,
                condutas = prontuario.Condutas,
                hipoteseDiagnostica = prontuario.HipoteseDiagnostica,
                prescricao = prontuario.Prescricao,
                createdOn = prontuario.CreatedOn,

            };
        }

        public ProntuarioParcial mapToEntity()
        {
            return new ProntuarioParcial()
            {
                Id = id,
                ProntuarioId = prontuarioId,
                MedicoId = medicoId,
                QueixaPrincipal = queixaPrincipal,
                Descricao = descricao,
                HistoricoFamiliar = historicoFamiliar,
                ExameFisico = exameFisico,
                Condutas = condutas,
                HipoteseDiagnostica = hipoteseDiagnostica,
                Prescricao = prescricao,
                CreatedOn = createdOn,

            };
        }
    }
}
