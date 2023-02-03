using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.DTO
{
    public class EspecialidadeMedicaDTO
    {
        public int id { get; set; }
        public string nome { get; set; }

        public EspecialidadeMedicaDTO mapToDTO(EspecialidadeMedica especialidade)
        {
            return new EspecialidadeMedicaDTO()
            {
                id = especialidade.Id,
                nome = especialidade.Nome,
            };
        }

        public EspecialidadeMedica mapToEntity()
        {
            return new EspecialidadeMedica()
            {
                Id = id,
                Nome = nome,
            };
        }
    }
}