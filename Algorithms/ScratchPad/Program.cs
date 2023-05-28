using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ScratchPad
{
    class first
    {
        public string A { get; set; }
        public string B { get; set; }
    }

    class second : first
    {
        public string C { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            #region function Calls
            // var obj1 = new second();
            // first obj2 = obj1;
            // System.Console.WriteLine(obj2);

            //AddTwoNums();
            //MaxPairwiseProduct();

            // for(int i=0;i<25;i++)
            //     System.Console.Write(fibo(i)+ "\t");

            //System.Console.WriteLine(fiboArray(40));

            //NaiveGCD(23434455,13234);
            //System.Console.WriteLine(SmartGCD(7,8)); //Euclidean algorithm

            //System.Console.WriteLine(fiboArrayLastDigit(443));

            //LCM(761457,614573);

            //System.Console.WriteLine(fiboArrayModuloM(15,3));

            //System.Console.WriteLine(fiboSumLastDigit(100));

            //System.Console.WriteLine(fiboSumMToNLastDigit(10,200));

            //System.Console.WriteLine(fiboSumOfSquaresLastDigit(1234567890));

            //System.Console.WriteLine(CarRefuelling(10,new int[] {0,3,5,13,18,25,29})); //O(n)

            //System.Console.WriteLine(MinChildrenGroups(new double[] {4,3.5,5.2,4.5,6,7.2,3}));

            //System.Console.WriteLine(FractionalKnapsack(new double[]{18,20,14},new double[]{3,4,2},7));  //values,weights

            //System.Console.WriteLine(MoneyChange(28));

            //MaxAddRevenue();

            //CollectingSignatures();

            //MaxNoOfPrizes();

            //MaxSalary();

            //BinarySearchSortedArrayIterative(new int[]{1,2,3,4,5,6,7,8},1);

            //NaivePolyMult(new int[]{1,2,3}, new int[]{4,5,6});

            //SelectionSort(new int[]{44,33,77,99,1,5,9,4,66,22,33});

            // var result1 = MergeSort(new List<int>{44,33,77,99,1,5,9,4,66,22,33});
            // foreach(var element in result1)
            // {
            //     System.Console.Write(element + " ");
            // }

            // var input = new List<int>{44,33,77,99,1,5,9,4,66,22,33};
            // QuickSort(input,0,10);
            // foreach(var element in input)
            // {
            //     System.Console.Write(element + " ");
            // }

            // var input2 = new List<int>{44,33,44,33,1,5,44,33,44,44,33,44,44};
            // RandomizedQuickSort3(input2,0,10);
            // foreach(var element in input2)
            // {
            //     System.Console.Write(element + " ");
            // }

            //MajorityElement(new List<int>{44,33,44,33,1,5,44,33,44,44,33,44,44});

            //System.Console.WriteLine(fibovar(13));

            //LittleSmartGCD(7,8); 

            //System.Console.WriteLine(CarRefuellingPrac(10,new int[] {0,3,5,16,18,25,29}));

            //System.Console.WriteLine(MinRefeulStops(100,10, new int[,] {{10,60},{20,30},{30,30},{60,40} }));

            //InsertionSort(new int[]{1,2,3,11,10,9,8,6,7,5,2,3});

            //DPChange(9,new int[]{6,5,1});

            //PrimitiveCalculator(99);

            //EditDistance("short","ports");

            //LCS2Sequence("BSBIM", "JMJKB");

            //LCS2SequenceRec("BSBIM", "JMJKB");

            //DiscreetKnapsackWithReps(10, new int[]{6,4,2,3}, new int[]{30,16,9,14});

            //DiscreetKnapsackWithoutReps(10, new int[]{6,4,2,3}, new int[]{30,16,9,14});

            MaxValueExpression(new int[]{5,8,7,4,8,9}, "-+x-+");
            #endregion

            stopwatch.Stop();
            System.Console.WriteLine("Time:-"+stopwatch.ElapsedMilliseconds+"ms");

        }
        #region functions
        private static void MaxValueExpression(int[] nums, string ops)
        {
            var length = nums.Length;
            int[,] matrixMax = new int[length+1,length+1];
            int[,] matrixMin = new int[length+1,length+1];
            for(int i=1; i<=length; i++)
            {
                matrixMax[i,i] = nums[i-1];
                matrixMin[i,i] = nums[i-1];
            }

            for(int s=1; s<=length; s++)
            {
                for(int i=1; i<=length-s; i++)
                {
                    int j=i+s;

                    (matrixMin[i,j], matrixMax[i,j]) = MinAndMax(i,j, matrixMax, matrixMin, ops);
                }
            }

            System.Console.WriteLine("Max value -"+matrixMax[1,length]); 

            ReconstructParenthesss(matrixMax,matrixMin,length,ops);
        }

        private static void ReconstructParenthesss(int[,] matrixMax, int[,] matrixMin, int length, string ops)
        {
            List<int[]> listIndices = new List<int[]>();
            MinMaxBrackets(matrixMax,matrixMin,1,6, matrixMax[1,6],ops,listIndices);

            foreach(var index in listIndices)
            {
                System.Console.WriteLine("Bracket indexes - "+index[0]+","+index[1]);
            }
        }

        private static void MinMaxBrackets(int[,] matrixMax, int[,] matrixMin, int v1, int v2, int target, string ops, List<int[]> listIndices)
        {
            listIndices.Add(new int[]{v1,v2});
            if(v1==v2 || Math.Abs(v2-v1)<2)
            {
                return;
            }

            for(int i=v1; i<v2; i++)
            {
                var a =  Compute(ops[i-1],matrixMax[v1,i],matrixMax[i+1,v2]);
                var b =  Compute(ops[i-1],matrixMax[v1,i],matrixMin[i+1,v2]);
                var c =  Compute(ops[i-1],matrixMin[v1,i],matrixMax[i+1,v2]);
                var d =  Compute(ops[i-1],matrixMin[v1,i],matrixMin[i+1,v2]);

                if(a==target) 
                {
                    MinMaxBrackets(matrixMax,matrixMin,v1,i, matrixMax[v1,i],ops,listIndices);
                    MinMaxBrackets(matrixMax,matrixMin,i+1,v2, matrixMax[i+1,v2],ops,listIndices);
                    break;
                }
                if(b==target) 
                {
                    MinMaxBrackets(matrixMax,matrixMin,v1,i, matrixMax[v1,i],ops,listIndices);
                    MinMaxBrackets(matrixMax,matrixMin,i+1,v2, matrixMin[i+1,v2],ops,listIndices);
                    break;
                }
                if(c==target) 
                {
                    MinMaxBrackets(matrixMax,matrixMin,v1,i, matrixMin[v1,i],ops,listIndices);
                    MinMaxBrackets(matrixMax,matrixMin,i+1,v2, matrixMax[i+1,v2],ops,listIndices);
                    break;
                }
                if(d==target) 
                {
                    MinMaxBrackets(matrixMax,matrixMin,v1,i, matrixMin[v1,i],ops,listIndices);
                    MinMaxBrackets(matrixMax,matrixMin,i+1,v2, matrixMin[i+1,v2],ops,listIndices);
                    break;
                }
            }
        }

        private static (int, int) MinAndMax(int i, int j, int[,] matrixMax, int[,] matrixMin, string ops)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            for(int k=i; k<j; k++)
            {
                var a = Compute(ops[k-1],matrixMax[i,k],matrixMax[k+1,j]);
                var b = Compute(ops[k-1],matrixMax[i,k],matrixMin[k+1,j]);
                var c = Compute(ops[k-1],matrixMin[i,k],matrixMax[k+1,j]);
                var d = Compute(ops[k-1],matrixMin[i,k],matrixMin[k+1,j]);

                min = Math.Min(Math.Min(Math.Min(a,b),Math.Min(c,d)),min);
                max = Math.Max(Math.Max(Math.Max(a,b),Math.Max(c,d)),max);
            }

            return(min,max);
        }

        private static int Compute(char op, int v1, int v2)
        {
            switch(op)
            {
                case '+':
                    return v1+v2;
                
                case '-':
                    return v1-v2;

                case '/':
                    return v1/v2;

                case 'x':
                    return v1*v2;
                
                default:
                    return -1;
            }
        }

        private static void DiscreetKnapsackWithoutReps(int tot, int[] weights, int[] values)
        {
            int[,] matrix = new int[tot+1,weights.Length+1];

            for(int i=0; i<=tot; i++)
            {
                for(int j=0; j<=weights.Length; j++)
                {
                    if(i==0 || j==0)
                    {
                        matrix[i,j] = 0;
                    }
                    else
                    {
                        if(weights[j-1] <= i)
                        {
                            matrix[i,j] = Math.Max(matrix[i-weights[j-1],j-1]+values[j-1],matrix[i,j-1]);
                        }
                    }
                }
            }
            System.Console.WriteLine("Maximum Value- "+matrix[tot,weights.Length]);
        }

        private static void DiscreetKnapsackWithReps(int tot, int[] weights, int[] values)
        {
            int[,] matrix = new int[tot+1,weights.Length+1];

            for(int i=0; i<=tot; i++)
            {
                for(int j=0; j<=weights.Length; j++)
                {
                    if(i==0 || j==0)
                    {
                        matrix[i,j] = 0;
                    }
                    else
                    {
                        if(weights[j-1] <= i)
                        {
                            matrix[i,j] = Math.Max(matrix[i-weights[j-1],j]+values[j-1],matrix[i,j-1]);
                        }
                    }
                }
            }
            System.Console.WriteLine("Maximum Value- "+matrix[tot,weights.Length]);
        }

        private static void LCS2SequenceRec(string text1, string text2)
        {
            int[,] matrix = new int[text1.Length,text2.Length];
            for (int i = 0; i < text1.Length; i++)
            {
                for(int j=0; j<text2.Length; j++)
                {
                    matrix[i,j] = -1;
                }
            }

            System.Console.WriteLine(LCS2SequenceRec2(text1, text2, 0, 0, matrix));
        }

        private static int LCS2SequenceRec2(string text1, string text2, int v1, int v2, int[,] matrix)
        {
            if(text1.Length == v1 || text2.Length == v2)
            {
                return 0;
            }

            if(matrix[v1,v2]!=-1)
            {
                return matrix[v1,v2];
            }

            int result = 0;
            if(text1[v1] == text2[v2])
            {
                result =  1 + LCS2SequenceRec2(text1, text2, v1+1, v2+1, matrix);
            }
            else
            {
                result = Math.Max(LCS2SequenceRec2(text1, text2, v1, v2+1, matrix), LCS2SequenceRec2(text1, text2, v1+1, v2, matrix));
            }
           
            matrix[v1,v2] = result;
            return result;
        }

        private static void LCS2Sequence(string text1, string text2)
        {
            int[,] matrix = new int[text1.Length+1, text2.Length+1];

            for(int i=0; i<=text1.Length; i++)
            {
                for(int j=0; j<=text2.Length; j++)
                {
                    if(i==0 || j==0)
                    {
                        matrix[i,j] = 0;
                    }
                    else if(text1[i-1] == text2[j-1])
                    {
                        matrix[i,j] = matrix[i-1,j-1] + 1;
                    }
                    else
                    {
                        matrix[i,j] = Math.Max(matrix[i,j-1],matrix[i-1,j]);
                    }
                }
            }
            System.Console.WriteLine(matrix[text1.Length, text2.Length]); 
        }

        private static void EditDistance(string v1, string v2)
        {
            int[,] matrix = new int[v1.Length+1,v2.Length+1];

            for(int i=0; i<=v1.Length; i++)
            {
                for(int j=0; j<=v2.Length; j++)
                {
                    if(i==0)
                    {
                        matrix[i,j] = j;
                    }
                    else if(j==0)
                    {
                        matrix[i,j] = i;
                    }
                    else
                    {
                        int mval = 0;
                        if(v1[i-1] == v2[j-1])
                        {
                            mval = matrix[i-1,j-1];
                        }
                        else
                        {
                            mval = matrix[i-1,j-1] + 1;
                        }

                        matrix[i,j] = Math.Min(Math.Min(matrix[i,j-1] + 1, matrix[i-1,j] + 1), mval);
                    }
                }
            }

            System.Console.WriteLine("Min value - "+matrix[v1.Length,v2.Length]);
            ShowAllignment(matrix,v1.Length,v2.Length,v1,v2);
        }

        private static void ShowAllignment(int[,] matrix, int row, int col, string v1, string v2)
        {
            if(row == 0 && col == 0)
            {
                return;
            }

            if(row>0 && matrix[row,col] == matrix[row - 1,col]+1)
            {
                ShowAllignment(matrix, row - 1, col, v1,v2);
                System.Console.WriteLine(v1[row-1]+" | -");
            }
            else if(col>0 && matrix[row,col] == matrix[row ,col - 1]+1)
            {
                ShowAllignment(matrix, row, col-1, v1,v2);
                System.Console.WriteLine("- | "+ v2[col-1]);
            }
            else
            {
                ShowAllignment(matrix, row-1, col-1, v1,v2);
                System.Console.WriteLine(v1[row-1]+" | "+ v2[col-1]);
            }

        }

        private static void PrimitiveCalculator(int v)
        {
            int[] outputArray = new int[v+1];

            outputArray[0] = 0;
            outputArray[1] = 1;
            outputArray[2] = 1;
            outputArray[3] = 1;

            for(int i = 4; i<=v; i++)
            {
                int minValue = int.MaxValue;
                if(i%3==0)
                {
                    var val = outputArray[i/3] + 1;
                    if(val < minValue)
                    {
                        minValue = val;
                    }
                }
                if(i%2==0)
                {
                    var val = outputArray[i/2] + 1;
                    if(val < minValue)
                    {
                        minValue = val;
                    }
                }
                if(outputArray[i-1]+1 < minValue)
                {
                    minValue = outputArray[i-1]+1;
                }

                outputArray[i] = minValue;
            }

            System.Console.WriteLine(outputArray.Last());
        }

        private static void DPChange(int v, int[] coins)
        {
            var changeArray = new int[v+1];
            for (int i=0; i<changeArray.Length; i++)
            {
                changeArray[i] = int.MaxValue;
            }

            changeArray[0] = 0;
            for(int i=1; i<changeArray.Length; i++)
            {
                for (int j=0; j<coins.Length; j++)
                {
                    if(i>=coins[j])
                    {
                        var value = changeArray[i-coins[j]]+1;
                        if(value< changeArray[i])
                        {
                            changeArray[i]= value;
                        }
                    }
                }
            }

            System.Console.WriteLine(changeArray.Last());
        }

        private static void InsertionSort(int[] ints)
        {
            for(int i=1; i< ints.Length;i++)
            {
                var key = ints[i];
                int j = i-1;
                while(j>=0&&ints[j]>key)
                {
                    ints[j+1]=ints[j];
                    j--;
                }
                ints[j+1]=key;
            }

            foreach(var x in ints)
            {
                System.Console.Write(x+" ");
            }
        }

        private static int MinRefeulStops(int target, int startFuel, int[,] stations)
        {
            if (target <= startFuel)
            {
                return 0;
            }
            var startpoint = 0;
            var stops = 0;

            for (int i = 0; i <= stations.GetLength(0); i++)
            {

                if (i == stations.GetLength(0))
                {
                    if (i == 0)
                    {
                        return -1;
                    }
                    if (target - startpoint > startFuel)
                    {
                        if (stations[i - 1, 0] == startpoint)
                        {
                            return -1;
                        }
                        stops++;
                        startFuel = startFuel - (stations[i - 1, 0] - startpoint) + stations[i - 1, 1];
                        startpoint = stations[i - 1, 0];
                        i--;
                        continue;
                    }
                    break;
                }

                if (stations[i, 0] - startpoint > startFuel)
                {
                    if (i == 0)
                    {
                        return -1;
                    }
                    if (stations[i - 1, 0] == startpoint)
                    {
                        return -1;
                    }

                    stops++;
                    startFuel = startFuel - (stations[i - 1, 0] - startpoint) + stations[i - 1, 1];
                    startpoint = stations[i - 1, 0];
                    i--;
                }
            }

            return stops;
        }

        private static int CarRefuellingPrac(int v, int[] ints)
        {
            var startPoint = ints[0];
            var stops = 0;

            for (int i = 1; i < ints.Length; i++)
            {
                if (ints[i] - startPoint > v)
                {
                    if (ints[i - 1] == startPoint)
                    {
                        System.Console.WriteLine("IMPOSIBLE");
                        return 0;
                    }
                    stops++;
                    startPoint = ints[i - 1];
                    i--;
                }
            }
            return stops;
        }

        private static void LittleSmartGCD(int v1, int v2)
        {
            if (v1 == v2)
            {
                System.Console.WriteLine(v1); ;
            }
            else if (v1 > v2)
            {
                LittleSmartGCD(v2, v1 - v2);
            }
            else
            {
                LittleSmartGCD(v1, v2 - v1);
            }
        }

        private static int fibovar(int num)
        {
            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return 1;
            }
            int res1 = 0;
            int res2 = 1;

            foreach (int i in Enumerable.Range(2, num - 1))
            {
                int temp = res2;
                res2 = res2 + res1;
                res1 = temp;
            }

            return res2;
        }

        private static void MajorityElement(List<int> input)
        {
            var sortedList = MergeSort(input);

            int range = 0;
            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                if (sortedList[i] == sortedList[i + 1])
                {
                    range += 1;
                    if (range + 1 > sortedList.Count / 2)
                    {
                        System.Console.WriteLine("Majority Element - " + sortedList[i]);
                    }
                }
                else
                {
                    range = 0;
                }
            }
        }

        private static void RandomizedQuickSort3(List<int> input, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            Random x = new Random();
            int k = x.Next(l, r);

            (int m1, int m2) = Partition3(input, l, r);

            RandomizedQuickSort3(input, l, m1 - 1);
            RandomizedQuickSort3(input, m2 + 1, r);
        }

        private static (int m1, int m2) Partition3(List<int> input, int l, int r)
        {
            int m1 = l, m2 = l;

            for (int i = l + 1; i <= r; i++)
            {
                if (input[i] < input[l])
                {
                    m1 += 1;
                    m2 += 1;
                    if (m1 == m2)
                    {
                        Swap(input, m1, i);
                    }
                    else
                    {
                        Swap(input, m1, i);
                        Swap(input, m2, i);
                    }
                }
                else if (input[i] == input[l])
                {
                    m2 += 1;
                    Swap(input, m2, i);
                }
            }
            Swap(input, l, m1);

            return (m1, m2);
        }

        private static void QuickSort(List<int> input, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            var m = partition(input, l, r);

            QuickSort(input, l, m - 1);
            QuickSort(input, m + 1, r);
        }

        private static int partition(List<int> input, int l, int r)
        {
            int j = l;

            for (int i = l + 1; i <= r; i++)
            {
                if (input[i] < input[l])
                {
                    j += 1;
                    Swap(input, j, i);
                }
            }
            Swap(input, l, j);
            return j;
        }

        private static List<int> MergeSort(List<int> input)
        {
            if (input.Count == 1)
            {
                return input;
            }

            var m = input.Count / 2;

            var B = MergeSort(input.GetRange(0, m));
            var C = MergeSort(input.GetRange(m, input.Count - m));

            var D = Merge(B, C);
            return D;
        }

        private static List<int> Merge(List<int> B, List<int> C)
        {
            List<int> D = new List<int>();

            int i = 0, j = 0;

            while (i < B.Count && j < C.Count)
            {
                if (B[i] < C[j])
                {
                    D.Add(B[i]);
                    i++;
                }
                else
                {
                    D.Add(C[j]);
                    j++;
                }
            }

            if (i < B.Count)
            {
                D.AddRange(B.GetRange(i, B.Count - i));
            }
            else
            {
                D.AddRange(C.GetRange(j, C.Count - j));
            }

            return D;
        }

        private static void SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[minIndex] > input[j])
                    {
                        minIndex = j;
                    }
                }
                if (i != minIndex)
                {
                    input[i] = input[i] + input[minIndex];
                    input[minIndex] = input[i] - input[minIndex];
                    input[i] = input[i] - input[minIndex];
                }
            }

            foreach (var element in input)
            {
                System.Console.Write(element + " ");
            }
        }

        private static void NaivePolyMult(int[] input1, int[] input2)
        {
            var n = input1.Length;
            var result = new int[2 * n - 1];

            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    result[i + j] += input1[i] * input2[j];
                }
            }
            foreach (int v in result)
            {
                System.Console.Write(v + " ");
            }
        }

        private static void BinarySearchSortedArrayIterative(int[] input, int key)
        {
            var high = input.Length - 1;
            var low = 0;

            while (low <= high)
            {
                int mid = (high - low) / 2 + low;

                if (input[mid] == key)
                {
                    System.Console.WriteLine(mid);
                    break;
                }
                else if (input[mid] > key)
                {
                    high = mid - 1;
                }
                else if (input[mid] < key)
                {
                    low = mid + 1;
                }
            }
            System.Console.WriteLine("Search Complete");
        }

        private static void MaxSalary()
        {

            int input = Convert.ToInt32(Console.ReadLine());
            var array = Console.ReadLine().Split(' ');

            List<string> numbers = array.ToList();

            string output = "";

            while (numbers.Count > 0)
            {
                string maxNumber = "";
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (IsGreaterOrEqual(numbers[i], maxNumber))
                    {
                        maxNumber = numbers[i];
                    }
                }
                output += maxNumber;
                numbers.Remove(maxNumber);
            }
            System.Console.WriteLine(output);
        }

        private static bool IsGreaterOrEqual(string v, string maxNumber)
        {
            if ((v + maxNumber).CompareTo(maxNumber + v) >= 0)
                return true;

            return false;
        }

        private static void MaxNoOfPrizes()
        {
            int total = Convert.ToInt32(Console.ReadLine());
            int counter = 0;
            int sum = 0;
            List<int> distinnctPrizes = new List<int>();

            while (sum < total)
            {
                counter++;
                sum += counter;
                distinnctPrizes.Add(counter);
            }

            if (sum > total)
            {
                var temp = total - (sum - distinnctPrizes[counter - 1]);
                distinnctPrizes.RemoveAt(counter - 1);
                distinnctPrizes[counter - 2] += temp;
            }

            System.Console.WriteLine(distinnctPrizes.Count);
            foreach (var prizes in distinnctPrizes)
            {
                System.Console.Write(prizes + " ");
            }

        }

        private static void CollectingSignatures()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Segment[] segments = new Segment[n];
            for (int i = 0; i < n; i++)
            {
                var inputs = (Console.ReadLine()).Split();
                segments[i] = new Segment(Convert.ToInt32(inputs[0]), Convert.ToInt32(inputs[1]));
            }

            List<int> points = optimalPoints(segments);
            System.Console.WriteLine(points.Count);
            foreach (int point in points)
            {
                System.Console.Write(point + " ");
            }
        }

        private static List<int> optimalPoints(Segment[] segments)
        {
            for (int i = 0; i < segments.Count(); i++)
            {
                for (int j = i + 1; j < segments.Count(); j++)
                {
                    if (segments[j].end < segments[i].end)
                    {
                        var temp = segments[i];
                        segments[i] = segments[j];
                        segments[j] = temp;
                    }
                }
            }

            List<int> points = new List<int>();
            int point = segments[0].end;

            for (int i = 1; i < segments.Length; i++)
            {
                if ( segments[i].start > point)
                {
                    points.Add(point);
                    point = segments[i].end;
                }
            }
            points.Add(point);
            return points;
        }

        private static void MaxAddRevenue()
        {
            var input = Convert.ToInt32(Console.ReadLine());
            var profits = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            var slots = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            Sort(profits);
            Sort(slots);

            double maxvalue = 0;

            for (int i = 0; i < input; i++)
            {
                maxvalue += profits[i] * slots[i];
            }
            System.Console.WriteLine(maxvalue);
        }

        private static int MoneyChange(int v)
        {
            int coins = 0;
            while (v > 0)
            {
                if (v >= 10)
                {
                    v -= 10;
                }
                else if (v >= 5)
                {
                    v -= 5;
                }
                else if (v >= 1)
                {
                    v -= 1;
                }
                coins++;
            }
            return coins;
        }

        static double FractionalKnapsack(double[] values, double[] weights, double KsWt)
        {
            double TotValue = 0;
            int itemKey = 0;
            int items = values.Length;
            int counter = 0;

            while (counter < items)
            {
                double value = 0;
                for (int i = counter; i < items; i++)
                {
                    if (values[i] / weights[i] > value)
                    {
                        itemKey = i;
                        value = values[i] / weights[i];
                    }
                }
                if (itemKey >= KsWt)
                {
                    TotValue += KsWt * (values[itemKey] / itemKey);
                    return TotValue;
                }
                else
                {
                    TotValue += values[itemKey];
                    KsWt -= itemKey;
                    counter++;
                }
            }
            return TotValue;
        }

        static int MinChildrenGroups(double[] ages)
        {
            Sort(ages);
            int init = 0;
            int groups = 1;
            for (int i = 0; i < ages.Length; i++)
            {
                if (Math.Abs(ages[i] - ages[init]) > 1)
                {
                    init = i;
                    groups++;
                }
            }
            return groups;
        }

        static int CarRefuelling(int mileage, int[] petrolPumps)
        {
            int stops = 0;
            int noOfStops = petrolPumps.Length;
            int currIndex = 0;

            while (currIndex < noOfStops - 1)
            {
                var lastRefill = currIndex;
                while (currIndex < noOfStops - 1 && (petrolPumps[currIndex + 1] - petrolPumps[lastRefill] < mileage))
                {
                    currIndex++;
                }
                if (currIndex == lastRefill)
                {
                    return (-1);
                }
                if (currIndex < noOfStops - 1)
                {
                    stops++;
                }
            }
            return stops;
        }

        static int fiboSumOfSquaresLastDigit(int num)
        {
            int[] fibo = new int[num + 1];
            fibo[0] = 0;
            fibo[1] = 1;
            fibo[2] = 2;

            for (int i = 3; i <= num; i++)
            {
                fibo[i] = (((fibo[i - 1] + fibo[i - 2]) * 2) - fibo[i - 3]) % 10;
            }
            return fibo[num];
        }

        static long fiboSumMToNLastDigit(int m, int n)
        {
            long prev = 0;
            long curr = fiboArrayLastDigit(m);
            long result = curr;

            for (int i = m; i < n; i++)
            {
                result = (prev + curr + 3) % 10;
                prev = curr;
                curr = result;
            }

            return result;
        }

        static int fiboSumLastDigit(int num)
        {
            if (num == 0)
                return 0;
            if (num == 1)
                return 1;
            if (num == 2)
                return 2;

            var prev = 1;
            var curr = 2;
            var result = 0;

            for (int i = 3; i <= num; i++)
            {
                result = (prev + curr + 1) % 10;
                prev = curr;
                curr = result;
            }

            return result;
        }

        static long fiboArrayModuloM(long n, int m)
        {
            long pisano = getPisanoPeriodLength(m);

            long remainder = n % pisano;

            long prev = 0;
            long curr = 1;

            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;

            for (int i = 0; i < remainder - 1; i++)
            {
                long temp = curr;
                curr = (prev + curr) % m;
                prev = temp;
            }

            return curr % m;
        }

        static void LCM(int a, int b)
        {
            if (a < b)
            {
                for (double i = a; i < double.MaxValue; i += a)
                {
                    if (i % b == 0)
                    {
                        System.Console.WriteLine(i);
                        return;
                    }
                }
            }
            else if (b < a)
            {
                for (double i = b; i < double.MaxValue; i += b)
                {
                    if (i % a == 0)
                    {
                        System.Console.WriteLine(i);
                        return;
                    }
                }
            }
            else
            {
                System.Console.WriteLine(a);
            }
        }

        static long fiboArrayLastDigit(long num)
        {
            var fib = new long[num];
            fib[0] = 1;
            fib[1] = 1;

            for (long i = 2; i < num; i++)
            {
                fib[i] = (fib[i - 1] + fib[i - 2]) % 10;
            }

            return fib[num - 1];

        }

        static double SmartGCD(int a, int b)
        {
            if (b == 0)
                return a;

            if (a > b)
                return SmartGCD(b, a % b);
            else
                return SmartGCD(a, b % a);
        }

        static void NaiveGCD(int num1, int num2)
        {
            int best = 0;

            for (int i = 1; i < num1 + num2; i++)
            {
                if (num1 % i == 0 && num2 % i == 0)
                    best = i;
            }
            System.Console.WriteLine(best);
        }

        static double fiboArray(int num)
        {
            var array = new double[num];
            array[0] = 1;
            array[1] = 1;

            for (int i = 2; i < num; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array[num - 1];
        }

        static double fibo(int num)
        {
            if (num <= 1)
                return num;

            return fibo(num - 1) + fibo(num - 2);
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
            long num1 = 0, num2 = 0;
            System.Console.WriteLine("Enter number of elements :");
            int noOfElements = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Enter the elements separated by space :");
            var array = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            for (int i = 0; i < noOfElements; i++)
            {
                if (array[i] > num1)
                {
                    if (array[i] > num2)
                    {
                        num1 = num2;
                        num2 = array[i];
                    }
                    else
                    {
                        num1 = array[i];
                    }
                }
            }

            System.Console.WriteLine("Max pairwse product : " + (num1 * num2));
        }
        #endregion

        #region methods/classes

        static long getPisanoPeriodLength(int m)
        {
            long prev = 0;
            long curr = 1;
            long res = 0;

            for (int i = 0; i < m * m; i++)
            {
                long temp = curr;
                curr = (prev + curr) % m;
                prev = temp;

                if (prev == 0 && curr == 1)
                {
                    res = i + 1;
                    break;
                }
            }

            return res;
        }

        static void Sort(double[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int k = i; k < input.Length; k++)
                {
                    if (input[i] > input[k])
                    {
                        Swap(input, i, k);
                    }
                }
            }
        }

        static void Swap(double[] input, int i, int k)
        {
            input[i] = input[i] + input[k];
            input[k] = input[i] - input[k];
            input[i] = input[i] - input[k];
        }

        static void Swap(List<int> input, int i, int k)
        {
            var temp = input[i];
            input[i] = input[k];
            input[k] = temp;
        }

        public class Segment
        {
            public int start, end;

            public Segment(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }
        #endregion

    }
}
