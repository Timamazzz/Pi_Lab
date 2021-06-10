using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Lab_8
{
    [Serializable]
    abstract public class Legum: Dicot
    {
        private string _lroot;
        public string LRoot
        {
            get { return _lroot; }
            set { _lroot = value; }
        }
        public Legum()
        { }

        public Legum(string dicotFetus, string root, int count_flower) : base(dicotFetus, count_flower)
        {
            this.LRoot = root;
        }

       
    }

    [Serializable]
     public class Peas : Legum, IComparable
    {
        private string _peaceVeiw;

        public string PeaceVeiw
        {
            get { return _peaceVeiw; }
            set { _peaceVeiw = value; }
        }

        public Peas()
        { }

        public Peas(string dicotFetus, string root, string peaceVeiw, int count_flower) : base(dicotFetus, root, count_flower)
        {
            this.PeaceVeiw = peaceVeiw;
        }

        static public string TextOut(Peas n)
        {
            string s = $"Вид плодов : {n.DicotFetus}, Тип корневой системы: {n.LRoot}, Название: {n.PeaceVeiw}";
            return s;
        }

        public override string Info()
        {
            return $"Вид плодов : {DicotFetus}, Тип корневой системы: {LRoot}, Название: {PeaceVeiw}, Количество цветков: {CountFlower}";
        }

        public override int met1()
        {
            return CountFlower * 30;
        }

        public int CompareTo(object o)
        {
            Peas p = o as Peas;
            if (p != null)
                return this.CountFlower.CompareTo(p.CountFlower);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }

    [Serializable]
     public class Clover : Legum, IComparable
    {
        private string _cloverView;

        public string CloverView
        {
            get { return _cloverView; }
            set { _cloverView = value; }
        }

        public Clover()
        { }

        public Clover(string dicotFetus, string root, string cloverView, int count_flower) : base(dicotFetus, root, count_flower)
        {
            this.CloverView = cloverView;
        }

        static public string TextOut(Clover n)
        {
            string s = $"Вид плодов : {n.DicotFetus}, Тип корневой системы: {n.LRoot}, Название: {n.CloverView}";
            return s;
        }

        public override string Info()
        {
            return $"Вид плодов : {DicotFetus}, Тип корневой системы: {LRoot}, Название: {CloverView}, Количество цветков: {CountFlower}";
        }

        public override int met1()
        {
            return CountFlower * 40;
        }

        public int CompareTo(object o)
        {
            Clover p = o as Clover;
            if (p != null)
                return this.CountFlower.CompareTo(p.CountFlower);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
