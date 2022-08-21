using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Model
{
    class SimpleSet<T> : IEnumerable
    {
        private List<T> Items = new List<T>();
        private int Count => Items.Count;

        public SimpleSet()
        {

        }
        public SimpleSet(T data)
        {
            Items.Add(data);
        }

        public SimpleSet(IEnumerable<T> items)
        {
            Items = items.ToList();
        }

        public void Add(T data)
        {
            if(Items.Contains(data))
            {
                return;
            }
            Items.Add(data);
        }

        public void Remove(T data)
        {
            Items.Remove(data);
        }

        public SimpleSet<T> Union(SimpleSet<T> set)
        {
            var result = new SimpleSet<T>();

            foreach(T item in Items)
            {
                result.Add(item);
            }
            foreach (T item in set.Items)
            {
                result.Add(item);
            }

            return result;
        }

        public SimpleSet<T> Intersect(SimpleSet<T> set)
        {
            var result = new SimpleSet<T>();

            var big = set;
            var small = this;
            if (Count > set.Count)
            {
                big = this;
                small = set;
            }

            for (int i = 0; i < small.Count; i++)
            {
                for (int j = 0; j < big.Count; j++)
                {
                    if (big.Items[j].Equals(small.Items[i]))
                    {
                        result.Add(small.Items[i]);
                        break;
                    }
                }
            }
            
            return result;
        }

        public SimpleSet<T> Difference(SimpleSet<T> set)
        {
            //var result = new SimpleSet<T>();

            //for (int i = 0; i < Count; i++)
            //{
            //    bool isEqual = false;
            //    for (int j = 0; j < set.Count; j++)
            //    {
            //        if (set.Items[j].Equals(Items[i]))
            //        {
            //            isEqual = true;
            //            break;
            //        }
            //    }

            //    if (!isEqual)
            //    {
            //        result.Add(Items[i]);
            //    }

            //}

            var result = new SimpleSet<T>(Items);

            foreach(T item in set.Items)
            {
                result.Remove(item);
            }

            return result;
        }

        public bool Subset(SimpleSet<T> set)
        {
            foreach (T item1 in Items)
            {
                bool isEqual = false;
                foreach (T item2 in set.Items)
                {
                    if (item1.Equals(item2))
                    {
                        isEqual = true;
                        break;
                    }
                }
                if (!isEqual)
                {
                    return false;
                }
            }
            return true;
        }

        public SimpleSet<T> SymmetricDifference(SimpleSet<T> set)
        {
            var result = new SimpleSet<T>();

            for (int i = 0; i < Count; i++)
            {
                bool isEqual = false;
                for (int j = 0; j < set.Count; j++)
                {
                    if (set.Items[j].Equals(Items[i]))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    result.Add(Items[i]);
                }

            }

            for (int i = 0; i < set.Count; i++)
            {
                bool isEqual = false;
                for (int j = 0; j < Count; j++)
                {
                    if (Items[j].Equals(set.Items[i]))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    result.Add(set.Items[i]);
                }

            }

            return result;
        }
        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
