using System;

namespace oop1
{
    public partial class MyColletion<T>
    {
        [Serializable]
        protected internal class ContinerOf16Items<T1>
        {
            public ContinerOf16Items<ContinerOf16Items<T1>> father;
            public T1 item0;
            public T1 item1;
            public T1 item2;
            public T1 item3;
            public T1 item4;
            public T1 item5;
            public T1 item6;
            public T1 item7;
            public T1 item8;
            public T1 item9;
            public T1 item10;
            public T1 item11;
            public T1 item12;
            public T1 item13;
            public T1 item14;
            public T1 item15;

            public ContinerOf16Items() { }
            public ContinerOf16Items(ContinerOf16Items<ContinerOf16Items<T1>> father) =>
                this.father = father;
            public ContinerOf16Items(T1 item0, T1 item1, T1 item2, T1 item3, T1 item4, T1 item5, T1 item6, T1 item7,
                                     T1 item8, T1 item9, T1 item10, T1 item11, T1 item12, T1 item13, T1 item14, T1 item15,
                                     ContinerOf16Items<ContinerOf16Items<T1>> father = null)
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

            public T1 this[int index]
            {
                get
                {
                    if (index < 0 || index >= 16)
                        throw new IndexOutOfRangeException("Index must be between 0 and 15");
                    // get the item using a 4 staged binary search
                    if (index / 16 == 0)
                    {
                        if (index / 8 == 0)
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) return item0;
                                else return item1;
                            }
                            else
                            {
                                if (index / 2 == 0) return item2;
                                else return item3;
                            }
                        }
                        else
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) return item4;
                                else return item5;
                            }
                            else
                            {
                                if (index / 2 == 0) return item6;
                                else return item7;
                            }
                        }
                    }
                    else
                    {
                        if (index / 8 == 0)
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) return item8;
                                else return item9;
                            }
                            else
                            {
                                if (index / 2 == 0) return item10;
                                else return item11;
                            }
                        }
                        else
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) return item12;
                                else return item13;
                            }
                            else
                            {
                                if (index / 2 == 0) return item14;
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
                    if (index / 16 == 0)
                    {
                        if (index / 8 == 0)
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) item0 = value;
                                else item1 = value;
                            }
                            else
                            {
                                if (index / 2 == 0) item2 = value;
                                else item3 = value;
                            }
                        }
                        else
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) item4 = value;
                                else item5 = value;
                            }
                            else
                            {
                                if (index / 2 == 0) item6 = value;
                                else item7 = value;
                            }
                        }
                    }
                    else
                    {
                        if (index / 8 == 0)
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) item8 = value;
                                else item9 = value;
                            }
                            else
                            {
                                if (index / 2 == 0) item10 = value;
                                else item11 = value;
                            }
                        }
                        else
                        {
                            if (index / 4 == 0)
                            {
                                if (index / 2 == 0) item12 = value;
                                else item13 = value;
                            }
                            else
                            {
                                if (index / 2 == 0) item14 = value;
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
    }
}
