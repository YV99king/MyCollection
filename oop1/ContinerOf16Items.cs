using System;

namespace oop1
{
    public partial class MyColletion<T>
    {
        protected internal class ContinerOf16Items<T1>
        {
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
            public ContinerOf16Items<ContinerOf16Items<T1>> father;
        }
    }
}
