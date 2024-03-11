using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C968.Models;

namespace C968
{
    public partial class AddPart : Form
    {
        public Part NewPart { get; set; }
        public AddPart()
        {
            InitializeComponent();

            maxTextBox.KeyPress += NumberOnly;
            minTextBox.KeyPress += NumberOnly;
            priceTextBox.KeyPress += NumberWithDecimal;

            radioInhouse.CheckedChanged += radioInhouse_CheckedChanged;
            radioOutsourced.CheckedChanged += radioOutsourced_CheckedChanged;

            cancelButton.Click += btnClose_Click;

            idTextBox.Enabled = false;
        }

        private void radioInhouse_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioInhouse.Checked) return;
            label8.Text = "Machine ID";
            this.button1.Click -= addButton_Outsource_Click;
            this.button1.Click += new EventHandler(addButton_Inhouse_Click);
        }

        private void radioOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioOutsourced.Checked) return;
            label8.Text = "Company Name";
            this.button1.Click -= addButton_Inhouse_Click;
            this.button1.Click += new EventHandler(addButton_Outsource_Click);
        }


        private bool ValidateMinMax()
        {
            bool minValid = int.TryParse(minTextBox.Text, out int min);
            bool maxValid = int.TryParse(maxTextBox.Text, out int max);
            var inventoryValid = int.TryParse(inventoryTextBox.Text, out int inventory);

            if (!minValid || !maxValid || !inventoryValid)
            {
                MessageBox.Show("Please enter valid numbers for Min and Max.");
                return false;
            }

            if (min > max)
            {
                MessageBox.Show("Minimum value cannot be greater than maximum value.");
                return false;
            }

            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory must be between the minimum and maximum values.");
                return false;
            }

            return true;
        }

        private void addButton_Inhouse_Click(object sender, EventArgs e)
        {
            if (!ValidateMinMax()) return; // Perform validation before proceeding

            NewPart = new InhousePart
            {
                PartID = Form1.GeneratePartId(),
                Name = nameTextBox.Text,
                Price = Convert.ToDecimal(priceTextBox.Text),
                InStock = Convert.ToInt32(inventoryTextBox.Text),
                Min = Convert.ToInt32(minTextBox.Text),
                Max = Convert.ToInt32(maxTextBox.Text),
                MachineID = Convert.ToInt32(machineIDorCompanyTextBox.Text)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void addButton_Outsource_Click(object sender, EventArgs e)
        {
            if (!ValidateMinMax()) return; // Perform validation before proceeding

            NewPart = new OutsourcedPart
            {
                PartID = Form1.GeneratePartId(),
                Name = nameTextBox.Text,
                Price = Convert.ToDecimal(priceTextBox.Text),
                InStock = Convert.ToInt32(inventoryTextBox.Text),
                Min = Convert.ToInt32(minTextBox.Text),
                Max = Convert.ToInt32(maxTextBox.Text),
                CompanyName = machineIDorCompanyTextBox.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Closes the AddPart form
        }
        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            // Check if the character is not a digit and also not a control character
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Handle the event, ignoring the key press
            }
        }

        private void NumberWithDecimal(object sender, KeyPressEventArgs e)
        {
            // Allow numbers, control characters, and a single decimal point
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore invalid input
            }

            // Check if '.' is already present in the textbox and ignore if pressed again
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

    }
}
