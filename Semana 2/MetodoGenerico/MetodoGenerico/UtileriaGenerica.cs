using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MetodoGenerico
{
    public static class UtileriaGenerica
    {
        //Devuelve lo que recibe 
        public static T Echo<T>(T valor)
        {
            return valor;
        }

        //igualdad generica para cualquier tipo
        public static bool EsIgual<T>(T primerValor, T segundoValor)
        {
            return EqualityComparer<T>.Default.Equals(primerValor, segundoValor);
        }

        public static T Max<T>(T primerValor, T segundoValor) where T : IComparable<T>
        {
            return primerValor.CompareTo(segundoValor)
                >= 0 ? primerValor : segundoValor;
        }

        //Repetir un valor varias veces, y devuelve una lista

        public static List<T> Repetir<T>(T valor, int repetir)
        {
            var Lista = new List<T>();
            for (int i = 0; i < repetir; i++)
                Lista .Add(valor);

            return Lista;

        }   
    }
}
