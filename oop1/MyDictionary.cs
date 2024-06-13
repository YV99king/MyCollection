using System;
using System.Collections;
using System.Collections.Generic;

namespace oop1
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, ICollection<KeyValuePair<TKey, TValue>>, ICollection, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : notnull
    {
        
    }
}
