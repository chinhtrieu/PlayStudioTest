using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClub.Infrastructure
{
    public class SearchClubRequest
    {
        public string Name { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
