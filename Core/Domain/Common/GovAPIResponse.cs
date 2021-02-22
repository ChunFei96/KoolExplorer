using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.GovAPI
{
    public class GovAPIResponse
    {
        public string help { get; set; }
        public bool? success { get; set; }
        public GovAPIResultModel result { get; set; }

    }

    public class GovAPIResultModel
    {
        public string resource_id { get; set; }
        public List<GovAPIFieldModel> fields { get; set; }
        public List<dynamic> records { get; set; }
        public GovAPILinkModel _links { get; set; }
        public int? limit { get; set; }
        public int? total { get; set; }
    }

    public class GovAPIFieldModel
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class GovAPILinkModel
    {
        public string start { get; set; }
        public string next { get; set; }
    }

}
