using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyşeŞimşekMatematikOyunu
{
    public partial class StartedPlay : Form
    {
        #region Değişkenler tanımlanıyor ... 
        string information_file = @"..\..\ScoreList.txt";
        string image_file = @"C:\Users\Mrs Engineer\source\repos\AyşeŞimşekMatematikOyunu\AyşeŞimşekMatematikOyunu\Resources\56661810-abstract-math-number-background-vector-illustration-for-business-design-black-white-colors-random-si.jpg";
        Dictionary<int, Data> Questions = new Dictionary<int, Data>();
        Dictionary<int, Data> Answer = new Dictionary<int, Data>();
        private int trueCount = 0;
        private int falseCount = 0;
        private int point = 0;
        private int i = 0;
        private string[] PassQuestions = new string[100];
        private string[] PassAnswer = new string[100];
        #endregion

        #region CONSTRUCTOR
        public StartedPlay(string playerName)
        {
            InitializeComponent();
            lbWelcome.Text = playerName;
        }
        #endregion

        #region METHOD
        #region İlerle ve Tamamla butonun belirli durumlara göre gerçekleşecek enabled kontrolü yapılmaktadır.  
        public void ButtonEnabledControl()
        {
            #region Cevapların enabled durumlarına göre İleri butonun aktiflik/pasiflik statusu ayarlanıyor .. 
            if (txtCevap1.Enabled != true &&
               txtCevap2.Enabled != true &&
               txtCevap3.Enabled != true &&
               txtCevap4.Enabled != true &&
               txtCevap5.Enabled != true &&
               Transaction.block != 4)
            {
                btnGo.Enabled = true;
            }
            else
            {
                btnGo.Enabled = false;
            }
            #endregion

            #region Cevapların enabled durumlarına göre Tamam butonunun aktiflik/pasiflik statusu ayarlanıyor ..
            if (txtCevap1.Enabled != true &&
               txtCevap2.Enabled != true &&
               txtCevap3.Enabled != true &&
               txtCevap4.Enabled != true &&
               txtCevap5.Enabled != true &&
               Transaction.block == 4)
            {
                btnOkey.Enabled = true;
            }
            else
            {
                btnOkey.Enabled = false;
            }
            #endregion           
        }
        #endregion

        #region Oyun yükleniyor ... 
        private void PlayLoad()
        {
            #region Block = 1 ise
            if (Transaction.block == 1)
            {
                txtSoru1.Text = Questions[0].Question;
                txtSoru2.Text = Questions[1].Question;
                txtSoru3.Text = Questions[2].Question;
                txtSoru4.Text = Questions[3].Question;
                txtSoru5.Text = Questions[4].Question;
            }
            #endregion

            #region Block = 2 ise
            else if (Transaction.block == 2)
            {
                txtSoru1.Text = Questions[5].Question;
                txtSoru2.Text = Questions[6].Question;
                txtSoru3.Text = Questions[7].Question;
                txtSoru4.Text = Questions[8].Question;
                txtSoru5.Text = Questions[9].Question;
            }
            #endregion

            #region Block = 3 ise
            else if (Transaction.block == 3)
            {
                txtSoru1.Text = Questions[10].Question;
                txtSoru2.Text = Questions[11].Question;
                txtSoru3.Text = Questions[12].Question;
                txtSoru4.Text = Questions[13].Question;
                txtSoru5.Text = Questions[14].Question;
            }
            #endregion

            #region Block = 4 ise
            else if (Transaction.block == 4)
            {
                txtSoru1.Text = Questions[15].Question;
                txtSoru2.Text = Questions[16].Question;
                txtSoru3.Text = Questions[17].Question;
                txtSoru4.Text = Questions[18].Question;
                txtSoru5.Text = Questions[19].Question;
            }
            #endregion
        }
        #endregion

        #region Bir sonraki bloğa geçişlerdeki temizlemeler gerçekleşiyor .. 
        public void CleanFormInEnabledSettings()
        {
            #region Gönder Butonu Enabled Setting
            btnSend1.Enabled = true;
            btnSend2.Enabled = false;
            btnSend3.Enabled = false;
            btnSend4.Enabled = false;
            btnSend5.Enabled = false;
            #endregion

            #region Cevap TextBox Enabled Setting
            txtCevap1.BackColor = Color.White;
            txtCevap2.BackColor = Color.White;
            txtCevap3.BackColor = Color.White;
            txtCevap4.BackColor = Color.White;
            txtCevap5.BackColor = Color.White;
            txtCevap1.Text = "";
            txtCevap2.Text = "";
            txtCevap3.Text = "";
            txtCevap4.Text = "";
            txtCevap5.Text = "";
            txtCevap1.Enabled = true;
            txtCevap2.Enabled = true;
            txtCevap3.Enabled = true;
            txtCevap4.Enabled = true;
            txtCevap5.Enabled = true;
            #endregion

            #region Pass Button BackGround
            btnPass1.BackColor = Color.Gainsboro;
            btnPass2.BackColor = Color.Gainsboro;
            btnPass3.BackColor = Color.Gainsboro;
            btnPass4.BackColor = Color.Gainsboro;
            btnPass5.BackColor = Color.Gainsboro;
            #endregion

            #region GroupBox BackGround
            groupBox1.BackgroundImage = Image.FromFile(image_file);
            groupBox2.BackgroundImage = Image.FromFile(image_file);
            groupBox3.BackgroundImage = Image.FromFile(image_file);
            groupBox4.BackgroundImage = Image.FromFile(image_file);
            groupBox5.BackgroundImage = Image.FromFile(image_file);
            #endregion           
        }
        #endregion
        #endregion

        #region EVENT

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonEnabledControl(); // İlerle ve Tamamla Butonunun Aktiflik Durumu Kontrol Edilmektedir .. 

            txtPoint.Text = point.ToString();
            txtTrueCount.Text = trueCount.ToString();
            txtFalseCount.Text = falseCount.ToString();
            txtLevel.Text = Transaction.level.ToString();
            txtBlock.Text = Transaction.block.ToString();
            
            int time = Convert.ToInt32(txtTime.Text);
            time--;
            txtTime.Text = time + "";
            if (time == 0)
            {
                timer1.Stop();
                MessageBox.Show("Süre bitmiştir .. ");
                WriteToScoreList(); // ScoreList.txt 'ye kaydediliyor.
                this.Close();
                Application.Exit();
            }
        }
        #endregion

        #region ScoreList.txt ye skor ve bilgiler kaydediliyor .. 
        public void WriteToScoreList()
        {
            FileStream fs = new FileStream(information_file, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(lbWelcome.Text + " --> \t" + point + " --> \t" + trueCount + " --> \t" + falseCount + " --> \t" + Transaction.level + Environment.NewLine);
            MessageBox.Show("Bilgileriniz dosyaya kaydedilmiştir ... ");
            sw.Close();
            fs.Close();
        }
        #endregion

        #region (Button)sender ile Gönder butonuna tıklanıldığında arka plan rengi / doğru-yanlış / puanlama hesaplaması yapılıyor ...
        private void btnSend1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            #region Button sender olayında btn.Name ine göre işlemler yapılmaktadır ..
            switch (btn.Name)
            {
                #region 1. Sorunun Gönder Butonu ..
                case "btnSend1":
                    #region Cevabın boş girilmesi kontrolü 
                    if (String.IsNullOrEmpty(txtCevap1.Text))
                    {
                        MessageBox.Show("Lütfen boş bırakmayınız ! \nSonuçtan eminseniz 'Gönderi' bilemediyseniz 'Pası' tıklayınız ..  ", "BİLDİRİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    else
                    {
                        try
                        {
                            btnSend1.Enabled = false;
                            btnSend2.Enabled = true;
                            btnSend3.Enabled = false;
                            btnSend4.Enabled = false;
                            btnSend5.Enabled = false;

                            txtCevap1.Enabled = false;
                            if (Convert.ToInt32(txtCevap1.Text) == Questions[i].Answer)
                            {
                                point += 10;
                                trueCount++;
                                txtCevap1.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                point -= 5;
                                falseCount++;
                                txtCevap1.BackColor = Color.Red;
                            }
                            i++;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Hata --> " + ex.Message);
                        }                       
                    }
                    break;
                #endregion

                #region 2. Sorunun Gönder Butonu ..
                case "btnSend2":
                    #region Cevabın boş girilmesi kontrolü 
                    if (String.IsNullOrEmpty(txtCevap2.Text))
                    {
                        MessageBox.Show("Lütfen boş bırakmayınız ! \nSonuçtan eminseniz 'Gönderi' bilemediyseniz 'Pası' tıklayınız ..  ", "BİLDİRİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    else
                    {
                        try
                        {
                            btnSend1.Enabled = false;
                            btnSend2.Enabled = false;
                            btnSend3.Enabled = true;
                            btnSend4.Enabled = false;
                            btnSend5.Enabled = false;

                            txtCevap2.Enabled = false;

                            if (Convert.ToInt32(txtCevap2.Text) == Questions[i].Answer)
                            {
                                point += 10;
                                trueCount++;
                                txtCevap2.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                point -= 5;
                                falseCount++;
                                txtCevap2.BackColor = Color.Red;
                            }
                            i++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata --> " + ex.Message);
                        }                       
                    }                   
                    break;
                #endregion

                #region 3. Sorunun Gönder Butonu ..
                case "btnSend3":
                    #region Cevabın boş girilmesi kontrolü 
                    if (String.IsNullOrEmpty(txtCevap3.Text))
                    {
                        MessageBox.Show("Lütfen boş bırakmayınız ! \nSonuçtan eminseniz 'Gönderi' bilemediyseniz 'Pası' tıklayınız ..  ", "BİLDİRİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    else
                    {
                        try
                        {
                            btnSend1.Enabled = false;
                            btnSend2.Enabled = false;
                            btnSend3.Enabled = false;
                            btnSend4.Enabled = true;
                            btnSend5.Enabled = false;

                            txtCevap3.Enabled = false;

                            if (Convert.ToInt32(txtCevap3.Text) == Questions[i].Answer)
                            {
                                point += 10;
                                trueCount++;
                                txtCevap3.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                point -= 5;
                                falseCount++;
                                txtCevap3.BackColor = Color.Red;
                            }
                            i++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata --> " + ex.Message);
                        }                       
                    }                   
                    break;
                #endregion

                #region 4. Sorunun Gönder Butonu ..
                case "btnSend4":
                    #region Cevabın boş girilmesi kontrolü 
                    if (String.IsNullOrEmpty(txtCevap4.Text))
                    {
                        MessageBox.Show("Lütfen boş bırakmayınız ! \nSonuçtan eminseniz 'Gönderi' bilemediyseniz 'Pası' tıklayınız ..  ", "BİLDİRİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    else
                    {
                        try
                        {
                            btnSend1.Enabled = false;
                            btnSend2.Enabled = false;
                            btnSend3.Enabled = false;
                            btnSend4.Enabled = false;
                            btnSend5.Enabled = true;

                            txtCevap4.Enabled = false;

                            if (Convert.ToInt32(txtCevap4.Text) == Questions[i].Answer)
                            {
                                point += 10;
                                trueCount++;
                                txtCevap4.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                point -= 5;
                                falseCount++;
                                txtCevap4.BackColor = Color.Red;
                            }
                            i++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata --> " + ex.Message);
                        }                       
                    }                   
                    break;
                #endregion

                #region 5. Sorunun Gönder Butonu .. 
                case "btnSend5":
                    #region Cevabın boş girilmesi kontrolü 
                    if (String.IsNullOrEmpty(txtCevap5.Text))
                    {
                        MessageBox.Show("Lütfen boş bırakmayınız ! \nSonuçtan eminseniz 'Gönderi' bilemediyseniz 'Pası' tıklayınız ..  ", "BİLDİRİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    else
                    {
                        try
                        {
                            btnSend1.Enabled = false;
                            btnSend2.Enabled = false;
                            btnSend3.Enabled = false;
                            btnSend4.Enabled = false;
                            btnSend5.Enabled = false;

                            txtCevap5.Enabled = false;

                            if (Convert.ToInt32(txtCevap5.Text) == Questions[i].Answer)
                            {
                                point += 10;
                                trueCount++;
                                txtCevap5.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                point -= 5;
                                falseCount++;
                                txtCevap5.BackColor = Color.Red;
                            }
                            i++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata --> " + ex.Message);
                        }                        
                    }
                    break;
                    #endregion
            }
            #endregion
        }
        #endregion

        #region Load 
        private void StartedPlay_Load(object sender, EventArgs e)
        {
            #region Oyun ilk başlangıcında butonların enabled durumları ayarlanıyor ... 
            btnSend1.Enabled = true;
            btnSend2.Enabled = false;
            btnSend3.Enabled = false;
            btnSend4.Enabled = false;
            btnSend5.Enabled = false;
            txtSoru1.Enabled = false;
            txtSoru2.Enabled = false;
            txtSoru3.Enabled = false;
            txtSoru4.Enabled = false;
            txtSoru5.Enabled = false;
            #endregion            
            txtTime.Text = Transaction.GetTime() + "";

            #region Toplamda 20 soru olmalıdır. Data sınıfına random olarak oluşturulan bilgiler atanmakatdır ... 
            for (int i = 0; i < 20; i++)
            {
                Data data = new Data();
                data = Transaction.GetQuestion();
                Questions.Add(i, data);
            }
            #endregion

            PlayLoad(); // Oyun Yükleniyor ...
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        #endregion

        #region Pass Butonu
        private void btnPass1_Click(object sender, EventArgs e)
        {
            Button btnPass = (Button)sender;

            #region 1. sorunun pass butonu
            if (btnPass.Name == "btnPass1")
            {
                PassQuestions[i] = txtSoru1.Text;
                PassAnswer[i] = txtCevap1.Text;
            }
            #endregion

            #region 2. sorunun pass butonu
            if (btnPass.Name == "btnPass2")
            {
                PassQuestions[i] = txtSoru2.Text;
                PassAnswer[i] = txtCevap2.Text;
            }
            #endregion

            #region 3. sorunun pass butonu
            if (btnPass.Name == "btnPass3")
            {
                PassQuestions[i] = txtSoru3.Text;
                PassAnswer[i] = txtCevap3.Text;
            }
            #endregion

            #region 4. sorunun pass butonu

            if (btnPass.Name == "btnPass4")
            {
                PassQuestions[i] = txtSoru4.Text;
                PassAnswer[i] = txtCevap4.Text;
            }
            #endregion

            #region 5. sorunun pass butonu
            if (btnPass.Name == "btnPass5")
            {
                PassQuestions[i] = txtSoru5.Text;
                PassAnswer[i] = txtCevap5.Text;
            }
            #endregion
        }
        #endregion

        #region Sadece rakam girebilme kontrolü yapılıyor ... 
        private void txtCevap5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Lütfen rakam giriniz !!! ");
            }
        }
        #endregion

        #region İlerle Butonu
        private void btnGo_Click(object sender, EventArgs e)
        {
            Transaction.block++;
            PlayLoad();
            btnGo.Enabled = false;
            CleanFormInEnabledSettings();
            #region Level atladıktan sonra çıkan yıldız durumunun tekrar bir tıklamada enabled = false olması ayarlanıyor .. 
            star1.Visible = false;
            start2.Visible = false;
            start3.Visible = false;
            #endregion           
        }
        #endregion

        #region Tamamla Butonu 
        private void btnOkey_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnOkey.Enabled = false;
            CleanFormInEnabledSettings();
            PlayLoad();
            i = 0;
            Transaction.GetQuestion();

            #region Doğru sayısı 11'den büyük ve leveli henüz bitmemiş ise .. 
            if (trueCount >= 11 && Transaction.level < 5)
                {
                #region Doğru sayısına göre Yıldızlar konuluyor .. 
                if (trueCount <= 15)
                {
                    star1.Visible = true;
                }
                else if (trueCount > 15 && trueCount <= 18)
                {
                    start2.Visible = true;
                }
                else if (trueCount > 18 && trueCount <= 20)
                {
                    start3.Visible = true;
                }
                #endregion
                Questions.Clear();
                Transaction.level++;

                #region Levele göre soru-cevap bilgileri tekrar alıyor .. 
                for (int i = 0; i < 20; i++)
                {
                    Data dataLevel2 = new Data();
                    dataLevel2 = Transaction.GetQuestion();
                    Questions.Add(i, dataLevel2);
                }
                #endregion
                             
                PlayLoad();
                CleanFormInEnabledSettings();              

                Transaction.block = 1;
                txtTime.Text = Transaction.GetTime() + "";
                trueCount = 0;
                timer1.Start();
                PlayLoad();
            }
            #endregion

            #region Doğru sayısı 11 ve daha fazla ve leveli bitmiş ise 
            else if (trueCount < 11 && Transaction.level == 5)
            {
                MessageBox.Show(lbWelcome.Text + " ne yazıkki oyunu tamamlayamadınız .. :(( \nDoğru sayınız level tamamlaması için az. ", " Oyun Tamamlanamadı. ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                WriteToScoreList();
                Application.Exit();
            }
            #endregion

            #region Doğru sayısı 11 den küçük ve level bitmiş ise 
            else if (trueCount < 11 && Transaction.level == 5)
            {
                MessageBox.Show(lbWelcome.Text + " tebrik ederiz :)) Oyunu başarılı şekilde bitirdiniz .. ");
                btnGo.Enabled = false;
                WriteToScoreList();
                Application.Exit();
            }
            #endregion

            #region Oyun başarılı şekilde bitmişse 
            else if (trueCount > 11 && Transaction.level == 5)
            {
                MessageBox.Show("Tebrik ederiz --> " + lbWelcome.Text + " oyunu başarılı şekilde bitirdiniz . :)");
                btnGo.Enabled = false;
                WriteToScoreList();
                Application.Exit();
            }
            #endregion

            #region Level atlamak için hak kazanamama durumu 
            else
            {
                MessageBox.Show(lbWelcome.Text + " malesef bir sonraki levele geçmeye hak kazanamadınız .. :(( ");
                WriteToScoreList();
                Application.Exit();
            }
            #endregion
        }
        #endregion

        #endregion
    }
}
