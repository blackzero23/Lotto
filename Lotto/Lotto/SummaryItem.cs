using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Grade
    {
        /// <summary>
        /// 등수.
        /// </summary>
        public int No { get; set; } //몇등

        public int Count { get; set; } //몇회

        public long Amount { get; set; } // 금액



        public long TotalAmount
        {
            get
            {
                return Count * Amount;
            }
        }
    }
}
