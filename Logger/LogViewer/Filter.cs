using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace LogViewer
{
    /// <summary>
    /// Represents a filter to check if the log follows the condition of the filter.
    /// </summary>
    class Filter : IFilter
    {
        LogAttributesEnum logAttribute;
        string attributeSearch;


        public Filter(LogAttributesEnum logAttribute, string attributeSearch)
        {
            this.logAttribute = logAttribute;
            this.attributeSearch = attributeSearch;
        }

        public bool RespectFilterCondition(Log log)
        {
            switch (logAttribute)
            {
                case LogAttributesEnum.Message:
                    return log.Message.Contains(attributeSearch);
                case LogAttributesEnum.Class:
                    return log.Class.Contains(attributeSearch);
                case LogAttributesEnum.Method:
                    return log.Method.Contains(attributeSearch);
                case LogAttributesEnum.Line:
                    return log.Line == Int32.Parse(attributeSearch);
                case LogAttributesEnum.Exception:
                    return log.Exception.Contains(attributeSearch);

                default:
                    throw new Exception("log attribute does not exist in log class"); // should never happen ; We should handle all cases of Log attribute




            }
        }
    }
}
