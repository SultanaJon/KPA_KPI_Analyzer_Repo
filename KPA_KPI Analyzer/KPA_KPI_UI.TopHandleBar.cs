﻿using KPA_KPI_Analyzer.TopHandleBar;
using System;
using System.Windows.Forms;


namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        /// <summary>
        /// The controller that will interact with the view and the model of the top handle bar
        /// </summary>
        public TopHandleBarController topHandleBarController;


        /// <summary>
        /// The mode associated with the top handle bar view
        /// </summary>
        public static ITopHandleBarModel topHandleBarModel;


        /// <summary>
        /// Creates the top handle bar controller.
        /// </summary>
        public void CreateTopHandleBarViewController()
        {
            // Ceate a new  top handle bar model
            topHandleBarModel = new TopHandleBarModel();

            // Create an instance of the controller
            topHandleBarController = new TopHandleBarController(topHandleBar, TopHandleBarNavigation_Click, topHandleBarModel);
        }
        

        /// <summary>
        /// Listens for when the user clicks the navigation button the TopHandleBarView
        /// </summary>
        /// <param name="sender">The navigation button</param>
        /// <param name="e">The click event</param>
        public void TopHandleBarNavigation_Click(object sender, EventArgs e)
        {
            // Change the position of the navigation window
            if (navigationSettings.Visible == Navigation.Visibility.Open)
            {
                navigationSettings.Visible = Navigation.Visibility.Closed;
                navigationWindow.AutoSize = false;
            }
            else
            {
                navigationSettings.Visible = Navigation.Visibility.Open;
                navigationWindow.AutoSize = true;
            }
        }
    }
}
