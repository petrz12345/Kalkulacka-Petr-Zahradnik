using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulacka_Petr_Zahradnik {
    public partial class Form1 : Form {
        //Proměnné operantů
        double mdblNum1, mdblNuml2, mdblOut;
        bool mblOperationSelected = false;
        enum enOperation {none, add, substract, multiply, divide};
        enOperation menCurrentOperation;
        public Form1() {
            InitializeComponent();
            //smazat proměnné
            ClrAll();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        //napiš stisknuté tlačítko na display
        private void button1_Click(object sender, EventArgs e) {
            Button MyButton;
            MyButton = (Button)sender;
            //Je na displayji nula?
            if (txtDisplay.Text == "0") {
                txtDisplay.Text = "";
            }
            //Je vybraná operace?
            if(mblOperationSelected == true) {
                txtDisplay.Text = "";
                mblOperationSelected = false;
            }

            txtDisplay.Text = txtDisplay.Text +MyButton.Text;
        }

        //Tlačítko smazat
        private void buttonCLR_Click(object sender, EventArgs e) {
            ClrAll();
        }

        private void ClrAll() {
            txtDisplay.Text = "0";
            mdblNum1 = mdblNuml2 = mdblOut = 0;
            mblOperationSelected = false;
            menCurrentOperation = enOperation.none;
        }

        //Handlování operací
        private void buttonOperations_Click(object sender, EventArgs e) {
            Button MyButton = (Button)sender;
            DisplayToVariable();
            mblOperationSelected = true;
            switch(MyButton.Text) {
                case "+": menCurrentOperation = enOperation.add; break;
                case "-": menCurrentOperation = enOperation.substract; break;
                case "*": menCurrentOperation = enOperation.multiply; break;
                case "/": menCurrentOperation = enOperation.divide; break;

            }
        }




        //posunout a yapsat čísla
        private void DisplayToVariable() {
            try {
                mdblNuml2 = mdblNum1;
                mdblNum1 = Convert.ToDouble(txtDisplay.Text);
            } catch(Exception e) {
                MessageBox.Show("NaN      Jejda, něco se pokazilo");
                ClrAll();
            }
        }
    }
}
