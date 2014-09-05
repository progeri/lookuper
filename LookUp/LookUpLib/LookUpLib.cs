using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LookUpLib
{
    [Serializable]
    public class Data
    {
        public Data(String text, DateTime date, String lang)
        {
            this.Text = text;
            this.Date = date;
            this.Lang = lang;
        }

        public String Text
        {
            set;
            get;
        }

        public DateTime Date
        {
            set;
            get;
        }

        public String Lang
        {
            set;
            get;
        }
    }

    [Serializable]
    public class Filter
    {
        public Filter(DateTime date, String lang)
        {
            this.sinceDate = date;
            this.Lang = lang;
        }

        public Boolean enabled = false;

        public DateTime sinceDate
        {
            set;
            get;
        }

        public String Lang
        {
            set;
            get;
        }

        public Boolean isFilterAccept(Data obj)
        {
            return obj.Lang.Equals(this.Lang) || obj.Date.Date >= this.sinceDate.Date;
        }
    }

    public class LookUp : MarshalByRefObject
    {
        List<Data> results;

        public Filter filter
        {
            set;
            get;
        }

        public List<Data> searchFor(String str)
        {
            FileStream fs = new FileStream(@"data.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            List<Data> extract = (List<Data>) bf.Deserialize(fs);

            foreach (Data item in extract)
            {
                if (item.Text.Contains(str))
                {
                    if (this.filter.enabled)
                    {
                        if (this.filter.isFilterAccept(item))
                            results.Add(item);
                    }
                    else
                    {
                        results.Add(item);
                    }
                }
            }

            return this.results;
        }
    }


}
