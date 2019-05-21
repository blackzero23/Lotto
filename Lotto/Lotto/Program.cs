using LottoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Round> rounds = Round.Load(@"d:\Lotto.txt");
         
            string input = Console.ReadLine(); //1 2 3 4 12 23
            string[] tokens = input.Split(' ');
                        
            //람다식.
            List<int> numbers = tokens.Select(x => int.Parse(x)).ToList();
            
            //구매이력.?
            List<Purchase> purchases = new List<Purchase>(rounds.Count());
            
            //각회 당첨 입력번화  입력한 번호 비교 계산후 당첨 시 구매이력에 저장
            foreach (Round round in rounds)
            {
                Purchase purchase = new Purchase();
                purchase.Caclulate(numbers, round);
                purchases.Add(purchase);
            }


            //저장된 구매 이력에서 각 등급에 이동?
            //grade 생성
            List<Grade> grades = new List<Grade>();
            
            for (int i = 0; i < 5; i++)
            {
                Grade grade = new Grade();
                grade.No = i+1;
                foreach (Purchase puchase in purchases)
                {
                    if (puchase.Grade != i + 1) continue;
                    grade.Count++;
                    grade.Amount += puchase.Prize;
                }
                grades.Add(grade);
            }
            //LINQ
            //각 등수(1등~5등)인 객체들을 뽑아야한다.
            //각 grade 등수에 해당하는 객체에 정보를 넣어야한다.

            for (int i = 0; i < 5; i++)
            {
                var temp = from purchase in purchases
                          from grade in grades
                           where purchase.Grade == i + 1
                          select purchase;
            }



            long totalAmount = 0;
            foreach (Grade grade in grades)
            {
                Console.WriteLine($"{grade.No}등 : {grade.Count}회," +
                    $"{grade.Amount:C0}");
                totalAmount += grade.Amount;
            }

            long totalPurchaseaMount = ((long)purchases.Count() * 1000);

            Console.WriteLine($"총 구매금액 : { purchases.Count() * 1000:C0}");

            Console.WriteLine($"총 당첨금액 : { totalAmount :C0}");
            //수익률 = 총당첨금액 - 구매금액 / 구매 금액 
            double yield = (double)(totalAmount - totalPurchaseaMount) / totalPurchaseaMount;

            Console.WriteLine($"수익률 : { yield:P2}");


            Console.WriteLine();

        }
    }
}
