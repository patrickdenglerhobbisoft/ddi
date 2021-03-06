﻿#if VSTOOLS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Newtonsoft.Json;
using System.Threading;
using Slam.Visualizers;
using Microsoft.VisualStudio.Shell;

namespace Slam.DynamicInjection
{

    public enum VisualizerType { Database = 1 }

    public class DefaultInjectors
    {
        private static DefaultInjectors _singletonDefaultInjectors = null;



        private MessageClient messageClient;
        private MessageClientLog messageClientLog;

        public DefaultInjectors()
        {
            messageClient = new MessageClient();
            messageClientLog = new MessageClientLog();

        }

        public async static void UpdateDBWatcher(string connectionString, SqlCommand cmd)
        {
            if (_singletonDefaultInjectors == null)
            {
                _singletonDefaultInjectors = new DefaultInjectors();
            }
            foreach (SqlParameter p in cmd.Parameters)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            await _singletonDefaultInjectors.messageClient.Send(cmd, connectionString);

        }

        public async static void LogMessage(object message, Exception exception = null)
        {
            if (_singletonDefaultInjectors == null)
            {
                _singletonDefaultInjectors = new DefaultInjectors();
            }
            else
            {
                _singletonDefaultInjectors.messageClient = new MessageClient();
                _singletonDefaultInjectors.messageClientLog = new MessageClientLog();

            }

            await _singletonDefaultInjectors.messageClientLog.Send(message, exception);


        }
    }




}
#endif