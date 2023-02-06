using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class PessoaDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public string naturalidade { get; set; }
        public SexoEnum sexo { get; set; }
        public PerfilEnum perfil { get; set; }
        public DateTime createdOn { get; set; }


        public PessoaDTO mapToDTO(Pessoa pessoa)
        {
            return new PessoaDTO()
            {
                id = pessoa.Id,
                nome = pessoa.Nome,
                sobrenome = pessoa.Sobrenome,
                cpf = pessoa.Cpf,
                rg = pessoa.Rg,
                telefone = pessoa.Telefone,
                email = pessoa.Email,
                dataNascimento = pessoa.DataNascimento,
                naturalidade = pessoa.Naturalidade,
                sexo = pessoa.Sexo,
                perfil = pessoa.Perfil,
                createdOn = pessoa.CreatedOn,
            };
        }

        public Pessoa mapToEntity()
        {
            return new Pessoa()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                Cpf = cpf,
                Rg = rg,
                Telefone = telefone,
                Email = email,
                DataNascimento = dataNascimento,
                Naturalidade = naturalidade,
                Sexo = sexo,
                Perfil = perfil,
                CreatedOn = createdOn,
            };
        }
    }
}
