﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstract 
{ 
    public interface IPetRepository: IBaseRepository<Pet>
    {
        IEnumerable<Pet> ObterPetsPorPalavraChave(string palavraChave);

    }
}
