using AcademiaApp.Models;

namespace AcademiaApp.Business
{
    public interface ICarrera
    {
        Task<int> RegistrarCarrera (string nombre);

        Task<List<Carrera>> ListarCarreraAsync();
    }
}
