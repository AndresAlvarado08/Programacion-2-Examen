namespace Pokemon.Services
{
    public class Pokemon
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string URL { get; set; }

        public required List<string> Moves { get; set; }
    }
}