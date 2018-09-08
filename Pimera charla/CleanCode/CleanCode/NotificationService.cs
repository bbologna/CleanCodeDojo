using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class NotificationService
    {
#pragma warning disable CS0649 // Field 'NotificationService.service' is never assigned to, and will always have its default value null
        private IWebApiService service;
#pragma warning restore CS0649 // Field 'NotificationService.service' is never assigned to, and will always have its default value null

#pragma warning disable CS0649 // Field 'NotificationService.DbNotififacion' is never assigned to, and will always have its default value null
        private IDbNotification DbNotififacion;
#pragma warning restore CS0649 // Field 'NotificationService.DbNotififacion' is never assigned to, and will always have its default value null

        public void NotifyErrorWebApi(string error)
        {
            /*Do some stuff*/
            service.Error(error);
        }

        public void NotifyErrorDb(string error)
        {
            /*Do some stuff*/
            DbNotififacion.Error(error);
        }

        public void NotifyInfoWebApi(string error)
        {
            /*Do some stuff*/
            service.Info(error);
        }

        public void NotifyInfoDb(string error)
        {
            /*Do some stuff*/
            DbNotififacion.Info(error);
        }

        public void NotifyWarningWebApi(string error)
        {
            service.Warning(error);
        }

        public void NotifyWarningDb(string error)
        {
            /*Do some stuff*/
            DbNotififacion.Warning(error);
        }

        public void NotifyTraceWebApi(string error)
        {
            /*Do some stuff*/
            service.Trace(error);
        }

        public void NotifyTraceDb(string error)
        {
            /*Do some stuff*/
            DbNotififacion.Trace(error);
        }
    }
}
