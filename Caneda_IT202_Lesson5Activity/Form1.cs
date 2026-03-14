using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caneda_IT202_Lesson5Activity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void grossIncomeBtn_Click(object sender, EventArgs e)
        {
            decimal income1 = 0, income2 = 0, income3 = 0;
            bool isValid = true;

            if (decimal.TryParse(rate_hour_1.Text, out decimal rate) &&
                (decimal.TryParse(no_of_hours_1.Text, out decimal hours))) 
            {
                income1 = rate * hours;
                income_cutOff_1.Text = income1.ToString("N2");
            }
            if (decimal.TryParse(rate_hour_2.Text, out decimal rate2) &&
                (decimal.TryParse(no_of_hours_2.Text, out decimal hours2)))
            {
                income2 = rate2 * hours2;
                income_cutOff_2.Text = income2.ToString("N2");
            }
            if (decimal.TryParse(rate_hour_3.Text, out decimal rate3) &&
                (decimal.TryParse(no_of_hours_3.Text, out decimal hours3)))
            {
                income3 = rate3 * hours3;
                income_cutOff_3.Text = income3.ToString("N2");
            }

            if (isValid)
            { 
                decimal totalCalculatedGross = income1 + income2 + income3;
                grossIncome_txt.Text = totalCalculatedGross.ToString("N2");
            }

            else
            {
                MessageBox.Show("Please enter valid numeric values for rate and hours.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Tax Contribution
            double gInc = Convert.ToDouble(grossIncome_txt.Text);

            //SSS Contribution Calculation
            double sss_contribution = gInc * .11;

            //Phil-Health Contribution Calculation

            double philhealth_contribution = 0;
            double phRate = 0.05;
            double phCeiling = 100000.00;
            double phFloor = 10000.00;

            if (gInc == phFloor)
            {
                philhealth_contribution = phFloor * phRate;
            }
            else if (gInc >= phCeiling)
            {
                philhealth_contribution = phCeiling * phRate;
            }
            else if (gInc > phFloor && gInc < phCeiling)
            {
                philhealth_contribution = Convert.ToDouble(grossIncome_txt.Text) * phRate;
            }

            //Pag-IBIG Contribution Calculation
            double pagibig_contribution = (gInc <= 1500.00) ? gInc * 0.01 : (gInc > 1500.00 && gInc < 5000.00) ? gInc * 0.02 : 2000.00;

            //Income Tax Contribution Calculation
            double tax = 0;
            
            if (gInc <= 10000.00)
            {
                tax = 0;
            }
            else if (gInc > 10000.00 && gInc <= 30000.00)
            {
                tax = Convert.ToDouble(grossIncome_txt.Text) * 0.10;
            }
            else if (gInc > 30000.00 && gInc <= 70000.00)
            {
                tax = Convert.ToDouble(grossIncome_txt.Text) * 0.15;
            }
            else if (gInc > 70000.00 && gInc <= 140000.00)
            {
                tax = Convert.ToDouble(grossIncome_txt.Text) * 0.20;
            }
            else if (gInc > 140000.00 && gInc <= 250000.00)
            {
                tax = Convert.ToDouble(grossIncome_txt.Text) * 0.25;
            }
            else if (gInc > 250000.00 && gInc <= 500000.00)
            {
                tax = Convert.ToDouble(grossIncome_txt.Text) * 0.30;
            }
            else if (gInc > 500000.00)
            {
                tax = Convert.ToDouble(grossIncome_txt.Text) * 0.35;
            }
             sssContribution.Text = sss_contribution.ToString("N2");
             philhealthContribution.Text = philhealth_contribution.ToString("N2");
             pagibigContribution.Text = pagibig_contribution.ToString("N2");
             incomeTaxContribution.Text = tax.ToString("N2");

            double totalDeductions = sss_contribution + philhealth_contribution + pagibig_contribution + tax;
            totalDeductions_txt.Text = totalDeductions.ToString("N2");
        }

        private void netIncomeBtn_Click(object sender, EventArgs e)
        {
            decimal net_income_1 = 0;

            if (decimal.TryParse(grossIncome_txt.Text, out decimal grossIncome) &&
                decimal.TryParse(totalDeductions_txt.Text, out decimal totalDeductions))
            {
                net_income_1 = grossIncome - totalDeductions;
                netIncome_txt.Text = net_income_1.ToString("N2");
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for gross income and total deductions.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
            MessageBox.Show("All fields have been saved.", "Clear Fields");
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
            MessageBox.Show("All fields have been cleared.", "Clear Fields");
        }

        private void employeeNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void deptNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void rate_hour_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void no_of_hours_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void income_cutOff_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rate_hour_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void no_of_hours_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void income_cutOff_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rate_hour_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void no_of_hours_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void income_cutOff_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void grossIncome_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void netIncome_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void middleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void surName_TextChanged(object sender, EventArgs e)
        {

        }

        private void civilStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void qualifiedDependentsStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void paydate_TextChanged(object sender, EventArgs e)
        {

        }

        private void employeeStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void designation_TextChanged(object sender, EventArgs e)
        {

        }

        private void sssContribution_TextChanged(object sender, EventArgs e)
        {

        }

        private void philhealthContribution_TextChanged(object sender, EventArgs e)
        {

        }

        private void pagibigContribution_TextChanged(object sender, EventArgs e)
        {

        }

        private void incomeTaxContribution_TextChanged(object sender, EventArgs e)
        {

        }

        private void sssLoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void pagibigLoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void facSavingsDeposit_TextChanged(object sender, EventArgs e)
        {

        }

        private void facSavingsLoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void salaryLoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void otherLoans_TextChanged(object sender, EventArgs e)
        {

        }

        private void totalDeductions_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
