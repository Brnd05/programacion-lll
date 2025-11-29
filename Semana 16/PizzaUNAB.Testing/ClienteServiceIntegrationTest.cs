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
    public class ClienteServiceIntegrationTest
    {
        private PizzeriaDb CreateDb()
        {
            return TestDbFactory.CreateInMemory();
        }

        [Fact]
        public async Task CrearCliente_DeberiaGuardarEnBd()
        {
            //Arrange (Preparar)
            using var db = CreateDb();
            var service = new ClienteService(db);
            var dto = new ClienteCreateDto
            {
                Nombre = "Juan Perez",
                Telefono = "123456789"
            };

            //Act (Actuar)  
            var id = await service.CreateAsync(dto);
            var cliente = await service.GetByIdAsync(id);

            //Assert (Afirmar)
            Assert.NotNull(cliente);
            Assert.Equal("Juan Perez", cliente.Nombre);
            Assert.Equal("123456789", cliente.Telefono);

            
        }
        [Fact]
        public async Task ActualizarCliente_DeberiaGuardarEnBD()
        {
            //Arrange (Preparar)
            using var db = CreateDb();

            var service = new ClienteService(db);

            var id = await service.CreateAsync(new ClienteCreateDto
            {
                Nombre = "Manuel",
                Telefono = "987654321"
            });
            //Act (Actuar)
            var ok = await service.UpdateAsync(id, new ClienteUpdateDto
            {
                Nombre = "Manuel Actualizado",
                Telefono = "111222333"

            });

            var cliente = await service.GetByIdAsync(id);
            //Assert (Afirmar)
            Assert.True(ok);
            Assert.NotNull(cliente);
            Assert.Equal("Manuel Actualizado", cliente.Nombre);
            Assert.Equal("111222333", cliente.Telefono);
        }

        [Fact]
        public async Task EliminarCliente_DeberiaEliminarDeBD()
        {
            //Arrange (Preparar)
            using var db = CreateDb();
            var service = new ClienteService(db);
            var id = await service.CreateAsync(new ClienteCreateDto
            {
                Nombre = "Carlos",
                Telefono = "555666777"
            });
            //Act (Actuar)
            var ok = await service.DeleteAsync(id);
            var cliente = await service.GetByIdAsync(id);
            //Assert (Afirmar)
            Assert.True(ok);
            Assert.Null(cliente);
        }
    }
}
