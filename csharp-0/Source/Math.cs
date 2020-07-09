using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            var listaNumeros = new List<int>() {0, 1};
            for (int i = 1; (listaNumeros[i-1] + listaNumeros[i]) <= 350; i++){
                listaNumeros.Add(listaNumeros[i-1] + listaNumeros[i]);    
            }
            return listaNumeros;
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    }
}
