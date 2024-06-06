using System;
using System.Collections;
using System.Collections.Generic;

namespace oop1
{
    public partial class MyColletion<T>
    {
        [Serializable]
        private class Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            private readonly MyColletion<T> collection;
            private int currentIndex;

            public Enumerator(MyColletion<T> collection)
            {
                this.collection = collection;
                Current = collection[0];
            }

            [NonSerialized]
            private T current;
            public T Current
            {
                get =>
                    current ?? collection[currentIndex];
                private set =>
                    current = value;
            }
            object IEnumerator.Current => Current;

            public void Dispose() { }
            public bool MoveNext()
            {
                if (++currentIndex < collection.Count)
                {
                    Current = collection[currentIndex];
                    return true;
                }
                else
                {
                    currentIndex--;
                    return false;
                }
            }
            public void Reset()
            {
                currentIndex = 0;
                Current = collection[0];
            }
        }
    }
}
