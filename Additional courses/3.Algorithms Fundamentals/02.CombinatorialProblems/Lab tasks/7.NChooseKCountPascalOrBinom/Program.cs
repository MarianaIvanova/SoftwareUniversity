using System;

namespace _7.NChooseKCountPascalOrBinom
{
    class Program
    {
        static void Main(string[] args)
        {
            //PASCAL's triangle БИНОМЕН коефициент!

            var n = int.Parse(Console.ReadLine());//Rows in Pascal's triangle - starting with 0// при 4 или при 5 
            var k = int.Parse(Console.ReadLine());//Columns in Pascal's triangle - starting with 0 //при 2 или при 3

            Console.WriteLine(GetBinom(n,k));//6 или 10
        }

        private static int GetBinom(int row, int col)
        {
            //Base - дъно
            if(row <= 1 || col == 0 || col == row)//row <= 1 - първите два реда 0 и 1 са единици, а също така първите и последните елементи на всеки ред са единици също (т.е. първата и последната колона), т.е. col = 0 (да първия елемент) и col == row, защото последния елемент позицията му е равна на номера на реда!
            {
                return 1;
            }

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }
}
