using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Domain.Repositories;
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
        private readonly IPessoaRepository _pessoaRepository;

        public RecepcionistaService(IRecepcionistaRepository repository, IPessoaRepository pessoaRepository)
        {
            _repository = repository;
            _pessoaRepository = pessoaRepository;
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

        public async Task<List<RecepcionistaDTO>> GetAll()
        {
            List<RecepcionistaDTO> listaDTO = new List<RecepcionistaDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var rec = new RecepcionistaDTO();
                listaDTO.Add(rec.mapToDTO(item));
            }

            foreach (var recepcionista in listaDTO)
            {
                var pessoadto = new PessoaDTO();
                recepcionista.pessoa = pessoadto.mapToDTO(await _pessoaRepository.FindById(recepcionista.pessoaId));
            }

            return listaDTO;
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
