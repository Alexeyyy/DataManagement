using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundApp.Models.ViewModels
{
    public class CouncilsProblems
    {
        public List<EcologicalProblem> listProblems { get; set; }
        public List<Council> listCouncils { get; set; }
    }
}