using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Utility;

namespace SensorMonitor.API.Library.Utility {
    public static class IoCUtility {

        private static IUnityContainer _unityContainer = null;

        private static readonly object syncObj = new object();

        public static IUnityContainer GetInstance() {
            lock (IoCUtility.syncObj) {
                if (IoCUtility._unityContainer == null) {
                    lock (IoCUtility.syncObj) {
                        IoCUtility._unityContainer = new UnityContainer();
                    }
                }
            }

            return IoCUtility._unityContainer;
        }
    }
}
