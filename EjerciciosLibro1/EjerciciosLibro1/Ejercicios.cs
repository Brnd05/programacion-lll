using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosLibro1
{

    public class Ejercicios
    {
        public void convertirFarenheint()
        {
            int F;
            Console.WriteLine("Ingrese una cantidad de grados farenheint para convertirla a su correspondiente en centigrados: ");
            F = int.Parse(Console.ReadLine());
            Console.WriteLine($"Grados Farenheint: {F}°F ");
            int C = F - 32;
            C = C * 5;
            C = C / 9;


            Console.WriteLine($"{F}°F equivalen a {C}°C");
        }

        public void encontrarHipotenusa()
        {
            Console.WriteLine("Este programa sirve para encontrar la hipotenusa por medio de sus dos catetos\n" +
                "digite el primer valor:");

            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite el segundo valor: ");
            int b = int.Parse(Console.ReadLine());
            double potenciacion = a * a + b * b;
            double resultado = Math.Sqrt(potenciacion);
            Console.WriteLine($"Los valores que ingresaste son {a} y {b}");
            Console.WriteLine($"por lo tanto su hipotenusa es {resultado}");

        }

        public void encontrarCodigoASCII()
        {
            Console.WriteLine("Este programa encuentra el codigo ascii segun los numeros ingresados\n" +
                "tambien la combinación de numeros necesarios para obtener dicho resultado");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Ingrese un caracter no numerico para mostrar su codigo ASCII: ");
            string Caracter = Console.ReadLine();
            byte[] Codifiacion;
            Codifiacion = Encoding.ASCII.GetBytes(Caracter);
            foreach (byte b in Codifiacion)
            {



                Console.WriteLine(b);




            }
            Console.WriteLine("Ahora digite un codigo ASCII para encontrar el caracter correspondiente: ");
            int Codigo = int.Parse(Console.ReadLine());
            char Decoficacion = Convert.ToChar(Codigo);
            Console.WriteLine(Decoficacion);



        }
        // Un empleado trabaja 48 horas a la semana a razón de $5000 por hora.
        // El porcentaje de retención en la fuente es del 12.5% del salario bruto
        // Se desea saber cuál es el salario bruto, la retención en la fuente y el salario neto semanal del trabajador.

        public void salariobruto()
        {
            int SalarioPorHora = 5000;
            Console.WriteLine("Este programa averigua el salario bruto de un empleado que trabaja 48hrs semanales y el salario despues de la retencion de fuente ");
            double Retencion = 12.5 / 100;
            int SalarioSemanal = SalarioPorHora * 48;
            double SalarioRetencion = SalarioSemanal * Retencion;
            double SalarioFinal = SalarioSemanal - SalarioRetencion;

            Console.WriteLine($"El salario por hora es de ${SalarioPorHora} dolares y el salario bruto seria de ${SalarioSemanal} dolares");
            Console.WriteLine($"La retención de fuente es de ${SalarioRetencion} dolares ");
            Console.WriteLine($"El Salario semanal luego de la retencion de fuente seria de ${SalarioFinal}");

        }

        public void intercambiarValores()
        {
            Console.WriteLine("Intercambiar los valores de a y b");
            Console.WriteLine("Ingrese el valor de a: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de b: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"El valor de a es: {a} y el valor de b es {b}");
            a = b;
            b = a;
            Console.WriteLine($"Cn los valores intercambiados a seria: {a} y b seria: {b}");

        }
        

        

        

    }
}
