using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.IO;
using HtmlAgilityPack;
using System.Data;

namespace ComboGrabber
{
    class Scraper
    {
        public List<Proxy> Proxies { get; private set; } = ProxyManager.Proxies;

        public string GoogleURL { get; private set; }

        //Variables for requests
        private const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";

        //variables to save requested data
        public List<string> ScrapedPastebinURLs { get; private set; } = new List<string>();

        //Locker
        private static object Locker = new object();

        //Form
        public MainForm Form;

        public Scraper(string GoogleURL, MainForm Form)
        {
            this.GoogleURL = GoogleURL;
            this.Form = Form;
        }

        public async Task Scrape()
        {
            LoadPastebinURLs();

            await FindCombos();
        }

        #region LoadPastebinURLs
        public void LoadPastebinURLs()
        {
            string HTML;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.UserAgent] = USER_AGENT;
                wc.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //wc.Headers[HttpRequestHeader.Cookie] = "";
                Proxy p = Proxies[new Random().Next(Proxies.Count)];
                wc.Proxy = new WebProxy(p.IP, p.Port);
                HTML = wc.DownloadString(GoogleURL);
            }

            //System.Windows.Forms.MessageBox.Show(HTML);

            HtmlDocument PageContent = new HtmlDocument();
            PageContent.LoadHtml(HTML);

            HtmlNode[] nodes = PageContent.DocumentNode.SelectNodes("//cite").ToArray();

            foreach(HtmlNode node in nodes)
            {
                ScrapedPastebinURLs.Add(node.InnerHtml.Replace("<b>", "").Replace("</b>", ""));
            }
        }
        #endregion

        #region FindCombosInHTML
        public async Task FindCombos()
        {
            using (WebClient wc = new WebClient())
            {
                foreach(string URL in ScrapedPastebinURLs)
                {
                    Proxy pr = Proxies[new Random().Next(Proxies.Count)];
                    wc.Proxy = new WebProxy(pr.IP, pr.Port);
                    string HTML;
                    try
                    {
                        HTML = wc.DownloadString(URL);
                    }
                    catch { continue; }

                    using (StringReader reader = new StringReader(HTML))
                    {
                        string PossibleCombo;
                        while ((PossibleCombo = reader.ReadLine()) != null)
                        {
                            if(PossibleCombo.Contains(":") && PossibleCombo.Contains("@"))
                            {
                                await Task.Delay(150);
                                try
                                {
                                    string[] Combo = PossibleCombo.Replace("</textarea>", "").Split(':');

                                    MailAddress m = new MailAddress(Combo[0]);
                                    //Need to do to avoid error
                                    string password = Combo[1];

                                    lock (Locker) { Form.AddAccount(Combo); }
                                }
                                catch { continue; }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
