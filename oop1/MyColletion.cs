using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace oop1
{
    [Serializable]
    public partial class MyColletion<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
    {
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
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
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
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

        public int Count{ get; private set; }
        public bool IsReadOnly => false;
        bool IList.IsFixedSize => false;
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => null;

        object IList.this[int index] { get => this[index]; set => this[index] = (T)value; }

        public MyColletion() { }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].Equals(item))
                    return i;
            return -1;
        }

        public void Add(T item)
        {
            if (Count + 1 == int.MaxValue)
                throw new InvalidOperationException("Collection length out of bounds");
            int itemCount = Count++;
            int level1 = itemCount % 16;
            itemCount /= 16;
            int level2 = itemCount % 16;
            itemCount /= 16;
            int level3 = itemCount % 16;
            itemCount /= 16;
            int level4 = itemCount % 16;
            itemCount /= 16;
            int level5 = itemCount % 16;
            itemCount /= 16;
            int level6 = itemCount % 16;
            itemCount /= 16;
            int level7 = itemCount % 16;
            itemCount /= 16;
            int level8 = itemCount % 16;
            itemCount /= 16;
            internalStorage[level8][level7][level6][level5][level4][level3][level2][level1] = item;
        }

        public void Clear()
        {
            internalStorage = new();
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var collectionItem in this)
                if (collectionItem.Equals(item)) return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array), "array cannot be null");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "arrayIndex cannot be negative");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("array index out of range", nameof(arrayIndex));
            for (int i = 0; i < Count; i++)
                array[arrayIndex++] = this[i];
        }

        public bool Remove(T item) => throw new NotSupportedException();

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
            try
            {
                Add((T)value);
            }
            catch (InvalidCastException)
            {
                return -1;
            }
            return Count - 1;
        }

        bool IList.Contains(object value) =>
            (value is T) && Contains((T)value);

        int IList.IndexOf(object value)
        {
            if (value is T)
                return IndexOf((T)value);
            else
                return -1;
        }

        void IList<T>.Insert(int index, T item) => throw new NotSupportedException();
        void IList.Insert(int index, object value) => throw new NotSupportedException();

        void IList.Remove(object value) => throw new NotSupportedException();

        void IList<T>.RemoveAt(int index) => throw new NotSupportedException();
        void IList.RemoveAt(int index) => throw new NotSupportedException();

        void ICollection.CopyTo(Array array, int index)
        {
            if (array.GetType().GetElementType() == typeof(T))
                CopyTo((T[])array, index);
        }
    }
}
