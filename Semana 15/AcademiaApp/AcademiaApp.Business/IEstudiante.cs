using AcademiaApp.Models;

namespace AcademiaApp.Business
{
    public interface IEstudiante
    {
        Task AgregarEstudianteAsync(string nombre, string carnet, int carreraId);

        Task<List<Estudiante>> ListarEstudianteAsync();

    }
}
 
 