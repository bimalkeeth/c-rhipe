using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rhipecode.businessrules.Resource;
using rhipecode.common.BusinessContract;
using rhipecode.common.Interfaces.Manager;
using rhipecode.ui.Contract;

namespace rhipecode.ui.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TriangularApiController : Controller
    {
        protected readonly ITriangleManager _triangleManager;
        protected readonly IMapper _mapper;

        public TriangularApiController(ITriangleManager triangleManager,IMapper mapper)
        {
            _triangleManager = triangleManager;
            _mapper = mapper;
        }
        [HttpPut("[action]")]
        public IActionResult ProcessData([FromBody]RequestVM request)
        {
            var requestResult= _triangleManager.GetTriangle(request.RequestData);
            if (requestResult != null)
            {
                return Ok(requestResult);
            }
            return NotFound(ValidationMessages.ExceptionRecordNotFoundTriangle);
        } 
    }
}