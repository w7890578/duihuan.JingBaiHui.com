using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Model
{
    public class EasyUiDataGrid<T>
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("rows")]
        public IList<T> Rows { get; set; }
    }

    public class ResponseModel
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public object Value { get; set; }
    }
}
