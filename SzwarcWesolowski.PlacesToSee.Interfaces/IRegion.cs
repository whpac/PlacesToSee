namespace SzwarcWesolowski.PlacesToSee.Interfaces
{
    public interface IRegion
    {
        int Id { get; }
        string Name { get; set; }
        string PhotoUrl { get; set; }
    }
}
