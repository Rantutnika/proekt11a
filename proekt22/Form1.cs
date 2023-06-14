using proekt22.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proekt22
{
    public partial class Form1 : Form
    {
        ParcelLogic parController = new ParcelLogic();
        TypeLogic typeController = new TypeLogic();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Parcel parcel)
        {
            txtId.Text = parcel.Id.ToString();
            txtNumber.Text = parcel.Number.ToString();
            txtName.Text = parcel.Name;
            txtPrice.Text = parcel.Price.ToString();
            cmbType.Text=typeController.GetTypeById(int.Parse(txtId.Text));
            listBoxDescription.Items.Add(parcel.Description.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ParcelType> allTypes = typeController.GetAllTypes();
            cmbType.DataSource = allTypes;
            cmbType.DisplayMember = "Type";
            cmbType.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || txtName.Text == "")
            {
                MessageBox.Show("Enter new data");
                txtId.Focus();
                txtId.BackColor = Color.Red;
                return;
            }
            txtId.BackColor = Color.Cyan;
            Parcel newPar = new Parcel();
            newPar.Id=int.Parse(txtId.Text);
            newPar.Name=txtName.Text;
            newPar.Number = int.Parse(txtNumber.Text);
            newPar.Price= double.Parse(txtPrice.Text);
            newPar.ParcelTypeId = (int)cmbType.SelectedValue;
            newPar.Description=listBoxDescription.Text;
            newPar.Weight = double.Parse(txtWeight.Text);
            parController.Create(newPar);
            MessageBox.Show("Added");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Parcel> allPar = parController.GetAll();
            listBoxAll.Items.Clear();
            foreach(var item in allPar)
            {
                listBoxAll.Items.Add($"{item.Id}. {item.Number}- {item.Name}- {item.Price}- {item.Weight}$");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter id");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId=int.Parse(txtId.Text);
            }
            Parcel findPar = parController.Get(findId);
            if (findPar == null)
            {
                MessageBox.Show("Can't find id");
                txtId.BackColor=Color.Red;
                txtId.Focus();
                return;
            }
            txtId.BackColor = Color.White;
            LoadRecord(findPar);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId;
            if(string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter id");
                return;
            }
            else
            {
                findId=int.Parse(txtId.Text);
            }
            Parcel findPar = parController.Get(findId);
            if(findPar == null)
            {
                MessageBox.Show("Can't find id");
                txtId.BackColor=Color.Red;
                return;
            }
            else
            {
                txtId.BackColor = Color.White;
                findPar.Name = txtName.Text;
                findPar.ParcelTypeId = int.Parse(txtId.Text);
                findPar.Number = int.Parse(txtNumber.Text);
                findPar.Price = int.Parse(txtPrice.Text);
                findPar.Description = listBoxDescription.Items.ToString();
                MessageBox.Show("Everything is ready");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter id");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId=int.Parse(txtId.Text);
                txtId.BackColor = Color.White;
            }
            Parcel findPar= parController.Get(findId);
            if (findPar == null)
            {
                MessageBox.Show("Can't find id");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                DialogResult answear = MessageBox.Show("Do you want to delete the ", "Question", MessageBoxButtons.YesNo);
                if(answear== DialogResult.Yes)
                {
                    parController.Delete(findId);
                    MessageBox.Show("Succesfull delete");

                }
                else
                {
                    return;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
