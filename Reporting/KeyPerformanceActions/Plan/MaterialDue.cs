namespace Reporting.KeyPerformanceActions.Plan
{
    class MaterialDue : KeyPerformanceAction
    {

        /// <summary>
        /// The data for the selective report
        /// </summary>
        private Templates.SelectiveReportTemplate selectiveData;



        public MaterialDue()
        {
            selectiveData = new Templates.SelectiveReportTemplate();
        }

        #region KeyPerformanceAction override functions

        public override void CalculateSelectiveReport()
        {

        }

        #endregion
    }
}
