using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.Contracts;
using UMarket.Infraestructure.Data;
namespace UMarket.Infraestructure.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly UMarketDb _db;

        public CategoriaService(UMarketDb db) => _db = db;

        public async Task
    }
}
