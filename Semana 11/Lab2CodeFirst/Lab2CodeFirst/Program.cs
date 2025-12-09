
using Lab2CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using var db = new AppDb();

var especialidad = new Especialidad
{
    NombreEspecialidad = "Cirujano"
};

var paciente = new Paciente
{
    Nombre = "Pedro",
    Descripcion = "Requiere una apendcectomia urgentemente"
};

var doctor = new Doctor
{
    Nombre = "Juan",
    EspecialidadDoctor = especialidad
};

var cita = new Cita
{
    Doctor = doctor,
    Paciente = paciente
};

static void MostrarCitas(AppDb c)
{
    Console.WriteLine("Citas:");
    var citas = c.Cita
        .Include(c => c.Doctor)
        .Include(c => c.Paciente)
        .ToList();
    foreach (var cita in citas)
    {
        Console.WriteLine($"Id de la cita: {cita.Id} el Dr.{cita.Doctor.Nombre} atendera a: {cita.Paciente.Nombre}" +
            $" Debido a: {cita.Paciente.Descripcion}");
    }
}
//db.Paciente.Add(paciente);
//db.Especialidads.Add(especialidad);
//db.Doctor.Add(doctor);
//db.Cita.Add(cita);
//db.SaveChanges();

MostrarCitas(db);