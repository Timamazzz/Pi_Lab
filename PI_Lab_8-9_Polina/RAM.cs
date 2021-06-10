using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_8_9_Polina
{
    [Serializable]
    abstract public class RAM : Storage_devices
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

        public RAM()
        { }

        public RAM(int c,  int f, string m) : base(c)
        {
            frequency = f;
            manufacturer = m;
        }
    }

    [Serializable]
     public class Trigger : RAM, IComparable
    {
        public string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Trigger()
        { }

        public Trigger(int c, int f, string m, string mod) : base(c, f, m)
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
            Trigger p = o as Trigger;
            if (p != null)
                return this.Capacity.CompareTo(p.Capacity);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }

    [Serializable]
     public class Capacitor : RAM, IComparable
    {
        public string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Capacitor()
        { }

        public Capacitor(int c, int f, string m, string mod) : base(c, f, m)
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
            Capacitor p = o as Capacitor;
            if (p != null)
                return this.Capacity.CompareTo(p.Capacity);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }

}
