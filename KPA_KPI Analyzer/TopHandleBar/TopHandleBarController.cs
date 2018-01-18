using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.TopHandleBar
{
    public class TopHandleBarController : ITopHandleBarController
    {
        /// <summary>
        /// Event that is fired when the hamburger icon in the TopHandleBar View is click
        /// </summary>
        public event EventHandler ToggleNavigation;


        /// <summary>
        /// A interface to interact with the top handle model
        /// </summary>
        private ITopHandleBarModel Model { get; set; }


        /// <summary>
        /// A interface to interact with the top handle bar  view
        /// </summary>
        private ITopHandleBarView view;


        /// <summary>
        /// Custom Constructor
        /// </summary>
        /// <param name="_view">The view this controll will control</param>
        public TopHandleBarController(ITopHandleBarView _view, EventHandler _handler, ITopHandleBarModel _model)
        {
            // set the model instance to the one provided.
            Model = _model;

            // Grab the instance of the view to send messages back and forth.
            view = _view;

            // Register the ToggleNavigation handler
            ToggleNavigation += _handler;

            // Register the views hamburger icon click event
            view.HamburgerClick += (sender, e) => { ToggleNavigation(sender, e); };

            // Register the models update event
            // When the model is updated, pass the model to the view by value to be updated
            Model.TopHandleModelUpdated += (sender, e) => { view.UpdateView(Model); };

            // update the top handle bar model
            Model.Update("N/A", "N/A", "N/A");
        }
    }
}
