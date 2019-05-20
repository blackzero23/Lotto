using LottoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Round> rounds = Round.Load(@"d:\Lotto.txt");

            //foreach (Round round in rounds)
            //{
            //    Console.WriteLine(round.No);
            //}

            string input = Console.ReadLine(); //1 2 3 4 12 23
            string[] tokens = input.Split(' ');
            //List<int> numbers = new List<int>();

            //foreach (string token in tokens)
            //{
            //    int number = int.Parse(token);
            //    numbers.Add(number);
            //}

            //람다식.
            List<int> numbers = tokens.Select(x => int.Parse(x)).ToList();


            //구매이력.?
            List<Purchase> purchases = new List<Purchase>(rounds.Count());

            foreach (Round round in rounds)
            {
                Purchase purchase = new Purchase();
                purchase.Caclulate(numbers, round);
                purchases.Add(purchase);
            }


            List<Grade> grades = new List<Grade>();
            for (int i = 0; i < 5; i++)
            {
                //grade 생성
            }


            foreach (Grade grade in grades)
            {
                Console.WriteLine($"{grade.No}등 : {grade.Count}회," +
                    $"{grade.Amount:C0}");
            }


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}등 : {0}회 * {0:C0} = " +
                    $"{0:C0}");
            }

            Console.WriteLine($"총 구매금액 : { purchases.Count() * 1000:C0}");
            Console.WriteLine($"총 당첨금액 : { 0:C0}");

            Console.WriteLine($"수익률 : { 0:P2}");


            Console.WriteLine();

        }
    }
}
