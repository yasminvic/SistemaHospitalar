using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class ProntuarioService : IProntuarioService
    {
        private readonly IProntuarioRepository _repository;

        public ProntuarioService(IProntuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(ProntuarioDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public async Task<ProntuarioDTO> FindById(int id)
        {
            var pr = new ProntuarioDTO();
            return pr.mapToDTO(await _repository.FindById(id));
        }

        public List<ProntuarioDTO> GetAll()
        {
            return _repository.GetAll().Select(p => new ProntuarioDTO()
            {
                id = p.Id,
                pacienteId = p.PacienteId,
                medicoId = p.MedicoId,
                queixaPrincipal = p.QueixaPrincipal,
                descricao = p.Descricao,
                historicoFamiliar = p.HistoricoFamiliar,
                exameFisico = p.ExameFisico,
                condutas = p.Condutas,
                prescricao = p.Prescricao,
                createdOn = p.CreatedOn,
            }).ToList();
        }

        public async Task<int> Save(ProntuarioDTO entity)
        {
            if (entity.id > 0)
            {
                return await _repository.Update(entity.mapToEntity());
            }
            else
            {
                return await _repository.Save(entity.mapToEntity());
            }
        }
    }
}
