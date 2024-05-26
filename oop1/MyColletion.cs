using System.Collections;
using System.Collections.Generic;

namespace oop1
{
    public partial class MyColletion<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
    {
        public T this[int index]
        {
            get
            {
                
            }
            set
            {

            }
        }
        private ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<ContinerOf16Items<T>>>>>>>> internalStorage;
    }
}
