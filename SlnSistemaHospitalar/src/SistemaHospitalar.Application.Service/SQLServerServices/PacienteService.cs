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
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<PacienteDTO> FindById(int id)
        {
            var p = new PacienteDTO();
            return p.mapToDTO( await _repository.FindById(id));
        }

        public List<PacienteDTO> GetAll()
        {
            return _repository.GetAll().Select(p => new PacienteDTO()
            {
                id = p.Id,
                pessoaId = p.PessoaId,
                convenioId = p.ConvenioId,
                situacao = p.Situacao
            }).ToList();
        }

        public async Task<int> Save(PacienteDTO entity)
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
