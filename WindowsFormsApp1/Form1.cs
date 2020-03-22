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
        private string labelTxt = "";
        private string previousCharacter;
        double currentResult = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void setTxtBoxText(string character)
        {
            this.calculatorTxtBox.Text = character;
        }
        private void appendLabelText(string character)
        {
            this.calculatorTxtBox.AppendText(character);
        }
        private bool isPreviousCharacterAnOperator()
        {
            return previousCharacter.Contains("+") ||
                previousCharacter.Contains("-") ||
                previousCharacter.Contains("*") ||
                previousCharacter.Contains("/");

        }
        private void add()
        {
            currentResult = currentResult + Double.Parse(calculatorTxtBox.Text);
        }
        private void multiply()
        {
            currentResult = currentResult * Double.Parse(calculatorTxtBox.Text);
        }
        private void divide()
        {
            currentResult =  currentResult / Double.Parse(calculatorTxtBox.Text) ;
        }
        private void subtract()
        {
            currentResult =currentResult - Double.Parse(calculatorTxtBox.Text)  ;
        }
        private void buttonClick(object sender,EventArgs e)
        {   
            Button clickedButton = (Button)sender;

            switch (clickedButton.Text)
            {
                case "C":
                    this.calculatorLabel.Text = "0";
                    setTxtBoxText("0");
                    this.currentResult = 0;
                    break;
                case "CE":
                    this.labelTxt = this.labelTxt.Remove(0, this.labelTxt.Length - 1);
                    setTxtBoxText("0");
                    break;
                case ",":
                    if (!this.labelTxt.Contains(","))
                    {

                    }
                    break;
                case "+":
                    if (!(labelTxt.Length == 0) &&  !isPreviousCharacterAnOperator())
                    {
                        add();
                        setTxtBoxText(currentResult.ToString());
                    }

                    break;
                case "/":
                    if (!(labelTxt.Length == 0) && !isPreviousCharacterAnOperator())
                    {
                        divide();
                        setTxtBoxText(currentResult.ToString());
                    }
                    break;
                case "*":
                    if (!(labelTxt.Length == 0) && !isPreviousCharacterAnOperator())
                    {
                        multiply();
                        setTxtBoxText(currentResult.ToString());
                    }
                    break;
                case "-":
                    if (!(labelTxt.Length == 0) && !isPreviousCharacterAnOperator())
                    {
                        subtract();
                        setTxtBoxText(currentResult.ToString());
                    }
                    break;
                case "=":
                    appendLabelText(labelTxt);
                    setTxtBoxText(currentResult.ToString());
                    break;

                case "0":
                    break;
                default:
                    this.previousCharacter = clickedButton.Text;
                    labelTxt += clickedButton.Text;
                    setTxtBoxText(clickedButton.Text);
                    break;

            }
        }
    }
}
