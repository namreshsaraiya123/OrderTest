using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSUI.Configuration;

namespace TBSUI.Interfaces
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetWebsite();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
        string GetDBConnectionString();
    }
}
