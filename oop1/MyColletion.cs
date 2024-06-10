using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

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
                SplitIndexTo8Levels(index, out int level1, out int level2, out int level3, out int level4, out int level5, out int level6, out int level7, out int level8);
                return internalStorage[level8][level7][level6][level5][level4][level3][level2][level1];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                SplitIndexTo8Levels(index, out int level1, out int level2, out int level3, out int level4, out int level5, out int level6, out int level7, out int level8);
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

        private static void SplitIndexTo8Levels(int index, out int level1, out int level2, out int level3, out int level4, out int level5, out int level6, out int level7, out int level8)
        {
            level1 = index % 16;
            index /= 16;
            level2 = index % 16;
            index /= 16;
            level3 = index % 16;
            index /= 16;
            level4 = index % 16;
            index /= 16;
            level5 = index % 16;
            index /= 16;
            level6 = index % 16;
            index /= 16;
            level7 = index % 16;
            index /= 16;
            level8 = index % 16;
        }

        public void Add(T item)
        {
            if (Count + 1 == int.MaxValue)
                throw new InvalidOperationException("Collection length out of bounds");
            SplitIndexTo8Levels(Count + 1, out int level1, out int level2, out int level3, out int level4, out int level5, out int level6, out int level7, out int level8);
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
            SplitIndexTo8Levels(index + 1, out int level1, out int level2, out int level3, out int level4, out int level5, out int level6, out int level7, out int level8);
            SplitIndexTo8Levels(Count + 1, out int level1Max, out int level2Max, out int level3Max, out int level4Max, out int level5Max, out int level6Max, out int level7Max, out int level8Max);
            T lastValue = this[index], newValue;
            ContinerOf16Items<T> level1Continer = internalStorage[level8][level7][level6][level5][level4][level3][level2];
            bool isLastRoundDone = false;
            Add(default);
            lock (internalStorage)
            {
                while (level8 < 16)
                {
                    while (level7 < 16)
                    {
                        while (level6 < 16)
                        {
                            while (level5 < 16)
                            {
                                while (level4 < 16)
                                {
                                    while (level3 < 16)
                                    {
                                        while (level2 < 16)
                                        {
                                            while (level1 < 16)
                                            {
                                                newValue = level1Continer[level1];
                                                level1Continer[level1] = lastValue;
                                                lastValue = newValue;
                                                if (level1 == level1Max
                                                    && level2 == level2Max
                                                    && level3 == level3Max
                                                    && level4 == level4Max
                                                    && level5 == level5Max
                                                    && level6 == level6Max
                                                    && level7 == level7Max
                                                    && level8 == level8Max)
                                                {
                                                    isLastRoundDone = true;
                                                    break;
                                                }
                                            }
                                            if (isLastRoundDone)
                                                break;
                                            level1 = 0;
                                            level2++;
                                            level1Continer = level1Continer.father[level2];
                                        }
                                        if (isLastRoundDone)
                                            break;
                                        level2 = 0;
                                        level3++;
                                        level1Continer = level1Continer.father.father[level3].item0;
                                    }
                                    if (isLastRoundDone)
                                        break;
                                    level3 = 0;
                                    level4++;
                                    level1Continer = level1Continer.father.father.father[level4].item0.item0;
                                }
                                if (isLastRoundDone)
                                    break;
                                level4 = 0;
                                level5++;
                                level1Continer = level1Continer.father.father.father.father[level5].item0.item0.item0;
                            }
                            if (isLastRoundDone)
                                break;
                            level5 = 0;
                            level6++;
                            level1Continer = level1Continer.father.father.father.father.father[level6].item0.item0.item0.item0;
                        }
                        if (isLastRoundDone)
                            break;
                        level6 = 0;
                        level7++;
                        level1Continer = level1Continer.father.father.father.father.father.father[level7].item0.item0.item0.item0.item0;
                    }
                    if (isLastRoundDone)
                        break;
                    level7 = 0;
                    level8++;
                    level1Continer = level1Continer.father.father.father.father.father.father.father[level8].item0.item0.item0.item0.item0.item0;
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
            SplitIndexTo8Levels(Count - 1, out int level1, out int level2, out int level3, out int level4, out int level5, out int level6, out int level7, out int level8);
            SplitIndexTo8Levels(index, out int level1Min, out int level2Min, out int level3Min, out int level4Min, out int level5Min, out int level6Min, out int level7Min, out int level8Min);
            T lastValue = this[Count], newValue;
            ContinerOf16Items<T> level1Continer = internalStorage[level8][level7][level6][level5][level4][level3][level2];
            bool isLastRoundDone = false;
            lock (internalStorage)
            {
                while (level8 >= 0)
                {
                    while (level7 >= 0)
                    {
                        while (level6 >= 0)
                        {
                            while (level5 >= 0)
                            {
                                while (level4 >= 0)
                                {
                                    while (level3 >= 0)
                                    {
                                        while (level2 >= 0)
                                        {
                                            while (level1 >= 0)
                                            {
                                                newValue = level1Continer[level1];
                                                level1Continer[level1] = lastValue;
                                                lastValue = newValue;
                                                if (level1 == level1Min
                                                    && level2 == level2Min
                                                    && level3 == level3Min
                                                    && level4 == level4Min
                                                    && level5 == level5Min
                                                    && level6 == level6Min
                                                    && level7 == level7Min
                                                    && level8 == level8Min)
                                                {
                                                    isLastRoundDone = true;
                                                    break;
                                                }
                                            }
                                            if (isLastRoundDone)
                                                break;
                                            level1 = 15;
                                            level2--;
                                            level1Continer = level1Continer.father[level2];
                                        }
                                        if (isLastRoundDone)
                                            break;
                                        level2 = 15;
                                        level3--;
                                        level1Continer = level1Continer.father.father[level3].item15;
                                    }
                                    if (isLastRoundDone)
                                        break;
                                    level3 = 15;
                                    level4--;
                                    level1Continer = level1Continer.father.father.father[level4].item15.item15;
                                }
                                if (isLastRoundDone)
                                    break;
                                level4 = 15;
                                level5--;
                                level1Continer = level1Continer.father.father.father.father[level5].item15.item15.item15;
                            }
                            if (isLastRoundDone)
                                break;
                            level5 = 15;
                            level6--;
                            level1Continer = level1Continer.father.father.father.father.father[level6].item15.item15.item15.item15;
                        }
                        if (isLastRoundDone)
                            break;
                        level6 = 15;
                        level7--;
                        level1Continer = level1Continer.father.father.father.father.father.father[level7].item15.item15.item15.item15.item15;
                    }
                    if (isLastRoundDone)
                        break;
                    level7 = 15;
                    level8--;
                    level1Continer = level1Continer.father.father.father.father.father.father.father[level8].item15.item15.item15.item15.item15.item15;
                }
            }
        }
        public override string ToString() =>
            string.Format("{0}, count:{1}", base.ToString().Split('`')[0], Count.ToString());
    }
}
