using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPAOverall : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public KPAOverall()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Load the template with the data stored in the overallData object after the calculations have been 
        /// performed
        /// </summary>
        /// <param name="overallData"></param>
        public void LoadTemplate(Overall overallData)
        {
            // KPA -> Plan -> PRs Aging (Not Rel)otRel.data.Le
            lbl_kpaPlanPRsAgingNotRel_One.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.LessThanZero);
            lbl_kpaPlanPRsAgingNotRel_Two.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.One_Three);
            lbl_kpaPlanPRsAgingNotRel_Three.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Four_Seven);
            lbl_kpaPlanPRsAgingNotRel_Four.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Eight_Fourteen);
            lbl_kpaPlanPRsAgingNotRel_Five.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Fifteen_TwentyOne);
            lbl_kpaPlanPRsAgingNotRel_Six.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.TwentyTwo_TwentyEight);
            lbl_kpaPlanPRsAgingNotRel_Seven.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.TwentyNinePlus);
            lbl_kpaPlanPRsAgingNotRel_Eight.Text = string.Format("{0:n}", overallData.kpa.plan.prsAgingNotRel.data.Average);
            lbl_kpaPlanPRsAgingNotRel_Nine.Text = string.Format("{0:n0}", overallData.kpa.plan.prsAgingNotRel.data.Total);

            // KPA -> Plan -> Material Due
            lbl_kpaPlanMaterialDue_One.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.LessThanZero);
            lbl_kpaPlanMaterialDue_Two.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.One_Three);
            lbl_kpaPlanMaterialDue_Three.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Four_Seven);
            lbl_kpaPlanMaterialDue_Four.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Eight_Fourteen);
            lbl_kpaPlanMaterialDue_Five.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Fifteen_TwentyOne);
            lbl_kpaPlanMaterialDue_Six.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.TwentyTwo_TwentyEight);
            lbl_kpaPlanMaterialDue_Seven.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.TwentyNinePlus);
            lbl_kpaPlanMaterialDue_Eight.Text = string.Format("{0:n}", overallData.kpa.plan.matDueDate.data.Average);
            lbl_kpaPlanMaterialDue_Nine.Text = string.Format("{0:n0}", overallData.kpa.plan.matDueDate.data.Total);

            // KPA -> Purch -> PRs Agin Rel
            lbl_kpaPurchPRsAgingRel_One.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.LessThanZero);
            lbl_kpaPurchPRsAgingRel_Two.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.One_Three);
            lbl_kpaPurchPRsAgingRel_Three.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Four_Seven);
            lbl_kpaPurchPRsAgingRel_Four.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Eight_Fourteen);
            lbl_kpaPurchPRsAgingRel_Five.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Fifteen_TwentyOne);
            lbl_kpaPurchPRsAgingRel_Six.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchPRsAgingRel_Seven.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.TwentyNinePlus);
            lbl_kpaPurchPRsAgingRel_Eight.Text = string.Format("{0:n}", overallData.kpa.purch.prsAgingRel.data.Average);
            lbl_kpaPurchPRsAgingRel_Nine.Text = string.Format("{0:n0}", overallData.kpa.purch.prsAgingRel.data.Total);

            // KPA -> Purch -> PO First Rel
            lbl_kpaPurchPOFirstRel_One.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.LessThanZero);
            lbl_kpaPurchPOFirstRel_Two.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.One_Three);
            lbl_kpaPurchPOFirstRel_Three.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Four_Seven);
            lbl_kpaPurchPOFirstRel_Four.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Eight_Fourteen);
            lbl_kpaPurchPOFirstRel_Five.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Fifteen_TwentyOne);
            lbl_kpaPurchPOFirstRel_Six.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchPOFirstRel_Seven.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.TwentyNinePlus);
            lbl_kpaPurchPOFirstRel_Eight.Text = string.Format("{0:n}", overallData.kpa.purch.poFirstRel.data.Average);
            lbl_kpaPurchPOFirstRel_Nine.Text = string.Format("{0:n0}", overallData.kpa.purch.poFirstRel.data.Total);

            // KPA -> Purch -> PO Prev Rel
            lbl_kpaPurchPOPrevRel_One.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.LessThanZero);
            lbl_kpaPurchPOPrevRel_Two.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.One_Three);
            lbl_kpaPurchPOPrevRel_Three.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Four_Seven);
            lbl_kpaPurchPOPrevRel_Four.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Eight_Fourteen);
            lbl_kpaPurchPOPrevRel_Five.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Fifteen_TwentyOne);
            lbl_kpaPurchPOPrevRel_Six.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchPOPrevRel_Seven.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.TwentyNinePlus);
            lbl_kpaPurchPOPrevRel_Eight.Text = string.Format("{0:n}", overallData.kpa.purch.poPrevRel.data.Average);
            lbl_kpaPurchPOPrevRel_Nine.Text = string.Format("{0:n0}", overallData.kpa.purch.poPrevRel.data.Total);

            // KPA -> Purch -> No Confirmation
            lbl_kpaPurchNoConfirmation_One.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.LessThanZero);
            lbl_kpaPurchNoConfirmation_Two.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.One_Three);
            lbl_kpaPurchNoConfirmation_Three.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Four_Seven);
            lbl_kpaPurchNoConfirmation_Four.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Eight_Fourteen);
            lbl_kpaPurchNoConfirmation_Five.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Fifteen_TwentyOne);
            lbl_kpaPurchNoConfirmation_Six.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchNoConfirmation_Seven.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.TwentyNinePlus);
            lbl_kpaPurchNoConfirmation_Eight.Text = string.Format("{0:n}", overallData.kpa.purch.noConfirmation.data.Average);
            lbl_kpaPurchNoConfirmation_Nine.Text = string.Format("{0:n0}", overallData.kpa.purch.noConfirmation.data.Total);



            // KPA -> Purch Sub -> PR Release to PO Release
            lbl_kpaPurchSubPRReleasePORelease_One.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.LessThanZero);
            lbl_kpaPurchSubPRReleasePORelease_Two.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.One_Three);
            lbl_kpaPurchSubPRReleasePORelease_Three.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.Four_Seven);
            lbl_kpaPurchSubPRReleasePORelease_Four.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.Eight_Fourteen);
            lbl_kpaPurchSubPRReleasePORelease_Five.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.Fifteen_TwentyOne);
            lbl_kpaPurchSubPRReleasePORelease_Six.Text = string.Format( "{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchSubPRReleasePORelease_Seven.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.TwentyNinePlus);
            lbl_kpaPurchSubPRReleasePORelease_Eight.Text = string.Format("{0:n}", overallData.kpa.purchSub.prRelToPORel.data.Average);
            lbl_kpaPurchSubPRReleasePORelease_Nine.Text = string.Format("{0:n0}", overallData.kpa.purchSub.prRelToPORel.data.Total);


            // KPA -> Purch Sub -> PO Release to Confirmation
            lbl_kpaPurchSubPOCreateConfEntry_One.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.LessThanZero);
            lbl_kpaPurchSubPOCreateConfEntry_Two.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.One_Three);
            lbl_kpaPurchSubPOCreateConfEntry_Three.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.Four_Seven);
            lbl_kpaPurchSubPOCreateConfEntry_Four.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.Eight_Fourteen);
            lbl_kpaPurchSubPOCreateConfEntry_Five.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.Fifteen_TwentyOne);
            lbl_kpaPurchSubPOCreateConfEntry_Six.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchSubPOCreateConfEntry_Seven.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.TwentyNinePlus);
            lbl_kpaPurchSubPOCreateConfEntry_Eight.Text = string.Format("{0:n}", overallData.kpa.purchSub.POCreatToConfEntry.data.Average);
            lbl_kpaPurchSubPOCreateConfEntry_Nine.Text = string.Format("{0:n0}", overallData.kpa.purchSub.POCreatToConfEntry.data.Total);

            // KPA -> Purch Total -> PR Release to Confirmation Entry
            lbl_kpaPurchTotalPRReleaseConfEntry_One.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.LessThanZero);
            lbl_kpaPurchTotalPRReleaseConfEntry_Two.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.One_Three);
            lbl_kpaPurchTotalPRReleaseConfEntry_Three.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Four_Seven);
            lbl_kpaPurchTotalPRReleaseConfEntry_Four.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Eight_Fourteen);
            lbl_kpaPurchTotalPRReleaseConfEntry_Five.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Fifteen_TwentyOne);
            lbl_kpaPurchTotalPRReleaseConfEntry_Six.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.TwentyTwo_TwentyEight);
            lbl_kpaPurchTotalPRReleaseConfEntry_Seven.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.TwentyNinePlus);
            lbl_kpaPurchTotalPRReleaseConfEntry_Eight.Text = string.Format("{0:n}", overallData.kpa.purchTotal.prRelConfEntry.data.Average);
            lbl_kpaPurchTotalPRReleaseConfEntry_Nine.Text = string.Format("{0:n0}", overallData.kpa.purchTotal.prRelConfEntry.data.Total);

            // KPA -> Follow Up -> Confirmed vs Plan Date
            lbl_kpaFollowUpConfvsPlanDate_One.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.LessThanZero);
            lbl_kpaFollowUpConfvsPlanDate_Two.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.One_Three);
            lbl_kpaFollowUpConfvsPlanDate_Three.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.Four_Seven);
            lbl_kpaFollowUpConfvsPlanDate_Four.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.Eight_Fourteen);
            lbl_kpaFollowUpConfvsPlanDate_Five.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.Fifteen_TwentyOne);
            lbl_kpaFollowUpConfvsPlanDate_Six.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.TwentyTwo_TwentyEight);
            lbl_kpaFollowUpConfvsPlanDate_Seven.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.TwentyNinePlus);
            lbl_kpaFollowUpConfvsPlanDate_Eight.Text = string.Format( "{0:n}",  overallData.kpa.followUp.confDateVsPlanDate.data.Average);
            lbl_kpaFollowUpConfvsPlanDate_Nine.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.confDateVsPlanDate.data.Total);

            // KPA -> Follow Up -> Confirmed Date for Upcoming Deliveries
            lbl_kpaFollowUpConfDateUpcomingDel_One.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.LessThanZero);
            lbl_kpaFollowUpConfDateUpcomingDel_Two.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.One_Three);
            lbl_kpaFollowUpConfDateUpcomingDel_Three.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.Four_Seven);
            lbl_kpaFollowUpConfDateUpcomingDel_Four.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.Eight_Fourteen);
            lbl_kpaFollowUpConfDateUpcomingDel_Five.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.Fifteen_TwentyOne);
            lbl_kpaFollowUpConfDateUpcomingDel_Six.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyTwo_TwentyEight);
            lbl_kpaFollowUpConfDateUpcomingDel_Seven.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.TwentyNinePlus);
            lbl_kpaFollowUpConfDateUpcomingDel_Eight.Text = string.Format( "{0:n}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.Average);
            lbl_kpaFollowUpConfDateUpcomingDel_Nine.Text = string.Format( "{0:n0}",  overallData.kpa.followUp.ConfDateForUpcomingDel.data.Total);


            // KPA -> Late To Confirmed Date
            lbl_kpaFollowUpLateToConfirmed_One.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.LessThanZero);
            lbl_kpaFollowUpLateToConfirmed_Two.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.One_Three);
            lbl_kpaFollowUpLateToConfirmed_Three.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Four_Seven);
            lbl_kpaFollowUpLateToConfirmed_Four.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Eight_Fourteen);
            lbl_kpaFollowUpLateToConfirmed_Five.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Fifteen_TwentyOne);
            lbl_kpaFollowUpLateToConfirmed_Six.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.TwentyTwo_TwentyEight);
            lbl_kpaFollowUpLateToConfirmed_Seven.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.TwentyNinePlus);
            lbl_kpaFollowUpLateToConfirmed_Eight.Text = string.Format("{0:n}", overallData.kpa.followUp.LateToConfDate.data.Average);
            lbl_kpaFollowUpLateToConfirmed_Nine.Text = string.Format("{0:n0}", overallData.kpa.followUp.LateToConfDate.data.Total);

            // KPA -> Hot Jobs-> PRs (Not on PO) - Hot Jobs Only
            lbl_kpaHotJobsprsNotOnPO_One.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.LessThanZero);
            lbl_kpaHotJobsprsNotOnPO_Two.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.One_Three);
            lbl_kpaHotJobsprsNotOnPO_Three.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.Four_Seven);
            lbl_kpaHotJobsprsNotOnPO_Four.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.Eight_Fourteen);
            lbl_kpaHotJobsprsNotOnPO_Five.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.Fifteen_TwentyOne);
            lbl_kpaHotJobsprsNotOnPO_Six.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.TwentyTwo_TwentyEight);
            lbl_kpaHotJobsprsNotOnPO_Seven.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.TwentyNinePlus);
            lbl_kpaHotJobsprsNotOnPO_Eight.Text = string.Format("{0:n}", overallData.kpa.hotJobs.prsNotOnPO.data.Average);
            lbl_kpaHotJobsprsNotOnPO_Nine.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.prsNotOnPO.data.Total);

            // KPA -> Hot Jobs -> No Confirmations - Hot Jobs Only
            lbl_kpaHotJobsNoConf_One.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.LessThanZero);
            lbl_kpaHotJobsNoConf_Two.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.One_Three);
            lbl_kpaHotJobsNoConf_Three.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.Four_Seven);
            lbl_kpaHotJobsNoConf_Four.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.Eight_Fourteen);
            lbl_kpaHotJobsNoConf_Five.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.Fifteen_TwentyOne);
            lbl_kpaHotJobsNoConf_Six.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.TwentyTwo_TwentyEight);
            lbl_kpaHotJobsNoConf_Seven.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.TwentyNinePlus);
            lbl_kpaHotJobsNoConf_Eight.Text = string.Format("{0:n}", overallData.kpa.hotJobs.noConfirmation.data.Average);
            lbl_kpaHotJobsNoConf_Nine.Text = string.Format("{0:n0}", overallData.kpa.hotJobs.noConfirmation.data.Total);






            // KPA -> Current Planned Date vs Current Conf Date
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_One.Text = string.Format( "{0:n}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Average);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Two.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanMinusThree);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Three.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusThree);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Four.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusTwo);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Five.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanEqualMinusOne);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Six.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.ZeroWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Seven.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualOneWeek);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Eight.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualTwoWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Nine.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.LessThanEqualThreeWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Ten.Text = string.Format( "{0:n0}",  overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GreaterThanThreeWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConf_Eleven.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDate.data.Total);



            // KPA -> Current Planned Date vs Current Conf Date (Hot Jobs Only)
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_One.Text = string.Format("{0:n}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Average);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Two.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanMinusThree);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Three.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusThree);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Four.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusTwo);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Five.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanEqualMinusOne);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Six.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.ZeroWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Seven.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualOneWeek);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Eight.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualTwoWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Nine.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.LessThanEqualThreeWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Ten.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GreaterThanThreeWeeks);
            lbl_kpaCurrPlanVsActualCurrPlanDateVsCurrConfHotJobs_Eleven.Text = string.Format("{0:n0}", overallData.kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.Total);



        }
    }
}
