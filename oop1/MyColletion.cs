using System;
using System.Collections;
using System.Collections.Generic;

namespace oop1
{
    [Serializable]
    public partial class MyColletion<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
    {
        public MyColletion() { }

        private ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<T>>>>>>>> internalStorage;
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
                lock (internalStorage)
                {
                    internalStorage[level8][level7][level6][level5][level4][level3][level2][level1] = value;
                }
            }
        }
        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = (T)value;
        }

        public int Count { get; private set; } = 0;
        bool IList.IsFixedSize => false;
        public bool IsReadOnly => false;
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => null;

        public void Add(T item)
        {
            if (Count + 1 == int.MaxValue)
                throw new InvalidOperationException("Collection length out of bounds");
            int itemCount = Count;
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
            internalStorage.GetNextLevelContiner(level8).GetNextLevelContiner(level7).GetNextLevelContiner(level6)
                           .GetNextLevelContiner(level5).GetNextLevelContiner(level4).GetNextLevelContiner(level3)
                           .GetNextLevelContiner(level2)[level1] = item;
            Count++;
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
        public void Clear()
        {
            internalStorage = new();
            Count = 0;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "array cannot be null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "arrayIndex cannot be negative");
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("array index out of range", nameof(arrayIndex));
            for (int i = 0; i < Count; i++)
                array[arrayIndex++] = this[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            if (array.GetType().GetElementType() == typeof(T))
                CopyTo((T[])array, index);
        }
        public bool Contains(T item)
        {
            foreach (var collectionItem in this)
                if (collectionItem.Equals(item)) return true;
            return false;
        }
        bool IList.Contains(object value) =>
            (value is T testedValue) && Contains(testedValue);
        public IEnumerator<T> GetEnumerator() =>
            new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].Equals(item))
                    return i;
            return -1;
        }
        int IList.IndexOf(object value) =>
            value is T testedValue ? IndexOf(testedValue) : -1;
        public void Insert(int index, T item)
        {
            int fullIndex = index++;
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
            index = fullIndex;

            int correntCount = Count + 1;
            int level1Max = correntCount % 16;
            correntCount /= 16;
            int level2Max = correntCount % 16;
            correntCount /= 16;
            int level3Max = correntCount % 16;
            correntCount /= 16;
            int level4Max = correntCount % 16;
            correntCount /= 16;
            int level5Max = correntCount % 16;
            correntCount /= 16;
            int level6Max = correntCount % 16;
            correntCount /= 16;
            int level7Max = correntCount % 16;
            correntCount /= 16;
            int level8Max = correntCount % 16;

            Add(default);
            T lastValue = this[index], newValue;
            ContinerOf16Items<T> level1Continer = internalStorage[level8][level7][level6][level5][level4][level3][level2];
            bool isLastRoundDone = false;
            lock (internalStorage)
            {
                while (level8 <= 16)                                //10,000,000
                {
                    while (level7 < 16)                             //1,000,000
                    {
                        while (level6 < 16)                         //100,000
                        {
                            while (level5 < 16)                     //10,000
                            {
                                while (level4 < 16)                 //1,000
                                {
                                    while (level3 < 16)             //100
                                    {
                                        while (level2 < 16)         //10
                                        {
                                            while (level1 < 16)     //1
                                            {
                                                newValue = level1Continer[level1];
                                                level1Continer[level1] = lastValue;
                                                lastValue = newValue;
                                                if (level8 == level8Max && level7 == level7Max && level6 == level6Max && level5 == level5Max && level4 == level4Max && level3 == level3Max && level2 == level2Max && level1 == level1Max)
                                                {
                                                    isLastRoundDone = true;
                                                    break;
                                                }
                                            }
                                            if (isLastRoundDone)
                                                break;
                                            level1Continer = level1Continer.father[level2];
                                            level1 = 0;
                                            level2++;
                                        }
                                        if (isLastRoundDone)
                                            break;
                                        level1Continer = level1Continer.father.father[level3][0];
                                        level2 = 0;
                                        level3++;
                                    }
                                    if (isLastRoundDone)
                                        break;
                                    level1Continer = level1Continer.father.father.father[level4][0][0];
                                    level3 = 0;
                                    level4++;
                                }
                                if (isLastRoundDone)
                                    break;
                                level1Continer = level1Continer.father.father.father.father[level5][0][0][0];
                                level4 = 0;
                                level5++;
                            }
                            if (isLastRoundDone)
                                break;
                            level1Continer = level1Continer.father.father.father.father.father[level6][0][0][0][0];
                            level5 = 0;
                            level6++;
                        }
                        if (isLastRoundDone)
                            break;
                        level1Continer = level1Continer.father.father.father.father.father.father[level7][0][0][0][0][0];
                        level6 = 0;
                        level7++;
                    }
                    if (isLastRoundDone)
                        break;
                    level1Continer = level1Continer.father.father.father.father.father.father.father[level8][0][0][0][0][0][0];
                    level7 = 0;
                    level8++;
                }
            }
            this[index] = item;
        }
        void IList.Insert(int index, object value)
        {
            if (value is T newValue)
                Insert(index, newValue);
        }
        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index == -1)
                return false;
            RemoveAt(index);
            return true;
        }
        void IList.Remove(object value)
        {
            if (value is T newValue)
                Remove(newValue);
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                this[i] = this[i + 1];
            Count--;
        }           //TODO: Add a lock() to RemoveAt()
        public override string ToString() =>
            string.Format("{0}, count:{1}", base.ToString().Split('`')[0], Count.ToString());
    }
}
