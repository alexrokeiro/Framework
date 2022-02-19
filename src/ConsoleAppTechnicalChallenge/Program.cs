using Domain;
using Infra;
using System;

namespace ConsoleAppTechnicalChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainResult<Number> domainResult = Number.Create(0);
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Informe um número.");
                string numberString = Console.ReadLine();
                int.TryParse(numberString, out int inputNumber);
                domainResult = Number.Create(inputNumber);
                if (!domainResult.IsSucess)
                    Console.WriteLine(domainResult.Error);

                valid = domainResult.IsSucess;
            }

            Console.WriteLine("Número de entrada: {0}", domainResult.Model.Value);
            Console.WriteLine("Número divisores: {0}", string.Join(" ", domainResult.Model.GetDividers()));
            Console.WriteLine("Divisores primos: {0}", string.Join(" ", domainResult.Model.GetPrimeDividers()));
            Console.ReadLine();
        }
    }
}
