﻿using SzwarcWesolowski.PlacesToSee.Core;

namespace SzwarcWesolowski.PlacesToSee.Interfaces
{
    public interface IPlace
    {
        string Name { get; }
        PlaceType PlaceType { get; }
        Coordinates Location { get; }

        ICountry Country { get; }
        IRegion Region { get; }
    }
}