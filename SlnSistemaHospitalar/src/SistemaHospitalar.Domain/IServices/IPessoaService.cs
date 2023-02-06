﻿using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Domain.IServices
{
    public interface IPessoaService : IBaseService<PessoaDTO>
    {
        //PessoaDTO GetTheLast();
    }
}
