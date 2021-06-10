using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

namespace PI_Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            treeView1.AllowDrop = true;
            this.ResumeLayout(false);
            this.Controls.Add(treeView1);
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox1.ReadOnly = true;
           

            treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
        }

    
        public class AllLists
        {
            List<Peas> peaces = new List<Peas>();
            List<Clover> clovers = new List<Clover>();
            List<Astra> astras = new List<Astra>();
            List<Chamomile> chamomiles = new List<Chamomile>();
            public List<Peas> Peaces { get => peaces; set => peaces = value; }
            public List<Clover> Clovers { get => clovers; set => clovers = value; }
            public List<Astra> Astras { get => astras; set => astras = value; }
            public List<Chamomile> Chamomiles { get => chamomiles; set => chamomiles = value; }
        }

        bool flag = false;
        private void Save_Win()
        {
            if (flag)
            {
                DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Внимание!",
               MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click(сохранитьToolStripMenuItem, null);
                }
            }
        }

        AllLists lists = new AllLists();

        private void Form1_Load(object sender, EventArgs e)
        {

            TreeNode node = new TreeNode("Двудольные растения"); // Добавляю сразу 3 класса от 1 до 3
            node.Nodes.Add("Бобовые");
            node.Nodes[0].Nodes.Add("Горох");
            node.Nodes[0].Nodes.Add("Клевер");
            node.Nodes.Add("Двуцветные");
            node.Nodes[1].Nodes.Add("Астра");
            node.Nodes[1].Nodes.Add("Ромашка");

            treeView1.Nodes.Add(node);

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lists.Peaces.Count != 0 || lists.Clovers.Count != 0 || lists.Astras.Count != 0 || lists.Chamomiles.Count != 0)
            {
                flag = false;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
                {
                    string str = saveFileDialog1.FileName;
                    FileStream fileStream = new FileStream(str, FileMode.Create, FileAccess.ReadWrite);
                    AllLists all = new AllLists();
                    all.Peaces = lists.Peaces;
                    all.Clovers = lists.Clovers;
                    all.Astras = lists.Astras;
                    all.Chamomiles = lists.Chamomiles;

                    var serializer = new XmlSerializer(typeof(AllLists));
                    serializer.Serialize(fileStream, all);
                    fileStream.Close();
                }
            }
            else MessageBox.Show("Данных нет", "Ошибка");

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Save_Win();
            lists.Peaces.Clear();
            lists.Clovers.Clear();
            lists.Astras.Clear();
            lists.Chamomiles.Clear();
            treeView1.Nodes.Clear();

            TreeNode node = new TreeNode("Двудольные растения"); // Добавляю сразу 3 класса от 1 до 3
            node.Nodes.Add("Бобовые");
            node.Nodes[0].Nodes.Add("Горох");
            node.Nodes[0].Nodes.Add("Клевер");
            node.Nodes.Add("Двуцветные");
            node.Nodes[1].Nodes.Add("Астра");
            node.Nodes[1].Nodes.Add("Ромашка");

            treeView1.Nodes.Add(node);

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != "")
            {
                string str = openFileDialog1.FileName;
                FileStream fileStream = new FileStream(str, FileMode.Open, FileAccess.Read);
                XmlReader xmlReader = new XmlTextReader(fileStream);
                XmlSerializer deserializer = new XmlSerializer(typeof(AllLists));
                if (deserializer.CanDeserialize(xmlReader))
                {
                  
                    AllLists lists = (AllLists)deserializer.Deserialize(xmlReader);
                    lists.Peaces = lists.Peaces;
                    foreach (var item in lists.Peaces)
                    {
                        treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Add(item.PeaceVeiw);
                        treeView1.Nodes[0].Nodes[0].Nodes[0].LastNode.Tag = item;
                    }
                    lists.Clovers = lists.Clovers;
                    foreach (var item in lists.Clovers)
                    {
                        treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add(item.CloverView);
                        treeView1.Nodes[0].Nodes[0].Nodes[1].LastNode.Tag = item;
                    }
                    lists.Astras = lists.Astras;
                    foreach (var item in lists.Astras)
                    {
                        treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add(item.AstraVeiw);
                        treeView1.Nodes[0].Nodes[1].Nodes[1].LastNode.Tag = item;
                    }
                    lists.Chamomiles = lists.Chamomiles;
                    foreach (var item in lists.Chamomiles)
                    {
                        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add(item.ChamomileView);
                        treeView1.Nodes[0].Nodes[1].Nodes[0].LastNode.Tag = item;
                    }

                    fileStream.Close();
                }
                else MessageBox.Show("Неверный формат файла", "Ошибка");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
                this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            switch (treeView1.SelectedNode.Text)
            {
                case "Горох":
                    pictureBox1.Image = Image.FromFile("Peac.jpg");
                    break;
                case "Клевер":
                    pictureBox1.Image = Image.FromFile("Clover.png");
                    break;
                case "Астра":
                    pictureBox1.Image = Image.FromFile("astra.jpg");
                    break;
                case "Ромашка":
                    pictureBox1.Image = Image.FromFile("Cham.jpg");
                    break;
            }
            

        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Горох":
                    foreach (var item in lists.Peaces)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            
                            textBox7.Text = item.DicotFetus;
                            textBox8.Text = item.LRoot;
                            textBox9.Text = item.PeaceVeiw;
                            textBox1.Text = Convert.ToString(item.CountFlower);

                        }
                    }
                    pictureBox1.Image = Image.FromFile("Peac.jpg");
                    break;

                case "Клевер":
                    try
                    {
                        foreach (var item in lists.Clovers)
                        {
                            if (item == treeView1.SelectedNode.Tag)
                            {
                               
                                textBox7.Text = item.DicotFetus;
                                textBox8.Text = item.LRoot;
                                textBox9.Text = item.CloverView;
                                textBox1.Text = Convert.ToString(item.CountFlower);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    pictureBox1.Image = Image.FromFile("Clover.png");
                    break;
                case "Астра":
                    try
                    {
                        foreach (var item in lists.Astras)
                        {
                            if (item == treeView1.SelectedNode.Tag)
                            {
                               
                                textBox7.Text = item.DicotFetus;
                                textBox8.Text = item.CRoot;
                                textBox9.Text = item.AstraVeiw;
                                textBox1.Text = Convert.ToString(item.CountFlower);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    pictureBox1.Image = Image.FromFile("astra.jpg");
                    break;
                case "Ромашка":
                    try
                    {
                        foreach (var item in lists.Chamomiles)
                        {
                            if (item == treeView1.SelectedNode.Tag)
                            {
                                
                                textBox7.Text = item.DicotFetus;
                                textBox8.Text = item.CRoot;
                                textBox9.Text = item.ChamomileView;
                                textBox1.Text = Convert.ToString(item.CountFlower);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    pictureBox1.Image = Image.FromFile("Cham.jpg");
                    break;
            }
        }


        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            flag = true;
            TreeNode NewNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                int index = DestinationNode.Index;
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (DestinationNode.Level != 0 && NewNode.Level == 3 &&
               DestinationNode.Level != 1)
                {
                    if (DestinationNode.Level == 3)
                    {
                        DestinationNode.Parent.Nodes.Insert(index,(TreeNode)NewNode.Clone());
                    }
                    else if (DestinationNode.Level == 2)
                    {
                        DestinationNode.Nodes.Insert(index, (TreeNode)NewNode.Clone());
                    }
                    NewNode.Remove();
                }
            }
        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("","","",0);
            f2.ShowDialog();

                switch (treeView1.SelectedNode.Text)
                {
                    case "Горох":
                        try
                        {
                            lists.Peaces.Add(new Peas(f2.Fet, f2.Root, f2.Name_0, f2.CF));
                            treeView1.SelectedNode.Nodes.Add(f2.Name_0);
                            treeView1.SelectedNode.LastNode.Tag = lists.Peaces.Last();
                            treeView1.SelectedNode.LastNode.Name = f2.Name_0;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Введены неверные данные!", "Ошибка!");
                        }
                        break;
                    case "Клевер":
                        try
                        {

                            lists.Clovers.Add(new Clover(f2.Fet, f2.Root, f2.Name_0, f2.CF));
                            treeView1.SelectedNode.Nodes.Add(f2.Name_0);
                            treeView1.SelectedNode.LastNode.Tag = lists.Clovers.Last();
                            treeView1.SelectedNode.LastNode.Name = f2.Name_0;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Введены неверные данные!", "Ошибка!");
                        }
                        break;
                    case "Астра":
                        try
                        {

                            lists.Astras.Add(new Astra(f2.Fet, f2.Root, f2.Name_0, f2.CF));
                            treeView1.SelectedNode.Nodes.Add(f2.Name_0);
                            treeView1.SelectedNode.LastNode.Tag = lists.Astras.Last();
                            treeView1.SelectedNode.LastNode.Name = f2.Name_0;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Введены неверные данные!", "Ошибка!");
                        }
                        break;
                    case "Ромашка":
                        try
                        {

                            lists.Chamomiles.Add(new Chamomile(f2.Fet, f2.Root, f2.Name_0, f2.CF));
                            treeView1.SelectedNode.Nodes.Add(f2.Name_0);
                            treeView1.SelectedNode.LastNode.Tag = lists.Chamomiles.Last();
                            treeView1.SelectedNode.LastNode.Name = f2.Name_0;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Введены неверные данные!", "Ошибка!");
                        }
                        break;

                }

          
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Горох":
                    foreach (var item in lists.Peaces)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Peaces.Remove(item);
                        break;
                    }
                    break;
                case "Клевер":
                    foreach (var item in lists.Clovers)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Clovers.Remove(item);
                        break;

                    }
                    break;

                case "Астра":
                    foreach (var item in lists.Astras)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Astras.Remove(item);
                        break;

                    }
                    break;

                case "Ромашка":
                    foreach (var item in lists.Chamomiles)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Chamomiles.Remove(item);
                        break;

                    }
                    break;



            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Горох":
                    foreach (var item in lists.Peaces)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.DicotFetus, item.LRoot, item.PeaceVeiw, item.CountFlower);
                            f2.ShowDialog();

                            item.DicotFetus = f2.Fet;
                            item.LRoot = f2.Root;
                            item.PeaceVeiw = f2.Name_0;
                            item.CountFlower = f2.CF;

                            treeView1.SelectedNode.Text = f2.Name_0;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Name_0;
                        }
                    }
                   
                    break;
                case "Клевер":
                    foreach (var item in lists.Clovers)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.DicotFetus, item.LRoot, item.CloverView, item.CountFlower);
                            f2.ShowDialog();

                            item.DicotFetus = f2.Fet;
                            item.LRoot = f2.Root;
                            item.CloverView = f2.Name_0;
                            item.CountFlower = f2.CF;

                            treeView1.SelectedNode.Text = f2.Name_0;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Name_0;
                        }
                    }
                    break;
                case "Астра":
                    foreach (var item in lists.Astras)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.DicotFetus, item.CRoot, item.AstraVeiw, item.CountFlower);
                            f2.ShowDialog();

                            item.DicotFetus = f2.Fet;
                            item.CRoot = f2.Root;
                            item.AstraVeiw = f2.Name_0;
                            item.CountFlower = f2.CF;

                            treeView1.SelectedNode.Text = f2.Name_0;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Name_0;
                        }
                    }
                    break;
                case "Ромашка":
                    foreach (var item in lists.Chamomiles)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.DicotFetus, item.CRoot, item.ChamomileView, item.CountFlower);
                            f2.ShowDialog();

                            item.DicotFetus = f2.Fet;
                            item.CRoot = f2.Root;
                            item.ChamomileView = f2.Name_0;
                            item.CountFlower = f2.CF;

                            treeView1.SelectedNode.Text = f2.Name_0;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Name_0;
                        }
                    }
                    break;

            }
        }

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Горох":
                    foreach (var item in lists.Peaces)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;
                    }
                    break;
                case "Клевер":
                    foreach (var item in lists.Clovers)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;

                    }
                    break;

                case "Астра":
                    foreach (var item in lists.Astras)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;

                    }
                    break;

                case "Ромашка":
                    foreach (var item in lists.Chamomiles)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;

                    }
                    break;
            }

        }

        private void метод1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Горох":
                    foreach (var item in lists.Peaces)
                    {
                        MessageBox.Show(Convert.ToString(item.met1()), "Метод1");
                        break;
                    }
                    break;
                case "Клевер":
                    foreach (var item in lists.Clovers)
                    {
                        MessageBox.Show(Convert.ToString(item.met1()), "Метод1");
                        break;

                    }
                    break;

                case "Астра":
                    foreach (var item in lists.Astras)
                    {
                        MessageBox.Show(Convert.ToString(item.met1()), "Метод1");
                        break;
                    }
                    break;

                case "Ромашка":
                    foreach (var item in lists.Chamomiles)
                    {
                        MessageBox.Show(Convert.ToString(item.met1()), "Метод1");
                        break;
                    }
                    break;
            }
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Text)
            {
                case "Горох":
                    lists.Peaces.Sort();
                    treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Clear();

                    foreach (var item in lists.Peaces)
                    {
                        
                        treeView1.SelectedNode.Nodes.Add(item.PeaceVeiw);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.PeaceVeiw;

                    }

                    break;
                case "Клевер":
                    lists.Clovers.Sort();
                    treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Clear();

                    foreach (var item in lists.Clovers)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.CloverView);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.CloverView;

                    }
                    break;

                case "Астра":
                    lists.Astras.Sort();
                    treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Clear();

                    foreach (var item in lists.Astras)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.AstraVeiw);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.AstraVeiw;

                    }
                    break;

                case "Ромашка":
                    lists.Chamomiles.Sort();
                    treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes.Clear();

                    foreach (var item in lists.Chamomiles)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.ChamomileView);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.ChamomileView;

                    }

                    break;
            }
        }
    }
   
}

