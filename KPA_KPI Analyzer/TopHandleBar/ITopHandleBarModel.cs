﻿using System;

namespace KPA_KPI_Analyzer.TopHandleBar
{
    public interface ITopHandleBarModel
    {
        /// <summary>
        /// The country that the PRPO report is associated with
        /// </summary>
        string CurrentCountry { get; set; }

        /// <summary>
        /// The date the PRPO report was generated
        /// </summary>
        string ReportGenerationDate { get; set; }

        /// <summary>
        /// The current performance the user is viewing
        /// </summary>
        string Performance { get; set; }

        /// <summary>
        /// The current section the user is viewing
        /// </summary>
        string Section { get; set; }

        /// <summary>
        /// The current category the user is viewing.
        /// </summary>
        string Category { get; set; }



        /// <summary>
        /// An event for when the model is updated
        /// </summary>
        event EventHandler TopHandleModelUpdated;
    


        /// <summary>
        /// Method to register the model update event
        /// </summary>
        /// <param name="_handler">The method to assign to the TopHandleModelUpdated event.</param>
        void RegisterTopHandleModelUpdateHandler(EventHandler _handler);



        /// <summary>
        /// Update the models country and generation date
        /// </summary>
        void Update(string _country, string _generationDate);



        /// <summary>
        /// Update the models country, generation date, perforamnce, section, and category
        /// </summary>
        void Update(string _country, string _generationDate, string _perforamnce, string _section, string _category);



        /// <summary>
        /// Update the models performance, section, and category
        /// </summary>
        void Update(string _performance, string _section, string _category);
    }
}
