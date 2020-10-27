using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class DecomposeNumberService : IDecomposeNumberService
    {
        public bool CalcNumberPrime(long number)
        {
            bool result = false;

            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    i = number + 1;
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        public DecomposeNumberDto CalcDecomposeNumber(long number)
        {
            try
            {
                var count = 1;
                var aux = 0;
                var lastDivisor = 2;
                var numberPrimos = new List<long>();
                var numbers = new Dictionary<long, long>();

                for (int i = 2; number > 1; i++)
                {
                    if (number % i == 0)
                    {
                        if (lastDivisor == i)
                        {
                            aux++;
                        }
                        else
                        {
                            count *= aux + 1;
                            lastDivisor = i;
                            aux = 1;
                        }

                        number /= i;

                        if (this.CalcNumberPrime(lastDivisor) && !numberPrimos.Contains(lastDivisor))
                        {
                            numberPrimos.Add(lastDivisor);
                        }

                        numbers.Add(number, lastDivisor);
                        i = 1;
                    }
                }

                count *= aux + 1;

                return new DecomposeNumberDto
                {
                    Numbers = numbers,
                    PrimeNumbers = numberPrimos
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
