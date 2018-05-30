using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LoadXls
{
    public class GroupOfAdjacent<TSource, TKey> : IGrouping<TKey, TSource>
    {
        public TKey Key { get; set; }
        private List<TSource> GroupList { get; set; }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TSource>)this).GetEnumerator();
        }
        IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
        {
            return ((IEnumerable<TSource>)GroupList).GetEnumerator();
        }

        public GroupOfAdjacent(List<TSource> source, TKey key)
        {
            GroupList = source;
            Key = key;
        }
    }
    public static class LocalExtensions
    {
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var last = default(TKey);
            var haveLast = false;
            var list = new List<TSource>();
            foreach (var s in source)
            {
                var k = keySelector(s);
                if (haveLast)
                {
                    if (!k.Equals(last))
                    {
                        yield return new GroupOfAdjacent<TSource, TKey>(list, last);
                        list = new List<TSource>();
                        list.Add(s);
                        last = k;
                    }
                    else
                    {
                        list.Add(s);
                        last = k;
                    }
                }
                else
                {
                    list.Add(s);
                    last = k;
                    haveLast = true;
                }
            }
            if (haveLast)
                yield return new GroupOfAdjacent<TSource, TKey>(list, last);
        }
    }
}
