using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace FHNWPrototype.UI.Web.MVC.App_Code
{
    public class StructureMapBootStraper
    {
        public static void BootStrap()
        {
            StructureMap.ObjectFactory.Initialize(
                bootStrapper =>
                {
                   // bootStrapper.For<ISomeThing>().Use<SomeThingOne>();
                });
        }

    }
}