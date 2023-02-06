using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(MedicoDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public async Task<MedicoDTO> FindById(int id)
        {
            var med = new MedicoDTO();
            return med.mapToDTO(await _repository.FindById(id));
        }

        public List<MedicoDTO> GetAll()
        {
            return _repository.GetAll().Select(m => new MedicoDTO()
            {
                id = m.Id,
                pessoaId = m.PessoaId,
                especialidadeId = m.EspecialidadeId,
                crm = m.CRM
            }).ToList();
        }

        public async Task<int> Save(MedicoDTO entity)
        {
            if(entity.id > 0)
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
