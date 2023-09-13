using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonRegister
{
    public partial class Form1 : Form, IDataView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Age 
        {
            get
            {
                return Convert.ToUInt16(AgeTextBox?.Text);
            }
            set
            {
                AgeTextBox.Text = value.ToString();
            }
        }
        public string Search 
        {
            get
            {
                return SearchTextBox?.Text;
            }
            set
            {
                OutputTextBox.Text += value.ToString() + "\n";
            }
        }
        public string PersonName
        {
            get
            {
                return NameTextBox?.Text;
            }
            set
            {
                NameTextBox.Text = value.ToString();
            }
        }

        public event EventHandler<EventArgs> SaveData;

        public event EventHandler<EventArgs> LoadData;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveData?.Invoke(this ,EventArgs.Empty);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadData?.Invoke(this ,EventArgs.Empty);
        }
    }
}
