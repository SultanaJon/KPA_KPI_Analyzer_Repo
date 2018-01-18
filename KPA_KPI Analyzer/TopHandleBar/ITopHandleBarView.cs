﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.TopHandleBar
{
    public interface ITopHandleBarView
    {
        /// <summary>
        /// Event for when the user clicks the hamburger icon on the TopHandleBarView.
        /// </summary>
        event EventHandler HamburgerClick;


        /// <summary>
        /// Updates the labels on the view to inform the user what they are looking at.
        /// </summary>
        /// <param name="_model">The model that is used to update the view</param>
        void UpdateView(ITopHandleBarModel _model);



        /// <summary>
        /// Updates the view with default values
        /// </summary>
        void UpdateDefaultView();
    }
}
