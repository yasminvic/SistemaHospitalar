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
    public class ProntuarioParcialService : IProntuarioParcialService
    {
        private readonly IProntuarioParcialRepository _repository;

        public ProntuarioParcialService(IProntuarioParcialRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(ProntuarioParcialDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public async Task<ProntuarioParcialDTO> FindById(int id)
        {
            var pr = new ProntuarioParcialDTO();
            return pr.mapToDTO(await _repository.FindById(id));
        }

        public List<ProntuarioParcialDTO> GetAll()
        {
            return _repository.GetAll().Select(p => new ProntuarioParcialDTO()
            {
                id = p.Id,
                prontuarioId = p.ProntuarioId,
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

        public async Task<int> Save(ProntuarioParcialDTO entity)
        {
            if (entity.id < 0)
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
