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
    public partial class Form1 : Form
    {
        public static List<Part> FormPartList { get; set; }
        public static List<Product> FormProductList { get; set; }
        public Form1()
        {
            InitializeComponent();

            FormPartList = GetPartsTestData();
            FormProductList = GetProductsTestData();

            dataGridView1.DataSource = FormPartList;
            dataGridView2.DataSource = FormProductList;

            SetupSearchFunctionality();

            button3.Click += Button3_Click;

            button4.Enabled = false;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            button4.Click += button4_Click;

            addProductButton.Click += addProductButton_click;
            modifyProductButton.Click += modifyProductButton_click;

            modifyProductButton.Enabled = false;
            dataGridView2.SelectionChanged += DataGridView2_SelectionChanged;

            deleteProductButton.Enabled = false;
            deletePartButton.Enabled = false;

            deletePartButton.Click += deletePartButton_Click;
            deleteProductButton.Click += deleteProductButton_Click;


        }

        public static int GeneratePartId()
        {
            return FormPartList.Count + 1;
        }

        public static int GenerateProductId()
        {
            return FormProductList.Count + 1;
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Check if product has associated parts
                    var selectedProduct = (Product)dataGridView2.SelectedRows[0].DataBoundItem;
                    if (selectedProduct.AssociatedParts.Count > 0)
                    {
                        MessageBox.Show("Cannot delete a product that has associated parts.");
                        return;
                    }

                    FormProductList.Remove(selectedProduct);

                    // Refresh the DataGridView
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = FormProductList;
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }


        private void deletePartButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this part?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Get the selected part
                    var selectedPart = (Part)dataGridView1.SelectedRows[0].DataBoundItem;

                    // Check if the part is associated with any product
                    bool isPartAssociated = FormProductList.Any(product => product.AssociatedParts.Contains(selectedPart));

                    if (isPartAssociated)
                    {
                        MessageBox.Show("This part is associated with a product and cannot be deleted.");
                        return; // Prevent deletion
                    }

                    // If the part is not associated, proceed with deletion
                    FormPartList.Remove(selectedPart);

                    // Refresh the DataGridView
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = FormPartList;
                }
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }
        }



        private void modifyProductButton_click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0) return;
            // Assuming your DataGridView is bound to a list of Part objects
            var selectedProduct = (Product)dataGridView2.SelectedRows[0].DataBoundItem;

            var modifyProductForm = new ModifyProduct(selectedProduct, FormPartList);
            var dialogResult = modifyProductForm.ShowDialog();
        }

        private void addProductButton_click(object sender, EventArgs e)
        {
            var addProductForm = new AddProduct(FormPartList);
            var dialogResult = addProductForm.ShowDialog();

            if (dialogResult != DialogResult.OK) return;
            var newProduct = addProductForm.CurrentProduct;

            if (newProduct == null) return;
            FormProductList.Add(newProduct);
            dataGridView2.DataSource = null; // Reset DataSource to refresh the DataGridView
            dataGridView2.DataSource = FormProductList;

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Enable the button only if there is at least one selected row
            button4.Enabled = dataGridView1.SelectedRows.Count > 0;
            deletePartButton.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            // Enable the button only if there is at least one selected row
            modifyProductButton.Enabled = dataGridView2.SelectedRows.Count > 0;
            deleteProductButton.Enabled = dataGridView2.SelectedRows.Count > 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            // Assuming your DataGridView is bound to a list of Part objects
            var selectedPart = (Part)dataGridView1.SelectedRows[0].DataBoundItem;

            // Assuming ModifyPart has a constructor that takes a Part object
            var modifyPartForm = new ModifyPart(selectedPart);
            modifyPartForm.ShowDialog(); // Show the modify form as a dialog

            // Optionally, refresh the DataGridView if modifications can affect the displayed data
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var addPartForm = new AddPart();
            var dialogResult = addPartForm.ShowDialog(); // Show AddPart form as a dialog

            if (dialogResult != DialogResult.OK) return;
            // Assuming AddPart form has a public property to access the new part
            var newPart = addPartForm.NewPart;

            // Check if newPart is not null and add to the list
            if (newPart == null) return;
            FormPartList.Add(newPart);
            dataGridView1.DataSource = null; // Reset DataSource to refresh the DataGridView
            dataGridView1.DataSource = FormPartList;
        }
        public bool SetupSearchFunctionality()
        {
            this.button1.Click += new EventHandler(button1_Click);
            this.button2.Click += new EventHandler(button2_Click);
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var searchQuery = textBox1.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                // If the search box is empty, display all parts
                dataGridView1.DataSource = FormPartList;
            }
            else
            {
                // Otherwise, filter the parts list
                var filteredList = FormPartList.Where(part => part.Name.ToLower().Contains(searchQuery)).ToList();
                dataGridView1.DataSource = filteredList;
            }

            dataGridView1.Refresh(); // Refresh the DataGridView to display the filtered results
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var searchQuery = textBox2.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                // If the search box is empty, display all parts
                dataGridView2.DataSource = FormProductList;
            }
            else
            {
                // Otherwise, filter the parts list
                var filteredList = FormProductList.Where(part => part.Name.ToLower().Contains(searchQuery)).ToList();
                dataGridView2.DataSource = filteredList;
            }

            dataGridView1.Refresh(); // Refresh the DataGridView to display the filtered results
        }

        public List<Part> GetPartsTestData()
        {
            var res = new List<Part>();
            var x = new InhousePart()
            {
                Name = "Wheel",
                InStock = 15,
                Price = (decimal)12.11,
                Min = 5,
                Max = 25,
                MachineID = 22
            };
            res.Add(x);

            x = new InhousePart()
            {
                PartID = 1,
                Name = "Pedal",
                InStock = 11,
                Price = (decimal)8.22,
                Min = 5,
                Max = 25,
                MachineID = 22
            };
            res.Add(x);

            var a = new OutsourcedPart()
            {
                PartID = 3,
                Name = "Brakes",
                InStock = 11,
                Price = (decimal)30.22,
                Min = 5,
                Max = 25,
                CompanyName = "TSCM"
            };
            res.Add(a);

            return res;
        }

        public List<Product> GetProductsTestData()
        {
            var res = new List<Product>();

            var x = new Product()
            {
                ProductID = 0,
                Name = "Red Bicycle",
                InStock = 15,
                Price = (decimal)11.44,
                Min = 1,
                Max = 25,
                AssociatedParts = new BindingList<Part>()
                {
                    new InhousePart()
                    {
                        Name = "Bike Brake",
                        InStock = 15,
                        MachineID = 1252,
                        Min = 1,
                        Max = 25,
                        PartID = 1111,
                        Price = (decimal)20.5
                    }

                }
            }; 

            res.Add(x);

            x = new Product()
            {
                ProductID = 1,
                Name = "Yellow Bicycle",
                InStock = 19,
                Price = (decimal)9.66,
                Min = 1,
                Max = 20,
                AssociatedParts = new BindingList<Part>()
                {
                    new InhousePart()
                    {
                        Name = "Bike Brake",
                        InStock = 15,
                        MachineID = 1252,
                        Min = 1,
                        Max = 25,
                        PartID = 1111,
                        Price = (decimal)20.5
                    }

                }
            };

            res.Add(x);

            return res;
        }
    }
}
