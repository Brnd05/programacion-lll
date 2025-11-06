using AcademiaApp.Models;

namespace AcademiaApp.Business
{
    public interface IEstudiante
    {
        Task AgregarEstudianteAsync(string nombre, int carnet, int carreraId);

        Task<List<Estudiante>> ListarEstudianteAsync();

    }
}
 
 