using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_8_9_Polina
{
    [Serializable]
    abstract public class External_memory : Storage_devices
    {
        private int frequency;
        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public External_memory()
        { }

        public External_memory(int c, int f, string m) : base(c)
        {
            frequency = f;
            manufacturer = m;
        }

    }


    [Serializable]
     public class Flash : External_memory, IComparable
    {
        public string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Flash()
        { }

        public Flash(int c, int f, string m, string mod) : base(c, f, m)
        {
            model = mod;
        }

        public override string Info()
        {
            return $"Объем {Capacity}, Частота{Frequency},  Производитель {Manufacturer}, Модель {Model}";
        }

        public override int FSB()
        {
            return Frequency / 23;
        }


        public int CompareTo(object o)
        {
            Flash p = o as Flash;
            if (p != null)
                return this.Capacity.CompareTo(p.Capacity);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }

    [Serializable]
     public class Disk : External_memory, IComparable
    {
        public string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Disk()
        { }

        public Disk(int c, int f, string m, string mod) : base(c, f, m)
        {
            model = mod;
        }

        public override string Info()
        {
            return $"Объем {Capacity}, Частота{Frequency},  Производитель {Manufacturer}, Модель {Model}";
        }

        public override int FSB()
        {
            return Frequency / 23;
        }


        public int CompareTo(object o)
        {
            Disk p = o as Disk;
            if (p != null)
                return this.Capacity.CompareTo(p.Capacity);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }



}
