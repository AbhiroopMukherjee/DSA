using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ScratchPad
{
    class first {
        public string A { get; set; }
        public string B { get; set; }
    }

    class second : first{
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
            //System.Console.WriteLine(SmartGCD(23434455,13234)); //Euclidean algorithm

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

            MajorityElement(new List<int>{44,33,44,33,1,5,44,33,44,44,33,44,44});
#endregion

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds); 
        }

#region functions
        private static void MajorityElement(List<int> input)
        {
            var sortedList = MergeSort(input);

            int range = 0;
            for(int i=0;i<sortedList.Count-1;i++)
            {
                if(sortedList[i]==sortedList[i+1])
                {
                    range+=1;
                    if(range+1>sortedList.Count/2)
                {
                    System.Console.WriteLine("Majority Element - "+sortedList[i]);
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
            if(l>=r)
            {
                return;
            }

            Random x = new Random();
            int k = x.Next(l,r);

            (int m1,int m2) = Partition3(input,l,r);

            RandomizedQuickSort3(input,l,m1-1);
            RandomizedQuickSort3(input,m2+1,r);
        }

        private static (int m1, int m2) Partition3(List<int> input, int l, int r)
        {
            int m1 = l, m2 = l;

            for(int i = l+1;i<=r;i++)
            {
                if(input[i]<input[l])
                {
                    m1+=1;
                    m2+=1;
                    if(m1==m2)
                    {
                        Swap(input,m1,i);
                    }
                    else
                    {
                        Swap(input,m1,i);
                        Swap(input,m2,i);
                    }
                }
                else if(input[i]==input[l])
                {
                    m2+=1;
                    Swap(input,m2,i);
                }
            }
            Swap(input,l,m1);

            return(m1,m2);
        }

        private static void QuickSort(List<int> input,int l,int r)
        {
            if(l>=r)
            {
                return;
            }

            var m = partition(input,l,r);
            
            QuickSort(input,l,m-1);
            QuickSort(input,m+1,r);
        }

        private static int partition(List<int> input, int l, int r)
        {
            int j = l;

            for(int i=l+1; i<=r; i++)
            {
                if(input[i]<input[l])
                {
                    j+=1;
                    Swap(input,j,i);
                }
            }
            Swap(input,l,j);
            return j;
        }

        private static List<int> MergeSort(List<int> input)
        {
            if(input.Count==1)
            {   
                 return input;
            }

            var m = input.Count/2;

            var B = MergeSort(input.GetRange(0,m));
            var C = MergeSort(input.GetRange(m,input.Count - m));

            var D = Merge(B,C);
            return D;
        }

        private static List<int> Merge(List<int> B, List<int> C)
        {
            List<int> D = new List<int>();

            int i = 0,j = 0;

            while(i < B.Count && j < C.Count)
            {
                if(B[i] < C[j])
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

            if(i < B.Count)
            {
                D.AddRange(B.GetRange(i,B.Count-i));
            }
            else
            {
                D.AddRange(C.GetRange(j,C.Count-j));
            }

            return D;
        }

        private static void SelectionSort(int[] input)
        {
            for(int i = 0;i<input.Length;i++)
            {
                var minIndex = i;
                for(int j=i+1;j<input.Length;j++)
                {
                    if(input[minIndex]>input[j])
                    {
                        minIndex = j;
                    }
                }
                if(i!=minIndex)
                {
                    input[i] =  input[i] + input[minIndex];
                    input[minIndex] = input[i] - input[minIndex];
                    input[i] = input[i] - input[minIndex];
                }
            }

            foreach(var element in input)
            {
                System.Console.Write(element+ " ");
            }
        }

        private static void NaivePolyMult(int[] input1, int[] input2)
        {
            var n = input1.Length;
            var result = new int[2*n-1];

            for(int i=0; i<=n-1; i++)
            {
                for(int j=0;j<=n-1;j++)
                {
                    result[i+j]+=input1[i]*input2[j];
                }
            }
            foreach(int v in result)
            {
                System.Console.Write(v+ " ");
            }
        }

        private static void BinarySearchSortedArrayIterative(int[] input, int key)
        {
            var high = input.Length-1;
            var low = 0;

            while(low<=high)
            {
                int mid = (high-low)/2+low;

                if(input[mid]==key)
                {
                    System.Console.WriteLine(mid);
                    break;
                }
                else if(input[mid]>key)
                {
                    high = mid - 1;
                }
                else if(input[mid]<key)
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

            List<string> numbers  = array.ToList();
            
            string output = "";

            while (numbers.Count>0)
            {
                string maxNumber = "";
                for(int i=0;i<numbers.Count;i++)
                {
                    if(IsGreaterOrEqual(numbers[i],maxNumber))
                    {
                        maxNumber = numbers[i];
                    }
                }
                output+=maxNumber;
                numbers.Remove(maxNumber);
            }
            System.Console.WriteLine(output);
        }

        private static bool IsGreaterOrEqual(string v, string maxNumber)
        {
            if((v+maxNumber).CompareTo(maxNumber+v)>=0)
                return true;
            
            return false;
        }

        private static void MaxNoOfPrizes()
        {
            int total = Convert.ToInt32(Console.ReadLine());
            int counter=0; 
            int sum = 0;
            List<int> distinnctPrizes = new List<int>();

            while(sum<total)
            {
                counter++;
                sum+=counter;
                distinnctPrizes.Add(counter);
            }

            if(sum>total)
            {
                var temp = total - (sum - distinnctPrizes[counter-1]);
                distinnctPrizes.RemoveAt(counter-1);
                distinnctPrizes[counter-2]+=temp;
            }

            System.Console.WriteLine(distinnctPrizes.Count);
            foreach(var prizes in distinnctPrizes)
            {
                System.Console.Write(prizes+ " ");
            }

        }

        private static void CollectingSignatures()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Segment[] segments = new Segment[n];
            for (int i = 0; i < n; i++) {
                var inputs = (Console.ReadLine()).Split( );
                segments[i] = new Segment(Convert.ToInt32(inputs[0]), Convert.ToInt32(inputs[1]));
            }

            List<int> points = optimalPoints(segments);
            System.Console.WriteLine(points.Count);
            foreach (int point in points) {
                System.Console.Write(point + " ");
            }
        }
        
        private static List<int> optimalPoints(Segment[] segments)
        {
            for(int i=0;i<segments.Count();i++)
            {
                for(int j=i+1;j<segments.Count();j++)
                {
                    if(segments[j].end<segments[i].end)
                    {
                        var temp = segments[i];
                        segments[i] = segments[j];
                        segments[j] = segments[i];
                    }
                }
            }

            List<int> points = new List<int>();
            int point = segments[0].end;
            points.Add(point);

            for(int i=1;i<segments.Length;i++)
            {
                if(point<segments[i].start || point > segments[i].end)
                {
                    point = segments[i].end;
                    points.Add(point);
                }
            }

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

            for(int i=0;i<input;i++)
            {
                maxvalue+=profits[i]*slots[i];
            }
            System.Console.WriteLine(maxvalue);
        }

        private static int MoneyChange(int v)
        {
            int coins = 0;
            while(v>0)
            {
                if(v>=10)
                {
                    v-=10;                    
                }
                else if(v>=5)
                {
                    v-=5;
                }
                else if(v>=1)
                {
                    v-=1;
                }
                coins ++;
            }
            return coins;
        }

        static double FractionalKnapsack(double[] values, double[] weights, double KsWt)
        {
            double TotValue = 0;
            int itemKey = 0;
            int items = values.Length;
            int counter = 0;

            while(counter < items)
            {
                double value = 0;
                for(int i=counter;i<items;i++)
                {
                    if(values[i]/weights[i]>value)
                    {
                        itemKey = i;
                        value = values[i]/weights[i];
                    }
                }
                if(itemKey>=KsWt)
                {
                    TotValue+= KsWt*(values[itemKey]/itemKey);
                    return TotValue;
                }
                else
                {
                    TotValue+=values[itemKey];
                    KsWt-=itemKey;
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
            for(int i=0;i<ages.Length;i++)
            {
                if(Math.Abs(ages[i]-ages[init])>1)
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

            while(currIndex<noOfStops-1)
            {
                var lastRefill = currIndex;
                while(currIndex<noOfStops-1 && (petrolPumps[currIndex+1]-petrolPumps[lastRefill]<mileage))
                {
                    currIndex++;
                }
                if(currIndex==lastRefill)
                {
                    return(-1);
                }
                if(currIndex<noOfStops-1)
                {
                    stops++;
                }
            }
            return stops;
        }

        static int fiboSumOfSquaresLastDigit(int num)
        {
            int[] fibo = new int[num+1]; 
            fibo[0]=0; 
            fibo[1]=1; 
            fibo[2]=2;

            for(int i=3; i<=num; i++)
            {
                fibo[i]= (((fibo[i-1]+fibo[i-2])*2) - fibo[i-3])%10; 
            }
            return fibo[num];
        }

        static long fiboSumMToNLastDigit(int m, int n)
        {
            long prev = 0;
            long curr = fiboArrayLastDigit(m);
            long result = curr;

            for(int i=m;i<n;i++)
            {
                result = (prev + curr + 3)%10;
                prev = curr;
                curr = result;
            }

            return result;
        }

        static int fiboSumLastDigit(int num)
        {
            if(num==0)
                return 0;
            if(num==1)
                return 1;
            if(num==2)
                return 2;
            
            var prev = 1;
            var curr = 2;
            var result = 0;

            for(int i=3;i<=num;i++)
            {
                result = (prev + curr + 1)%10;
                prev = curr;
                curr = result;
            }

            return result;
        }

        static long fiboArrayModuloM(long n,int m)
        {
            long pisano = getPisanoPeriodLength(m);

            long remainder = n%pisano;

            long prev = 0;
            long curr = 1;

            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;

            for(int i=0;i<remainder-1;i++)
            {
                long temp = curr;
                curr = (prev + curr)%m;
                prev = temp;
            }

            return curr%m;
        } 

        static void LCM(int a, int b)
        {
            if(a<b)
            {
                for(double i=a;i<double.MaxValue;i+=a)
                {
                    if(i%b==0)
                    {
                        System.Console.WriteLine(i);
                        return;
                    }
                }
            }
            else if(b<a)
            {
                for(double i=b;i<double.MaxValue;i+=b)
                {
                    if(i%a==0)
                    {
                        System.Console.WriteLine(i);
                        return;
                    }
                }
            }
            else{
                System.Console.WriteLine(a);
            }
        }
        
        static long fiboArrayLastDigit(long num)
        {
            var fib = new long[num];
            fib[0] = 1;
            fib[1] = 1;   

            for(long i=2;i<num;i++)
            {
                fib[i] = (fib[i-1] + fib[i-2])%10;
            }       

            return fib[num-1];

        }

        static double SmartGCD(int a, int b)
        {
            if(b==0)
                return a;

            if(a>b)
                return SmartGCD(b,a%b);
            else
                return SmartGCD(a,b%a);
        }

        static void NaiveGCD(int num1, int num2)
        {
            int best = 0;

            for(int i =1;i<num1 + num2; i++)
            {
                if( num1%i==0 && num2%i==0)
                    best = i;
            }
             System.Console.WriteLine(best);
        }

        static double fiboArray(int num)
        {
            var array = new double[num];
            array[0] = 1;
            array[1] = 1;

            for(int i=2;i<num;i++)
            {
                array[i] = array[i-1] + array [i-2];
            }

            return array[num-1];
        }

        static double fibo(int num)
        {
            if(num<=1)
                return 1;

            return fibo(num -1) + fibo(num -2);
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
#endregion
    
#region methods/classes
        
        static long getPisanoPeriodLength(int m)
        {
            long prev = 0;
            long curr = 1;
            long res = 0;

            for(int i=0;i<m*m;i++)
            {
                long temp = curr;
                curr = (prev + curr)%m;
                prev = temp;

                if(prev ==0 && curr ==1)
                {
                    res = i+1;
                    break;
                }
            }

            return res;
        }

        static void Sort(double[] input)
        {
            for(int i=0;i<input.Length;i++)
            {
                for(int k=i;k<input.Length;k++)
                {
                    if(input[i]>input[k])
                    {
                        Swap(input,i,k);
                    }
                }
            }
        }

        static void Swap(double[] input,int i, int k)
        {
            input[i] = input[i] + input[k];
            input[k] = input[i] - input[k];
            input[i] = input[i] - input[k];
        }

        static void Swap(List<int> input,int i, int k)
        {
            var temp = input[i];
            input[i] = input[k];
            input[k] = temp;
        }           
        
        public class Segment {
            public int start, end;

            public Segment(int start, int end) {
                this.start = start;
                this.end = end;
            }
    }
#endregion
    
    }
}
