using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Lab_8
{
    [Serializable]
    abstract public class Compound : Dicot
    {
        private string _croot;
        public string CRoot
        {
            get { return _croot; }
            set { _croot = value; }
        }
        public Compound()
        { }

        public Compound(string dicotFetus, string root, int count_flower) : base(dicotFetus, count_flower)
        {
            this.CRoot = root;
        }
    }


    [Serializable]
     public class Astra : Compound, IComparable
    {
        private string _astraVeiw;

        public string AstraVeiw
        {
            get { return _astraVeiw; }
            set { _astraVeiw = value; }
        }

        public Astra()
        { }

        public Astra(string dicotFetus, string root, string astraVeiw, int count_flower) : base(dicotFetus, root, count_flower)
        {
            this.AstraVeiw = astraVeiw;
        }

        static public string TextOut(Astra n)
        {
            string s = $"Вид плодов : {n.DicotFetus}, Тип корневой системы: {n.CRoot}, Название: {n.AstraVeiw}";
            return s;
        }

        public override string Info()
        {
            return $"Вид плодов : {DicotFetus}, Тип корневой системы: {CRoot}, Название: {AstraVeiw}, Количество цветков: {CountFlower}";
        }

        public override int met1()
        {
            return CountFlower * 10;
        }

        public int CompareTo(object o)
        {
            Astra p = o as Astra;
            if (p != null)
                return this.CountFlower.CompareTo(p.CountFlower);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }


    [Serializable]
     public class Chamomile : Compound, IComparable
    {
        private string _chamomileView;

        public string ChamomileView
        {
            get { return _chamomileView; }
            set { _chamomileView = value; }
        }

        public Chamomile()
        { }

        public Chamomile(string dicotFetus, string root, string chamomileView, int count_flower) : base(dicotFetus, root, count_flower)
        {
            this.ChamomileView = chamomileView;
        }

        static public string TextOut(Chamomile n)
        {
            string s = $"Вид плодов : {n.DicotFetus}, Тип корневой системы: {n.CRoot}, Название: {n.ChamomileView}";
            return s;
        }

        public override string Info()
        {
            return $"Вид плодов : {DicotFetus}, Тип корневой системы: {CRoot}, Название: {ChamomileView}, Количество цветков: {CountFlower}";
        }

        public override int met1()
        {
            return CountFlower * 20;
        }

        public int CompareTo(object o)
        {
            Chamomile p = o as Chamomile;
            if (p != null)
                return this.CountFlower.CompareTo(p.CountFlower);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}