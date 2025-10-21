using Microsoft.EntityFrameworkCore;
using OperacionesCRUD.Models;

using var db = new EmpresaContext();

//Crear un nuevo Departamento
var departamento = new Departamento { Nombre = "Recursos Humanos" };

//db.Departamentos.Add(departamento);
//db.SaveChanges();


//Crear un nuevo Empleado
var empleado1 = new Empleado { Nombre = "Dario", Salario = 750.00m, DepartamentoId = departamento.Id };
var empleado2 = new Empleado { Nombre = "Luis", Salario = 850.00m, DepartamentoId = departamento.Id };
//db.Empleados.AddRange(empleado1,empleado2);
//db.SaveChanges();

//Obtener

var empleados = db.Empleados.Include(e => e.Departamento).ToList();

Console.WriteLine("Lista de Empleados");
foreach (var e in empleados)
{
    Console.WriteLine($"{e.Nombre} - {e.Departamento.Nombre} - {e.Salario}");
}

//Actualizar 
var empleado = db.Empleados.FirstOrDefault(e => e.Nombre.Contains("Dario"));

if (empleado != null)
{
    empleado.Salario += 150;
    db.SaveChanges();
    Console.WriteLine($"Salario actualizado para {empleado.Nombre} ");
}

//Eliminar 
var empleadoEliminar = db.Empleados.FirstOrDefault(e => e.Nombre.Contains("Luis"));
if (empleadoEliminar != null)
{
    db.Empleados.Remove(empleadoEliminar);
    db.SaveChanges();
    Console.WriteLine($"Se elimino: {empleadoEliminar.Nombre}");
}


Console.ReadLine();