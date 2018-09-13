using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class NotificationService
    {
        private IWebApiService service;
        private IDbNotification DbNotififacion;

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
