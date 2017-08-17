using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ComboGrabber
{
    class ProxyManager
    {
        public static List<Proxy> Proxies { get; private set; } = new List<Proxy>();

        public static bool LoadProxies(string Path)
        {
            if (Proxies.Count > 0) Proxies.Clear();

            foreach(string Proxy in File.ReadLines(Path))
            {
                try
                {
                    string[] ProxyContent = Proxy.Split(':');
                    Proxies.Add(new Proxy { IP = ProxyContent[0], Port = Int32.Parse(ProxyContent[1]) });
                }
                catch { continue; }
            }

            return (Proxies.Count > 0);
        }
    }
}
