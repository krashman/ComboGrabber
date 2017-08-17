using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Net;

namespace ComboGrabber
{
    class Grabber
    {
        public List<string> GoogleURLs { get; private set; } = new List<string>();
        List<DataTable> ComboTables = new List<DataTable>();
        public int MaxThreads { get; private set; } = 40;

        //Form
        public MainForm Form;

        //Filenames
        List<string> FileNames = new List<string>();

        public Grabber(int MaxThreads, MainForm Form)
        {
            this.GoogleURLs = GetURLs();
            this.MaxThreads = MaxThreads;
            this.Form = Form;
        }

        #region Grabber
        public void Grab()
        {
            Parallel.ForEach(
                GoogleURLs,
                new ParallelOptions { MaxDegreeOfParallelism = MaxThreads },
                URL =>
                {
                    bool success = false;
                    int Tries = 0;

                    do
                    {
                        Tries++;
                        try
                        {
                            new Scraper(URL, Form).Scrape().Wait();

                            success = true;
                        }
                        catch
                        {
                            //System.Windows.Forms.MessageBox.Show(ex.Message);
                            if(Tries == 100)
                            {
                                success = true;
                            }
                        }
                    } while (success == false);
                });
        }
        #endregion

        private List<string> GetURLs()
        {
            return new List<string>
            {
                "https://www.google.co.th/search?q=intext:%40gmail+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40hotmail+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40yahoo+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40live+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40gmx+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40comcast+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40aol+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40ziggo+inurl:pastebin.com&tbs=qdr:d",
                "https://www.google.co.th/search?q=intext:%40yandex+inurl:pastebin.com&tbs=qdr:d",
            };
        }
    }
}
