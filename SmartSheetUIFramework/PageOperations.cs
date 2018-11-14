using SmartSheetUIFramework.PageOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSheetUIFramework
{
    public class PageOperations
    {
        public LoginPageOps loginPageOps { get; }

        public PageOperations()
        {
           loginPageOps = new LoginPageOps();
        }

    }
}
