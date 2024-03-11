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
    public partial class ModifyPart : Form
    {
        private Part _currentPart;
        public Part CurrentPart
        {
            get => _currentPart;
            set => _currentPart = value;
        }
        public ModifyPart(Part part)
        {
            InitializeComponent();
            CurrentPart = part;
            InitializeWithDetails();
        }

        public void InitializeWithDetails()
        {
            radioInhouse.CheckedChanged += radioInhouse_CheckedChanged;
            radioOutsourced.CheckedChanged += radioOutsourced_CheckedChanged;

            idTextBox.Text = CurrentPart.PartID.ToString();
            nameTextBox.Text = CurrentPart.Name;
            inventoryTextBox.Text = CurrentPart.InStock.ToString();
            priceTextBox.Text = CurrentPart.Price.ToString();
            maxTextBox.Text = CurrentPart.Max.ToString();
            minTextBox.Text = CurrentPart.Min.ToString();


            if (CurrentPart is InhousePart)
            {
                radioInhouse.Checked = true;
                machineIDorCompanyTextBox.Text = ((InhousePart)CurrentPart).MachineID.ToString();
            }
            else
            {
                radioOutsourced.Checked = true;
                machineIDorCompanyTextBox.Text = ((OutsourcedPart)CurrentPart).CompanyName;
            }

            cancelButton.Click += btnClose_Click;
            button1.Click += btnSave_Click;


            idTextBox.Enabled = false;
            maxTextBox.KeyPress += NumberOnly;
            minTextBox.KeyPress += NumberOnly;
            priceTextBox.KeyPress += NumberWithDecimal;
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
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Initial validation checks remain the same
            bool inventoryValid = int.TryParse(inventoryTextBox.Text, out int inventory);
            bool priceValid = decimal.TryParse(priceTextBox.Text, out decimal price);
            bool minValid = int.TryParse(minTextBox.Text, out int min);
            bool maxValid = int.TryParse(maxTextBox.Text, out int max);
            bool partIDValid = int.TryParse(idTextBox.Text, out int partID);
            int machineID = 0; // Declare outside to be accessible throughout method

            // Additional condition for parsing machineID only if Inhouse is selected
            bool machineIDValid = !radioInhouse.Checked || int.TryParse(machineIDorCompanyTextBox.Text, out machineID);

            if (!inventoryValid || !priceValid || !minValid || !maxValid || !partIDValid || !machineIDValid)
            {
                MessageBox.Show("Please enter valid numbers for all fields.");
                return;
            }

            if (min > max)
            {
                MessageBox.Show("Min cannot be greater than Max.");
                return;
            }

            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory must be between the minimum and maximum values.");
            }

            // Proceed to update or convert the part based on the radio button selection
            if (radioInhouse.Checked)
            {
                var inhousePart = CurrentPart as InhousePart ?? new InhousePart();
                machineID = Convert.ToInt32(machineIDorCompanyTextBox.Text);
                inhousePart.MachineID = machineID;
                UpdatePartCommonFields(inhousePart, nameTextBox.Text, inventory, price, min, max, partID);

                var index = Form1.FormPartList.FindIndex(p => p.PartID == CurrentPart.PartID);
                if (index != -1)
                {
                    Form1.FormPartList[index] = inhousePart;
                }

                CurrentPart = inhousePart;
            }
            else
            {
                var outsourcedPart = CurrentPart as OutsourcedPart ?? new OutsourcedPart();
                outsourcedPart.CompanyName = machineIDorCompanyTextBox.Text;
                UpdatePartCommonFields(outsourcedPart, nameTextBox.Text, inventory, price, min, max, partID);

                var index = Form1.FormPartList.FindIndex(p => p.PartID == CurrentPart.PartID);
                if (index != -1)
                {
                    Form1.FormPartList[index] = outsourcedPart;
                }

                CurrentPart = outsourcedPart;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdatePartCommonFields(Part part, string name, int inventory, decimal price, int min, int max, int partID)
        {
            part.Name = name;
            part.InStock = inventory;
            part.Price = price;
            part.Min = min;
            part.Max = max;
            part.PartID = partID;
        }



        private void radioInhouse_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioInhouse.Checked) return;
            label8.Text = "Machine ID";
        }

        private void radioOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioOutsourced.Checked) return;
            label8.Text = "Company Name";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
