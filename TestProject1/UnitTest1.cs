using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Hashtable lista = new Hashtable();

            lista.Add(123, "Juan");
            lista.Add(456, "Marcos");
            lista.Add(789, "Luis");
            lista.Add(012, "Maria");

            Assert.Equal(4, lista.Count); //Verificamos la cantidad de objetos en la lista
            Assert.Equal("Juan", lista[123]);// Buscamos el objeto con nombre Maria a travez de su codigo hash

            lista.Remove(123);//Removemos el objeto con nombre Juan a travez de su codigo hash 

            Assert.Equal(3, lista.Count);//Verificamos la cantidad de objetos nuevamente
            Assert.NotEqual("Juan", lista[123]);//Se verifica que el objeto con nombre Juan se halla eliminado
            Assert.NotEqual("marcos", lista[456]);//Probamos que las listas Hash no son sensibles a los cambios de mayusculas o minusculas

            lista.Clear();//Borramos todos los objetos de la lista
            Assert.Empty(lista);//Corroboramos el paso anterior
        }

        [Theory]
        [InlineData(1000, "Demo1")]
        [InlineData(10000, "Demo2")]
        [InlineData(100000, "Demo3")]
        [InlineData(1000000, "Demo4")]
        [InlineData(10000000, "Demo5")]
        public void Test2(int cantidad, string nombre) //Hacemos una comparacion entre una lista HashTable y  
        {                                               //linkedList de tiempo de busqueda de un objeto en una lista determinada
            Hashtable hashtable = new Hashtable();
            LinkedList<int> linkedList = new LinkedList<int>();

            // Se cargan los datos en hashtable y linkedList por medio de un bucle for
            for (int i = 0; i < cantidad; i++)
            {
                hashtable.Add(i, i);
                linkedList.AddLast(i);
            }

            int a = cantidad - 150;

            // Buscar elemento en hashtable
            var stopwatchHashtable = Stopwatch.StartNew();
            var hashtableResult = hashtable[a];
            stopwatchHashtable.Stop();

            // Buscar elemento en linkedList
            var stopwatchLinkedList = Stopwatch.StartNew();
            var linkedListResult = linkedList.ElementAt(a);
            stopwatchLinkedList.Stop();

            // Se comprueba que los resultados son iguales
            Assert.Equal(hashtableResult, linkedListResult);

            // Comparamos tiempos de búsqueda
            Assert.True(stopwatchHashtable.ElapsedMilliseconds < stopwatchLinkedList.ElapsedMilliseconds);

        }

    }

}