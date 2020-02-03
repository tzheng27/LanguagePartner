using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanguagePartner.Models
{
    public class Learner
    {
        public long Id { get; set; }

        private string _key;

        public string Key
        {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(UserName.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Native Language")]
        public string NativeLanuage { get; set; }

        [Display(Name = "Second Language")]
        public string SecondLanguage { get; set; }

        [Required]
        [Display(Name = "I am learning")]
        public string LearningLanguage { get; set; }

        public DateTime UpdatedTime { get; set; } 
    }
}
