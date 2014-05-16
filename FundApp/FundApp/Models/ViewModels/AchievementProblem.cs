using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class AchievementProblem
    {
        public Achievement ItemAchievement { get; set; }
        public IEnumerable<EcologicalProblem> ItemsProblems { get; set; }
    }
}