using System.Collections.Generic;

namespace Models.DTO
{
    public class DecomposeNumberDto
    {
        public Dictionary<long, long> Numbers { get; set; }
        public IEnumerable<long> PrimeNumbers { get; set; }
    }
}
