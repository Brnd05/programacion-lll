class Metodos
{
    //Modificadores de acceso
    //Public: Accesible desde cualquier parte del programa
    // Private: Accesible solo dentro de la clase
    // Protected: Accesible dentro de la clase y sus subclases
    // Internal: Accesible dentro del mismo ensamblado

    //Metodo simple no retorna nada
    public void MetodoSimple()
    {
        Console.WriteLine("Este es un metodo simple que no retorna nada");
    }

    //Metodo con parametros y retorno
    private int Sumar (int numero1, int numero2) // Solo se retorna un valor
    {
        return numero1 + numero2;
    }

    protected void Mostrar(string mensaje)
    {
        Console.WriteLine(mensaje);
            var suma = 10 + 10;
        
    }

    internal void Mostrar(string mensaje, int veces)
    {  for (int i = 0; i < veces; i++)
        {
            Console.WriteLine(mensaje);
        }   
    }
}