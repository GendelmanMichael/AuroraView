using System.Collections.Generic;

namespace AuroraView_Task_4
{

    // By the task it looks for me that you're expecting to get something alike HashMap.
    // Last time i've implemented own HashMap during studying,
    // so this is not the perfect implementation. Here is no protections and not implemented
    // what to do if we will get max quantity of elements with the same hash(theoretically it's possible)
    // But the main Idea that only HasMap guves complexity 0(1)

    public class Collection<K, V>
    {
        private SubCollection[] subs = new SubCollection[2];

        public V Get(K key)
        {
            Node res = subs[key.GetHashCode() % subs.Length].Get(key);
            if(res == null)
            {
                throw new KeyNotFoundException($"Key {key} not found!!!");
            }
            return res.value;
        }

        public void Set(K key, V value)
        {
            int index = key.GetHashCode() % subs.Length;
            if (!subs[index].Set(key, value))
            {
                if (subs[index].Count == 8)
                {
                    Resize();
                    Set(key, value);
                }
                subs[index].Add(new Node(key, value));
            }
        }

        private void Resize()
        {
            SubCollection[] newSubs = new SubCollection[2 * subs.Length];
            for (int i = 0; i < subs.Length; i++)
            {
                for (int j = 0;  j < subs[i].Count; j++)
                {
                    Node node = subs[i].nodes[j];
                    newSubs[node.key.GetHashCode() % newSubs.Length].Add(node);
                }
            }
            subs = newSubs;
        }

        public void SetAll(V val)
        {
            for (int i = 0; i < subs.Length; i++)
            {
                for (int j = 0; j < subs[i].Count; j++)
                {
                    subs[i].nodes[j].value = val;
                }
            }
        }

        private class SubCollection
        {
            public Node[] nodes = new Node[8];
            public int Count = 0;
            
            public bool Set(K key, V value)
            {
                Node exist = Get(key);
                if (exist != null)
                {
                    exist.value = value;
                    return true;
                }
                return false;
            }

            public void Add(Node node)
            {
                 nodes[Count++] = node;
            }

            public Node Get(K key)
            {
                for (int i = 0; i < Count; i++) 
                {
                    if (nodes[i].key.Equals(key))
                    {
                        return nodes[i];
                    }
                }

                return null;
            }
        }

        private class Node
        {
            public K key;
            public V value;

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
