using Voolt.Test.Domain;

namespace Voolt.Test.Backend.Api.Mapping
{
    public static class ContractToDomainMapper
    {
        public static Ad ContractToDomain(this AdViewModel viewModel)
        {
            return new Ad
            {
                AdId = viewModel.AdId,
                AdBalance = viewModel.AdBalance,
                AdCreationDate = viewModel.AdCreationDate,
                AdDescription = viewModel.AdDescription,
                AdExternalId = viewModel.AdExternalId,
                AdStatus = viewModel.AdStatus,
                AdTotalLead = viewModel.AdTotalLead
            };
        }
    }
}
