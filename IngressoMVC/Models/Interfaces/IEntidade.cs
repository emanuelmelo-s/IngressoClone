﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.Interfaces
{
    public interface IEntidade
    {
        
        int Id { get;  }
        DateTime DataCadastro { get;  }
        DateTime DataAlteracao { get; }
    }
}
