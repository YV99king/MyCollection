using System;

namespace oop1
{
    [Serializable]
    internal class ContinerOf16Items<T>
    {
        public ContinerOf16Items<ContinerOf16Items<T>> father;
        public T item0;
        public T item1;
        public T item2;
        public T item3;
        public T item4;
        public T item5;
        public T item6;
        public T item7;
        public T item8;
        public T item9;
        public T item10;
        public T item11;
        public T item12;
        public T item13;
        public T item14;
        public T item15;

        public ContinerOf16Items() { }
        public ContinerOf16Items(ContinerOf16Items<ContinerOf16Items<T>> father) =>
            this.father = father;
        public ContinerOf16Items(T item0, T item1, T item2, T item3, T item4, T item5, T item6, T item7,
                                 T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15,
                                 ContinerOf16Items<ContinerOf16Items<T>> father = null)
        {
            this.item0 = item0;
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.item7 = item7;
            this.item8 = item8;
            this.item9 = item9;
            this.item10 = item10;
            this.item11 = item11;
            this.item12 = item12;
            this.item13 = item13;
            this.item14 = item14;
            this.item15 = item15;
            this.father = father;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= 16)
                    throw new IndexOutOfRangeException("Index must be between 0 and 15");
                // get the item using a 4 staged binary search
                int level1 = index % 2;
                index /= 2;
                int level2 = index % 2;
                index /= 2;
                int level3 = index % 2;
                index /= 2;
                int level4 = index % 2;
                if (level4 == 0)
                {
                    if (level3 == 0)
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) return item0;
                            else return item1;
                        }
                        else
                        {
                            if (level1 == 0) return item2;
                            else return item3;
                        }
                    }
                    else
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) return item4;
                            else return item5;
                        }
                        else
                        {
                            if (level1 == 0) return item6;
                            else return item7;
                        }
                    }
                }
                else
                {
                    if (level3 == 0)
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) return item8;
                            else return item9;
                        }
                        else
                        {
                            if (level1 == 0) return item10;
                            else return item11;
                        }
                    }
                    else
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) return item12;
                            else return item13;
                        }
                        else
                        {
                            if (level1 == 0) return item14;
                            else return item15;
                        }
                    }
                }
            }
            set
            {
                if (index < 0 || index >= 16)
                    throw new IndexOutOfRangeException("Index must be between 0 and 15");
                // access the item using a 4 staged binary search
                int level1 = index % 2;
                index /= 2;
                int level2 = index % 2;
                index /= 2;
                int level3 = index % 2;
                index /= 2;
                int level4 = index % 2;
                if (level4 == 0)
                {
                    if (level3 == 0)
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) item0 = value;
                            else item1 = value;
                        }
                        else
                        {
                            if (level1 == 0) item2 = value;
                            else item3 = value;
                        }
                    }
                    else
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) item4 = value;
                            else item5 = value;
                        }
                        else
                        {
                            if (level1 == 0) item6 = value;
                            else item7 = value;
                        }
                    }
                }
                else
                {
                    if (level3 == 0)
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) item8 = value;
                            else item9 = value;
                        }
                        else
                        {
                            if (level1 == 0) item10 = value;
                            else item11 = value;
                        }
                    }
                    else
                    {
                        if (level2 == 0)
                        {
                            if (level1 == 0) item12 = value;
                            else item13 = value;
                        }
                        else
                        {
                            if (level1 == 0) item14 = value;
                            else item15 = value;
                        }
                    }
                }
            }
        }

#if DEBUG
        #region tests
        internal static bool IsTestsPassed => TestIndexer();
        internal static bool TestIndexer()
        {
            ContinerOf16Items<int> testContiner = new(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            for (int i = 0; i < 16; i++)
                if (!(testContiner[i] == i))
                    return false;
            for (int i = 0; i < 16; i++)
                testContiner[i] = 16 - i;
            return testContiner.item0 == 16 &&
                   testContiner.item1 == 15 &&
                   testContiner.item2 == 14 &&
                   testContiner.item3 == 13 &&
                   testContiner.item4 == 12 &&
                   testContiner.item5 == 11 &&
                   testContiner.item6 == 10 &&
                   testContiner.item7 == 9 &&
                   testContiner.item8 == 8 &&
                   testContiner.item9 == 7 &&
                   testContiner.item10 == 6 &&
                   testContiner.item11 == 5 &&
                   testContiner.item12 == 4 &&
                   testContiner.item13 == 3 &&
                   testContiner.item14 == 2 &&
                   testContiner.item15 == 1;
        }
        #endregion
#endif
    }
    internal static class ContinerOf16ItemsExtentions
    {
        public static ContinerOf16Items<T> GetNextLevelContiner<T>(this ContinerOf16Items<ContinerOf16Items<T>> continer, int index)
        {
            if (continer[index] == null)
                continer[index] = new ContinerOf16Items<T>(continer);
            return continer[index];
        }
    }

}
