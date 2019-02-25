using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dreadmare.DTOModels.Infrastructure;
using Dreadmare;

namespace Dreadmare.DTOModels
{
    public class Quotes
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int id_Quote { get; set; }
        public string Quote { get; set; }
        public string QuoteBy { get; set; }
        public string QuoteByImage { get; set; }
    }


}
