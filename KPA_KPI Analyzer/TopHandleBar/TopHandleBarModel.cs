using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.TopHandleBar
{
    internal class TopHandleBarModel : ITopHandleBarModel
    {
        private string country;
        private string generationDate;
        private string performance;
        private string section;
        private string category;


        /// <summary>
        /// An event for when the model is updated
        /// </summary>
        public event EventHandler TopHandleModelUpdated;



        /// <summary>
        /// An enumeration parallel to the defaultLabelValues array
        /// </summary>
        private enum DefaultLabelValue
        {
            Country,
            GenerationDate,
            Performance,
            Section,
            Category
        }


        public static string[] defaultLabelValues =
        {
            "Checking...",
            "Checking...",
            "N/A",
            "N/A",
            "N/A"
        };



        /// <summary>
        /// The country that the PRPO report is associated with
        /// </summary>
        public string CurrentCountry
        {
            get { return country; }
            set
            {
                if(TopHandleModelUpdated != null)
                {
                    country = value;
                    TopHandleModelUpdated(this, new EventArgs());
                }
            }
        }




        /// <summary>
        /// The date the PRPO report was generated
        /// </summary>
        public string ReportGenerationDate
        {
            get { return generationDate; }
            set
            {
                if (TopHandleModelUpdated != null)
                {
                    generationDate = value;
                    TopHandleModelUpdated(this, new EventArgs());
                }
            }
        }




        /// <summary>
        /// The current performance the user is viewing
        /// </summary>
        public string Performance
        {
            get { return performance; }
            set
            {
                if (TopHandleModelUpdated != null)
                {
                    performance = value;
                    TopHandleModelUpdated(this, new EventArgs());
                }
            }
        }





        /// <summary>
        /// The current section the user is viewing
        /// </summary>
        public string Section
        {
            get { return section; }
            set
            {
                if (TopHandleModelUpdated != null)
                {
                    section = value;
                    TopHandleModelUpdated(this, new EventArgs());
                }
            }
        }




        /// <summary>
        /// The current category the user is viewing.
        /// </summary>
        public string Category
        {
            get { return category; }
            set
            {
                if (TopHandleModelUpdated != null)
                {
                    category = value;
                    TopHandleModelUpdated(this, new EventArgs());
                }
            }
        }




        /// <summary>
        /// Update the models country and generation date
        /// </summary>
        public void Update(string _country, string _generationDate)
        {
            country = _country;
            ReportGenerationDate = _generationDate;

            // Notify the controller that the model has been updated
            TopHandleModelUpdated(this, new EventArgs());
        }




        /// <summary>
        /// Update the models country, generation date, perforamnce, section, and category
        /// </summary>
        public void Update(string _country, string _generationDate, string _performance, string _section, string _category)
        {
            country = _country;
            ReportGenerationDate = _generationDate;
            Performance = _performance;
            Section = _section;
            Category = _category;

            // Notify the controller that the model has been updated
            TopHandleModelUpdated(this, new EventArgs());
        }



        /// <summary>
        /// Update the models performance, section, and category
        /// </summary>
        public void Update(string _performance, string _section, string _category)
        {
            Performance = _performance;
            Section = _section;
            Category = _category;

            // Notify the controller that the model has been updated
            TopHandleModelUpdated(this, new EventArgs());
        }








        /// <summary>
        /// Method to register the model update event
        /// </summary>
        /// <param name="_handler">The method to assign to the TopHandleModelUpdated event.</param>
        public void RegisterTopHandleModelUpdateHandler(EventHandler _handler)
        {
            if(TopHandleModelUpdated != null)
            {
                TopHandleModelUpdated += _handler;
            }
        }
    }
}
