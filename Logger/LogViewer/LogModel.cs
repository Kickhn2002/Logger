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

        public void addFilter (LogAttributesEnum attribute, string attributeSearch)
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
            if (filters == null || !filters.Any())
            {
                return logs;
            }

            var filteredList = new List<Log>();

            // check if each logs fullfill the filter condition. If yes, then gets added to the list
            foreach (Log log in logs)
            {
                foreach (Filter filter in filters)
                {
                    if (filter.RespectFilterCondition(log))
                    {
                        filteredList.Add(log);
                        break;
                    }
                }

            }
            return filteredList;
        }
    }
}
