using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyşeŞimşekMatematikOyunu
{
    #region 5 İşlemi tutan enum tanımlaması yapılıyor ... 
    enum TransactionFour
    {
        Toplama,
        Cikarma,
        Carpma,
        Bolme,
        Rastgele
    }
    #endregion

    class Transaction
    {
        #region Değişkenler tanımlanıyor .. 
        public static TransactionFour SelectTransaction;
        public static int level = 1;
        public static int block = 1;
        static Random rnd = new Random(); // Random 
        #endregion

        #region Enumdan gelen işlemlere göre Data class'a soru cevaplar gönderiliyor ... 
        public static Data GetQuestion()
        {
            Data data = new Data();

            switch (SelectTransaction)
            {
                #region İşlem toplama işlemi ise ---->
                case TransactionFour.Toplama:
                    if (level == 1)
                    {
                        int numberFirst = rnd.Next(10);
                        int numberSecond = rnd.Next(10);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    else if (level == 2)
                    {
                        int numberFirst = rnd.Next(10, 100);
                        int numberSecond = rnd.Next(10, 100);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    else if (level == 3)
                    {
                        int numberFirst = rnd.Next(100, 1000);
                        int numberSecond = rnd.Next(100, 1000);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    else if (level == 4)
                    {
                        int numberFirst = rnd.Next(1000, 10000);
                        int numberSecond = rnd.Next(1000, 10000);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    else if (level == 5)
                    {
                        int numberFirst = rnd.Next(10000, 100000);
                        int numberSecond = rnd.Next(10000, 100000);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    break;
                #endregion

                #region İşlem çıkarma işlemi ise ---->
                case TransactionFour.Cikarma:
                    if (level == 1)
                    {
                        int numberFirst = rnd.Next(10);
                        int numberSecond = rnd.Next(10);
                        data.Question = numberFirst + " - " + numberSecond;
                        data.Answer = numberFirst - numberSecond;
                    }
                    else if (level == 2)
                    {
                        int numberFirst = rnd.Next(10, 100);
                        int numberSecond = rnd.Next(10, 100);
                        data.Question = numberFirst + " - " + numberSecond;
                        data.Answer = numberFirst - numberSecond;
                    }
                    else if (level == 3)
                    {
                        int numberFirst = rnd.Next(100, 1000);
                        int numberSecond = rnd.Next(100, 1000);
                        data.Question = numberFirst + " - " + numberSecond;
                        data.Answer = numberFirst - numberSecond;
                    }
                    else if (level == 4)
                    {
                        int numberFirst = rnd.Next(1000, 10000);
                        int numberSecond = rnd.Next(1000, 10000);
                        data.Question = numberFirst + " - " + numberSecond;
                        data.Answer = numberFirst - numberSecond;
                    }
                    else if (level == 5)
                    {
                        int numberFirst = rnd.Next(10000, 100000);
                        int numberSecond = rnd.Next(10000, 100000);
                        data.Question = numberFirst + " - " + numberSecond;
                        data.Answer = numberFirst - numberSecond;
                    }
                    break;
                #endregion

                #region İşlem çarpma işlemi ise ---->
                case TransactionFour.Carpma:
                    if (level == 1)
                    {
                        int numberFirst = rnd.Next(10);
                        int numberSecond = rnd.Next(10);
                        data.Question = numberFirst + " * " + numberSecond;
                        data.Answer = numberFirst * numberSecond;
                    }
                    else if (level == 2)
                    {
                        int numberFirst = rnd.Next(10, 100);
                        int numberSecond = rnd.Next(10, 100);
                        data.Question = numberFirst + " * " + numberSecond;
                        data.Answer = numberFirst * numberSecond;
                    }
                    else if (level == 3)
                    {
                        int numberFirst = rnd.Next(100, 1000);
                        int numberSecond = rnd.Next(100, 1000);
                        data.Question = numberFirst + " * " + numberSecond;
                        data.Answer = numberFirst * numberSecond;
                    }
                    else if (level == 4)
                    {
                        int numberFirst = rnd.Next(1000, 10000);
                        int numberSecond = rnd.Next(1000, 10000);
                        data.Question = numberFirst + " * " + numberSecond;
                        data.Answer = numberFirst * numberSecond;
                    }
                    else if (level == 5)
                    {
                        int numberFirst = rnd.Next(10000, 100000);
                        int numberSecond = rnd.Next(10000, 100000);
                        data.Question = numberFirst + " * " + numberSecond;
                        data.Answer = numberFirst * numberSecond;
                    }
                    break;
                #endregion

                #region İşlem bölme işlemi ise ---->
                case TransactionFour.Bolme:
                    if (level == 1)
                    {
                        int numberFirst = rnd.Next(1,10);
                        int numberSecond = rnd.Next(1,10);
                        if (numberSecond != 0)
                        {
                            data.Question = numberFirst + " / " + numberSecond;
                            data.Answer = numberFirst / numberSecond;
                        }                        
                    }
                    else if (level == 2)
                    {
                        int numberFirst = rnd.Next(10, 100);
                        int numberSecond = rnd.Next(10, 100);
                        if (numberSecond != 0)
                        {
                            data.Question = numberFirst + " / " + numberSecond;
                            data.Answer = numberFirst / numberSecond;
                        }
                    }
                    else if (level == 3)
                    {
                        int numberFirst = rnd.Next(100, 1000);
                        int numberSecond = rnd.Next(100, 1000);
                        if (numberSecond != 0)
                        {
                            data.Question = numberFirst + " / " + numberSecond;
                            data.Answer = numberFirst / numberSecond;
                        }
                    }
                    else if (level == 4)
                    {
                        int numberFirst = rnd.Next(1000, 10000);
                        int numberSecond = rnd.Next(1000, 10000);
                        if (numberSecond != 0)
                        {
                            data.Question = numberFirst + " / " + numberSecond;
                            data.Answer = numberFirst / numberSecond;
                        }
                    }
                    else if (level == 5)
                    {
                        int numberFirst = rnd.Next(10000, 100000);
                        int numberSecond = rnd.Next(10000, 100000);
                        if (numberSecond != 0)
                        {
                            data.Question = numberFirst + " / " + numberSecond;
                            data.Answer = numberFirst / numberSecond;
                        }
                    }
                    break;
                #endregion

                #region İşlem rastgele işlemi ise ---->
                case TransactionFour.Rastgele:
                    if (level == 1)
                    {
                        int numberFirst = rnd.Next(1, 10);
                        int numberSecond = rnd.Next(1, 10);
                        data.Question = numberFirst + " / " + numberSecond;
                        data.Answer = numberFirst / numberSecond;
                    }
                    else if (level == 2)
                    {
                        int numberFirst = rnd.Next(10, 100);
                        int numberSecond = rnd.Next(10, 100);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    else if (level == 3)
                    {
                        int numberFirst = rnd.Next(100, 1000);
                        int numberSecond = rnd.Next(100, 1000);
                        data.Question = numberFirst + " - " + numberSecond;
                        data.Answer = numberFirst - numberSecond;
                    }
                    else if (level == 4)
                    {
                        int numberFirst = rnd.Next(1000, 10000);
                        int numberSecond = rnd.Next(1000, 10000);
                        data.Question = numberFirst + " + " + numberSecond;
                        data.Answer = numberFirst + numberSecond;
                    }
                    else if (level == 5)
                    {
                        int numberFirst = rnd.Next(10000, 100000);
                        int numberSecond = rnd.Next(10000, 100000);
                        data.Question = numberFirst + " * " + numberSecond;
                        data.Answer = numberFirst * numberSecond;
                    }
                    break;
                    #endregion
            }

            return data;
        }
        #endregion

        #region Enumdan gelen işlemlere göre süre ayarlaması yapılıyor .. 
        public static int GetTime()
        {
            if (SelectTransaction == TransactionFour.Toplama)
            {
                Time();
            }
            else if(SelectTransaction == TransactionFour.Cikarma)
            {
                Time();
            }
            else if(SelectTransaction == TransactionFour.Carpma)
            {
                Time();
            }
            else if (SelectTransaction == TransactionFour.Bolme)
            {
                Time();
            }
            else if (SelectTransaction == TransactionFour.Rastgele)
            {
                Time();
            }           
            return Time();
        }
        #endregion

        #region Levele göre süre ayarlaması yapılıyor .. 
        public static int Time()
        {
            if (level == 1)
            {
                return 100;
            }
            else if (level == 2)
            {
                return 200;
            }
            else if (level == 3)
            {
                return 300;
            }
            else if (level == 4)
            {
                return 400;
            }
            else
            {
                return 500;
            }
        }
        #endregion     
    }
}
