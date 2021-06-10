using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

namespace PI_8_9_Polina
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
            List<Trigger> triggers = new List<Trigger>();
            List<Capacitor> capacitors = new List<Capacitor>();
            List<Flash> flashes = new List<Flash>();
            List<Disk> disks = new List<Disk>();

            public List<Trigger> Triggers { get => triggers; set => triggers = value; }
            public List<Capacitor> Capacitors { get => capacitors; set => capacitors = value; }
            public List<Flash> Flashes { get => flashes; set => flashes = value; }
            public List<Disk> Disks { get => disks; set => disks = value; }
        }

        AllLists lists = new AllLists();

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Запоминающие стройства"); // Добавляю сразу 3 класса от 1 до 3
            node.Nodes.Add("Озу");
            node.Nodes[0].Nodes.Add("Триггеры");
            node.Nodes[0].Nodes.Add("Конденсаторы");
            node.Nodes.Add("Внешняя память");
            node.Nodes[1].Nodes.Add("Флешки");
            node.Nodes[1].Nodes.Add("Диски");

            treeView1.Nodes.Add(node);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lists.Triggers.Count != 0 || lists.Capacitors.Count != 0 || lists.Flashes.Count != 0 || lists.Disks.Count != 0)
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
                {
                    string str = saveFileDialog1.FileName;
                    FileStream fileStream = new FileStream(str, FileMode.Create, FileAccess.ReadWrite);
                    AllLists all = new AllLists();
                    all.Triggers = lists.Triggers;
                    all.Capacitors = lists.Capacitors;
                    all.Flashes = lists.Flashes;
                    all.Disks = lists.Disks;

                    var serializer = new XmlSerializer(typeof(AllLists));
                    serializer.Serialize(fileStream, all);
                    fileStream.Close();
                }
            }
            else MessageBox.Show("Данных нет", "Ошибка");

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lists.Triggers.Clear();
            lists.Capacitors.Clear();
            lists.Flashes.Clear();
            lists.Disks.Clear();
            treeView1.Nodes.Clear();

            TreeNode node = new TreeNode("Запоминающие стройства"); // Добавляю сразу 3 класса от 1 до 3
            node.Nodes.Add("Озу");
            node.Nodes[0].Nodes.Add("Триггеры");
            node.Nodes[0].Nodes.Add("Конденсаторы");
            node.Nodes.Add("Внешняя память");
            node.Nodes[1].Nodes.Add("Флешки");
            node.Nodes[1].Nodes.Add("Диски");

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
                    lists.Triggers = lists.Triggers;
                    foreach (var item in lists.Triggers)
                    {
                        treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Add(item.Model);
                        treeView1.Nodes[0].Nodes[0].Nodes[0].LastNode.Tag = item;
                    }
                    lists.Capacitors = lists.Capacitors;
                    foreach (var item in lists.Capacitors)
                    {
                        treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add(item.Model);
                        treeView1.Nodes[0].Nodes[0].Nodes[1].LastNode.Tag = item;
                    }
                    lists.Flashes = lists.Flashes;
                    foreach (var item in lists.Flashes)
                    {
                        treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add(item.Model);
                        treeView1.Nodes[0].Nodes[1].Nodes[1].LastNode.Tag = item;
                    }
                    lists.Disks = lists.Disks;
                    foreach (var item in lists.Disks)
                    {
                        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add(item.Model);
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

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Триггеры":
                    foreach (var item in lists.Triggers)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            textBox7.Text = item.Capacity.ToString();
                            textBox8.Text = item.Frequency.ToString();
                            textBox9.Text = item.Manufacturer;
                            textBox1.Text = item.Model;

                        }
                    }
                    break;

                case "Конденсаторы":
                    try
                    {
                        foreach (var item in lists.Capacitors)
                        {
                            if (item == treeView1.SelectedNode.Tag)
                            {
                                textBox7.Text = item.Capacity.ToString();
                                textBox8.Text = item.Frequency.ToString();
                                textBox9.Text = item.Manufacturer;
                                textBox1.Text = item.Model;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    break;
                case "Флешки":
                    try
                    {
                        foreach (var item in lists.Flashes)
                        {
                            if (item == treeView1.SelectedNode.Tag)
                            {
                                textBox7.Text = item.Capacity.ToString();
                                textBox8.Text = item.Frequency.ToString();
                                textBox9.Text = item.Manufacturer;
                                textBox1.Text = item.Model;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    break;
                case "Диски":
                    try
                    {
                        foreach (var item in lists.Disks)
                        {
                            if (item == treeView1.SelectedNode.Tag)
                            {
                                textBox7.Text = item.Capacity.ToString();
                                textBox8.Text = item.Frequency.ToString();
                                textBox9.Text = item.Manufacturer;
                                textBox1.Text = item.Model;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    break;
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
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
                        DestinationNode.Parent.Nodes.Insert(index, (TreeNode)NewNode.Clone());
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(0, 0, "", "", 0);
            f2.ShowDialog();

            switch (treeView1.SelectedNode.Text)
            {
                case "Триггеры":
                    try
                    {
                        lists.Triggers.Add(new Trigger(f2.Cap, f2.Fec, f2.Man, f2.Mod));
                        treeView1.SelectedNode.Nodes.Add(f2.Mod);
                        treeView1.SelectedNode.LastNode.Tag = lists.Triggers.Last();
                        treeView1.SelectedNode.LastNode.Name = f2.Mod;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    break;
                case "Конденсаторы":
                    try
                    {
                        lists.Capacitors.Add(new Capacitor(f2.Cap, f2.Fec, f2.Man, f2.Mod));
                        treeView1.SelectedNode.Nodes.Add(f2.Mod);
                        treeView1.SelectedNode.LastNode.Tag = lists.Triggers.Last();
                        treeView1.SelectedNode.LastNode.Name = f2.Mod;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    break;
                case "Флешки":
                    try
                    {

                        lists.Flashes.Add(new Flash(f2.Cap, f2.Fec, f2.Man, f2.Mod));
                        treeView1.SelectedNode.Nodes.Add(f2.Mod);
                        treeView1.SelectedNode.LastNode.Tag = lists.Triggers.Last();
                        treeView1.SelectedNode.LastNode.Name = f2.Mod;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка!");
                    }
                    break;
                case "Диски":
                    try
                    {
                        lists.Disks.Add(new Disk(f2.Cap, f2.Fec, f2.Man, f2.Mod));
                        treeView1.SelectedNode.Nodes.Add(f2.Mod);
                        treeView1.SelectedNode.LastNode.Tag = lists.Triggers.Last();
                        treeView1.SelectedNode.LastNode.Name = f2.Mod;

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
                case "Триггеры":
                    foreach (var item in lists.Triggers)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Triggers.Remove(item);
                        break;
                    }
                    break;
                case "Конденсаторы":
                    foreach (var item in lists.Capacitors)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Capacitors.Remove(item);
                        break;

                    }
                    break;

                case "Флешки":
                    foreach (var item in lists.Flashes)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Flashes.Remove(item);
                        break;

                    }
                    break;

                case "Диски":
                    foreach (var item in lists.Disks)
                    {
                        treeView1.SelectedNode.Remove();
                        lists.Disks.Remove(item);
                        break;

                    }
                    break;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Триггеры":
                    foreach (var item in lists.Triggers)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.Capacity, item.Frequency, item.Manufacturer, item.Model, 1);
                            f2.ShowDialog();

                            item.Capacity = f2.Cap;
                            item.Frequency = f2.Fec;
                            item.Manufacturer = f2.Man;
                            item.Model = f2.Mod;

                            treeView1.SelectedNode.Text = f2.Mod;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Mod;
                        }
                    }

                    break;
                case "Конденсаторы":
                    foreach (var item in lists.Capacitors)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.Capacity, item.Frequency, item.Manufacturer, item.Model, 1);
                            f2.ShowDialog();

                            item.Capacity = f2.Cap;
                            item.Frequency = f2.Fec;
                            item.Manufacturer = f2.Man;
                            item.Model = f2.Mod;

                            treeView1.SelectedNode.Text = f2.Mod;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Mod;
                        }
                    }
                    break;
                case "Флешки":
                    foreach (var item in lists.Flashes)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.Capacity, item.Frequency, item.Manufacturer, item.Model, 1);
                            f2.ShowDialog();

                            item.Capacity = f2.Cap;
                            item.Frequency = f2.Fec;
                            item.Manufacturer = f2.Man;
                            item.Model = f2.Mod;

                            treeView1.SelectedNode.Text = f2.Mod;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Mod;
                        }
                    }
                    break;
                case "Диски":
                    foreach (var item in lists.Disks)
                    {
                        if (item == treeView1.SelectedNode.Tag)
                        {
                            Form2 f2 = new Form2(item.Capacity, item.Frequency, item.Manufacturer, item.Model, 1);
                            f2.ShowDialog();

                            item.Capacity = f2.Cap;
                            item.Frequency = f2.Fec;
                            item.Manufacturer = f2.Man;
                            item.Model = f2.Mod;

                            treeView1.SelectedNode.Text = f2.Mod;
                            treeView1.SelectedNode.Tag = item;
                            treeView1.SelectedNode.Name = f2.Mod;
                        }
                    }
                    break;

            }
        }

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Триггеры":
                    foreach (var item in lists.Triggers)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;
                    }
                    break;
                case "Конденсаторы":
                    foreach (var item in lists.Capacitors)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;

                    }
                    break;

                case "Флешки":
                    foreach (var item in lists.Flashes)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;

                    }
                    break;

                case "Диски":
                    foreach (var item in lists.Disks)
                    {
                        MessageBox.Show(item.Info(), "Инфо");
                        break;

                    }
                    break;
            }

        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Text)
            {
                case "Триггеры":
                    lists.Triggers.Sort();
                    treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Clear();

                    foreach (var item in lists.Triggers)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.Model);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.Model;

                    }

                    break;
                case "Конденсаторы":
                    lists.Capacitors.Sort();
                    treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Clear();

                    foreach (var item in lists.Capacitors)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.Model);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.Model;

                    }
                    break;

                case "Флешки":
                    lists.Flashes.Sort();
                    treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Clear();

                    foreach (var item in lists.Flashes)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.Model);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.Model;

                    }
                    break;

                case "Диски":
                    lists.Disks.Sort();
                    treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes.Clear();

                    foreach (var item in lists.Disks)
                    {

                        treeView1.SelectedNode.Nodes.Add(item.Model);
                        treeView1.SelectedNode.LastNode.Tag = item;
                        treeView1.SelectedNode.LastNode.Name = item.Model;

                    }

                    break;
            }
        }

        private void fSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Parent.Text)
            {
                case "Триггеры":
                    foreach (var item in lists.Triggers)
                    {
                        MessageBox.Show($"FSB = {Convert.ToString(item.FSB())}", "FSB");
                        break;
                    }
                    break;
                case "Конденсаторы":
                    foreach (var item in lists.Capacitors)
                    {
                        MessageBox.Show($"FSB = {Convert.ToString(item.FSB())}", "FSB");
                        break;

                    }
                    break;

                case "Флешки":
                    foreach (var item in lists.Flashes)
                    {
                        MessageBox.Show($"FSB = {Convert.ToString(item.FSB())}", "FSB");
                        break;
                    }
                    break;

                case "Диски":
                    foreach (var item in lists.Disks)
                    {
                        MessageBox.Show($"FSB = {Convert.ToString(item.FSB())}", "FSB");
                        break;
                    }
                    break;
            }
        }
    }
}
