using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguagePartner.Models
{
    public class FormattingService
    {
        public string AsReadableData(DateTime date)
        {
            return date.ToString("D");
        }
    }
}
