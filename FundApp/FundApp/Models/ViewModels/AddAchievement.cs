using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FundApp.Models.ViewModels
{
    public class AddAchievement
    {
        public Achievement AchievementItem { get; set; }

        [Display(Name = "Фото")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}