using Microsoft.AspNetCore.Mvc;
using System.Net;
using Voolt.Test.Backend.Api.Contracts;
using Voolt.Test.Backend.Api.Mapping;
using Voolt.Test.Data.Interfaces;
using Voolt.Test.Domain;

namespace Voolt.Backend.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IAdRepository _repository;

        public AdController(IAdRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetListOfAds")]
        public ApiResponse<IEnumerable<AdViewModel>> Get()
        {
            var response = _repository.GetAll();
            return new ApiResponse<IEnumerable<AdViewModel>> { 
                StatusCode = (int)HttpStatusCode.OK, 
                Success = true, 
                Data = response.Select(x => x.DomainToContract()), 
                Total = response.Count() 
            };
        }

        [HttpPost(Name = "CreateOrUpdate")]
        public ApiResponse<bool> CreateOrUpdate([FromBody] AdViewModel request)
        {
            try
            {
                if (request.AdId > 0)
                    _repository.Update(request.ContractToDomain());
                else
                    _repository.Create(request.ContractToDomain());

                return new ApiResponse<bool>
                {
                    Success = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = true,
                    Total = 1
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = false,
                    Total = 0
                };
            }
        }
    }
}
