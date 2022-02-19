using System.Collections.Generic;

namespace Application.Dto
{
    public class GetDividersAndPrimeDividersDTO
    {
        public int Number { get; set; }
        public List<int> Dividers { get; set; }
        public List<int> PrimeDividers { get; set; }
    }
}
