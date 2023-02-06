using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Application.Service.SQLServerServices
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _repository;

        public ConvenioService(IConvenioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(ConvenioDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public List<ConvenioDTO> GetAll()
        {
            return _repository.GetAll().Select(c => new ConvenioDTO()
                                                {
                                                    id = c.Id,
                                                    nome = c.Nome
                                                }).ToList();
        }

        public async Task<int> Save(ConvenioDTO entity)
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

        public async Task<ConvenioDTO> FindById(int id)
        {
            var conv = new ConvenioDTO();
            return conv.mapToDTO(await _repository.FindById(id));
        }
    }
}
