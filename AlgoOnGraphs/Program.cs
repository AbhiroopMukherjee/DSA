// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Scratchpad
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindingIfVerticesConnected();
            //NoOfConnectedGroups();
            //CheckIfCycleDiGraph();
            //TopologicalSort();
            //StronglyConnectedGraph();
            //BreadthFirstSearchUndirectedGraph(); //Bipartite solution needs fixing
            //DijkstrasAlgorithm();
            BelmanFordAlgo();
        }

        private static void BelmanFordAlgo()
        {
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<Edge>[] graph = new List<Edge>[noOfEdges+1];
            long[] distance = new long[noOfEdges+1];

            for(int i=1;i<distance.Length;i++)
            {
                distance[i] = int.MaxValue;
            }

            int[] previous = new int[noOfEdges+1];
            for(int i=1;i<previous.Length;i++)
            {
                previous[i] = -1;
            }

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<Edge>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(new Edge(input[1], input[2]));
            }

            int startIndex = Convert.ToInt32(Console.ReadLine());

            BellmanFord(graph,previous,distance,startIndex);
            //System.Console.WriteLine(CheckNegetiveCycle(graph,distance)?1:0);
            SetNegetiveCycleNodes(graph,distance);

            for(int i=1; i<distance.Count(); i++)
            {
                if(distance[i]==int.MaxValue)
                {
                    System.Console.WriteLine("*");
                }
                else if(distance[i]==int.MinValue)
                {
                    System.Console.WriteLine("-");
                }
                else
                {
                    System.Console.WriteLine(distance[i]);
                }
            }
        }

        private static void SetNegetiveCycleNodes(List<Edge>[] graph, long[] distance)
        {
            for(int i=1; i<graph.Count();i++)
            {
                for(int j=1; j<graph.Count(); j++)
                {
                    foreach(var edge in graph[j])
                    {
                        if(distance[edge.vertex] > distance[j] + edge.weight)
                        {
                            distance[edge.vertex] = int.MinValue;
                        }
                    }
                }
            }
        }

        private static bool CheckNegetiveCycle(List<Edge>[] graph, long[] distance)
        {
            for(int j=1; j<graph.Count(); j++)
            {
                foreach(var edge in graph[j])
                {
                    if(distance[edge.vertex] > distance[j] + edge.weight)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void BellmanFord(List<Edge>[] graph, int[] previous, long[] distance, int startIndex = 1)
        {
            distance[startIndex] = 0;
            for(int i=1; i<graph.Count()-1;i++)
            {
                for(int j=1; j<graph.Count(); j++)
                {
                    foreach(var edge in graph[j])
                    {
                        if(distance[edge.vertex] > distance[j] + edge.weight)
                        {
                            distance[edge.vertex] = distance[j] + edge.weight;
                        }
                    }
                }
            }
        }

        private static void DijkstrasAlgorithm()
        {
            //int[] input1 = {4,4};
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<Edge>[] graph = new List<Edge>[noOfEdges+1];
            bool[] visited = new bool[noOfEdges+1];
            long[] distance = new long[noOfEdges+1];

            for(int i=1;i<distance.Length;i++)
            {
                distance[i] = int.MaxValue;
            }

            int[] previous = new int[noOfEdges+1];
            for(int i=1;i<previous.Length;i++)
            {
                previous[i] = -1;
            }

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<Edge>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(new Edge(input[1], input[2]));
            }

            // graph[1].Add(new Edge(2, 1));
            // graph[4].Add(new Edge(1, 2));
            // graph[2].Add(new Edge(3, 2));
            // graph[1].Add(new Edge(3, 5));
            // int[] points = {1,4};

            int[] points =  Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            Dijkstra(graph,visited,previous,distance,points[0]);
            System.Console.WriteLine(Math.Abs(distance[points[1]])==int.MaxValue?-1:distance[points[1]]);
        }

        private static void Dijkstra(List<Edge>[] graph, bool[] visited, int[] previous, long[] distance, int start)
        {
            distance[start] = 0;
            PriorityQueue queue = new PriorityQueue();

            for(int i=1; i<distance.Length; i++)
            {
                queue.Enqueue(new Edge(i,distance[i]));
            }

            while(!queue.IsEmpty())
            {
                Edge point = queue.Dequeue();
                int vertex = point.vertex;

                foreach(var edge in graph[vertex])
                {
                    if(distance[edge.vertex] > distance[vertex] + edge.weight)
                    {
                        distance[edge.vertex] = distance[vertex] + edge.weight;
                        previous[edge.vertex] = vertex;
                        queue.Update(edge.vertex,distance[edge.vertex]);
                    } 
                }
            }
        }

        private static void BreadthFirstSearchUndirectedGraph()
        {
            //int[] input1 = {4,4};
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<int>[] graph = new List<int>[noOfEdges+1];
            int[] visited = new int[noOfEdges+1];
            int[] distance = new int[noOfEdges+1];
            int[] color = new int[noOfEdges+1];
            for(int i=1;i<color.Length;i++)
            {
                color[i] = -1;
            }
            for(int i=1;i<distance.Length;i++)
            {
                distance[i] = -1;
            }

            int[] parent = new int[noOfEdges+1];
            for(int i=1;i<parent.Length;i++)
            {
                parent[i] = -1;
            }

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<int>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);
            }

            // graph[1].Add(2);
            // graph[4].Add(1);
            // graph[2].Add(3);
            // graph[3].Add(1);
            // graph[2].Add(1);
            // graph[1].Add(4);
            // graph[3].Add(2);
            // graph[1].Add(3);

            //int[] points = {2,4};
            int[] points =  Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            bool isBipartite = true;
            BFS(graph,distance,parent,points[0],visited, ref isBipartite, color);

            System.Console.WriteLine(distance[points[1]]);
            //System.Console.WriteLine(isBipartite?1:0);
        }

        private static void BFS(List<int>[] graph, int[] distance, int[] parent, int start, int[] visited, ref bool isBipartite, int[] color)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            color[start] = 0;

            while(queue.Count!=0)
            {
                int x = queue.Dequeue();
                distance[x] = parent[x]==-1?0:distance[parent[x]]+1;

                foreach(int v in graph[x])
                {
                    if(color[v]==color[x])
                    {
                        isBipartite = false;
                    }
                    if(visited[v]!=1)
                    {
                        color[v] = color[x]==0?1:0;
                        visited[v] = 1;
                        parent[v] = x;
                        queue.Enqueue(v);
                    }
                }                
            }
        }

        private static void StronglyConnectedGraph()
        {
            //int[] input1 = {4,3};
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<int>[] graph = new List<int>[noOfEdges+1];
            List<int>[] graphReverse = new List<int>[noOfEdges+1];
            int[] visited = new int[noOfEdges+1];
            int[] preOrder = new int[noOfEdges+1];
            int[] postOrder = new int[noOfEdges+1];
            List<int> postOrderList = new List<int>();

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<int>();
                graphReverse[i] = new List<int>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(input[1]);
                graphReverse[input[1]].Add(input[0]);
            }

            // graph[2].Add(1);
            // graph[3].Add(2);
            // graph[3].Add(1);
            // graph[4].Add(3);
            // graph[4].Add(1);
            // graph[5].Add(2);
            // graph[5].Add(3);

            // graphReverse[1].Add(2);
            // graphReverse[2].Add(3);
            // graphReverse[1].Add(3);
            // graphReverse[3].Add(4);
            // graphReverse[1].Add(4);
            // graphReverse[2].Add(5);
            // graphReverse[3].Add(5);

            DFSDiGraph(graphReverse,visited,preOrder,postOrder,postOrderList);
            visited = new int[noOfEdges+1];

            System.Console.WriteLine(DFSSCC(graph,visited,postOrder));
        }

        private static int DFSSCC(List<int>[] graph, int[] visited, int[] postOrder)
        {
            var postOrderReverse = OrderDescendingList(postOrder);

            int stronglyConnectGroups = 0;

            for(int i=1; i<graph.Length; i++)
            {
                if(visited[postOrderReverse[i]]==0)
                {
                    stronglyConnectGroups++;
                    Explore(graph,visited,postOrderReverse[i]);
                }
            }

            return stronglyConnectGroups;
        }

        private static void Explore(List<int>[] graph, int[] visited, int node)
        {
            visited[node] = 1;

            foreach(int x in graph[node])
            {
                if(visited[x]!=1)
                {
                    Explore(graph,visited,x);
                }
            }
        }
        
        private static int[] OrderDescendingList(int[] postOrder)
        {
            int[] list = new int[postOrder.Length];

            for(int i=1; i<postOrder.Length; i++)
            {
                int value = int.MinValue;
                int index = 0;
                for(int j=1; j<postOrder.Length; j++)
                {
                    if(postOrder[j]>value)
                    {
                        index = j;
                        value = postOrder[j];
                    }
                }
                list[i] = index;
                postOrder[index] = int.MinValue;
            }

            return list;
        }

        private static void TopologicalSort()
        {
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<int>[] graph = new List<int>[noOfEdges+1];
            int[] visited = new int[noOfEdges+1];
            int[] preOrder = new int[noOfEdges+1];
            int[] postOrder = new int[noOfEdges+1];
            List<int> postOrderList = new List<int>();

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<int>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(input[1]);
            }

            DFSDiGraph(graph,visited,preOrder,postOrder,postOrderList);
            
            postOrderList.Reverse();

            foreach(var x in postOrderList)
            {
                System.Console.Write(x+" ");
            }
        }

        private static void DFSDiGraph(List<int>[] graph, int[] visited, int[] preOrder, int[] postOrder, List<int> postOrderList)
        {
            int counter = 0;
            for(int i=1; i<graph.Length; i++)
            {
                if(visited[i]==0)
                {
                    ExploreWithOrders(graph,visited,i,preOrder,postOrder,ref counter,postOrderList);
                }
            }
        }

        private static void CheckIfCycleDiGraph()
        {
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<int>[] graph = new List<int>[noOfEdges+1];
            int[] visited = new int[noOfEdges+1];

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<int>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(input[1]);
            }

            System.Console.WriteLine(DFSCheckCycle(graph,visited));
        }

        private static int DFSCheckCycle(List<int>[] graph, int[] visited)
        {
            bool isCycle = false;
            for(int i=1; i<graph.Length; i++)
            {
                if(visited[i]==0)
                {
                    ExploreCycle(graph,visited,i,i,ref isCycle);
                }
            }

            return isCycle?1:0;
        }

        private static void NoOfConnectedGroups()
        {
            //int[] input1 = {4,2};
            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<int>[] graph = new List<int>[noOfEdges+1];
            int[] visited = new int[noOfEdges+1];

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<int>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);
            }

            // graph[1].Add(2);
            // graph[3].Add(2);
            // graph[2].Add(1);
            // graph[2].Add(3);


            System.Console.WriteLine(DFS(graph,visited));
        }

        private static int DFS(List<int>[] graph, int[] visited)
        {
            int connectGroups = 0;

            for(int i=1; i<graph.Length; i++)
            {
                if(visited[i]==0)
                {
                    connectGroups++;
                    Explore(graph,visited,i);
                }
            }

            return connectGroups;
        }

        public static void FindingIfVerticesConnected()
        {
            //int[] input1 = {4,2};

            int[] input1 = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            var noOfEdges = input1[0];
            var noOfVertices = input1[1];

            List<int>[] graph = new List<int>[noOfEdges+1];
            int[] visited = new int[noOfEdges+1];

            for(int i=1;i<=noOfEdges;i++)
            {
                graph[i] = new List<int>();
            }

            for(int i=1;i<=noOfVertices;i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);
            }

            // graph[1].Add(2);
            // graph[3].Add(2);
            //graph[4].Add(3);
            //graph[1].Add(4);
            //int[] search = {1,4};

            int[] search = Array.ConvertAll(Console.ReadLine()?.Split(' ') ?? Array.Empty<string>(), int.Parse);
            
            System.Console.WriteLine(DFSSingle(graph,visited,search));
        }

        private static int DFSSingle(List<int>[] graph, int[] visited, int[] search)
        {
            Explore(graph, visited, search[0]);

            if(visited[search[1]]==1) return 1;
            else return 0;
        }

        private static void ExploreWithOrders(List<int>[] graph, int[] visited, int node, int[] preOrder, int[] postOrder, ref int counter, List<int> postOrderList)
        {
            visited[node] = 1;
            preOrder[node] = ++counter;
            foreach(int x in graph[node])
            {
                if(visited[x]!=1)
                {
                    ExploreWithOrders(graph,visited,x,preOrder,postOrder,ref counter, postOrderList); 
                }  
            }
            postOrder[node] = ++counter;
            postOrderList.Add(node);
        }

        private static void ExploreCycle(List<int>[] graph, int[] visited, int node, int source, ref bool isCycle)
        {
            visited[node] = 1;

            foreach(int x in graph[node])
            {
                if(visited[x]!=1)
                {
                    ExploreCycle(graph,visited,x, source, ref isCycle);
                }
                else if(x==source)
                {
                    isCycle = true;
                }
            }
        }
    }

    class PriorityQueue
    {
        private List<Edge> heap;

        public PriorityQueue()
        {
            heap = new List<Edge>();
        }

        public int Size()
        {
            return heap.Count;
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        public void Enqueue(Edge item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public Edge Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            Edge root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return root;
        }

        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;
            while (index > 0 && heap[index].weight < heap[parent].weight)
            {
                Swap(index, parent);
                index = parent;
                parent = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;

            if (leftChild < heap.Count && heap[leftChild].weight < heap[smallest].weight)
            {
                smallest = leftChild;
            }

            if (rightChild < heap.Count && heap[rightChild].weight < heap[smallest].weight)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            Edge temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        internal void Update(int vertex, long v)
        {
            for(int i=0;i<heap.Count;i++)
            {
                if(heap[i].vertex == vertex)
                {
                    heap[i].weight = v;
                    HeapifyUp(i);
                    break;
                }
            }
        }
    }

    class Edge
    {
        public int vertex { get; set; }
        public long weight { get; set; }
        public Edge(int v, long w)
        {
            vertex = v;
            weight = w;
        }
    }
}
