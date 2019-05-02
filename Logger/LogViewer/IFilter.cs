using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
namespace LogViewer
{
    public interface IFilter
    {
        Boolean RespectFilterCondition(Log log);
    }
}
