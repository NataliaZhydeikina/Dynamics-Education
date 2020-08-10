using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            dayCount = dayCount > 1 ? dayCount - 1 : dayCount;
            DateTime endDate = startDate.AddDays(dayCount);

            if ((weekEnds != null && weekEnds.Length > 0))
                foreach (WeekEnd weekEnd in weekEnds)
                {
                    DateTime st = weekEnd.StartDate >= startDate ? weekEnd.StartDate : startDate;
                    if (weekEnd.StartDate <= endDate && weekEnd.EndDate >= startDate)
                    {
                        endDate = endDate.AddDays((weekEnd.EndDate - st).Days + 1);
                    }
                }

            return endDate;
        }
    }
}
