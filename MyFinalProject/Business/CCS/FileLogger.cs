using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public class FileLogger : ILogger //dosyada loglama
    {
        public void Log()
        {
            Console.WriteLine("Dosya loglandı");
        }
    }
}
