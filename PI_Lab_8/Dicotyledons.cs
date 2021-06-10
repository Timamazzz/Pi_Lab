using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PI_Lab_8
{
    [Serializable]
    abstract public class Dicot
    {
       
       private string _dicotFetus;
       private int _count_flower;

        public string DicotFetus
        {
            get { return _dicotFetus; }
            set { _dicotFetus = value; }

        }

        public int CountFlower
        {
            get { return _count_flower; }
            set { _count_flower = value; }
        }

        public Dicot()
        { }
        
        public Dicot(string dicotFetus, int count_flower)
        {
            _dicotFetus = dicotFetus;
            _count_flower = count_flower;
        }

       public abstract string Info();

        public virtual int met1()
        { 
            return _count_flower;
        }
    }
}
