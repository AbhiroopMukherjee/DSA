using System;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddTwoNums();
            MaxPairwiseProduct();
        }

        static void AddTwoNums()
        {
            System.Console.WriteLine("Enter 1st Number - ");
            var input1 = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Enter 2nd Number - ");
            var input2 = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("The sum is : " + (input1 + input2));
        }

        static void MaxPairwiseProduct()
        {
            long num1 = 0 , num2 = 0;
            System.Console.WriteLine("Enter number of elements :");
            int noOfElements = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Enter the elements separated by space :");
            var array = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            for(int i = 0; i<noOfElements; i++)
            {
                if(array[i]>num1){
                    if(array[i]>num2){
                        num1 = num2;
                        num2 = array[i];
                    }
                    else{
                        num1 = array[i];
                    }
                }
            }

            System.Console.WriteLine("Max pairwse product : " + (num1*num2));
        }
    }
}
