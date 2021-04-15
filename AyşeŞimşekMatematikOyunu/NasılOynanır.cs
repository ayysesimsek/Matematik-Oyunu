using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyşeŞimşekMatematikOyunu
{
    public partial class NasılOynanır : Form
    {
        #region CONSTRUCTOR
        public NasılOynanır()
        {
            InitializeComponent();
        }
        #endregion

        #region Çıkış Yap Butonu
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Oyuna Başla Butonu
        private void btnStart_Click(object sender, EventArgs e)
        {
            İslemSeçme go = new İslemSeçme();
            this.Hide();
            go.Show();
        }
        #endregion        
    }
}
