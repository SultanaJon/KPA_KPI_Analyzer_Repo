using System;
using System.Windows.Forms;

namespace Reporting.TimeSpans.Templates
{
    public abstract class Template
    {
        /// <summary>
        /// Method to calculate the averate for this KPA
        /// </summary>
        public double CalculateAverage(double _totalDays, int _totalRecords)
        {
            double average = 0;
            try
            {
                average = Math.Round(_totalDays / _totalRecords, 2);
                if (double.IsNaN(average))
                    average = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date Average Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (DivideByZeroException)
            {
                average = 0;
            }

            // Return the average calculated
            return average;
        }
    }
}
