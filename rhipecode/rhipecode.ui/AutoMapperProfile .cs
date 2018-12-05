using AutoMapper;
using rhipecode.common.BusinessContract;
using rhipecode.ui.Contract;

namespace rhipecode.ui
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TriangularContractBO, TriangularContractVM>();
            CreateMap<RequestVM, RequestBO>();
        }
    }
}