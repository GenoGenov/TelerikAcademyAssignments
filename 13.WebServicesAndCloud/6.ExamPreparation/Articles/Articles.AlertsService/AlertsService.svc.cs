using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Articles.AlertsService
{
    using System.ServiceModel.Web;

    using Articles.Data;
    using Articles.Services.Models;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlertsService.svc or AlertsService.svc.cs at the Solution Explorer and start debugging.
    public class AlertsService : IAlertsService
    {
        private IArticlesData data=new ArticlesData(new ArticlesDbContext());

        [WebGet(UriTemplate = "")]
        public IEnumerable<AlertModel> GetAllAllerts()
        {
            return data.Alerts.All().Select(AlertModel.FromAlert).ToList();
        }
    }
}
