using System;
using LottoLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Purchase
    {
        public int No { get; set; }


        /// <summary>
        /// 등수
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 당첨금
        /// </summary>
        public long Prize { get; set; }


        public void Caclulate(List<int> numbers, Round round)
        {
            Grade = 1;
            Prize = 2_200_000_000;
        }
    }
}
