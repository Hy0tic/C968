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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C968
{
    public partial class AddProduct : Form
    {
        public Product CurrentProduct { get; set; }
        public List<Part> PartList { get; set; }
        
        public AddProduct(List<Part> partList)
        {
            InitializeComponent();
            CurrentProduct = new Product()
            {
                AssociatedParts = new BindingList<Part>()
            };
            PartList = partList;
            InitializeWithDetails();
            SetupSearchFunctionality();

            AllPartDataGridView.SelectionChanged += AllPartDataGridView_SelectionChanged;
            AllAssociatedPartListView.SelectionChanged += AllAssociatedPartListView_SelectionChanged;
            cancelButton.Click += btnClose_Click;

            deleteAssociatedPartButton.Enabled = false;
            saveProductButton.Enabled = false;

            idTextBox.Enabled = false;
            inventoryTextBox.KeyPress += NumberOnly;
            priceTextBox.KeyPress += NumberWithDecimal;
            maxTextBox.KeyPress += NumberOnly;
            minTextBox.KeyPress += NumberOnly;

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

        private void AllAssociatedPartListView_SelectionChanged(object sender, EventArgs e)
        {
            // Enable the deleteAssociatedPart button only if at least one row is selected
            deleteAssociatedPartButton.Enabled = AllAssociatedPartListView.SelectedRows.Count > 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Closes the AddPart form
        }
        private void AllPartDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            addPartButton.Enabled = AllPartDataGridView.SelectedRows.Count > 0;
        }

        public void InitializeWithDetails()
        {
            AllPartDataGridView.DataSource = PartList;
            CurrentProduct = new Product()
            {
                AssociatedParts = new BindingList<Part>()
            };
            AllAssociatedPartListView.DataSource = CurrentProduct.AssociatedParts;

            idTextBox.TextChanged += TextBoxes_TextChanged;
            nameTextBox.TextChanged += TextBoxes_TextChanged;
            inventoryTextBox.TextChanged += TextBoxes_TextChanged;
            priceTextBox.TextChanged += TextBoxes_TextChanged;
            maxTextBox.TextChanged += TextBoxes_TextChanged;
            minTextBox.TextChanged += TextBoxes_TextChanged;
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            // Check if all textboxes have non-null and non-empty text
            saveProductButton.Enabled = !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                                        !string.IsNullOrWhiteSpace(inventoryTextBox.Text) &&
                                        !string.IsNullOrWhiteSpace(priceTextBox.Text) &&
                                        !string.IsNullOrWhiteSpace(maxTextBox.Text) &&
                                        !string.IsNullOrWhiteSpace(minTextBox.Text);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var searchQuery = allPartSearchBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                // If the search box is empty, display all parts
                AllPartDataGridView.DataSource = PartList;
            }
            else
            {
                // Otherwise, filter the parts list
                var filteredList = PartList.Where(part => part.Name.ToLower().Contains(searchQuery)).ToList();
                AllPartDataGridView.DataSource = filteredList;
            }

            AllPartDataGridView.Refresh(); // Refresh the DataGridView to display the filtered results
        }

        public bool SetupSearchFunctionality()
        {
            this.AllPartSearchButton.Click += new EventHandler(button1_Click);
            return true;
        }

        private void addPartButton_click(object sender, EventArgs e)
        {
            if (AllPartDataGridView.SelectedRows.Count <= 0) return;
            // Assuming your DataGridView is bound directly to PartList and Part has a parameterless constructor
            // Get the selected part
            var selectedPart = (Part)AllPartDataGridView.SelectedRows[0].DataBoundItem;

            // Add the selected part to the AssociatedParts of the current product
            // Make sure CurrentProduct and its AssociatedParts are properly initialized
            CurrentProduct.AssociatedParts.Add(selectedPart);

            // Optionally, refresh any UI components that display AssociatedParts
        }

        private void saveProductButton_Click(object sender, EventArgs e)
        {
            // Attempt to parse Min, Max, and Inventory from the textboxes
            bool minValid = int.TryParse(minTextBox.Text, out int min);
            bool maxValid = int.TryParse(maxTextBox.Text, out int max);
            bool inventoryValid = int.TryParse(inventoryTextBox.Text, out int inventory);

            // Validate parsing was successful
            if (!minValid || !maxValid || !inventoryValid)
            {
                MessageBox.Show("Please enter valid numbers for Min, Max, and Inventory.");
                return;
            }

            // Now that we have valid integers, perform logical validation
            if (min > max)
            {
                MessageBox.Show("Min cannot be greater than Max.");
                return;
            }

            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory must be between Min and Max.");
                return;
            }

            // Assuming all validation checks pass, proceed to update the product
            if (decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                CurrentProduct.Price = price;
                CurrentProduct.Name = nameTextBox.Text;
                CurrentProduct.InStock = inventory;
                CurrentProduct.Min = min;
                CurrentProduct.Max = max;
                CurrentProduct.ProductID = Form1.GenerateProductId();

                // Indicate success and close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for Price.");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Check if there is a selected part
            if (AllAssociatedPartListView.SelectedRows.Count <= 0) return;
            // Assuming AllAssociatedPartListView is correctly set up to display AssociatedParts
            var selectedPart = (Part)AllAssociatedPartListView.SelectedRows[0].DataBoundItem;

            // Confirm before deletion
            var confirmResult = MessageBox.Show("Are you sure you want to delete this part?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes) return;
            // Remove the selected part from the AssociatedParts
            CurrentProduct.AssociatedParts.Remove(selectedPart);

            // Optionally, refresh the DataGridView to reflect the changes
            AllAssociatedPartListView.DataSource = null;
            AllAssociatedPartListView.DataSource = CurrentProduct.AssociatedParts;

        }
    }
}
