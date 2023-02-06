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
    public class EspecialidadeMedicaService : IEspecialidadeMedicaService
    {
        private readonly IEspecialidadeMedicaRepository _repository;

        public EspecialidadeMedicaService(IEspecialidadeMedicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(EspecialidadeMedicaDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public async Task<EspecialidadeMedicaDTO> FindById(int id)
        {
            var esp = new EspecialidadeMedicaDTO();
            return esp.mapToDTO(await _repository.FindById(id));
        }

        public List<EspecialidadeMedicaDTO> GetAll()
        {
            return _repository.GetAll().Select(e => new EspecialidadeMedicaDTO()
            {
                id = e.Id,
                nome = e.Nome
            }).ToList();
        }

        public async Task<int> Save(EspecialidadeMedicaDTO entity)
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
