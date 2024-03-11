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
    public partial class ModifyProduct : Form
    {

        private Product _currentProduct;
        private List<Part> FormAllPartsList;
        public Product CurrentProduct
        {
            get => _currentProduct;
            set => _currentProduct = value;
        }
        public ModifyProduct(Product product, List<Part> partList)
        {
            CurrentProduct = product;
            InitializeComponent();
            cancelButton.Click += btnClose_Click;
            FormAllPartsList = partList;
            InitializeWithDetails();

            deleteAssociatedPartButton.Enabled = false;
        }

        private void InitializeWithDetails()
        {
            idTextBox.Text = CurrentProduct.ProductID.ToString();
            nameTextBox.Text = CurrentProduct.Name;
            inventoryTextBox.Text = CurrentProduct.InStock.ToString();
            priceTextBox.Text = CurrentProduct.Price.ToString();
            maxTextBox.Text = CurrentProduct.Max.ToString();
            minTextBox.Text = CurrentProduct.Min.ToString();

            AllAssociatedPartListView.DataSource = CurrentProduct.AssociatedParts;
            AllPartDataGridView.DataSource = FormAllPartsList;

            SetupSearchFunctionality();

            saveProductButton.Click += saveButton_click;

            addPartButton.Enabled = false;
            AllPartDataGridView.SelectionChanged += AllPartDataGridView_SelectionChanged;
            addPartButton.Click += addPartButton_click;
            AllAssociatedPartListView.SelectionChanged += AllAssociatedPartGridView_SelectionChanged;

            idTextBox.Enabled = false;
            nameTextBox.KeyPress += NumberOnly;
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
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void AllAssociatedPartGridView_SelectionChanged(object sender, EventArgs e)
        {
            deleteAssociatedPartButton.Enabled = AllAssociatedPartListView.SelectedRows.Count > 0;
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
        private void AllPartDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            addPartButton.Enabled = AllPartDataGridView.SelectedRows.Count > 0;
        }

        private void saveButton_click(object sender, EventArgs e)
        {
            // Attempt to parse and validate all input fields.
            bool priceValid = decimal.TryParse(priceTextBox.Text, out decimal price);
            bool inventoryValid = int.TryParse(inventoryTextBox.Text, out int inventory);
            bool minValid = int.TryParse(minTextBox.Text, out int min);
            bool maxValid = int.TryParse(maxTextBox.Text, out int max);
            bool productIDValid = int.TryParse(idTextBox.Text, out int productID);

            // Check if parsing was successful for numerical fields
            if (!priceValid || !inventoryValid || !minValid || !maxValid || !productIDValid)
            {
                MessageBox.Show("Please ensure all fields are filled out correctly with valid numbers.");
                return;
            }

            // Validate min is not greater than max
            if (min > max)
            {
                MessageBox.Show("Minimum value cannot be greater than maximum value.");
                return;
            }

            // Validate inventory is within min and max bounds
            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory must be between the minimum and maximum values.");
                return;
            }

            // Assuming validation passes, proceed to update the product details
            CurrentProduct.ProductID = productID;
            CurrentProduct.Name = nameTextBox.Text;
            CurrentProduct.InStock = inventory;
            CurrentProduct.Price = price;
            CurrentProduct.Min = min;
            CurrentProduct.Max = max;

            // Close the form and indicate success
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public bool SetupSearchFunctionality()
        {
            this.AllPartSearchButton.Click += new EventHandler(button1_Click);
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchQuery = allPartSearchBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                // If the search box is empty, display all parts
                AllPartDataGridView.DataSource = FormAllPartsList;
            }
            else
            {
                // Otherwise, filter the parts list
                var filteredList = FormAllPartsList.Where(part => part.Name.ToLower().Contains(searchQuery)).ToList();
                AllPartDataGridView.DataSource = filteredList;
            }

            AllPartDataGridView.Refresh(); // Refresh the DataGridView to display the filtered results
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Closes the AddPart form
        }

        private void deleteAssociatedPartButton_Click(object sender, EventArgs e)
        {
            if (AllAssociatedPartListView.SelectedRows.Count > 0)
            {
                // Get the selected part
                var selectedPart = (Part)AllAssociatedPartListView.SelectedRows[0].DataBoundItem;

                // Confirm before deletion
                var confirmResult = MessageBox.Show("Are you sure you want to delete this associated part?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo);
                if (confirmResult != DialogResult.Yes) return;
                // Remove the selected part from the AssociatedParts
                CurrentProduct.AssociatedParts.Remove(selectedPart);

                // Refresh the DataGridView to reflect the changes
                AllAssociatedPartListView.DataSource = null;
                AllAssociatedPartListView.DataSource = CurrentProduct.AssociatedParts;
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }

        }
    }
}
