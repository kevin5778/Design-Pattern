using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double UnitPrice = double.Parse(textBox1.Text);
            double Quantity = double.Parse(textBox2.Text);
            string CalculateMethod = comboBox1.SelectedItem.ToString();
            CashSuper cs = CashFactory.CreateCashFactory(CalculateMethod);
            double TotalPrice = cs.AcceptCash(UnitPrice * Quantity);
            string FinalResult;
            FinalResult = String.Format("Unit Price = {0}, Quanity = {1}, Calculate Method = {2}, Total Price = {3}"
                ,UnitPrice
                ,Quantity
                ,CalculateMethod
                ,TotalPrice);
            richTextBox1.AppendText(FinalResult);
            richTextBox1.AppendText("\n");
        }
    }

    abstract class CashSuper
    {
        public abstract double AcceptCash(double money);
    }

    class CashNormal : CashSuper
    {
        public override double AcceptCash(double money)
        {
            return money;
        }
    }

    class CashOFF : CashSuper
    {
        private double Rebate = 0;
        public CashOFF(string RebateString)
        {
            this.Rebate = double.Parse(RebateString);
        }
        public override double AcceptCash(double money)
        {
            return this.Rebate * money;
        }
    }

    class CashFactory
    {
        public static CashSuper CreateCashFactory(string CalculateString)
        {
            CashSuper CashSuperBuffer = null;
            switch (CalculateString)
            {
                case "Normal":
                    CashSuperBuffer = new CashNormal();
                    break;
                case "10% off":
                    CashOFF co = new CashOFF("0.9");
                    CashSuperBuffer = co;
                    break;
                case "20% off":
                    CashOFF co1 = new CashOFF("0.8");
                    CashSuperBuffer = co1;
                    break;
            }
            return CashSuperBuffer;
        }
    }
}
