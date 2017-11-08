using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Templates.Template_Controls.KPI_Controls
{
    public partial class KPIOverall : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public KPIOverall()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Loads the overall template with all the data contained withint overallData
        /// </summary>
        /// <param name="overallData"></param>
        public void LoadTemplate(Overall overallData)
        {
            // KPI -> Plan -> PR Plan Date vs Current Plan Date
            lbl_kpiPlanPRPlannedDateVsCurrPlan_One.Text = string.Format("{0:n}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Average);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Two.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_TwentyTwo);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Three.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Fifteen_TwentyOne);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Four.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_Eight_Fourteen);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Five.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Minus_One_Seven);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Six.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Zero);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Seven.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.One_Seven);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Eight.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Eight_Fourteen);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Nine.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Fifteen_TwentyOne);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Ten.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.TwentyTwo);
            lbl_kpiPlanPRPlannedDateVsCurrPlan_Eleven.Text = string.Format("{0:n0}", overallData.kpi.plan.prPlanDateVsCurrPlan.data.Total);


            // KPI -> Plan -> (Original Planned Date - 2nd Lvl Release Date) - Coded Lead-time
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_One.Text = string.Format("{0:n}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Two.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Three.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Four.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Five.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Six.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Seven.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Eight.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Nine.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Ten.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo);
            lbl_kpiPlanOrigPnDt_2ndLvlRelDt_codeLeadTime_Eleven.Text = string.Format("{0:n0}", overallData.kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total);


            // KPI -> Plan -> (Current Planned Date - 2nd Lvl Release Date) - Coded Lead-time
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_One.Text = string.Format("{0:n}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Average);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Two.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_TwentyTwo);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Three.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Fifteen_TwentyOne);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Four.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_Eight_Fourteen);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Five.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Minus_One_Seven);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Six.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Zero);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Seven.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.One_Seven);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Eight.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Eight_Fourteen);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Nine.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Fifteen_TwentyOne);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Ten.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.TwentyTwo);
            lbl_kpiPlanCurrPnDt_2ndLvlRelDt_codeLeadTime_Eleven.Text = string.Format("{0:n0}", overallData.kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.Total);


            // KPI -> Purch -> Initial Confirmation vs PR Planned Date
            lbl_kpiPurchInitConfVsPrPlanDate_One.Text = string.Format("{0:n}", overallData.kpi.purch.initConfVsPRPlanDate.data.Average);
            lbl_kpiPurchInitConfVsPrPlanDate_Two.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_TwentyTwo);
            lbl_kpiPurchInitConfVsPrPlanDate_Three.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Fifteen_TwentyOne);
            lbl_kpiPurchInitConfVsPrPlanDate_Four.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_Eight_Fourteen);
            lbl_kpiPurchInitConfVsPrPlanDate_Five.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Minus_One_Seven);
            lbl_kpiPurchInitConfVsPrPlanDate_Six.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Zero);
            lbl_kpiPurchInitConfVsPrPlanDate_Seven.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.One_Seven);
            lbl_kpiPurchInitConfVsPrPlanDate_Eight.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Eight_Fourteen);
            lbl_kpiPurchInitConfVsPrPlanDate_Nine.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Fifteen_TwentyOne);
            lbl_kpiPurchInitConfVsPrPlanDate_Ten.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.TwentyTwo);
            lbl_kpiPurchInitConfVsPrPlanDate_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purch.initConfVsPRPlanDate.data.Total);
            lbl_kpiPurchInitConfVsPrPlanDate_Twelve.Text = string.Format("{0:n}", overallData.kpi.purch.initConfVsPRPlanDate.data.PercentUnconf + "%");


            // KPI -> Follow Up -> Initial Confirmation vs Current Confirmation
            lbl_kpiFollowUpInitConfVsCurrConf_One.Text = string.Format("{0:n}", overallData.kpi.followUp.initConfVsCurrConf.data.Average);
            lbl_kpiFollowUpInitConfVsCurrConf_Two.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_TwentyTwo);
            lbl_kpiFollowUpInitConfVsCurrConf_Three.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Fifteen_TwentyOne);
            lbl_kpiFollowUpInitConfVsCurrConf_Four.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_Eight_Fourteen);
            lbl_kpiFollowUpInitConfVsCurrConf_Five.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Minus_One_Seven);
            lbl_kpiFollowUpInitConfVsCurrConf_Six.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Zero);
            lbl_kpiFollowUpInitConfVsCurrConf_Seven.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.One_Seven);
            lbl_kpiFollowUpInitConfVsCurrConf_Eight.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Eight_Fourteen);
            lbl_kpiFollowUpInitConfVsCurrConf_Nine.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Fifteen_TwentyOne);
            lbl_kpiFollowUpInitConfVsCurrConf_Ten.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.TwentyTwo);
            lbl_kpiFollowUpInitConfVsCurrConf_Eleven.Text = string.Format("{0:n0}", overallData.kpi.followUp.initConfVsCurrConf.data.Total);
            lbl_kpiFollowUpInitConfVsCurrConf_Twelve.Text = string.Format("{0:n}", overallData.kpi.followUp.initConfVsCurrConf.data.PercentUnconf + "%");


            // KPI -> Follow Up -> Final Confirmation Date vs Final Planned Date
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_One.Text = string.Format("{0:n}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Average);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Two.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_TwentyTwo);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Three.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Four.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Five.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Minus_One_Seven);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Six.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Zero);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Seven.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.One_Seven);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Eight.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Eight_Fourteen);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Nine.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Fifteen_TwentyOne);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Ten.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.TwentyTwo);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Eleven.Text = string.Format("{0:n0}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.Total);
            lbl_kpiFollowUpFinalConfVsFinalPlanDate_Twelve.Text = string.Format("{0:n}", overallData.kpi.followUp.finalConfDateVsFinalPlan.data.PercentUnconf + "%");


            // KPI -> Follow Up -> Receipt Date vs Current Planned Date
            lbl_kpiFollowUpRecVsCurrPlanDate_One.Text = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Average);
            lbl_kpiFollowUpRecVsCurrPlanDate_Two.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_TwentyTwo);
            lbl_kpiFollowUpRecVsCurrPlanDate_Three.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne);
            lbl_kpiFollowUpRecVsCurrPlanDate_Four.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen);
            lbl_kpiFollowUpRecVsCurrPlanDate_Five.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Minus_One_Seven);
            lbl_kpiFollowUpRecVsCurrPlanDate_Six.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Zero);
            lbl_kpiFollowUpRecVsCurrPlanDate_Seven.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.One_Seven);
            lbl_kpiFollowUpRecVsCurrPlanDate_Eight.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Eight_Fourteen);
            lbl_kpiFollowUpRecVsCurrPlanDate_Nine.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne);
            lbl_kpiFollowUpRecVsCurrPlanDate_Ten.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.TwentyTwo);
            lbl_kpiFollowUpRecVsCurrPlanDate_Eleven.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrPlanDate.data.Total);

            // KPI -> Follow Up -> Receipt Date vs Original Confirmed Date
            lbl_kpiFollowUpRecVsOrigConfDate_One.Text = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Average);
            lbl_kpiFollowUpRecVsOrigConfDate_Two.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_TwentyTwo);
            lbl_kpiFollowUpRecVsOrigConfDate_Three.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne);
            lbl_kpiFollowUpRecVsOrigConfDate_Four.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen);
            lbl_kpiFollowUpRecVsOrigConfDate_Five.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Minus_One_Seven);
            lbl_kpiFollowUpRecVsOrigConfDate_Six.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Zero);
            lbl_kpiFollowUpRecVsOrigConfDate_Seven.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.One_Seven);
            lbl_kpiFollowUpRecVsOrigConfDate_Eight.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Eight_Fourteen);
            lbl_kpiFollowUpRecVsOrigConfDate_Nine.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Fifteen_TwentyOne);
            lbl_kpiFollowUpRecVsOrigConfDate_Ten.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.TwentyTwo);
            lbl_kpiFollowUpRecVsOrigConfDate_Eleven.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.Total);
            lbl_kpiFollowUpRecVsOrigConfDate_Twelve.Text = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsOrigConfDate.data.PercentUnconf + "%");

            // KPI -> Follow Up -> Receipt Date vs Current Confirmed Date
            lbl_kpiFollowUpRecVsCurrConfDate_One.Text = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Average);
            lbl_kpiFollowUpRecVsCurrConfDate_Two.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_TwentyTwo);
            lbl_kpiFollowUpRecVsCurrConfDate_Three.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne);
            lbl_kpiFollowUpRecVsCurrConfDate_Four.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen);
            lbl_kpiFollowUpRecVsCurrConfDate_Five.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Minus_One_Seven);
            lbl_kpiFollowUpRecVsCurrConfDate_Six.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Zero);
            lbl_kpiFollowUpRecVsCurrConfDate_Seven.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.One_Seven);
            lbl_kpiFollowUpRecVsCurrConfDate_Eight.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Eight_Fourteen);
            lbl_kpiFollowUpRecVsCurrConfDate_Nine.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Fifteen_TwentyOne);
            lbl_kpiFollowUpRecVsCurrConfDate_Ten.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.TwentyTwo);
            lbl_kpiFollowUpRecVsCurrConfDate_Eleven.Text = string.Format("{0:n0}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.Total);
            lbl_kpiFollowUpRecVsCurrConfDate_Twelve.Text = string.Format("{0:n}", overallData.kpi.followUp.receiptDateVsCurrConfDate.data.PercentUnconf + "%");


            // KPI -> PurchTwo -> PR 2nd Lvl Release vs PO Creation
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_One.Text = string.Format("{0:n}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Average);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Two.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.LessThanZero);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Three.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.One_Three);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Four.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Four_Seven);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Five.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Eight_Fourteen);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Six.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Fifteen_TwentyOne);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.FourtyThree_FourtyNine);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Fifty_FiftySix);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchTwoPr2ndLvlRelVsPoCreation_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.Total);

            // KPI -> PurchTwo -> PO Creation vs PO Release
            lbl_kpiPurchTwoPOCreateVsPORel_One.Text = string.Format("{0:n}", overallData.kpi.purchTwo.poCreationVsPORel.data.Average);
            lbl_kpiPurchTwoPOCreateVsPORel_Two.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.LessThanZero);
            lbl_kpiPurchTwoPOCreateVsPORel_Three.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.One_Three);
            lbl_kpiPurchTwoPOCreateVsPORel_Four.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.Four_Seven);
            lbl_kpiPurchTwoPOCreateVsPORel_Five.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.Eight_Fourteen);
            lbl_kpiPurchTwoPOCreateVsPORel_Six.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.Fifteen_TwentyOne);
            lbl_kpiPurchTwoPOCreateVsPORel_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchTwoPOCreateVsPORel_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchTwoPOCreateVsPORel_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchTwoPOCreateVsPORel_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.FourtyThree_FourtyNine);
            lbl_kpiPurchTwoPOCreateVsPORel_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.Fifty_FiftySix);
            lbl_kpiPurchTwoPOCreateVsPORel_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchTwoPOCreateVsPORel_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poCreationVsPORel.data.Total);

            // KPI -> Purch Two - PO Release vs Po Confirm
            lbl_kpiPurchTwoPORelVsPOConf_One.Text = string.Format("{0:n}", overallData.kpi.purchTwo.poRelVsPOConf.data.Average);
            lbl_kpiPurchTwoPORelVsPOConf_Two.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.LessThanZero);
            lbl_kpiPurchTwoPORelVsPOConf_Three.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.One_Three);
            lbl_kpiPurchTwoPORelVsPOConf_Four.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.Four_Seven);
            lbl_kpiPurchTwoPORelVsPOConf_Five.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.Eight_Fourteen);
            lbl_kpiPurchTwoPORelVsPOConf_Six.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.Fifteen_TwentyOne);
            lbl_kpiPurchTwoPORelVsPOConf_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchTwoPORelVsPOConf_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchTwoPORelVsPOConf_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchTwoPORelVsPOConf_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.FourtyThree_FourtyNine);
            lbl_kpiPurchTwoPORelVsPOConf_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.Fifty_FiftySix);
            lbl_kpiPurchTwoPORelVsPOConf_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchTwoPORelVsPOConf_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchTwo.poRelVsPOConf.data.Total);
            lbl_kpiPurchTwoPORelVsPOConf_Fourteen.Text = string.Format("{0:n}", overallData.kpi.purchTwo.poRelVsPOConf.data.PercentUnconf + "%");

            // KPI -> Purch Sub -> PR Release vs PO Release
            lbl_kpiPurchSubPRRelVsPORel_One.Text = string.Format("{0:n}", overallData.kpi.purchSub.prRelVsPORel.data.Average);
            lbl_kpiPurchSubPRRelVsPORel_Two.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.LessThanZero);
            lbl_kpiPurchSubPRRelVsPORel_Three.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.One_Three);
            lbl_kpiPurchSubPRRelVsPORel_Four.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Four_Seven);
            lbl_kpiPurchSubPRRelVsPORel_Five.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Eight_Fourteen);
            lbl_kpiPurchSubPRRelVsPORel_Six.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Fifteen_TwentyOne);
            lbl_kpiPurchSubPRRelVsPORel_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchSubPRRelVsPORel_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchSubPRRelVsPORel_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchSubPRRelVsPORel_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.FourtyThree_FourtyNine);
            lbl_kpiPurchSubPRRelVsPORel_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Fifty_FiftySix);
            lbl_kpiPurchSubPRRelVsPORel_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchSubPRRelVsPORel_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchSub.prRelVsPORel.data.Total);

            // KPI -> Purch Sub - PO Creation vs Confirmation Entry
            lbl_kpiPurchSubPOCreateVsConfEntry_One.Text = string.Format("{0:n}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Average);
            lbl_kpiPurchSubPOCreateVsConfEntry_Two.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.LessThanZero);
            lbl_kpiPurchSubPOCreateVsConfEntry_Three.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.One_Three);
            lbl_kpiPurchSubPOCreateVsConfEntry_Four.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Four_Seven);
            lbl_kpiPurchSubPOCreateVsConfEntry_Five.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Eight_Fourteen);
            lbl_kpiPurchSubPOCreateVsConfEntry_Six.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Fifteen_TwentyOne);
            lbl_kpiPurchSubPOCreateVsConfEntry_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchSubPOCreateVsConfEntry_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchSubPOCreateVsConfEntry_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchSubPOCreateVsConfEntry_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.FourtyThree_FourtyNine);
            lbl_kpiPurchSubPOCreateVsConfEntry_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Fifty_FiftySix);
            lbl_kpiPurchSubPOCreateVsConfEntry_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchSubPOCreateVsConfEntry_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchSub.poCreateVsConfEntry.data.Total);
            lbl_kpiPurchSubPOCreateVsConfEntry_Fourteen.Text = string.Format("{0:n}", overallData.kpi.purchSub.poCreateVsConfEntry.data.PercentUnconf + "%");

            // KPI -> Purch Total -> PR Release vs Confirmation Entry
            lbl_kpiPurchTotalPRRelConfEntry_One.Text = string.Format("{0:n}", overallData.kpi.purchTotal.prRelConfEntry.data.Average);
            lbl_kpiPurchTotalPRRelConfEntry_Two.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.LessThanZero);
            lbl_kpiPurchTotalPRRelConfEntry_Three.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.One_Three);
            lbl_kpiPurchTotalPRRelConfEntry_Four.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Four_Seven);
            lbl_kpiPurchTotalPRRelConfEntry_Five.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Eight_Fourteen);
            lbl_kpiPurchTotalPRRelConfEntry_Six.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne);
            lbl_kpiPurchTotalPRRelConfEntry_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchTotalPRRelConfEntry_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchTotalPRRelConfEntry_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchTotalPRRelConfEntry_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.FourtyThree_FourtyNine);
            lbl_kpiPurchTotalPRRelConfEntry_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Fifty_FiftySix);
            lbl_kpiPurchTotalPRRelConfEntry_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchTotalPRRelConfEntry_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchTotal.prRelConfEntry.data.Total);
            lbl_kpiPurchTotalPRRelConfEntry_Fourteen.Text = string.Format("{0:n}", overallData.kpi.purchTotal.prRelConfEntry.data.PercentUnconf + "%");




            // KPI -> Purch/Plan - PO Release vs PR Delivery Date
            lbl_kpiPurchPlanPORelVsPRDelDate_One.Text = string.Format("{0:n}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Average);
            lbl_kpiPurchPlanPORelVsPRDelDate_Two.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.LessThanZero);
            lbl_kpiPurchPlanPORelVsPRDelDate_Three.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.One_Three);
            lbl_kpiPurchPlanPORelVsPRDelDate_Four.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Four_Seven);
            lbl_kpiPurchPlanPORelVsPRDelDate_Five.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Eight_Fourteen);
            lbl_kpiPurchPlanPORelVsPRDelDate_Six.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Fifteen_TwentyOne);
            lbl_kpiPurchPlanPORelVsPRDelDate_Seven.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.TwentyTwo_TwentyEight);
            lbl_kpiPurchPlanPORelVsPRDelDate_Eight.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.TwentyNine_ThirtyFive);
            lbl_kpiPurchPlanPORelVsPRDelDate_Nine.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.ThirtySix_FourtyTwo);
            lbl_kpiPurchPlanPORelVsPRDelDate_Ten.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.FourtyThree_FourtyNine);
            lbl_kpiPurchPlanPORelVsPRDelDate_Eleven.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Fifty_FiftySix);
            lbl_kpiPurchPlanPORelVsPRDelDate_Twelve.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.GreaterThanEqualFiftySeven);
            lbl_kpiPurchPlanPORelVsPRDelDate_Thirteen.Text = string.Format("{0:n0}", overallData.kpi.purchPlan.poRelVsPRDelDate.data.Total);


            // KPI -> Other - PRs Created
            lbl_kpiOtherPrsCreated_One.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.TotalValue);
            lbl_kpiOtherPrsCreated_Two.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanZeroWeeks);
            lbl_kpiOtherPrsCreated_Three.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusOneWeeks);
            lbl_kpiOtherPrsCreated_Four.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusTwoWeeks);
            lbl_kpiOtherPrsCreated_Five.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusThreeWeeks);
            lbl_kpiOtherPrsCreated_Six.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusFourWeeks);
            lbl_kpiOtherPrsCreated_Seven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusFiveWeeks);
            lbl_kpiOtherPrsCreated_Eight.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusSixWeeks);
            lbl_kpiOtherPrsCreated_Nine.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusSevenWeeks);
            lbl_kpiOtherPrsCreated_Ten.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.GreaterThanMinusEightWeeks);
            lbl_kpiOtherPrsCreated_Eleven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsCreated.data.LessThanEightWeeks);
            lbl_kpiOtherPrsCreated_Twelve.Text = string.Format("{0:n0}", overallData.kpi.other.prsCreated.data.Total);

            // KPI -> Other - PRs Released
            lbl_kpiOtherPRsReleased_One.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.TotalValue);
            lbl_kpiOtherPRsReleased_Two.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanZeroWeeks);
            lbl_kpiOtherPRsReleased_Three.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusOneWeeks);
            lbl_kpiOtherPRsReleased_Four.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusTwoWeeks);
            lbl_kpiOtherPRsReleased_Five.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusThreeWeeks);
            lbl_kpiOtherPRsReleased_Six.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusFourWeeks);
            lbl_kpiOtherPRsReleased_Seven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusFiveWeeks);
            lbl_kpiOtherPRsReleased_Eight.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusSixWeeks);
            lbl_kpiOtherPRsReleased_Nine.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusSevenWeeks);
            lbl_kpiOtherPRsReleased_Ten.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.GreaterThanMinusEightWeeks);
            lbl_kpiOtherPRsReleased_Eleven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prsReleased.data.LessThanEightWeeks);
            lbl_kpiOtherPRsReleased_Twelve.Text = string.Format("{0:n0}", overallData.kpi.other.prsReleased.data.Total);


            // KPI -> Other - Total Spend
            lbl_kpiOtherTotalSpend_One.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.TotalValue);
            lbl_kpiOtherTotalSpend_Two.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanZeroWeeks);
            lbl_kpiOtherTotalSpend_Three.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusOneWeeks);
            lbl_kpiOtherTotalSpend_Four.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusTwoWeeks);
            lbl_kpiOtherTotalSpend_Five.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusThreeWeeks);
            lbl_kpiOtherTotalSpend_Six.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusFourWeeks);
            lbl_kpiOtherTotalSpend_Seven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusFiveWeeks);
            lbl_kpiOtherTotalSpend_Eight.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusSixWeeks);
            lbl_kpiOtherTotalSpend_Nine.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusSevenWeeks);
            lbl_kpiOtherTotalSpend_Ten.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.GreaterThanMinusEightWeeks);
            lbl_kpiOtherTotalSpend_Eleven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.totalSpend.data.LessThanEightWeeks);
            lbl_kpiOtherTotalSpend_Twelve.Text = string.Format("{0:n0}", overallData.kpi.other.totalSpend.data.Total);



            // KPI -> Other - PR vs PO Value
            lbl_kpiOtherPRsVsPOValue_One.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.TotalValue);
            lbl_kpiOtherPRsVsPOValue_Two.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanZeroWeeks);
            lbl_kpiOtherPRsVsPOValue_Three.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusOneWeeks);
            lbl_kpiOtherPRsVsPOValue_Four.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusTwoWeeks);
            lbl_kpiOtherPRsVsPOValue_Five.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusThreeWeeks);
            lbl_kpiOtherPRsVsPOValue_Six.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusFourWeeks);
            lbl_kpiOtherPRsVsPOValue_Seven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusFiveWeeks);
            lbl_kpiOtherPRsVsPOValue_Eight.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSixWeeks);
            lbl_kpiOtherPRsVsPOValue_Nine.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusSevenWeeks);
            lbl_kpiOtherPRsVsPOValue_Ten.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.GreaterThanMinusEightWeeks);
            lbl_kpiOtherPRsVsPOValue_Eleven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.prVsPOValue.data.LessThanEightWeeks);
            lbl_kpiOtherPRsVsPOValue_Twelve.Text = string.Format("{0:n0}", overallData.kpi.other.prVsPOValue.data.Total);





            // KPI -> Other - Hot Job PRs
            lbl_kpiOtherHotJobPrs_One.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.TotalValue);
            lbl_kpiOtherHotJobPrs_Two.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanZeroWeeks);
            lbl_kpiOtherHotJobPrs_Three.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusOneWeeks);
            lbl_kpiOtherHotJobPrs_Four.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusTwoWeeks);
            lbl_kpiOtherHotJobPrs_Five.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusThreeWeeks);
            lbl_kpiOtherHotJobPrs_Six.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFourWeeks);
            lbl_kpiOtherHotJobPrs_Seven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusFiveWeeks);
            lbl_kpiOtherHotJobPrs_Eight.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSixWeeks);
            lbl_kpiOtherHotJobPrs_Nine.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusSevenWeeks);
            lbl_kpiOtherHotJobPrs_Ten.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.GreaterThanMinusEightWeeks);
            lbl_kpiOtherHotJobPrs_Eleven.Text = "$" + string.Format("{0:n}", overallData.kpi.other.hotJobPrs.data.LessThanEightWeeks);
            lbl_kpiOtherHotJobPrs_Twelve.Text = string.Format("{0:n0}", overallData.kpi.other.hotJobPrs.data.Total);
        }
    }
}
