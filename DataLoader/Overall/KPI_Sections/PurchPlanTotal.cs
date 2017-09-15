﻿using DataLoader.Templates;
using KPA_KPI_Analyzer.FilterFeeature;

namespace DataLoader.Overall.KPI_Sections
{
    public class PurchPlanTotal
    {
        public Plan_Order_Creation_vs_Conf_Entry planOrderCreationVsConfEntry;

        // Default Constructor
        public PurchPlanTotal()
        {
            planOrderCreationVsConfEntry = new Plan_Order_Creation_vs_Conf_Entry();
        }
    }







    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Plan_Order_Creation_vs_Conf_Entry
    {
        public TempFour data;

        public Plan_Order_Creation_vs_Conf_Entry()
        {
            data = new TempFour();
        }
    }
}
