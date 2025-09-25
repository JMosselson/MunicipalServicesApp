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
    }
}
