using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class EnderecoDTO
    {
        public int id { get; set; }
        public int pessoaId { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }

        public EnderecoDTO mapToDTO(Endereco endereco)
        {
            return new EnderecoDTO()
            {
                id = endereco.Id,
                pessoaId = endereco.PessoaId,
                cep = endereco.Cep,
                rua = endereco.Rua,
                numero = endereco.Numero, 
                bairro = endereco.Bairro,
                cidade = endereco.Cidade,
                uf = endereco.UF,
            };
        }

        public Endereco mapToEntity()
        {
            return new Endereco()
            {
                Id = id,
                PessoaId = pessoaId,
                Cep = cep,
                Rua = rua,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf,
            };
        }
    }
}
