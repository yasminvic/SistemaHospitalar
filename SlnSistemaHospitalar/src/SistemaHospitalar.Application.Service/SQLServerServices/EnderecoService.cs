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
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _repository = enderecoRepository;
        }

        public async Task<int> Delete(EnderecoDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public async Task<EnderecoDTO> FindById(int id)
        {
            var end = new EnderecoDTO();
            return end.mapToDTO(await _repository.FindById(id));
        }

        public List<EnderecoDTO> GetAll()
        {
            return _repository.GetAll().Select(e => new EnderecoDTO()
            {
                id = e.Id,
                pessoaId = e.PessoaId,
                cep = e.Cep,
                rua = e.Rua,
                numero = e.Numero,
                bairro = e.Bairro,
                cidade = e.Cidade,
                uf = e.UF
            }).ToList();
        }

        public async Task<int> Save(EnderecoDTO entity)
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
