using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Variants
{
    public partial class VariantsEditWindow : Form
    {
        #region PROPERTIES
        private string name;
        private string description;

        public string VariantName
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                    txtBox_Name.Text = name;
                }
            }
        }

        public string VariantDescription
        {
            get { return description; }
            set
            {
                if(value != null)
                {
                    description = value;
                    txtbox_Description.Text = description;
                }
            }
        }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public VariantsEditWindow()
        {
            InitializeComponent();
        }




        #region EVENTS

        /////////////////////////////////////////////////// UI DIALOGS //////////////////////////////////////////////////
        //
        //  here we can control the behavior of the form.
        // 
        //  These functions perform the following
        //  1) minimize the form into the taskbar.
        //  2) maximize the form to the size of the screen and min down to normal size.
        //  3) close the application.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region UI_Dialogs

        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Enter Event</param>
        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize_Hover_Icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave event</param>
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the minimize button. The form will minimize into the taskbar.
        /// </summary>
        /// <param name="sender">The minimize button</param>
        /// <param name="e">The click event.</param>
        private void btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Over event</param>
        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close;
        }






        /// <summary>
        /// This event will close the entire application (process)
        /// </summary>
        /// <param name="sender">The Close button</param>
        /// <param name="e">The click event</param>
        private void btn_Close_Click(object sender, EventArgs e) => Close();

        #endregion




        /// <summary>
        /// This event will trigger when the user starts to enter text into any of the text fields.
        /// Once the both the name and the description text fields contain information this event
        /// will enable the create button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextFields_TextChange(object sender, EventArgs e)
        {
            if (txtBox_Name.Text != "" && txtbox_Description.Text != "")
            {
                btn_Update.Enabled = true;
            }
            else
            {
                btn_Update.Enabled = false;
            }
        }





        /// <summary>
        /// Sets the variant name and variant description and closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_Update_Click(object sender, EventArgs e)
        {
            VariantName = txtBox_Name.Text;
            VariantDescription = txtbox_Description.Text;
            Close();
        }

        #endregion
    }
}