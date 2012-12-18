using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers
{
    public static class Converters
    {
        public static CompleteProfileView ConvertFromViewModelToView(CompleteProfileViewModel model)
        {
            return new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey= model.BasicProfile.ReferenceKey , AccountType=model.BasicProfile.AccountType  }, FullName=model.FullName, Description1=model.Description1 , Description2=model.Description2  };
        }

        public static List<CompleteProfileView> ConvertFromViewModelToView(List<CompleteProfileViewModel> model)
        {
            List<CompleteProfileView> list = new List<CompleteProfileView>();

            foreach (CompleteProfileViewModel item in model)
            {
                list.Add(ConvertFromViewModelToView(item));
            }

            return list;
        }
    }
}
