using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Studio> _list = new List<Studio>();

        public Form1()
        {
            InitializeComponent();
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
                _list.Add(new Studio(studioName,studioAdress,cenaZaTraсk,timeForTraсk,emploeeMonthSalery));
                comboBox1.Items.Add(studioName);
            }
            catch
            {
                MessageBox.Show("invalid data");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            textBox1.Text = _list[index].studioName;
            textBox2.Text = _list[index].studioAdress;
            textBox3.Text = _list[index].workersCount.ToString();
            textBox4.Text = _list[index].cenaZaTraсk.ToString();
            textBox5.Text = _list[index].timeForTraсk.ToString();
            textBox6.Text = _list[index].emploeeMonthSalery.ToString();
            textBox7.Text = _list[index].allEmploeesMonthSalery.ToString();
            textBox8.Text = _list[index].musicalInstrumentCount.ToString();
            textBox9.Text = _list[index].instrumentRoomCount.ToString();
            textBox10.Text = _list[index].studioMoneyBalance.ToString();
        }

        private void buildNewRoom_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) 
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            _list[index].buildNewInstrumentalRoom();
            textBox9.Text = _list[index].instrumentRoomCount.ToString();
            textBox10.Text = _list[index].studioMoneyBalance.ToString();
        }

        private void destroyRoom_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            _list[index].destroyInstrumentalRoom();
            textBox9.Text = _list[index].instrumentRoomCount.ToString();
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
            textBox3.Text = _list[index].workersCount.ToString();
        }

        private void dismissWorker_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("please select studio");
                return;
            }
            int index = comboBox1.SelectedIndex;
            _list[index].dismissEmployee();
            textBox3.Text = _list[index].workersCount.ToString();
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
            textBox8.Text = _list[index].musicalInstrumentCount.ToString();
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
            textBox8.Text = _list[index].musicalInstrumentCount.ToString();
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
    }
}
