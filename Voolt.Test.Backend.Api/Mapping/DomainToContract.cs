using Voolt.Test.Domain;

namespace Voolt.Test.Backend.Api.Mapping
{
    public static class DomainToContractMapper
    {
        public static AdViewModel DomainToContract(this Ad model)
        {
            return new AdViewModel
            {
                AdId = model.AdId,
                AdBalance = model.AdBalance,
                AdCreationDate = model.AdCreationDate,
                AdDescription = model.AdDescription,
                AdExternalId = model.AdExternalId,
                AdStatus = model.AdStatus,
                AdTotalLead = model.AdTotalLead
            };
        }
    }
}