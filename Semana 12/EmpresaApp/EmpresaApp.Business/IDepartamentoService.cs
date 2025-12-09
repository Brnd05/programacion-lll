using EmpresaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Business
{
    public interface IDepartamentoService
    {
        Task <List<Departamento>> ListarDepartamentosAsync();
        Task<int> CrearDepartamentoAsync(string nombre);

        Task<bool> ActualizarDepartamentoAsync(int id, string nuevoNombre);

        Task<bool> EliminarDepartamentosAsync(int id);

    }
}
