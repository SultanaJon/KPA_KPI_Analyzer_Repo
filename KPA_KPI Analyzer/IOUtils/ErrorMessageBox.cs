using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace KPA_KPI_Analyzer.IOUtils
{
    public partial class ErrorMessageBox : Form
    {
        private List<string> errorList;


        public List<string> Errors { set { errorList.Clear(); errorList = value; } }


        /// <summary>
        /// constructor
        /// </summary>
        public ErrorMessageBox()
        {
            InitializeComponent();
            errorList = new List<string>();
        }





        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Over event</param>
        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            btn_Close.Image = Properties.Resources.Close_Hover_icon;
        }








        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e) => btn_Close.Image = Properties.Resources.Close;








        /// <summary>
        /// This event will close the entire application (process)
        /// </summary>
        /// <remarks>
        ///     06/08/2017 - Created
        /// </remarks>
        /// <param name="sender">The Close button</param>
        /// <param name="e">The click event</param>
        private DialogResult btn_Close_Click(object sender, EventArgs e)
        {
            return DialogResult.OK;
        }








        /// <summary>
        /// Print out all the errors that were found at run-time.
        /// </summary>
        public void PrintErrors()
        {
            txtbx_errorLog.Clear();
            foreach(string error in errorList)
            {
                txtbx_errorLog.Text += "[" + DateTime.Now.ToString() + "] - " +  error + Environment.NewLine;
            }
        }







        /// <summary>
        /// Clear all the errors from the last operation & wait for new ones to occur.
        /// </summary>
        private void ClearErrorBox()
        {
            txtbx_errorLog.Clear();
        }









        /// <summary>
        /// Change the color of the text of the OK button.
        /// </summary
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_MouseHover(object sender, EventArgs e)
        {
            btn_ok.ForeColor = System.Drawing.Color.White;
        }







        /// <summary>
        /// Triggered when the users mouse leaves the surface of the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_MouseLeave(object sender, EventArgs e)
        {
            btn_ok.ForeColor = System.Drawing.Color.Coral;
        }






        /// <summary>
        /// Triggered when the Error Message Box UI loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorMessageBox_Load(object sender, EventArgs e)
        {
            PrintErrors();
        }
    }
}
