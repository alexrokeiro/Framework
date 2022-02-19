using Infra;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Number
    {
        private Number() { }

        public int Value { get; private set; }

        public static DomainResult<Number> Create(int value)
        {
            if (value < 1)
                return DomainResult<Number>.CreateFail("Valor precisa ser maior que zero.");

            Number number = new Number();
            number.Value = value;

            return DomainResult<Number>.CreateSuccess(number);
        }

        public List<int> GetDividers()
        {
            List<int> dividers = new List<int>();
            dividers.Add(1);
            for (int i = 2; i < Value; i++)
            {
                if ((Value % i) == 0)
                    dividers.Add(i);
            }
            if (!dividers.Any(it => it == Value))
                    dividers.Add(Value);

            return dividers;
        }

        public List<int> GetPrimeDividers()
        {
            List<int> dividers = GetDividers();
            List<int> primeNumbers = new List<int>();

            foreach (var divider in dividers)
            {
                if (IsPrimeNumber(divider))
                    primeNumbers.Add(divider);
            }

            return primeNumbers;
        }

        public bool IsPrimeNumber(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if ((number % i) == 0)
                    return false;
            }

            return true;
        }
    }
}
