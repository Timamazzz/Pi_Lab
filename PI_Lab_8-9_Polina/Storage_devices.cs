using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_8_9_Polina
{
    [Serializable]
    abstract public class Storage_devices
    {
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public Storage_devices()
        { }

        public Storage_devices(int c)
        {
            capacity = c;
        }

        public abstract string Info();

        public virtual int FSB()
        {
            return 0;
        }
    }
}
