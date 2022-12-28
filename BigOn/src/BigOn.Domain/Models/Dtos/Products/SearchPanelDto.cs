using BigOn.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Models.Dtos.Products
{
    public class SearchPanelDto
    {
        public IEnumerable<HolderChooseDto> Brands { get; set; }
        public IEnumerable<HolderChooseDto> Colors { get; set; }
        public IEnumerable<HolderChooseDto> Materials { get; set; }
        public IEnumerable<HolderChooseDto> Sizes { get; set; }
        public IEnumerable<HolderChooseDto> Types { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
