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
            No = round.No;

            //비교
            int sameNumberCnt = 0;
            bool sameBounsnumber = false;

//            foreach (var number in numbers)
//            {
//                sameNumberCnt += round.Numbers.Count(x => x == number);
//                
//            }
            
            foreach (var number in numbers)
            {
                //t는 리스트의 원소 , j 는 인덱스.
                sameNumberCnt += numbers.Where((t, j) => number == round.Numbers[j]).Count();
                
                
                if (number == round.Bonus)
                    sameBounsnumber= true;
            }
            
//            for (int i = 0; i < numbers.Count(); i++)
//            {
//                for (int j = 0; j < numbers.Count; j++)
//                {
//                    if (numbers[i] == round.Numbers[j])
//                        sameNumberCnt++;                                     
//                }
//                if (numbers[i] == round.Bonus)
//                    sameBounsnumber= true;
//            }



            //round.Count(x => x.Bonus == 3);

            //익명타입 공부.
            //메서드 타입.
            //복잡도가 감소한다.
            //var ??2 = rounds.Where(x=>x.Bonus ==3)
            //    .Select(x=>new ???(x.No,,xfirstPrize))
            
            ////쿼리 타입
            //var ??3 = from x in rouns
            //          where x.Bouns ==3
            //          select new {x,No, x.FirstPrize}.Tolist

           

            //LINQ
            //group by 로 묶어야될까 ?
            // 같다면 반환을 어떻게 해야되나 .?

            //var sameNumbers = from number in numbers
            //                  from roundNumber in round.Numbers
            //                  where number == roundNumber
            
            
            // select number;

            //var bounsnumber2 = from number in numbers
            //                   where number == round.Bonus
            //                   select number;


            switch (sameNumberCnt)
            {
                //비교 확인 후 저장
                case 6:
                    Grade = 1;
                    Prize = round.FirstPrize;
                    break;
                case 5 when sameBounsnumber:
                    Grade = 2;
                    Prize = round.SecondPrize;
                    break;
                case 5:
                    Grade = 3;
                    Prize = round.ThirdPrize;
                    break;
                case 4:
                    Grade = 4;
                    Prize = 50000;
                    break;
                case 3:
                    Grade = 5;
                    Prize = 5000;
                    break;
            }            
        }
    }
}
