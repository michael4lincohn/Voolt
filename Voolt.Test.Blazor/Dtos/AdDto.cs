namespace Voolt.Test.Blazor.Dtos
{
    public class AdDto
    {
        public int AdId { get; set; }
        public string AdDescription { get; set; }
        public DateTime AdCreationDate { get; set; }
        public int AdStatus { get; set; }
        public decimal? AdBalance { get; set; }
        public string? AdExternalId { get; set; }
        public int AdTotalLead { get; set; }
    }

    public enum Status
    {
        Active,
        Paused
    }
}