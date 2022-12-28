using BigOn.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        static public IEnumerable<Category> GetAllChildren(this Category parent)
        {
            if (parent.ParentId != null)
                yield return parent;

            foreach (var item in parent.Children.SelectMany(c => c.GetAllChildren()))
            {
                yield return item;
            }
        }
    }
}
