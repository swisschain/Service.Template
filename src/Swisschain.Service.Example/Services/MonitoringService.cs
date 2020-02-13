﻿using System.Reflection;
using System.Threading.Tasks;
using Grpc.Core;
using Swisschain.Service.Example.Common;
using Swisschain.Service.Example.Protos;

namespace Swisschain.Service.Example.Services
{
    public class MonitoringService : Monitoring.MonitoringBase
    {
        public override Task<IsAliveResponce> IsAlive(IsAliveRequest request, ServerCallContext context)
        {
            var name = Assembly.GetEntryAssembly()?.GetName();
            var result = new IsAliveResponce()
            {
                Name = ApplicationInformation.AppName,
                Version = ApplicationInformation.AppVersion,
                StartedAt = ApplicationInformation.StartedAt.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return Task.FromResult(result);
        }
    }
}