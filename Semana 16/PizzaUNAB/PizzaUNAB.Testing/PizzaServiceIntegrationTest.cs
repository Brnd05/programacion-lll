using PizzaUNAB.Application.DTOs;
using PizzaUNAB.Infrastructure.Data;
using PizzaUNAB.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Testing
{
    //Crear el contexto de la base de datos en memoria para las pruebas de integracion
    public class PizzaServiceIntegrationTest
    {
        private PizzeriaDb CreateDb()
        {
         return TestDbFactory.CreateInMemory();
        }
        //Patron AAA - Arrange, Act, Assert
        //Arrange(Preparar) - Preparar el contexto de la prueba
        //Act(Actuar) - Ejecutar la accion a probar
        //Assert(Afirmar) - Verificar el resultado esperado
        //Assert.xxx

        [Fact]
        public async Task CrearPizza_DeberiaGuardarEnBD()
        {
            //Arrange (Preparar)
            using var db = CreateDb();
            var service = new PizzaService(db);
            var dto = new PizzaCreateDto
            {
                Nombre = "Jamón",
                Precio = 8.99m,
                Stock = 10
            };

            //Act (Actuar)  
            var id = await service.CreateAsync(dto);
            var pizza = await service.GetByIdAsync(id);

            //Assert (Afirmar)
            Assert.NotNull(pizza);
            Assert.Equal("Jamon", pizza.Nombre);
            Assert.Equal(8.99m, pizza.Precio);
            Assert.Equal(10, pizza.Stock);
        }
        [Fact]
        public async Task ActualizarPizza_DeberiaModificarLosDatosEnBD()
        {
            //Arrange (Preparar)
            using var db = CreateDb();

            var service = new PizzaService(db);

            var id = await service.CreateAsync(new PizzaCreateDto
            {
                Nombre = "Pepperoni",
                Precio = 6,
                Stock = 5
            });
            //Act (Actuar)
            var ok = await service.UpdateAsync(id, new PizzaUpdateDto {
                Nombre = "Pepperoni Updated",
                Precio = 6.99m,
                Stock = 8
            });

            var pizza = await service.GetByIdAsync(id);
            //Assert (Afirmar)
            Assert.True(ok);
            Assert.NotNull(pizza);
            Assert.Equal("Pepperoni Updated", pizza.Nombre);
            Assert.Equal(6.99m, pizza.Precio);
            Assert.Equal(8, pizza.Stock);
        }

        [Fact]
        public async Task EliminarPizza_DeberiaEliminarDeBD() { 
         using var db = CreateDb();
            var service = new PizzaService(db);
            var id = await service.CreateAsync(new PizzaCreateDto
            {
                Nombre = "Hawaiana",
                Precio = 7.5m,
                Stock = 12
            });

            //Act (Actuar)
            var ok = await service.DeleteAsync(id);
            var pizzaEliminada = await service.GetByIdAsync(id);
          
            //Assert (Afirmar)
            Assert.True(ok);
            Assert.Null(pizzaEliminada);
        }
}

    }