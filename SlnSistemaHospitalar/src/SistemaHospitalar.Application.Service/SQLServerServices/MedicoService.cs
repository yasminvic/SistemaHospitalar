using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Domain.Repositories;
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
        private readonly IPessoaService _pessoaRepository;

        public MedicoService(IMedicoRepository repository, IPessoaService pessoaRepository)
        {
            _repository = repository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }


        public async Task<MedicoDTO> FindById(int id)
        {
            var med = new MedicoDTO();
            return med.mapToDTO(await _repository.FindById(id));
        }

        public async Task<MedicoDTO> FindByIdPessoa(int id)
        {
            var medico = new MedicoDTO();
            return medico.mapToDTO(await _repository.FindByIdPessoa(id));
        }

        public async Task<List<MedicoDTO>> GetAll()
        {
            List<MedicoDTO> listaDTO = new List<MedicoDTO>();

            var lista = await _repository.GetAll();
            foreach (var item in lista)
            {
                var med = new MedicoDTO();
                listaDTO.Add(med.mapToDTO(item));
            }

            foreach (var medico in listaDTO)
            {
                var pessoadto = new PessoaDTO();
                medico.pessoa = await _pessoaRepository.FindById(medico.pessoaId);
            }

            return listaDTO;
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
