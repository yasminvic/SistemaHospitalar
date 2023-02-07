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
    public class RecepcionistaService : IRecepcionistaService
    {
        private readonly IRecepcionistaRepository _repository;

        public RecepcionistaService(IRecepcionistaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<RecepcionistaDTO> FindById(int id)
        {
            var r = new RecepcionistaDTO();
            return r.mapToDTO(await _repository.FindById(id));
        }

        public List<RecepcionistaDTO> GetAll()
        {
            return _repository.GetAll().Select(r => new RecepcionistaDTO()
            {
                id = r.Id,
                pessoaId = r.PessoaId,
                bloco = r.Bloco
            }).ToList();
        }

        public async Task<int> Save(RecepcionistaDTO entity)
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
