namespace SzwarcWesolowski.PlacesToSee.Interfaces
{
    public interface ICountry
    {
        int Id { get; }
        string Name { get; set; }
        string FlagUrl { get; set; }
    }
}
