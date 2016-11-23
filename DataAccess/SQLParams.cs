using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [Serializable]
    public class SQLParams
    {
        public string ComCod { get; set; }
        public string Segment { get; set; }
        public string ProcName { get; set; }
        public DataSet varXml01 { get; set; }
        public DataSet varXml02 { get; set; }
        public byte[] varBin01 { get; set; }
        public string var01 { get; set; }
        public string var02 { get; set; }
        public string var03 { get; set; }
        public string var04 { get; set; }
        public string var05 { get; set; }
        public string var06 { get; set; }
        public string var07 { get; set; }
        public string var08 { get; set; }
        public string var09 { get; set; }
        public string var10 { get; set; }
        public string var11 { get; set; }
        public string var12 { get; set; }
        public string var13 { get; set; }
        public string var14 { get; set; }
        public string var15 { get; set; }
        public string var16 { get; set; }
        public string var17 { get; set; }
        public string var18 { get; set; }
        public string var19 { get; set; }
        public string var20 { get; set; }
        public string var21 { get; set; }
        public string var22 { get; set; }

        public SQLParams(string comcod="",string _ProcName = "XXXXXX", string _Segment = "XXXXXX", DataSet _varXml01 = null, DataSet _varXml02 = null,
                   byte[] _varBin01 = null, string _var01 = "", string _var02 = "", string _var03 = "", string _var04 = "", string _var05 = "",
                   string _var06 = "", string _var07 = "", string _var08 = "", string _var09 = "", string _var10 = "", string _var11 = "",
                   string _var12 = "", string _var13 = "", string _var14 = "", string _var15 = "", string _var16 = "", string _var17 = "",
                   string _var18 = "", string _var19 = "", string _var20 = "")
        {
            this.ComCod = comcod;
            this.ProcName = _ProcName;
            this.Segment = _Segment;
            this.varXml01 = _varXml01;
            this.varXml02 = _varXml02;
            this.varBin01 = _varBin01;
            this.var01 = _var01;
            this.var02 = _var02;
            this.var03 = _var03;
            this.var04 = _var04;
            this.var05 = _var05;
            this.var06 = _var06;
            this.var07 = _var07;
            this.var08 = _var08;
            this.var09 = _var09;
            this.var10 = _var10;
            this.var11 = _var11;
            this.var12 = _var12;
            this.var13 = _var13;
            this.var14 = _var14;
            this.var15 = _var15;
            this.var16 = _var16;
            this.var17 = _var17;
            this.var18 = _var18;
            this.var19 = _var19;
            this.var20 = _var20;
        }
    }
}
