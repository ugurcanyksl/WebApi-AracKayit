using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_AracKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Yakıt Tür
            cmbYakitTur.Items.Add("Benzin");
            cmbYakitTur.Items.Add("Dizel");
            cmbYakitTur.Items.Add("LPG");

            //Kasa Tip
            cmbKasaTip.Items.Add("Sedan");
            cmbKasaTip.Items.Add("Hatchback");
            cmbKasaTip.Items.Add("Cabrio");

            //Vites Tip
            cmbVitesTip.Items.Add("Manuel");
            cmbVitesTip.Items.Add("Otomatik");
            cmbVitesTip.Items.Add("Triptonik");


        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region If-else
            //if (cmbMarka.Text == "Audi")
            //{
            //    cmbModel.Items.Add("A5");
            //    cmbModel.Items.Add("A6");
            //} 
            #endregion

            cmbModel.Items.Clear();

            switch (cmbMarka.Text)
            {
                case "Audi":
                    cmbModel.Items.Add("A5");
                    cmbModel.Items.Add("A6");
                    break;
                case "Mercedes":
                    cmbModel.Items.Add("E250");
                    break;
                case "Ferrari":
                    cmbModel.Items.Add("F450");
                    break;

            }
        }

        private void btnRenk_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                btnRenk.BackColor = colorDialog1.Color;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.UseItemStyleForSubItems = false;

            lvi.Text = cmbMarka.Text;//0
            lvi.SubItems.Add(cmbModel.Text);//1
            lvi.SubItems.Add(cmbYakitTur.Text);//2
            lvi.SubItems.Add(cmbKasaTip.Text);//3
            lvi.SubItems.Add(cmbVitesTip.Text);//4
            lvi.SubItems.Add("");//5
            lvi.SubItems[5].BackColor = btnRenk.BackColor;
            lvi.SubItems.Add(dtpModelYil.Text);

            listView1.Items.Add(lvi);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
