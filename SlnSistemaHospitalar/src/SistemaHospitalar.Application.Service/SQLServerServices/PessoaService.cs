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
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(PessoaDTO entity)
        {
            return await _repository.Delete(entity.mapToEntity());
        }

        public async Task<PessoaDTO> FindById(int id)
        {
            var pessoa = new PessoaDTO();
            return pessoa.mapToDTO(await _repository.FindById(id));
        }

        public List<PessoaDTO> GetAll()
        {
            return _repository.GetAll().Select(p => new PessoaDTO()
            {
                id = p.Id,
                nome = p.Nome,
                sobrenome = p.Sobrenome,
                email = p.Email,
                cpf = p.Cpf,
                telefone = p.Telefone,
                dataNascimento = p.DataNascimento,
                naturalidade = p.Naturalidade,
                sexo = p.Sexo,
                perfil = p.Perfil,
                createdOn = p.CreatedOn
            }).ToList();
        }

        public async Task<int> Save(PessoaDTO entity)
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
