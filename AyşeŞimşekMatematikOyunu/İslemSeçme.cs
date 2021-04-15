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
    public partial class İslemSeçme : Form
    {
        #region CONTRUCTOR
        public İslemSeçme()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENT

        #region PictureBox sender olayı ile yapılacak işlemler Transaction class'a atanıyor .. 
        private void pbToplama_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            string playerName = txtName.Text;
            #region Boş kontrolü yapılıyor .. 
            if (String.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Lütfen isim alanını boş bırakmayınız. \nOyunun ilerleyişi için bu gereklidir .. ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
            else
            {
                #region Toplama ise
                if (picture.Name == "pbToplama")
                {
                    Transaction.SelectTransaction = TransactionFour.Toplama;
                    Go(playerName);
                }
                #endregion

                #region Çıkarma ise
                else if (picture.Name == "pbCikarma")
                {
                    Transaction.SelectTransaction = TransactionFour.Cikarma;
                    Go(playerName);
                }
                #endregion

                #region Çarpma ise
                else if (picture.Name == "pbCarpma")
                {
                    Transaction.SelectTransaction = TransactionFour.Carpma;
                    Go(playerName);
                }
                #endregion

                #region Bölme ise
                else if (picture.Name == "pbBolme")
                {
                    Transaction.SelectTransaction = TransactionFour.Bolme;
                    Go(playerName);
                }
                #endregion

                #region Rastgele ise
                else if (picture.Name == "rbRastgele")
                {
                    Transaction.SelectTransaction = TransactionFour.Rastgele;
                    Go(playerName);
                }
                #endregion
            }            
        }
        #endregion

        #region Sadece harf girebiilme kontrolü yapılıyor .. 
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("Lütfen string bir ifade giriniz .. ");
            }
        }
        #endregion

        #endregion

        #region METHOD

        #region Oyun Nasıl Oynanır Butonu
        private void btnWhatPlay_Click(object sender, EventArgs e)
        {
            NasılOynanır how = new NasılOynanır();
            this.Hide();
            how.Show();
        }
        #endregion

        #region Go
        private void Go(string playerName)
        {
            StartedPlay start = new StartedPlay(playerName);
            this.Hide();
            start.Show();
        }
        #endregion

        #endregion
    }
}
