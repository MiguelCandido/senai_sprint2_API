using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {
        public int IdVeiculo { get; set; }
        public string TipoVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public int IdModelo { get; set; }
        public int IdEmpresa { get; set; }

        public ModeloDomain modelo { get; set; }
        public EmpresaDomain empresa { get; set; }

    }
}
