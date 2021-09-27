using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public enum TimePeriod
    {
        ForThisWeek = 7,
        ForThisMounth = 30,
        ForYear = 365,
        ForAllTime = 0
    }
}
