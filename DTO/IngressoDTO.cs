﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.DTO
{
    public class IngressoDTO
    {
        public Guid FilmeId { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }
    }
}
