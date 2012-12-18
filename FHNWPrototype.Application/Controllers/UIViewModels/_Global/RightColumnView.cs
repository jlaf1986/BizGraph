using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers.UIViewModels._Global
{
    public class RightColumnView
    {
        public KeyValuePair<String, String> WorkContactSuggestion { get; set; }
        public KeyValuePair<String, String> PartnershipContactSuggestion { get; set; }
        public KeyValuePair<String, String> GroupSuggestion { get; set; }

        public KeyValuePair<String, String> SisterDivisionSuggestion { get; set; }
        public KeyValuePair<String, String> PartnerSuggestion { get; set; }
        public KeyValuePair<String, String> AllianceSuggestion { get; set; }
    }
}
