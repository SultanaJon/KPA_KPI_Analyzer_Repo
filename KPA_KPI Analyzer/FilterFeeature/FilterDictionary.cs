using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.FilterFeeature
{
    public class FilterDictionary
    {
        private List<string> keys;
        private List<List<string>> values;
        private List<int> checkBoxTags;

        public FilterDictionary()
        {
            keys = new List<string>();
            values = new List<List<string>>();
            checkBoxTags = new List<int>();
        }

        /// <summary>
        /// Adds fitlers to the list of filters with their unique key and tag.
        /// </summary>
        /// <param name="_key">The selected value from the check list box.</param>
        /// <param name="_value">The list of values from the check list box.</param>
        /// <param name="_tag">The tag number of the check list box.</param>
        internal void Add(string _key, List<string> _value, int _tag)
        {
            keys.Add(_key);
            values.Add(_value);
            checkBoxTags.Add(_tag);
        }


        /// <summary>
        /// Removes the specified key from the Filter Dictionary.
        /// </summary>
        /// <param name="_key">The unselected key from the check list box</param>
        /// <param name="_tag">The tag number of the check list box.</param>
        internal void Remove(string _key, int _tag)
        {
            foreach(var key in keys)
            {
                if(key == _key)
                {
                    int index = keys.IndexOf(key);
                    if (checkBoxTags[index] == _tag)
                    {
                        keys.RemoveAt(index);
                        values.RemoveAt(index);
                        checkBoxTags.RemoveAt(index);
                    }
                }
            }
        }



        /// <summary>
        /// Clears the FitlerDictionary object of all values contained within its keys, values, and tag numbers.
        /// </summary>
        internal void Clear()
        {
            keys.Clear();
            values.Clear();
            checkBoxTags.Clear();
        }
    }
}
