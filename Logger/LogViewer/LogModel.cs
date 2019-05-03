using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using Newtonsoft.Json;

namespace LogViewer
{
    public class LogModel
    {

        public delegate void LogChangedEventHandler();
        public event LogChangedEventHandler logChanged;

        public List<Log> logs;
        public List<IFilter> filters;

        public LogModel()
        {
            logs = new List<Log>();
            filters = new List<IFilter>();
        }
        public void addLog(List<Log> logs)
        {
            this.logs = logs;
            logChanged?.Invoke();
        }

        public void addFilter(LogAttributesEnum attribute, string attributeSearch)
        {
            filters.Add(new Filter(attribute, attributeSearch));
            logChanged?.Invoke();
        }

        public void clearFilter()
        {
            filters.Clear();
            logChanged?.Invoke();
        }

        public List<Log> getFilteredLogs()
        {
            var filteredList = new List<Log>(logs);


            
            // check if each logs fullfill the filter condition. If yes, then gets added to the list
            for (int i = filteredList.Count - 1; i >= 0; i--) // for loop iterating backwards to be able to delete element in the list
            {
                foreach (Filter filter in filters)
                {
                    if (!filter.RespectFilterCondition(filteredList[i]))
                    {
                        filteredList.RemoveAt(i);
                        break;
                    }
                }


            }
            return filteredList;
        }
    }
}
