using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //genel bağlılıkyalı yükle
        void Load(IServiceCollection serviceCollection);

    }
}
