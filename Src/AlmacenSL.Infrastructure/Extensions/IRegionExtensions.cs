using System;
using Microsoft.Practices.Prism.Regions;

namespace AlmacenSL.Infrastructure
{
    public static class IRegionExtensions
    {
        public static void ClearActiveViews(this IRegion region)
        {
            foreach (var v in region.ActiveViews)
            {
                region.Deactivate(v);
            }
        }
    }
}
