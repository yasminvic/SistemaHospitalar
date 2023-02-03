﻿using SistemaHospitalar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.DTO
{
    public class MedicoDTO 
    {
        public int id { get; set; }
        public int pessoaId { get; set; }
        public int especialidadeId { get; set; }
        public string crm { get; set; }
        public virtual PessoaDTO? pessoa { get; set; }
        public virtual EspecialidadeMedicaDTO? especialidade { get; set; }

        public MedicoDTO mapToDTO(Medico medico)
        {
            return new MedicoDTO()
            {
                id = medico.Id,
                pessoaId = medico.PessoaId,
                especialidadeId = medico.EspecialidadeId,
                crm = medico.CRM,
            };
        }

        public Medico mapToEntity()
        {
            return new Medico()
            {
                Id = id,
                PessoaId = pessoaId,
                EspecialidadeId = especialidadeId,
                CRM = crm,
            };
        }
    }

}
