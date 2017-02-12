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
            ICashFactory CashFactory = null;
            switch (CalculateMethod)
            {
                case "Normal":
                    CashFactory = new CashNormalFactory();
                    break;
                case "10% off":
                    CashFactory = new Cash10OffFactory();
                    break;
                case "20% off":
                    CashFactory = new Cash20OffFactory();
                    break;
            }


            double TotalPrice = CashFactory.CreateCashSuper().AcceptCash(UnitPrice * Quantity);
            string FinalResult;
            FinalResult = String.Format("Unit Price = {0}, Quanity = {1}, Calculate Method = {2}, Total Price = {3}"
                , UnitPrice
                , Quantity
                , CalculateMethod
                , TotalPrice);
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
    interface ICashFactory
    {
        CashSuper CreateCashSuper();
    }

    class CashNormalFactory : ICashFactory
    {
        public CashSuper CreateCashSuper()
        {
            return new CashNormal();
        }
    }

    class Cash10OffFactory : ICashFactory
    {
        public CashSuper CreateCashSuper()
        {
            return new CashOFF("0.9");
        }
    }

    class Cash20OffFactory : ICashFactory
    {
        public CashSuper CreateCashSuper()
        {
            return new CashOFF("0.8");
        }
    }
}
