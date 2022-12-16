using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Random _R = new Random();
        private List<Studio> _list = new List<Studio>();

        public Form1()
        {
            InitializeComponent();
        }
        private InstrumentClass getRandomInstrumentaalClass()
        {
            var v = InstrumentClass.GetValues(typeof(InstrumentClass));
            return (InstrumentClass)v.GetValue(_R.Next(v.Length));
        }

        private void createStudio_Click(object sender, EventArgs e)
        {
            string studioName = textBox1.Text;
            string studioAdress = textBox2.Text;
            int cenaZaTraсk;
            int timeForTraсk;
            int emploeeMonthSalery;
            try
            {
                if (studioName == "" || studioAdress == "")
                    throw new Exception();
                cenaZaTraсk = Convert.ToInt32(textBox4.Text);
                timeForTraсk = Convert.ToInt32(textBox5.Text);
                emploeeMonthSalery = Convert.ToInt32(textBox6.Text);
                _list.Add(new Studio(studioName, studioAdress, cenaZaTraсk, timeForTraсk, emploeeMonthSalery));
                comboBox1.Items.Add(studioName);
            }
            catch
            {
                MessageBox.Show("invalid data");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            int index = comboBox1.SelectedIndex;
            foreach (var item in _list[index]._instrumentList)
            {
                textBox20.Text += item.id.ToString();
                textBox20.Text += "\n";
            }
            foreach (var item in _list[index]._workersMap)
            {
                textBox21.Text += item.Key;
                textBox21.Text += "  ||  ";
            }
            foreach (var item in _list[index]._roomList)
            {
                textBox22.Text += item.id.ToString();
                textBox22.Text += "\n";
            }
            textBox1.Text = _list[index].studioName;
            textBox2.Text = _list[index].studioAdress;
            textBox3.Text = _list[index]._workersMap.Count().ToString();
            textBox4.Text = _list[index].cenaZaTraсk.ToString();
            textBox5.Text = _list[index].timeForTraсk.ToString();
            textBox6.Text = _list[index].emploeeMonthSalery.ToString();
            textBox7.Text = _list[index].allEmploeesMonthSalery.ToString();
            textBox8.Text = _list[index]._instrumentList.Count().ToString();
            textBox9.Text = _list[index]._roomList.Count().ToString();
            textBox10.Text = _list[index].studioMoneyBalance.ToString();
        }

        private void buildNewRoom_Click(object sender, EventArgs e)
        {
            List<Instrument> instrumentList = new List<Instrument>();
            for (int i = 0; i < 10; i++)
            {
                instrumentList.Add(new Instrument(getRandomInstrumentaalClass()));
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }

            int index = comboBox1.SelectedIndex;
            _list[index].buildNewInstrumentalRoom(instrumentList);
            textBox9.Text = _list[index]._roomList.Count().ToString();
            textBox10.Text = _list[index].studioMoneyBalance.ToString();
            textBox22.Clear();
            foreach (var item in _list[index]._roomList)
            {
                textBox22.Text += item.id.ToString();
                textBox22.Text += "\n";
            }
        }

        private void destroyRoom_Click(object sender, EventArgs e)
        {
            string roomID = textBox14.Text;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            try
            {
                if (roomID == "")
                    throw new Exception();
                int index = comboBox1.SelectedIndex;
                _list[index].destroyInstrumentalRoom(textBox14.Text);
                textBox9.Text = _list[index]._roomList.Count().ToString();
                textBox22.Clear();
                foreach (var item in _list[index]._roomList)
                {
                    textBox22.Text += item.id.ToString();
                    textBox22.Text += "\n";
                }
            }
            catch
            {
                MessageBox.Show("invalid data");
            }
            //int index = comboBox1.SelectedIndex;
            //_list[index].destroyInstrumentalRoom(textBox14.Text);
            //textBox9.Text = _list[index]._roomList.Count().ToString();
        }

        private void hireWorker_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            _list[index].hireEmployee();
            textBox3.Text = _list[index]._workersMap.Count().ToString();
            _list[index].allEmploeesMonthSalery += _list[index].emploeeMonthSalery;
            textBox7.Text = _list[index].allEmploeesMonthSalery.ToString();
            textBox21.Clear();
            foreach (var item in _list[index]._workersMap)
            {
                textBox21.Text += item.Key;
                textBox21.Text += "  ||  ";
            }
        }

        private void dismissWorker_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            string idToRemove = textBox13.Text;
            int index = comboBox1.SelectedIndex;
            _list[index].dismissEmployee(idToRemove);
            textBox3.Text = _list[index]._workersMap.Count().ToString();
            textBox21.Clear();
            foreach (var item in _list[index]._workersMap)
            {
                textBox21.Text += item.Key;
                textBox21.Text += "  ||  ";
            }
        }

        private void buyInstrument_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            _list[index].buyNewInstrument();
            textBox8.Text = _list[index]._instrumentList.Count().ToString();
            textBox20.Clear();
            foreach (var item in _list[index]._instrumentList)
            {
                textBox20.Text += item.id.ToString();
                textBox20.Text += "\n";
            }
        }
        private void brokeInstrument_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            _list[index].brokeInstrument();
            textBox8.Text = _list[index]._instrumentList.Count().ToString();
            textBox20.Clear();
            foreach (var item in _list[index]._instrumentList)
            {
                textBox20.Text += item.id.ToString();
                textBox20.Text += "\n";
            }
        }
        private void copyStudio_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            Studio cloned = (Studio)_list[index].Clone();
            _list.Add(cloned);
            comboBox1.Items.Add(cloned.studioName);
        }

        private void addBalance_Click(object sender, EventArgs e)
        {
            string toCheck = textBox11.Text;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            if (toCheck != "")
            {
                int index = comboBox1.SelectedIndex;
                _list[index].addBalance(Convert.ToInt32(textBox11.Text));
                textBox10.Text = _list[index].studioMoneyBalance.ToString();
            }
        }

        private void findInstrument_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            string instrumentID = textBox12.Text;
            if (instrumentID != "")
            {
                int index = comboBox1.SelectedIndex;
                Instrument found = _list[index].findInstrumentByNumber(instrumentID);
                textBox18.Text = found.instrumentClass.ToString();
                textBox19.Text = found.price.ToString();
            }
        }

        private void findWorker_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            string workerID = textBox13.Text;
            if (workerID != "")
            {
                int index = comboBox1.SelectedIndex;
                Worker found = _list[index].findWorkerDataByNumber(workerID);
                textBox15.Text = found.initials.ToString();
                textBox16.Text = found.salery.ToString();
                textBox17.Text = found.traksCount.ToString();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (_list.Count == 0)
            {
                MessageBox.Show("you have no studios to save", "Error", MessageBoxButtons.OK);
                return;
            }
            StringBuilder sb = new StringBuilder();
            foreach (Studio studio in _list)
            {
                string dir = $"C:\\StudioSave\\{studio.studioName}";
                string dir2 = $"C:\\StudioSave\\{studio.studioName}\\data";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    Directory.CreateDirectory(dir2);
                }
                if (!Directory.Exists(dir2))
                    Directory.CreateDirectory(dir2);
                string path = $"C:\\StudioSave\\{studio.studioName}\\{studio.studioName}.txt";
                string pathInstrument = $"C:\\StudioSave\\{studio.studioName}\\data\\Instruments.txt";
                string pathWorker = $"C:\\StudioSave\\{studio.studioName}\\data\\Workers.txt";
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter stream = new StreamWriter(file))
                    {
                        sb.Clear();
                        sb.AppendLine(studio.studioName.ToString());
                        sb.AppendLine(studio.studioMoneyBalance.ToString());
                        sb.AppendLine(studio.studioAdress);
                        sb.AppendLine(studio.cenaZaTraсk.ToString());
                        sb.AppendLine(studio.timeForTraсk.ToString());
                        sb.AppendLine(studio.emploeeMonthSalery.ToString());
                        sb.AppendLine(studio.allEmploeesMonthSalery.ToString());
                        foreach (var item in studio._roomList)
                        {
                            sb.AppendLine(item.id);
                        }
                        stream.WriteLine(sb.ToString());
                    }
                }
                using (FileStream file = new FileStream(pathInstrument, FileMode.Create))
                {
                    using (StreamWriter stream = new StreamWriter(file))
                    {
                        sb.Clear();
                        foreach (var item in studio._instrumentList)
                        {
                            sb.AppendLine(item.id);
                            sb.AppendLine(item.instrumentClass.ToString());
                            sb.AppendLine(item.price.ToString());
                        }
                        stream.WriteLine(sb.ToString());
                    }
                }
                using (FileStream file = new FileStream(pathWorker, FileMode.Create))
                {
                    using (StreamWriter stream = new StreamWriter(file))
                    {
                        sb.Clear();
                        foreach (var item in studio._workersMap)
                        {
                            sb.AppendLine(item.Value.id);
                            sb.AppendLine(item.Value.initials);
                            sb.AppendLine(item.Value.salery.ToString());
                            sb.AppendLine(item.Value.traksCount.ToString());
                        }
                        stream.WriteLine(sb.ToString());
                    }
                }
            }
            MessageBox.Show("Studios saved!", "Error", MessageBoxButtons.OK);
        }

        private void reed_Click(object sender, EventArgs e)
        {
            List<Worker> workers = new List<Worker>();
            List<Instrument> instruments = new List<Instrument>();
            List<Room> rooms = new List<Room>();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            if ((Path.GetFileName(filename) == "Workers.txt") | (Path.GetFileName(filename) == "Instruments.txt"))
            {
                MessageBox.Show("File not correct!", "Error", MessageBoxButtons.OK);
                return;
            }
            string path = Path.GetDirectoryName(filename);
            string pathInstument = Path.Combine(path, "data", "Instruments.txt");
            string pathWorker = Path.Combine(path, "data", "Workers.txt");
            if (!File.Exists(pathInstument) | !File.Exists(pathWorker))
            {
                MessageBox.Show("File not correct!", "Error", MessageBoxButtons.OK);
                return;
            }
            using (StreamReader stream = new StreamReader(pathInstument, Encoding.Default))
            {
                string id;
                while ((id = stream.ReadLine()) != "")
                {
                    try
                    {
                        InstrumentClass iClass = (InstrumentClass)Enum.Parse(typeof(InstrumentClass), stream.ReadLine());
                        int price = Convert.ToInt32(stream.ReadLine());
                        Instrument ins = new Instrument(id, iClass, price);
                        instruments.Add(ins);
                    }
                    catch
                    {
                        MessageBox.Show("File is incorrect!", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            using (StreamReader stream = new StreamReader(pathWorker, Encoding.Default))
            {
                string id;
                while ((id = stream.ReadLine()) != "")
                {
                    try
                    {
                        string initials = stream.ReadLine();
                        int salery = Convert.ToInt32(stream.ReadLine());
                        int traksCount = Convert.ToInt32(stream.ReadLine());
                        workers.Add(new Worker(initials, salery, traksCount, id));
                    }
                    catch
                    {
                        MessageBox.Show("File is empty!", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            using (StreamReader stream = new StreamReader(filename, Encoding.Default))
            {
                string studioName;
                if ((studioName = stream.ReadLine()) != "")
                {
                    //try
                    //{
                        int studioMoneyBalance = Convert.ToInt32(stream.ReadLine());
                        string studioAdress = stream.ReadLine();
                        int cenaZaTraсk = Convert.ToInt32(stream.ReadLine());
                        int timeForTraсk = Convert.ToInt32(stream.ReadLine());
                        int emploeeMonthSalery = Convert.ToInt32(stream.ReadLine());
                        int allEmploeesMonthSalery = Convert.ToInt32(stream.ReadLine());
                        foreach (Studio item in _list)
                        {
                            if (studioName == item.studioName)
                            {
                                MessageBox.Show("Studio is already exist!", "Error", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        try
                        {
                            string id;
                            while ((id = stream.ReadLine()) != "")
                            {
                                rooms.Add(new Room(id));
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Read error!", "Error", MessageBoxButtons.OK);
                        }
                        Studio resultStudio = new Studio(studioName, studioMoneyBalance, studioAdress, cenaZaTraсk, timeForTraсk, emploeeMonthSalery, allEmploeesMonthSalery,rooms,workers,instruments);
                        _list.Add(resultStudio);
                        comboBox1.Items.Add(resultStudio);
                        MessageBox.Show("!!!CONGRATULATIONS!!!\n!Data read!", "Error", MessageBoxButtons.OK);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("File contains incorrect data!", "Error", MessageBoxButtons.OK);
                    //    return;
                    //}
                }
            }
        }
    }
}
