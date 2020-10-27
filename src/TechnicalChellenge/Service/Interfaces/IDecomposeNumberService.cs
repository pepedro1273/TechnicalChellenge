using Models.DTO;

namespace Services.Interfaces
{
    public interface IDecomposeNumberService
    {
        bool CalcNumberPrime(long number);
        DecomposeNumberDto CalcDecomposeNumber(long number);
    }
}
