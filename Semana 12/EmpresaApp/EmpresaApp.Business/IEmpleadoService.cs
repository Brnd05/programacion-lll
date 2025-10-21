using EmpresaApp.Models;

namespace EmpresaApp.Business
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> ListarEmpleadoAsync();

        Task AgregarEmpleadoAsync(string nombre, decimal salario, int departamentoId);

        Task<bool> ActualizarEmpleadoAsync(int id, string nombre, decimal salario, int departamentoId);

        Task<bool> EliminarEmpleadoAsync(int id);


    }
}
