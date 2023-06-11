using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            //CheckBracketsIfBalanced("(([([(())])]))");

            //ComputeTreeHeight();

            //PacketProcessing(new int[,] {{1,2},{0,1},{1,1}});

            //ExtendingStack();

            //SlidingWindow(new int[]{2,7,3,1,5,2,6,2}, 4);

            //LCMergeArrays(new int[]{-1,0,0,3,3,3,0,0,0}, 6, new int[]{1,2,2}, 3);

            //ArrayToHeap(new int[]{5,4,6,1,2});

            //ParallelProcessing(2,5,new List<int>{1,2,3,4,5});

            //HeapSort(new int[]{5,4,6,1,2});

            //PhoneBookDirectAddressing();

            //HashingWithChains();

            //FindPatternRabinKarp("aba", "abacaba"); //need to fix

            //BinaryTreeTraversal();

            //IsItBST();

            //BuildBST();

            //BuildAVLTree();

            AVLMerge();

            stopwatch.Stop();
            System.Console.WriteLine("Time:-"+stopwatch.ElapsedMilliseconds+"ms");
        }

        private static void AVLMerge()
        {
            var avl1 = new AVLTree();
            avl1.AVLInsert(1);
            avl1.AVLInsert(4);
            avl1.AVLInsert(6);
            avl1.AVLInsert(7);
            avl1.AVLInsert(13);
            avl1.AVLInsert(14);
            avl1.AVLInsert(10);
            avl1.AVLInsert(15);
            avl1.AVLInsert(3);
            avl1.AVLInsert(2);
            avl1.AVLInsert(5);
            avl1.AVLInsert(8);
            avl1.AVLInsert(9);
            avl1.AVLInsert(11);
            avl1.AVLInsert(12);
            avl1.AVLInsert(16);

            var avl2 = new AVLTree();
            avl2.AVLInsert(23);
            avl2.AVLInsert(18);
            avl2.AVLInsert(16);
            avl2.AVLInsert(81);
            avl2.AVLInsert(91);
            avl2.AVLInsert(51);

            var root = Merge(avl1,avl2);

            var list = avl1.RangeSearch(6,16);

            foreach(var x in list)
            {
                System.Console.WriteLine(x.key);
            }

            bool flag = true;
            CheckIfBst(avl1.root, ref flag,new LinkedList<int>());
            System.Console.WriteLine("Is Bst - "+flag);

            Inorder(avl1.root);

        }

        private static NodeTree Merge(AVLTree avl1, AVLTree avl2)
        {
            var T = avl1.Find(int.MaxValue,avl1.root);
            avl1.AVLDelete(T);
            return AVLMergeWithRoot(avl1.root,avl2.root,T,avl1,avl2);
        }

        private static NodeTree AVLMergeWithRoot(NodeTree root1, NodeTree root2, NodeTree t, AVLTree avl1, AVLTree avl2)
        {
            var r1h = root1.Height();
            var r2h = root2.Height();
            var o = Math.Abs(r1h - r2h);
            if(o <=1)
            {
                MergeWithRoot(root1,root2,t);
                return t;
            }
            else if(root1.Height() > root2.Height())
            {
                var mergedNode = AVLMergeWithRoot(root1.rightChild,root2,t,avl1,avl2);
                root1.rightChild = mergedNode;
                mergedNode.parent = root1;
                avl1.Rebalance(root1);
                return root1;
            }
            else if(root1.Height() < root2.Height())
            {
                var mergedNode = AVLMergeWithRoot(root2.leftChild,root1,t,avl1,avl2);
                root2.rightChild = mergedNode;
                mergedNode.parent = root2;
                avl2.Rebalance(root2);
                return root2;
            }
            return null;
        }

        private static void MergeWithRoot(NodeTree root1, NodeTree root2, NodeTree t)
        {
            t.leftChild = root1;
            t.rightChild = root2;

            root1.parent = t;
            root2.parent = t;
        }

        private static void BuildAVLTree()
        {
            var avl = new AVLTree();
            avl.AVLInsert(1);
            avl.AVLInsert(4);
            avl.AVLInsert(6);
            avl.AVLInsert(7);
            avl.AVLInsert(13);
            avl.AVLInsert(14);
            avl.AVLInsert(10);
            avl.AVLInsert(15);
            avl.AVLInsert(3);
            avl.AVLInsert(2);
            avl.AVLDelete(avl.Find(7,avl.root));

            var list = avl.RangeSearch(6,16);

            foreach(var x in list)
            {
                System.Console.WriteLine(x.key);
            }

            bool flag = true;
            CheckIfBst(avl.root, ref flag,new LinkedList<int>());
            System.Console.WriteLine("Is Bst - "+flag);

            Inorder(avl.root);
        }

        private static void BuildBST()
        {
            var bst = new BST();
            bst.Insert(7);
            bst.Insert(4);
            bst.Insert(6);
            bst.Insert(1);
            bst.Insert(13);
            bst.Insert(15);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(3);
            bst.Insert(2);
            bst.Delete(bst.Find(7,bst.root));

            var list = bst.RangeSearch(6,16);

            foreach(var x in list)
            {
                System.Console.WriteLine(x.key);
            }

            bool flag = true;
            CheckIfBst(bst.root, ref flag,new LinkedList<int>());
            System.Console.WriteLine("Is Bst - "+flag);

            //Inorder(bst.root);
        }

        private static void IsItBST()
        {
            //int[,] input = new int[4,3]{{4,1,-1},{2,2,3},{1,-1,-1},{5,-1,-1}};
            int count = Convert.ToInt32(Console.ReadLine());

            NodeTree[] treeNodes = new NodeTree[count];
            for (int i = 0; i < count; i++)
            {
                treeNodes[i] = new NodeTree();
            }

            var root = treeNodes[0];

            for(int i=0; i<count; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                treeNodes[i].key = input[0];
                treeNodes[i].leftChild = input[1]==-1?null:treeNodes[input[1]];
                treeNodes[i].rightChild = input[2]==-1?null:treeNodes[input[2]];
            }

            bool isBst = true;
            LinkedList<int> bstOutput = new LinkedList<int>();
            

            CheckIfBst(root,ref isBst, bstOutput);

            if(isBst)
            {
                System.Console.WriteLine("CORRECT");
            }
            else
            {
                System.Console.WriteLine("INCORRECT");
            }
        }

        private static void CheckIfBst(NodeTree node, ref bool isBst, LinkedList<int> bstOutput)
        {
            if(node==null || !isBst) return;

            CheckIfBst(node.leftChild, ref isBst, bstOutput);

            if(bstOutput.Last()>node.key)
            {
                isBst = false;
                return;
            }
            else
            {
                bstOutput.AddLast(node.key);
            }

            CheckIfBst(node.rightChild, ref isBst, bstOutput);
        }

        private static void BinaryTreeTraversal()
        {
            //int[,] input = new int[5,3]{{4,1,2},{2,3,4},{5,-1,-1},{1,-1,-1},{3,-1,-1}};
            int count = Convert.ToInt32(Console.ReadLine());

            NodeTree[] treeNodes = new NodeTree[count];
            for (int i = 0; i < count; i++)
            {
                treeNodes[i] = new NodeTree();
            }

            var root = treeNodes[0];

            for(int i=0; i<count; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                treeNodes[i].key = input[0];
                treeNodes[i].leftChild = input[1]==-1?null:treeNodes[input[1]];
                treeNodes[i].rightChild = input[2]==-1?null:treeNodes[input[2]];
            }

            Inorder(root);
            System.Console.WriteLine();
            Preorder(root);
            System.Console.WriteLine();
            Postorder(root);
        }

        private static void Postorder(NodeTree node)
        {
            if(node==null) return;
            Postorder(node.leftChild);
            Postorder(node.rightChild);
            System.Console.Write(node.key+" ");
        }

        private static void Preorder(NodeTree node)
        {
            if(node==null) return;
            System.Console.Write(node.key+" ");
            Preorder(node.leftChild);
            Preorder(node.rightChild);
        }

        private static void Inorder(NodeTree node)
        {
            if(node==null) return;
            Inorder(node.leftChild);
            System.Console.Write(node.key+" ");
            Inorder(node.rightChild);
        }

        private static void FindPatternRabinKarp(string pattern, string text)
        {
            List<int> result = new List<int>();

            int p = 9973; // random big prime number
            int x = 221; // random number less than prime above

            long[] tHash = new long[text.Length - pattern.Length +1];

            PrecomputeHash(text, pattern.Length, p, x, tHash);

            var pHash = ComputePolyHash(pattern,p,x);

            for(int i=0; i<tHash.Length; i++)
            {
                if(tHash[i]!=pHash)
                {
                    continue;
                }
                if(text.Substring(i,pattern.Length) == pattern)
                {
                    result.Add(i);
                }
            }

            foreach(int index in result)
            {
                System.Console.Write(index+" ");
            }
        }

        private static void PrecomputeHash(string text, int length, int p, int x, long[] tHash)
        {
            tHash[tHash.Length-1] = ComputePolyHash(text.Substring(tHash.Length-1), p, x);

            long y = 1;
            for(int i=0; i<length; i++)
            {
                y*=x;
            }

            for(int i=tHash.Length-2; i>=0; i--)
            {
                tHash[i] = (tHash[i+1]*x + Convert.ToInt32(text[i]) - y*Convert.ToInt32(text[i+length])) % p;
            }
        }

        private static void HashingWithChains()
        {
            int p = 100000007;
            int x = 263;

            int m = int.Parse(Console.ReadLine());
            int inputCount = int.Parse(Console.ReadLine());
            string[] inputs = new string[inputCount];

            LinkedList<string>[] chain = new LinkedList<string>[m];

            for(int i=0; i<inputCount; i++)
            {
                inputs[i] = Console.ReadLine();
            }

            // inputs[0] = "add world";
            // inputs[1] = "check 4";
            // inputs[2] = "del world";
            // inputs[3] = "find world";
            // inputs[4] = "del world";

            foreach (var input in inputs)
            {
                switch(input)
                {
                    case var s when s.StartsWith("add"):
                        var param1 = input.Substring(4);
                        Add(param1,chain,p,x,m);
                        break;

                    case var s when s.StartsWith("del"):
                        var param2 = input.Substring(4);
                        Del(param2,chain,p,x,m);
                        break;

                    case var s when s.StartsWith("find"):
                        var param3 = input.Substring(5);
                        Find(param3,chain,p,x,m);
                        break;

                    case var s when s.StartsWith("check"):
                        var param4 = input.Substring(6);
                        Check(param4,chain);
                        break;

                    default:
                        System.Console.WriteLine("Wrong Input");
                        break;

                }
            }

        }

        private static void Check(string param4, LinkedList<string>[] chain)
        {
            int num = Convert.ToInt32(param4);

            if(chain[num]==null)
            {
                System.Console.WriteLine("Null");
                return;
            }

            var node = chain[num].head;

            while(node!=null)
            {
                System.Console.WriteLine(node.key+" ");
                node = node.next;
            }

        }

        private static void Find(string param3, LinkedList<string>[] chain, int p, int x, int m)
        {
            var hash = ComputePolyHash(param3,p,x,m);
            if(chain[hash]==null || !chain[hash].Exists(param3))
            {
                System.Console.WriteLine("No");
            }
            else
            {
                System.Console.WriteLine("Yes");
            }
        }

        private static void Del(string param2, LinkedList<string>[] chain, int p, int x, int m)
        {
            var hash = ComputePolyHash(param2,p,x,m);
            if(chain[hash]==null)
            {
                chain[hash] = new LinkedList<string>();
            }
            chain[hash].Remove(param2);
        }

        private static void Add(string param1, LinkedList<string>[] chain, int p, int x, int m)
        {
            var hash = ComputePolyHash(param1,p,x,m);
            if(chain[hash]==null)
            {
                chain[hash] = new LinkedList<string>();
            }
            chain[hash].AddFirst(param1);
        }

        private static long ComputePolyHash(string input, int p, int x, int m=0)
        {
            long hash = 0;

            for(int i = input.Length-1; i>=0; i--)
            {
                hash = (hash*x  + Convert.ToInt32(input[i])%p);
            }
            return m==0?hash:hash%m;
        }

        private static void PhoneBookDirectAddressing()
        {
            string[] phoneBook = new string[10000000];
            
            Add(911,"police",phoneBook);
            System.Console.WriteLine(Find(921,phoneBook)?? "Not Found");  
            Del(911,phoneBook);
        }

        private static void Del(int v, string[] phoneBook)
        {
            phoneBook[v] = null;
        }

        private static string Find(int v, string[] phoneBook)
        {
            return phoneBook[v];
        }

        private static void Add(int v1, string v2, string[] phoneBook)
        {
            phoneBook[v1] = v2;
        }

        private static void HeapSort(int[] ints)
        {
            ArrayToHeap(ints);

            for(int i=0;i<ints.Length;i++)
            {
                System.Console.WriteLine(ExtractMin(ints,i));
            }
        }

        private static int ExtractMin(int[] nums, int i)
        {
            SwapArray(nums,nums.Length-1-i,0);
            MinShiftDown(nums,0,nums.Length-1-i);
            return nums[nums.Length-1-i];
        }

        private static void ParallelProcessing(int v1, int v2, List<int> tasks)
        {
            int i=0;
            int[] threads = new int[v1];

            while(tasks.Count !=0)
            {
                if(threads[0] - i == 0)
                {
                    threads[0] = tasks[0]+i;
                    tasks.RemoveAt(0);
                    System.Console.WriteLine("0 "+i);
                }
                if(threads[1] - i == 0)
                {
                    threads[1] = tasks[0]+i;
                    tasks.RemoveAt(0);
                    System.Console.WriteLine("1 "+i);
                }
                i++;
            }
        }

        private static void ArrayToHeap(int[] nums)
        {
            var length = nums.Length;

            int count = 0;
            List<int> swaps = new List<int>();

            for(int i = (length/2)+1; i>=0; i--)
            {
                int c = 0; 
                List<int> s = new List<int>();
                (c,s) = MinShiftDown(nums,i,nums.Length);

                count+= c;
                swaps.AddRange(s);
            }

            System.Console.WriteLine("Count - "+count);

            for(int i=0; i<swaps.Count; i+=2)
            {
                System.Console.WriteLine("Swaps - "+swaps[i]+ " "+swaps[i+1]);
            }
        } 

        private static (int count, List<int> swaps) MinShiftDown(int[] nums, int i, int length)
        {
            int count = 0;
            List<int> swaps = new List<int>();
            while(i*2+1<length)
            {
                if(2*i+2<length)
                {
                    if(nums[2*i+1]<nums[2*i+2] && nums[i]>nums[2*i+1])
                    {
                        SwapArray(nums,2*i+1,i); 
                        count++;
                        swaps.Add(i);
                        swaps.Add(2*i+1);
                        i = 2*i+1;
                    }
                    else if(nums[i]>nums[2*i+2])
                    {
                        SwapArray(nums,2*i+2,i);
                        count++;
                        swaps.Add(i);
                        swaps.Add(2*i+2);
                        i = 2*i+2;
                    }
                    else
                    {
                        break;
                    }
                }
                else if(nums[i]>nums[2*i+1])
                {
                    SwapArray(nums,2*i+1,i);
                    count++;
                    swaps.Add(i);
                    swaps.Add(2*i+1);
                    i = 2*i+1;
                }
                else
                {
                    break;
                }
            }

            return (count,swaps);
        }

        private static void SwapArray(int[] nums, int v, int i)
        {
            var temp = nums[v];
            nums[v] = nums[i];
            nums[i] = temp;
        }

        private static void LCMergeArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int count = 0;
            int pos = m-1;
            
            for(int i=0; i<n; i++)
            {
                bool flag = false;
                while(count<pos)
                {
                    if(nums2[i]<nums1[count])
                    {
                        for(int j=pos; j>=count; j--)
                        {
                            nums1[j+1] = nums1[j];
                        }
                        nums1[count]=nums2[i];
                        count++;
                        pos++;
                        flag = true;
                        break;
                    }
                    
                    count++;
                }
                if(!flag)
                {
                    nums1[pos+1]=nums2[i];
                    pos++;
                }
            }
            foreach(var element in nums1)
            {
                System.Console.WriteLine(element);
            }
        }

        private static void SlidingWindow(int[] array, int window)
        {
            var dequeue = new Deque<int>();
            var result = new int[array.Length-window+1];
            int index = 0;
            
            for(int i=0; i<array.Length; i++)
            {
                if(i>(window-1) && !dequeue.IsEmpty() && dequeue.Front()==array[i-window])
                {
                    dequeue.PopFront();
                }

                while(!dequeue.IsEmpty() && dequeue.Back()<array[i])
                {
                    dequeue.PopBack();
                }
                
                dequeue.PushBack(array[i]);

                if(i>=window-1)
                {
                    result[index++] = dequeue.Front();
                }
            }

            foreach(var x in result)
            {
                System.Console.WriteLine(x);
            }
        }

        private static void ExtendingStack()
        {
            var stack = new StackWithMax();

            stack.Push('2');
            stack.Push('1');
            System.Console.WriteLine(stack.Max()); 
            System.Console.WriteLine(stack.Pop());  
            System.Console.WriteLine(stack.Max());
            System.Console.WriteLine(stack.Pop());  
            System.Console.WriteLine(stack.Max());
        }

        private static void PacketProcessing(int[,] packets)
        {
            var bufferSize = packets[0,0];
            var packetsCount = packets[0,1];
            var queue = new QueueArray(10);

            for(int i=1; i<=packetsCount; i++)
            {
                if(queue.counter < bufferSize)
                {
                    if(queue.Front()[0]!=-1 && (packets[i,0] - queue.Front()[0] >= queue.Front()[1]))
                    {
                        queue.Dequeue();
                    }

                    queue.Enqueue(new int[]{packets[i,0], packets[i,1]});
                    System.Console.WriteLine(packets[i,0]);
                }
                else if((packets[i,0] - queue.Front()[0] >= queue.Front()[1]))
                {
                    queue.Dequeue();
                    queue.Enqueue(new int[]{packets[i,0], packets[i,1]});
                    System.Console.WriteLine(packets[i,0]);
                }
                else
                {
                    System.Console.WriteLine(-1);
                }
            }
        }

        private static void ComputeTreeHeight()
        {
            int count = Convert.ToInt32(Console.ReadLine());
            int[] elements = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            NodeTree root = new NodeTree();
            NodeTree[] nodes = new NodeTree[elements.Length];
            for(int i=0;i<elements.Length;i++)
            {
                nodes[i] = new NodeTree();
                nodes[i].key = elements[i];
            }

            for(int i=0; i<elements.Length; i++)
            {
                if(elements[i] == -1)
                {
                    root = nodes[i];
                }
                else
                {
                    nodes[elements[i]].AddChild(nodes[i]);
                }
            }

            System.Console.WriteLine(root.Height());
        }

        public static void CheckBracketsIfBalanced(string text)
        {
            var stack = new StackLinkedList();

            foreach(var character in text)
            {
                if(character == '(' || character == '[')
                {
                    stack.Push(character);
                }
                else
                {
                    var returnedChar = stack.Pop();

                    if(!((returnedChar=='(' && character == ')') || (returnedChar=='[' && character == ']')))
                    {
                        System.Console.WriteLine("NOT BALANCED");
                        break;
                    }
                }
            }

            if(!stack.IsEmpty())
            {
                System.Console.WriteLine("NOT BALANCED");
            }
            else
            {
                System.Console.WriteLine("BALANCED");
            }
        }
    }

    public class Deque<T>
{
    private LinkedList<T> deque;

    public Deque()
    {
        deque = new LinkedList<T>();
    }

    public bool IsEmpty()
    {
        return deque.count == 0;
    }

    public void PushFront(T item)
    {
        deque.AddFirst(item);
    }

    public void PushBack(T item)
    {
        deque.AddLast(item);
    }

    public T PopFront()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");

        T item = deque.First();
        deque.RemoveFirst();
        return item;
    }

    public T PopBack()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");

        T item = deque.Last();
        deque.RemoveLast();
        return item;
    }

    public T Front()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");

        return deque.First();
    }

    public T Back()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");

        return deque.Last();
    }
}
    public class StackWithMax
    {
        StackLinkedList mainStack;
        StackLinkedList maxStack;

        public StackWithMax()
        {
            mainStack = new StackLinkedList();
            maxStack = new StackLinkedList();
        }

        public void Push(char c)
        {
            mainStack.Push(c);
            if(maxStack.IsEmpty())
            {
                maxStack.Push(c);
            }
            else if(c>= maxStack.Top())
            {
                maxStack.Push(c);
            }
        }

        public char Pop()
        {
            if(!mainStack.IsEmpty() && mainStack.Top()==maxStack.Top())
            {
                maxStack.Pop();
            }
            return mainStack.Pop();
        }

        public char Top()
        {
            return mainStack.Top();
        }

        public bool IsEEmpty()
        {
            return mainStack.IsEmpty();
        }

        public char Max()
        {
            if(maxStack.IsEmpty())
            {
                return default(char);
            }
            return maxStack.Top();
        }
    }
    public class StackLinkedList
    {
        NodeLinkedList<char> head = null;

        public void Push(char c)
        {
            if(head == null)
            {
                head = new NodeLinkedList<char>{ key = c};
            }
            else
            {
                var temp = head;
                head = new NodeLinkedList<char>{ key = c};
                head.next = temp;
                temp = null;
            }
        }

        public char Pop()
        {
            if(head == null)
            {
                throw new Exception("NO ELEMENTS!");
            }
            else
            {
                var temp =  head.key;
                head = head.next;
                return temp;
            }
        }

        public char Top()
        {
            if(head == null)
            {
                return default(char);
            }
            return head.key;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
    public class LinkedList<T>
    {
        public int count = 0;
        public NodeLinkedList<T> head;
        public NodeLinkedList<T> tail;

        public void AddFirst(T item)
        {
            if(count==0)
            {
                head = new NodeLinkedList<T>{key = item};
                tail = head;
            }
            else
            {
                var temp = head;
                head = new NodeLinkedList<T>{key = item};
                head.next = temp;
                temp.previous = head;
            }
            count++;
        }

        public void AddLast(T item)
        {
            if(count==0)
            {
                head = new NodeLinkedList<T>{key = item};
                tail = head;
            }
            else
            {
                var temp = tail;
                tail = new NodeLinkedList<T>{key = item};
                temp.next = tail;
                tail.previous = temp;
            }
            count++;
        }

        public void RemoveFirst()
        {
            if(count==0)
            {
                System.Console.WriteLine("Empty Linked list");
                return;
            }
            else if(count==1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.previous = null;
            }
            count--;
        }

        public void RemoveLast()
        {
            if(count==0)
            {
                System.Console.WriteLine("Empty Linked list");
                return;
            }
            else if(count==1)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.previous;
                tail.next = null;
            }
            count--;
        }

        public T First()
        {
            if(count==0)
            {
                System.Console.WriteLine("Empty Linked list");
                return default(T);
            }
            else
            {
                return head.key;
            }
        }

        public T Last()
        {
            if(count==0)
            {
                System.Console.WriteLine("Empty Linked list");
                return default(T);
            }
            else
            {
                return tail.key;
            }
        }

        public bool Remove(T item)
        {
            bool isRemoved = false;
            if(IsEmpty())
            {
                return isRemoved;
            }

            var node = head;
            while(node!=null)
            {
                if(node.key.Equals(item))
                {
                    if(node.previous!=null)
                    {
                        node.previous.next = node.next;
                    }
                    if(node.next!=null)
                    {
                        node.next.previous = node.previous;
                    }
                    isRemoved = true;
                    break;
                }
                node = node.next;
            }
            return isRemoved;
        }

        public bool Exists(T item)
        {
            bool exists = false;
            if(IsEmpty())
            {
                return exists;
            }

            var node = head;
            while(node!=null)
            {
                if(node.key.Equals(item))
                { 
                    exists = true;
                    break;
                }
                node = node.next;
            }
            return exists;
        }

        public bool IsEmpty()
        {
            return (count>0);
        }
    }
    public class NodeLinkedList<T>
    {
        public T key { get; set; }
        public NodeLinkedList<T> next { get; set; }
        public NodeLinkedList<T> previous { get; set; }
    }
    public class NodeTree
    {
        public int key;
        public NodeTree leftChild;
        public NodeTree rightChild;
        public NodeTree parent;

        public void AddChild(NodeTree child)
        {
            _ = leftChild == null ? leftChild = child : rightChild = child;
        }

        public int Height()
        {
            if(leftChild == null && rightChild == null)
            {
                return 1;
            }
            else if(leftChild == null)
            {
                return 1 + rightChild.Height();
            }
            else if(rightChild == null)
            {
                return 1 + leftChild.Height();
            }
            else
            {
                return 1 + Math.Max(leftChild.Height(), rightChild.Height());
            }
        }
    }
    public class QueueLinkedList
    {
        public int counter = 0;
        NodeLinkedList<int[]> head;
        NodeLinkedList<int[]> tail;

        public void Enqueue(int[] values)
        {
            if(head==null)
            {
                head = new NodeLinkedList<int[]>();
                tail = head;
                head.key = values;
            }
            else
            {
                tail.next = new NodeLinkedList<int[]>();
                tail = tail.next;
            }
            counter++;
        }

        public int[] Front()
        {
            if(head==null)
            {
                return new int[]{-1,-1};
            }
            return head.key;
        }

        public int[] Dequeue()
        {
            if(head==null)
            {
                return new int[]{-1,-1};
            }

            var op = this.Front();
            head = head.next;
            counter--;
            return op;
        }

        public bool IsEmpty()
        {
            return head==null;
        }
    }
    public class QueueArray
    {
        public int counter = 0;
        int length = 0;
        int[][] array;
        int read = 0;
        int write = 0;
        public QueueArray(int length)
        {
            this.length = length;
            array = new int[length+1][];
        }

        public void Enqueue(int[] key)
        {
            if((write > read && (write==array.Length && read == 0)) || (read > write && (read - write == 1)))
            {
                System.Console.WriteLine("Array is full");
            }
            else
            {
                array[write] = key;
                write = write==array.Length? 0:write+1;
                counter++;
            }
        }

        public int[] Front()
        {
            if(write==read)
            {
                return new int[]{-1,-1};
            }
            else
            {
                return array[read];
            }
        }

        public int[] Dequeue()
        {
            if(read==write)
            {
                System.Console.WriteLine("Queue Empty");
                return new int[]{-1,-1};
            }
            var temp = array[read];
            read = read==array.Length? 0:read+1;
            counter --;
            return temp;
        }

    }
    public class BST
    {
        public NodeTree root = null;
        public int size = 0;

        public void Insert(int item)
        {
            if(root == null) 
            {
                root = new NodeTree();
                root.key = item;
                size++;
                return;
            }
            var node = Find(item, root);
            if(node.key == item)
            {
                return;
            }
            else if(item > node.key)
            {
                node.rightChild = new NodeTree();
                node.rightChild.key = item;
                node.rightChild.parent = node;
            }
            else
            {
                node.leftChild = new NodeTree();
                node.leftChild.key = item;
                node.leftChild.parent = node;
            }
            size++;
        }
        
        public NodeTree Find(int item, NodeTree node)
        {
            if(node == null) return node;
            if(node.key == item) return node;
            else if(item<node.key)
            {
                if(node.leftChild == null)
                {
                    return node;
                }
                else
                {
                    return Find(item,node.leftChild);
                }
            }
            else
            {
                if(node.rightChild == null)
                {
                    return node;
                }
                else
                {
                    return Find(item, node.rightChild);
                }
            }
        }

        public NodeTree Next(NodeTree node)
        {
            if(node.rightChild!=null)
            {
                return LeftDescendent(node.rightChild);
            }
            else
            {
                return RightAncestor(node)??node;
            }
        }

        private NodeTree RightAncestor(NodeTree node)
        {
            if(node.parent ==null) return null;
            if(node.parent.key > node.key)
            {
                return node.parent;
            }
            else
            {
                return RightAncestor(node.parent);
            }
        }

        private NodeTree LeftDescendent(NodeTree node)
        {
            if(node.leftChild == null)
            {
                return node;
            }
            else
            {
                return LeftDescendent(node.leftChild);
            }
        }

        public List<NodeTree> RangeSearch(int x, int y, List<NodeTree> list = null)
        {
            if (list == null)
            {
                list = new List<NodeTree>();
            }

            var node = Find(x,root);

            if (node.key >= x && node.key <= y)
            {
                list.Add(node);
                var node2 = Next(node);
                if(node.key == node2.key) return list;
                return RangeSearch(node2.key,y,list);
            }
            else
            {
                return list;
            }
        }
    
        public void Delete(NodeTree node)
        {
            if(node.rightChild == null)
            {
                if(node.parent.leftChild == node)
                {
                    var x = node.leftChild;
                    var parent = node.parent;
                    node = null;
                    parent.leftChild = x;
                    x.parent = parent;
                }
                else
                {
                    var x = node.rightChild;
                    var parent = node.parent;
                    node = null;
                    parent.rightChild = x;
                    x.parent = parent;
                }
            }
            else
            {
                var x = Next(node);
                // Replace N by X, promote X.Right
                node.key = x.key;

                //promote X.Right
                if(x.parent.leftChild==x)
                {
                    x.parent.leftChild = x.rightChild;
                    if (x.rightChild != null)
                    {
                        x.rightChild.parent = x.parent;
                    }
                    x=null;
                }
                else
                {
                    x.parent.leftChild = x.rightChild;
                    if (x.rightChild != null)
                    {
                        x.rightChild.parent = x.parent;
                    }
                    x=null;
                }
            }
            size--;
        }
    }
    public class AVLTree
    {
        public NodeTree root = null;
        public int size = 0;

        public void AVLInsert(int item)
        {
            Insert(item);
            var node = Find(item,root);
            Rebalance(node);
        }

        public void Rebalance(NodeTree node)
        {
            var parent = node.parent;
            var Hleft = node.leftChild?.Height()??0;
            var Hright = node.rightChild?.Height()??0;

            if(Hleft > Hright + 1)
            {
                RebalanceRight(node);
            }
            if(Hright > Hleft +1)
            {
                RebalanceLeft(node);
            }
            if(parent!=null)
            {
                Rebalance(parent);
            }
        }

        private void RebalanceLeft(NodeTree node)
        {
            var rightChild = node.rightChild;

            var left = rightChild?.leftChild?.Height()??0;
            var right = rightChild?.rightChild?.Height()??0;

            if(left > right)
            {
                RotateRight(rightChild);
            }

            RotateLeft(node);
        }

        private void RebalanceRight(NodeTree node)
        {
            var leftChild = node.leftChild;
            var left = leftChild?.leftChild?.Height()??0;
            var right = leftChild?.rightChild?.Height()??0;

            if(right > left)
            {
                RotateLeft(leftChild);
            }

            RotateRight(node);
        }

        private void RotateRight(NodeTree node)
        {
            var parent = node.parent;
            var Y = node.leftChild;
            var YRight = Y.rightChild;

            Y.parent = parent;
            if(parent!=null)
            {
                if(parent?.leftChild?.key == node.key)
                {
                    parent.leftChild = Y;
                }
                else
                {
                    parent.rightChild = Y;
                }
            }
            else
            {
                root = Y;
            }
            
            node.parent = Y;
            Y.rightChild = node;
            if(YRight!=null)
            {
                YRight.parent = node;
            }
            node.leftChild = YRight;
        }

        private void RotateLeft(NodeTree node)
        {
            var parent = node.parent;
            var Y = node.rightChild;
            var YLeft = Y.leftChild;

            Y.parent = parent;
            if(parent!=null)
            {
                if(parent.leftChild.key == node.key)
                {
                    parent.leftChild = Y;
                }
                else
                {
                    parent.rightChild = Y;
                }
            }
            else
            {
                root = Y;
            }
            
            node.parent = Y;
            Y.leftChild = node;
            if(YLeft!=null)
            {
                YLeft.parent = node;
            }
            node.rightChild = YLeft;
        }

        private void Insert(int item)
        {
            if(root == null) 
            {
                root = new NodeTree();
                root.key = item;
                size++;
                return;
            }
            var node = Find(item, root);
            if(node.key == item)
            {
                return;
            }
            else if(item > node.key)
            {
                node.rightChild = new NodeTree();
                node.rightChild.key = item;
                node.rightChild.parent = node;
            }
            else
            {
                node.leftChild = new NodeTree();
                node.leftChild.key = item;
                node.leftChild.parent = node;
            }
            size++;
        }
        
        public NodeTree Find(int item, NodeTree node)
        {
            if(node == null) return node;
            if(node.key == item) return node;
            else if(item<node.key)
            {
                if(node.leftChild == null)
                {
                    return node;
                }
                else
                {
                    return Find(item,node.leftChild);
                }
            }
            else
            {
                if(node.rightChild == null)
                {
                    return node;
                }
                else
                {
                    return Find(item, node.rightChild);
                }
            }
        }

        public NodeTree Next(NodeTree node)
        {
            if(node.rightChild!=null)
            {
                return LeftDescendent(node.rightChild);
            }
            else
            {
                return RightAncestor(node)??node;
            }
        }

        private NodeTree RightAncestor(NodeTree node)
        {
            if(node.parent ==null) return null;
            if(node.parent.key > node.key)
            {
                return node.parent;
            }
            else
            {
                return RightAncestor(node.parent);
            }
        }

        private NodeTree LeftDescendent(NodeTree node)
        {
            if(node.leftChild == null)
            {
                return node;
            }
            else
            {
                return LeftDescendent(node.leftChild);
            }
        }

        public List<NodeTree> RangeSearch(int x, int y, List<NodeTree> list = null)
        {
            if (list == null)
            {
                list = new List<NodeTree>();
            }

            var node = Find(x,root);

            if (node.key >= x && node.key <= y)
            {
                list.Add(node);
                var node2 = Next(node);
                if(node.key == node2.key) return list;
                return RangeSearch(node2.key,y,list);
            }
            else
            {
                return list;
            }
        }
    
        public void AVLDelete(NodeTree node)
        {
            var key = node.key;
            var parent = Delete(node);
            Rebalance(parent);
        }

        private NodeTree Delete(NodeTree node)
        {
            var p = new NodeTree();
            if(node.rightChild == null)
            {
                if(node.parent.leftChild == node)
                {
                    var x = node.leftChild;
                    var parent = node.parent;
                    node = null;
                    parent.leftChild = x;
                    if(x!=null)
                    {
                        x.parent = parent;
                    }
                    p = parent;
                }
                else
                {
                    var x = node.rightChild;
                    var parent = node.parent;
                    node = null;
                    parent.rightChild = x;
                    if(x!=null)
                    {
                        x.parent = parent;
                    }
                    p = parent;
                }
            }
            else
            {
                var x = Next(node);
                // Replace N by X, promote X.Right
                node.key = x.key;
                p = x.parent;

                //promote X.Right
                if(x.parent.leftChild==x)
                {
                    x.parent.leftChild = x.rightChild;
                    if (x.rightChild != null)
                    {
                        x.rightChild.parent = x.parent;
                    }
                    x=null;
                }
                else
                {
                    x.parent.leftChild = x.rightChild;
                    if (x.rightChild != null)
                    {
                        x.rightChild.parent = x.parent;
                    }
                    x=null;
                }
            }
            size--;
            return p;
        }
    }
}
