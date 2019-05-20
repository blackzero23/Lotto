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
        /// <summary>
        /// 구매 횟수 ?
        /// </summary>
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
            //Grade = 1;
            //Prize = 2_200_000_000;

            //저장되어있는 numbers 랑 round 랑 비교를 해야된다.

            No = round.No;

            //비교
            int sameNumber = 0;
            int bounsnumber = 0;
            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == round.Numbers[j])
                        sameNumber++;                                     
                }
                if (numbers[i] == round.Bonus)
                    bounsnumber++;
            }

            //비교 확인 후 저장
            if(sameNumber == 6)
            {               
                Grade = 1;
                Prize = round.FirstPrize;
            }
            else if(sameNumber == 5 && bounsnumber == 1)
            {                
                Grade = 2;
                Prize = round.SecondPrize;
            }
            else if(sameNumber == 5)
            {                
                Grade = 3;
                Prize = round.ThirdPrize;
            }
            else if(sameNumber == 4)
            {                
                Grade = 4;
                Prize = 50000;
            }
            else if(sameNumber == 3)
            {                
                Grade = 5;
                Prize = 5000;
            }            
        }
    }
}
