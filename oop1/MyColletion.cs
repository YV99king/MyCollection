using System;
using System.Collections;
using System.Collections.Generic;

namespace oop1
{
    [Serializable]
    public partial class MyColletion<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
    {
        public T this[int index]
        {
            get
            {
                int level1 = index % 16;
                index /= 16;
                int level2 = index % 16;
                index /= 16;
                int level3 = index % 16;
                index /= 16;
                int level4 = index % 16;
                index /= 16;
                int level5 = index % 16;
                index /= 16;
                int level6 = index % 16;
                index /= 16;
                int level7 = index % 16;
                index /= 16;
                int level8 = index % 16;
                index /= 16;
                return internalStorage[level8][level7][level6][level5][level4][level3][level2][level1];
            }
            set
            {
                int level1 = index % 16;
                index /= 16;
                int level2 = index % 16;
                index /= 16;
                int level3 = index % 16;
                index /= 16;
                int level4 = index % 16;
                index /= 16;
                int level5 = index % 16;
                index /= 16;
                int level6 = index % 16;
                index /= 16;
                int level7 = index % 16;
                index /= 16;
                int level8 = index % 16;
                index /= 16;
                internalStorage[level8][level7][level6][level5][level4][level3][level2][level1] = value;
            }
        }
        private ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<T>>>>>>>> internalStorage;



        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        bool IList.IsFixedSize => throw new NotImplementedException();

        bool ICollection.IsSynchronized => throw new NotImplementedException();

        object ICollection.SyncRoot => throw new NotImplementedException();

        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyColletion() { }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IList.Add(object value)
        {
            throw new NotImplementedException();
        }

        bool IList.Contains(object value)
        {
            throw new NotImplementedException();
        }

        int IList.IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        void IList.Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        void IList.Remove(object value)
        {
            throw new NotImplementedException();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
