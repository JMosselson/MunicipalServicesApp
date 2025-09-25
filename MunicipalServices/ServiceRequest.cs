    using System;
using System.Collections.Generic;

namespace MunicipalServices
{
    // Part 3: Model and Data Structures

    // Represents a single service request with status tracking. (Part 3 Model)
    public class ServiceRequest
    {
        public string ReferenceId { get; private set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime ReportedDate { get; private set; }
        public List<string> StatusHistory { get; private set; }

        public ServiceRequest(string refId, string title, string category, string description, string location, DateTime reportedDate)
        {
            ReferenceId = refId;
            Title = title;
            Category = category;
            Description = description;
            Location = location;
            ReportedDate = reportedDate;
            StatusHistory = new List<string> { $"Reported on {reportedDate:g}" };
        }

        public void UpdateStatus(string newStatus)
        {
            StatusHistory.Add($"{newStatus} ({DateTime.Now:g})");
        }

        public string GetCurrentStatus()
        {
            return StatusHistory[StatusHistory.Count - 1];
        }
    }

    // Represents a node in the Binary Search Tree.
    public class Node
    {
        public ServiceRequest Data;
        public Node Left, Right;

        public Node(ServiceRequest data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    // A Binary Search Tree to store and efficiently search for Service Requests by Reference ID.
    public class BinarySearchTree
    {
        private Node root;

        public void Insert(ServiceRequest data)
        {
            root = InsertRec(root, new Node(data));
        }

        private Node InsertRec(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
                return root;
            }

            if (string.Compare(newNode.Data.ReferenceId, root.Data.ReferenceId) < 0)
                root.Left = InsertRec(root.Left, newNode);
            else if (string.Compare(newNode.Data.ReferenceId, root.Data.ReferenceId) > 0)
                root.Right = InsertRec(root.Right, newNode);

            return root;
        }

        public ServiceRequest Search(string referenceId)
        {
            return SearchRec(root, referenceId);
        }

        private ServiceRequest SearchRec(Node root, string referenceId)
        {
            if (root == null || root.Data.ReferenceId == referenceId)
                return root?.Data;

            if (string.Compare(referenceId, root.Data.ReferenceId) < 0)
                return SearchRec(root.Left, referenceId);

            return SearchRec(root.Right, referenceId);
        }
        
        // Method to get all service requests using in-order traversal
        public List<ServiceRequest> GetAllRequests()
        {
            var result = new List<ServiceRequest>();
            InOrderTraversal(root, result);
            return result;
        }
        
        private void InOrderTraversal(Node node, List<ServiceRequest> result)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Data);
                InOrderTraversal(node.Right, result);
            }
        }
    }

    // A Graph to represent the dispatch grid for calculating optimal routes.
    // Uses an adjacency list representation.
    public class Graph
    {
        private Dictionary<string, Dictionary<string, int>> adj = new Dictionary<string, Dictionary<string, int>>();

        public void AddNode(string node)
        {
            if (!adj.ContainsKey(node))
            {
                adj[node] = new Dictionary<string, int>();
            }
        }

        public void AddEdge(string source, string destination, int weight)
        {
            if (adj.ContainsKey(source) && adj.ContainsKey(destination))
            {
                adj[source][destination] = weight;
                adj[destination][source] = weight; // For undirected graph
            }
        }

        public Tuple<List<string>, int> FindShortestPath(string startNode, string endNode)
        {
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var nodes = new List<string>();

            foreach (var vertex in adj.Keys)
            {
                if (vertex == startNode)
                    distances[vertex] = 0;
                else
                    distances[vertex] = int.MaxValue;
                previous[vertex] = null;
                nodes.Add(vertex);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x].CompareTo(distances[y]));
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == endNode)
                {
                    var path = new List<string>();
                    while (previous[smallest] != null)
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }
                    path.Add(startNode);
                    path.Reverse();
                    return Tuple.Create(path, distances[endNode]);
                }

                if (distances[smallest] == int.MaxValue)
                    break;

                foreach (var neighbor in adj[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }
            return null; // Path not found
        }
        
        // Depth-First Search traversal
        public List<string> DepthFirstSearch(string startNode)
        {
            var visited = new HashSet<string>();
            var result = new List<string>();
            DFSUtil(startNode, visited, result);
            return result;
        }
        
        private void DFSUtil(string node, HashSet<string> visited, List<string> result)
        {
            visited.Add(node);
            result.Add(node);
            
            if (adj.ContainsKey(node))
            {
                foreach (var neighbor in adj[node].Keys)
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFSUtil(neighbor, visited, result);
                    }
                }
            }
        }
        
        // Breadth-First Search traversal
        public List<string> BreadthFirstSearch(string startNode)
        {
            var visited = new HashSet<string>();
            var result = new List<string>();
            var queue = new Queue<string>();
            
            queue.Enqueue(startNode);
            visited.Add(startNode);
            
            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);
                
                if (adj.ContainsKey(current))
                {
                    foreach (var neighbor in adj[current].Keys)
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            
            return result;
        }
        
        // Edge class for MST algorithms
        public class Edge : IComparable<Edge>
        {
            public string Source { get; set; }
            public string Destination { get; set; }
            public int Weight { get; set; }
            
            public Edge(string source, string destination, int weight)
            {
                Source = source;
                Destination = destination;
                Weight = weight;
            }
            
            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other?.Weight);
            }
        }
        
        // Kruskal's algorithm for Minimum Spanning Tree
        public List<Edge> KruskalMST()
        {
            var edges = new List<Edge>();
            var result = new List<Edge>();
            var parent = new Dictionary<string, string>();
            
            // Get all edges
            foreach (var vertex in adj.Keys)
            {
                foreach (var neighbor in adj[vertex])
                {
                    if (string.Compare(vertex, neighbor.Key) < 0) // Avoid duplicate edges
                    {
                        edges.Add(new Edge(vertex, neighbor.Key, neighbor.Value));
                    }
                }
            }
            
            // Sort edges by weight
            edges.Sort();
            
            // Initialize parent for Union-Find
            foreach (var vertex in adj.Keys)
            {
                parent[vertex] = vertex;
            }
            
            foreach (var edge in edges)
            {
                string rootX = FindParent(parent, edge.Source);
                string rootY = FindParent(parent, edge.Destination);
                
                if (rootX != rootY)
                {
                    result.Add(edge);
                    parent[rootX] = rootY;
                }
            }
            
            return result;
        }
        
        private string FindParent(Dictionary<string, string> parent, string vertex)
        {
            if (parent[vertex] != vertex)
                parent[vertex] = FindParent(parent, parent[vertex]);
            return parent[vertex];
        }
        
        // Prim's algorithm for Minimum Spanning Tree
        public List<Edge> PrimMST()
        {
            var result = new List<Edge>();
            var visited = new HashSet<string>();
            var priorityQueue = new SortedDictionary<int, List<Edge>>();
            
            if (adj.Count == 0) return result;
            
            // Start with first vertex
            string startVertex = adj.Keys.First();
            visited.Add(startVertex);
            
            // Add all edges from start vertex to priority queue
            AddEdgesToQueue(startVertex, priorityQueue, visited);
            
            while (priorityQueue.Count > 0 && visited.Count < adj.Count)
            {
                // Get minimum weight edge
                var minWeight = priorityQueue.Keys.First();
                var edgeList = priorityQueue[minWeight];
                var edge = edgeList[0];
                edgeList.RemoveAt(0);
                
                if (edgeList.Count == 0)
                    priorityQueue.Remove(minWeight);
                
                // If destination is not visited, add edge to MST
                if (!visited.Contains(edge.Destination))
                {
                    result.Add(edge);
                    visited.Add(edge.Destination);
                    AddEdgesToQueue(edge.Destination, priorityQueue, visited);
                }
            }
            
            return result;
        }
        
        private void AddEdgesToQueue(string vertex, SortedDictionary<int, List<Edge>> queue, HashSet<string> visited)
        {
            if (adj.ContainsKey(vertex))
            {
                foreach (var neighbor in adj[vertex])
                {
                    if (!visited.Contains(neighbor.Key))
                    {
                        var edge = new Edge(vertex, neighbor.Key, neighbor.Value);
                        if (!queue.ContainsKey(neighbor.Value))
                            queue[neighbor.Value] = new List<Edge>();
                        queue[neighbor.Value].Add(edge);
                    }
                }
            }
        }
    }
    
    // AVL Tree Node for self-balancing binary search tree
    public class AVLNode
    {
        public ServiceRequest Data;
        public AVLNode Left, Right;
        public int Height;

        public AVLNode(ServiceRequest data)
        {
            Data = data;
            Left = Right = null;
            Height = 1;
        }
    }
    
    // AVL Tree implementation for balanced service request storage
    public class AVLTree
    {
        private AVLNode root;
        
        public void Insert(ServiceRequest data)
        {
            root = InsertRec(root, data);
        }
        
        private AVLNode InsertRec(AVLNode node, ServiceRequest data)
        {
            // Standard BST insertion
            if (node == null)
                return new AVLNode(data);
            
            if (string.Compare(data.ReferenceId, node.Data.ReferenceId) < 0)
                node.Left = InsertRec(node.Left, data);
            else if (string.Compare(data.ReferenceId, node.Data.ReferenceId) > 0)
                node.Right = InsertRec(node.Right, data);
            else
                return node; // Duplicate keys not allowed
            
            // Update height of current node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            
            // Get the balance factor
            int balance = GetBalance(node);
            
            // Left Left Case
            if (balance > 1 && string.Compare(data.ReferenceId, node.Left.Data.ReferenceId) < 0)
                return RightRotate(node);
            
            // Right Right Case
            if (balance < -1 && string.Compare(data.ReferenceId, node.Right.Data.ReferenceId) > 0)
                return LeftRotate(node);
            
            // Left Right Case
            if (balance > 1 && string.Compare(data.ReferenceId, node.Left.Data.ReferenceId) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            
            // Right Left Case
            if (balance < -1 && string.Compare(data.ReferenceId, node.Right.Data.ReferenceId) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }
            
            return node;
        }
        
        private int GetHeight(AVLNode node)
        {
            return node?.Height ?? 0;
        }
        
        private int GetBalance(AVLNode node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }
        
        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;
            
            // Perform rotation
            y.Left = x;
            x.Right = T2;
            
            // Update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            
            return y;
        }
        
        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;
            
            // Perform rotation
            x.Right = y;
            y.Left = T2;
            
            // Update heights
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            
            return x;
        }
        
        public ServiceRequest Search(string referenceId)
        {
            return SearchRec(root, referenceId);
        }
        
        private ServiceRequest SearchRec(AVLNode node, string referenceId)
        {
            if (node == null || node.Data.ReferenceId == referenceId)
                return node?.Data;
            
            if (string.Compare(referenceId, node.Data.ReferenceId) < 0)
                return SearchRec(node.Left, referenceId);
            
            return SearchRec(node.Right, referenceId);
        }
        
        public List<ServiceRequest> GetAllRequests()
        {
            var result = new List<ServiceRequest>();
            InOrderTraversal(root, result);
            return result;
        }
        
        private void InOrderTraversal(AVLNode node, List<ServiceRequest> result)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Data);
                InOrderTraversal(node.Right, result);
            }
        }
    }
    
    // Red-Black Tree Node with color property
    public enum Color { Red, Black }
    
    public class RBNode
    {
        public ServiceRequest Data;
        public RBNode Left, Right, Parent;
        public Color Color;

        public RBNode(ServiceRequest data)
        {
            Data = data;
            Left = Right = Parent = null;
            Color = Color.Red; // New nodes are always red
        }
    }
    
    // Red-Black Tree implementation for balanced service request storage
    public class RedBlackTree
    {
        private RBNode root;
        private RBNode nullNode; // Sentinel node
        
        public RedBlackTree()
        {
            nullNode = new RBNode(null) { Color = Color.Black };
            root = nullNode;
        }
        
        public void Insert(ServiceRequest data)
        {
            var newNode = new RBNode(data);
            newNode.Parent = null;
            newNode.Left = nullNode;
            newNode.Right = nullNode;
            newNode.Color = Color.Red;
            
            RBNode y = null;
            RBNode x = root;
            
            while (x != nullNode)
            {
                y = x;
                if (string.Compare(newNode.Data.ReferenceId, x.Data.ReferenceId) < 0)
                    x = x.Left;
                else
                    x = x.Right;
            }
            
            newNode.Parent = y;
            if (y == null)
                root = newNode;
            else if (string.Compare(newNode.Data.ReferenceId, y.Data.ReferenceId) < 0)
                y.Left = newNode;
            else
                y.Right = newNode;
            
            if (newNode.Parent == null)
            {
                newNode.Color = Color.Black;
                return;
            }
            
            if (newNode.Parent.Parent == null)
                return;
            
            FixInsert(newNode);
        }
        
        private void FixInsert(RBNode k)
        {
            RBNode u;
            while (k.Parent.Color == Color.Red)
            {
                if (k.Parent == k.Parent.Parent.Right)
                {
                    u = k.Parent.Parent.Left; // uncle
                    if (u.Color == Color.Red)
                    {
                        u.Color = Color.Black;
                        k.Parent.Color = Color.Black;
                        k.Parent.Parent.Color = Color.Red;
                        k = k.Parent.Parent;
                    }
                    else
                    {
                        if (k == k.Parent.Left)
                        {
                            k = k.Parent;
                            RightRotate(k);
                        }
                        k.Parent.Color = Color.Black;
                        k.Parent.Parent.Color = Color.Red;
                        LeftRotate(k.Parent.Parent);
                    }
                }
                else
                {
                    u = k.Parent.Parent.Right; // uncle
                    
                    if (u.Color == Color.Red)
                    {
                        u.Color = Color.Black;
                        k.Parent.Color = Color.Black;
                        k.Parent.Parent.Color = Color.Red;
                        k = k.Parent.Parent;
                    }
                    else
                    {
                        if (k == k.Parent.Right)
                        {
                            k = k.Parent;
                            LeftRotate(k);
                        }
                        k.Parent.Color = Color.Black;
                        k.Parent.Parent.Color = Color.Red;
                        RightRotate(k.Parent.Parent);
                    }
                }
                if (k == root)
                    break;
            }
            root.Color = Color.Black;
        }
        
        private void LeftRotate(RBNode x)
        {
            RBNode y = x.Right;
            x.Right = y.Left;
            if (y.Left != nullNode)
                y.Left.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;
            y.Left = x;
            x.Parent = y;
        }
        
        private void RightRotate(RBNode x)
        {
            RBNode y = x.Left;
            x.Left = y.Right;
            if (y.Right != nullNode)
                y.Right.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                root = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;
            else
                x.Parent.Left = y;
            y.Right = x;
            x.Parent = y;
        }
        
        public ServiceRequest Search(string referenceId)
        {
            return SearchHelper(root, referenceId);
        }
        
        private ServiceRequest SearchHelper(RBNode node, string referenceId)
        {
            if (node == nullNode || node.Data.ReferenceId == referenceId)
                return node == nullNode ? null : node.Data;
            
            if (string.Compare(referenceId, node.Data.ReferenceId) < 0)
                return SearchHelper(node.Left, referenceId);
            
            return SearchHelper(node.Right, referenceId);
        }
        
        public List<ServiceRequest> GetAllRequests()
        {
            var result = new List<ServiceRequest>();
            InOrderTraversal(root, result);
            return result;
        }
        
        private void InOrderTraversal(RBNode node, List<ServiceRequest> result)
        {
            if (node != nullNode)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Data);
                InOrderTraversal(node.Right, result);
            }
        }
    }

    // Priority Service Request wrapper for heap operations
    public class PriorityServiceRequest : IComparable<PriorityServiceRequest>
    {
        public ServiceRequest Request { get; set; }
        public int Priority { get; set; } // Lower number = higher priority
        
        public PriorityServiceRequest(ServiceRequest request, int priority)
        {
            Request = request;
            Priority = priority;
        }
        
        public int CompareTo(PriorityServiceRequest other)
        {
            return Priority.CompareTo(other?.Priority);
        }
    }
    
    // Min-Heap implementation for priority queuing of service requests
    public class MinHeap
    {
        private List<PriorityServiceRequest> heap;
        
        public MinHeap()
        {
            heap = new List<PriorityServiceRequest>();
        }
        
        public int Count => heap.Count;
        
        public void Insert(PriorityServiceRequest item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }
        
        public PriorityServiceRequest ExtractMin()
        {
            if (heap.Count == 0)
                return null;
            
            var min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            
            if (heap.Count > 0)
                HeapifyDown(0);
            
            return min;
        }
        
        public PriorityServiceRequest Peek()
        {
            return heap.Count > 0 ? heap[0] : null;
        }
        
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                    break;
                
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
        
        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int smallest = index;
                
                if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
                    smallest = leftChild;
                
                if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
                    smallest = rightChild;
                
                if (smallest == index)
                    break;
                
                Swap(index, smallest);
                index = smallest;
            }
        }
        
        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        
        public List<PriorityServiceRequest> GetAllItems()
        {
            return new List<PriorityServiceRequest>(heap);
        }
    }
}
