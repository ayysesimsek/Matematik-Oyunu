using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyşeŞimşekMatematikOyunu
{
    class Data
    {
        #region Private Members

        /// <summary>
        /// Private soru
        /// </summary>
        private string question;
        /// <summary>
        /// private cevap
        /// </summary>
        private int answer;
        /// <summary>
        /// Private pass hakkı
        /// </summary>
        private string pass;
        /// <summary>
        /// blok
        /// </summary>
        private static int block = 1;

        #endregion

        #region Public Members

        /// <summary>
        /// Soru
        /// </summary>
        public string Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
            }
        }
        /// <summary>
        /// Cevap
        /// </summary>
        public int Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }
        /// <summary>
        /// Pas Geçme
        /// </summary>
        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
            }
        }
        /// <summary>
        /// Block sayısı 
        /// </summary>
        public static int Block
        {
            get
            {
                return block;
            }
            set
            {
                block = value;
            }
        }

        #endregion
    }
}
