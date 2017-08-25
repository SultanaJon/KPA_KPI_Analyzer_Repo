using System.Drawing;

namespace KPA_KPI_Analyzer
{
    class FormData
    {
        /// <summary>
        /// The forms normal position
        /// </summary>
        private Point frmNormPos = new Point();




        
        /// <summary>
        /// The point along the x-axis where the application sits.
        /// </summary>
        public int FrmX
        {
            get { return frmNormPos.X; }
            set { frmNormPos.X = value; }
        }





        /// <summary>
        /// The point along the y-axis where the applications sits.
        /// </summary>
        public int FrmY
        {
            get { return frmNormPos.Y; }
            set { frmNormPos.Y = value; }
        }
    }
}
