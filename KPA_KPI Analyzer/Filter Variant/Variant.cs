using System.Collections.Generic;

namespace KPA_KPI_Analyzer.Filter_Variant
{
    public class Variant
    {
        /// <summary>
        /// The details of the variant. The key is the name of the filter category and the value is the list of filters included
        /// in this variant.
        /// </summary>
        public Dictionary<string, List<string>> details;




        /// <summary>
        /// The name of the fitler variant. This is supplied by the user.
        /// </summary>
        public string VariantName { get; set; }


        /// <summary>
        /// Indication of whether or not the Variant is active (the user selected filters for this variant)
        /// </summary>
        public bool Active { get; set; }



        /// <summary>
        /// Description of the variant. This is supplied by the user.
        /// </summary>
        public string VariantDescription { get; set; }


        public Variant()
        {

        }


        /// <summary>
        /// Custom Constructor
        /// </summary>
        public Variant(string _name, string _description, Dictionary<string, List<string>> _data)
        {
            details = _data;
            VariantName = _name;
            VariantDescription = _description;
            
            // When the user adds a variant, they have already applied this variant against the data.
            Active = true;
        }
    }
}
