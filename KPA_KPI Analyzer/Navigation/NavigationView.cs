using System;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.Collections.Generic;

namespace KPA_KPI_Analyzer.Navigation
{
    public partial class NavigationView : UserControl, INavigationView
    {
        /// <summary>
        /// Evet to notfy the controller that the user is clicking main navigation buttons
        /// </summary>
        public event EventHandler<NavigationArgs> NavigationClick;



        /// <summary>
        /// The setting of the navigation
        /// </summary>
        private NavigationSettings Settings { get; set; }




        /// <summary>
        /// Used to know what the last active main button was.
        /// </summary>
        BunifuFlatButton activeMainButton = new BunifuFlatButton();




        /// <summary>
        /// Used to know what the last active section button was
        /// </summary>
        Button activeSectionButton = new Button();




        /// <summary>
        /// The arguments that are used when acting upon the users navigation requests.
        /// </summary>
        public NavigationArgs NavigationArguments { get; private set; }





        /// <summary>
        /// Default Constructor
        /// </summary>
        public NavigationView()
        {
            InitializeComponent();

            // Create a new instance of navigation arguments
            NavigationArguments = new NavigationArgs();

            // Create a new navigation settings so the view knows status and visibility of the navigation
            Settings = new NavigationSettings();
        }




        /// <summary>
        /// Attach the navigation settings to the view
        /// </summary>
        /// <param name="_settings"></param>
        public void AttachSettings(NavigationSettings _settings)
        {
            Settings = _settings;
        }





        /// <summary>
        /// Sets the main and section navigation tags so the controller knows what navigation items to load.
        /// </summary>
        /// <param name="_mainTag">The main navigation button tag</param>
        /// <param name="_sectionTag">The section navigation tag</param>
        public void SetArgs(MainNavigationTag _mainTag, SectionNavigationTag _sectionTag)
        {
            // Set the main and section navigation tags
            NavigationArguments.MainTag = _mainTag;
            NavigationArguments.SectionTag = _sectionTag;
        }





        /// <summary>
        /// Sets the section navigation tags so the main for knows what navigaiton items to load.
        /// </summary>
        /// <param name="_sectionTag">The section navigation tag</param>
        public void SetArgs(SectionNavigationTag _sectionTag)
        {
            // Only set the section tag as the main tag should already be set.
            NavigationArguments.SectionTag = _sectionTag;
        }





        /// <summary>
        /// Event that listens for when the main navigation buttons are clicked
        /// </summary>
        /// <param name="sender">The main navigation buttons</param>
        /// <param name="e">The click event</param>
        private void MainNavigation_Click(object sender, EventArgs e)
        {
            // If the navigation is currently locked, return and dont process the request
            if (Settings.Status == Functionality.Locked)
            {
                // The navigaiton is locked and interaction is not allowed at this moment.
                return;
            }

            try
            {
                // cast the object (button) clicked to a bunifu flat button
                BunifuFlatButton btn = sender as BunifuFlatButton;
                int tag = Convert.ToInt32(btn.Tag);

                // Determine what navigation tag the click button is
                foreach(MainNavigationTag navTag in Enum.GetValues(typeof(MainNavigationTag)))
                {
                    // Check if the the MainNavigationTag int value equal the tag of the clicked button
                    if((int)navTag == tag)
                    {
                        // If we are not dealing with the KPA or KPI main navigation buttons
                        if (navTag != MainNavigationTag.KPA && navTag != MainNavigationTag.KPI)
                        {
                            // Set the tag to the main tag (button) that was clicked and no section
                            SetArgs(navTag, SectionNavigationTag.None);

                            // Store the click button as the last active button
                            activeMainButton = sender as BunifuFlatButton;

                            // Notify the controller of this click action
                            NavigationClick(sender, NavigationArguments);
                        }
                        else
                        {
                            // Open or close the section window
                            ToggleSectionWindow(tag);

                            if (!btn.Equals(activeMainButton))
                            {
                                // Get a reference to the last active main button
                                activeMainButton = sender as BunifuFlatButton;

                                // Set the navigation arguments
                                SetArgs(navTag, SectionNavigationTag.Overall);

                                SetActiveSectionBtnToDefault();
                                
                                // Set the overall buttons of the KPA or KPI section to actively viewing
                                if(navTag == MainNavigationTag.KPA)
                                {
                                    SetActiveSectionBtn(btn_kpaOverall);
                                }
                                else
                                {
                                    SetActiveSectionBtn(btn_kpiOverall);
                                }

                                // Notify the main form of the user interaction event
                                NavigationClick(sender, NavigationArguments);
                            }
                        }
                    }
                }
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("An argument null exception was thrown", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch(ArgumentException)
            {
                MessageBox.Show("An argument exception was thrown", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("A invalid operation exception", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch(FormatException)
            {
                MessageBox.Show("A format exception was thrown", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }          
            catch(InvalidCastException)
            {
                MessageBox.Show("An invalid cast exception was thrown.", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (OverflowException)
            {
                MessageBox.Show("An overflow exception was thrown.", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }






        /// <summary>
        /// Event that listens for when the KPA navigation buttons are clicked.
        /// </summary>
        /// <param name="sender">The KPA section buttons</param>
        /// <param name="e">The click event</param>
        private void SectionNavigation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tag = Convert.ToInt32(btn.Tag);
            SetActiveSectionBtnToDefault();
            SetActiveSectionBtn(btn);

            try
            {
                foreach (SectionNavigationTag secNavTag in Enum.GetValues(typeof(SectionNavigationTag)))
                {
                    if ((int)secNavTag == tag)
                    {
                        // Set the section arguments
                        SetArgs(secNavTag);
                        NavigationClick(sender, NavigationArguments);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("A format exception was thrown", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("An invalid cast exception was thrown.", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (OverflowException)
            {
                MessageBox.Show("An overflow exception was thrown.", "Navigation Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }





        /// <summary>
        /// This function will toggle the main navigation sections when either KPA or KPI buttons are clicked.
        /// </summary>
        /// <param name="tag">The tag of the main navigation button that was clicked.</param>
        private void ToggleSectionWindow(int tag)
        {
            switch (tag)
            {
                case 1:
                    // if the KPI section panel is visible, hide it.
                    if(pnl_KPISectionsPanel.Visible)
                    {
                        pnl_KPISectionsPanel.Visible = false;
                    }

                    // Open or close the KPA panel
                    if (!pnl_KPASectionsPanel.Visible)
                    {
                        pnl_KPASectionsPanel.Visible = true;
                    }
                    else
                    {
                        pnl_KPASectionsPanel.Visible = false;
                    }
                    break;
                case 2:
                    // if the KPA section panel is visible, hide it.
                    if (pnl_KPASectionsPanel.Visible)
                    {
                        pnl_KPASectionsPanel.Visible = false;
                    }


                    // Open or close the KPI panel
                    if (!pnl_KPISectionsPanel.Visible)
                    {
                        pnl_KPISectionsPanel.Visible = true;
                    }
                    else
                    {
                        pnl_KPISectionsPanel.Visible = false;
                    }
                    break;
                default:
                    // Close both the KPA and KPI panel
                    pnl_KPASectionsPanel.Visible = false;
                    pnl_KPISectionsPanel.Visible = false;
                    break;
            }
        }




        /// <summary>
        /// Set the current active section button back to its default state.
        /// </summary>
        private void SetActiveSectionBtnToDefault()
        {
            activeSectionButton.BackColor = System.Drawing.Color.FromArgb(36, 41, 46);
            activeSectionButton.ForeColor = System.Drawing.Color.FromArgb(103, 110, 117);
        }



        /// <summary>
        /// Set the supplied button argument as the active section button
        /// </summary>
        /// <param name="btn">The button to make active</param>
        private void SetActiveSectionBtn(Button btn)
        {
            activeSectionButton = btn;
            activeSectionButton.BackColor = System.Drawing.Color.FromArgb(101, 198, 187);
            activeSectionButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
        }
    }
}