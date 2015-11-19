using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Process.Interface {
    public interface IProcessTwitter {
        void SendToCloud(string data);
    }
}
