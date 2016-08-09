using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    /// <summary>
    /// 1-n Tree with unique node, defined by Id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T> : IEnumerable
    {
        public readonly Dictionary<long, T> Data;

        public readonly Dictionary<long, NodeLink> Links;

        public Tree()
        {
            Data = new Dictionary<long, T>();
            Links = new Dictionary<long, NodeLink>();
        }

        public List<long> Roots { get; } = new List<long>();

        public List<long> Leaves { get; } = new List<long>();

        public Node<T> this[long id] => new Node<T> { Link = Links[id], Data = Data[id] };

        public bool Contains(long id) => Links.ContainsKey(id);

        public void AddChild(long? parentId, long id, T data)
        {
            if (Data.ContainsKey(id))
                throw new Exception($"id {id} already exists in tree.");

            if (parentId != null && !Data.ContainsKey((long)parentId))
                throw new Exception($"parentId {parentId} not found in tree.");

            var link = new NodeLink { Id = id, Parent = parentId };
            var depth = 0;

            if (parentId == null)
            {
                if (Roots.Any())
                    Links[Roots[Roots.Count - 1]].Next = id;

                Roots.Add(id);
            }
            else
            {
                var parentLink = Links[(long)parentId];

                depth = parentLink.Depth + 1;

                if (parentLink.Child != null)
                {
                    link.Next = parentLink.Child;
                }
                else
                {
                    if (!Leaves.Contains((long)parentId))
                        throw new Exception($"parentId {parentId} not found in tree.");

                    Leaves.Remove((long)parentId);
                }
                parentLink.Child = id;
            }

            // Saves data

            Data.Add(id, data);

            // Saves link

            link.Depth = depth;
            Links.Add(id, link);

            // Registers as leaf

            Leaves.Add(id);
        }

        public IEnumerator GetEnumerator()
        {
            return Links.Select(x => x.Value).GetEnumerator();
        }
    }
}
