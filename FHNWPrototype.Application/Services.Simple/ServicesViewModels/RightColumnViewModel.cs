using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class RightColumnViewModel
    {

        public KeyValuePair<String, String> StrongTieSuggestion { get; set; }
        public KeyValuePair<String, String> WeakTieSuggestion { get; set; }
        public KeyValuePair<String, String> CommunitySuggestion { get; set; }

    }
}
