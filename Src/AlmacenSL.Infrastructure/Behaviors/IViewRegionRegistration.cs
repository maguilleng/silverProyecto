using System;

namespace AlmacenSL.Infrastructure
{
    public interface IViewRegionRegistration
    {
        string RegionName { get; }
        bool IsActiveByDefault { get; }
    }
}
