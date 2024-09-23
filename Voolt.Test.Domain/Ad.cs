namespace Voolt.Test.Domain
{
    public class Ad
    {
        public int AdId { get; set; }
        public string AdDescription { get; set; }
        public DateTime AdCreationDate { get; set; }
        public Status AdStatus { get; set; }
        public decimal? AdBalance { get; set; }
        public string? AdExternalId { get; set; }
        public int AdTotalLead { get; set; }
    }
}