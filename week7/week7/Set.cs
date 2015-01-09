using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7
{
    public class Set : ISet
    {
        public int[] Items { get; private set; }

        private Set() { }

        public Set(params int[] ints)
        {
            this.Items = ints.Select(x => x).Distinct().ToArray();
        }

        public Set(IEnumerable<int> ints)
        {
            this.Items = ints.Select(x => x).Distinct().ToArray();
        }

        public bool Contains(int item)
        {
            return this.Items.Contains(item);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Set))
            {
                return false;
            }
            
            return this.Equals(obj as Set);
        }

        private bool Equals(Set s)
        {
            if (this.Items.Length != s.Items.Length)
                return false;

            for (int i = 0; i < this.Items.Length; ++i)
            {
                if (this.Contains(s.Items[i]))
                    continue;

                return false;
            }

            return true;
        }

        public static Set Union(Set s1, Set s2)
        {
            Set result = new Set(s1.Items.Concat(s2.Items));

            return result;
        }

        public static Set Intersection(Set s1, Set s2)
        {
            Set result = new Set(s1.Items.Intersect(s2.Items));

            return result;
        }

        public static bool Equals(Set s1, Set s2)
        {
            return s1.Equals(s2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int count = 0;
            foreach (var i in Items.OrderBy(x => x))
            {
                count++;
                sb.Append(i);
                if (count < Items.Count())
                    sb.Append(",");
            }
            return sb.ToString();
            
        }
    }
}
