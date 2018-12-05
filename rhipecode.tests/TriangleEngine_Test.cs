using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Moq;
using rhipecode.businessrules.Engine;
using rhipecode.common.BusinessContract;
using Xunit;
using Xunit.Abstractions;

namespace rhipecode.tests
{
    public class TriangleEngine_Test:IClassFixture<TriangleMockBase>
    {
        protected readonly TriangleMockBase _mockBase;
        protected readonly ITestOutputHelper _testOutputHelper;

        public TriangleEngine_Test(TriangleMockBase  mockBase,ITestOutputHelper testOutputHelper)
        {
            _mockBase = mockBase;
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact(DisplayName = "Engine Triangle Invalid Request for EquilateralEngine")]
        public void Engine_When_GetTriangle_WithEmpty_Request_Should_Return_ValidationException_EquilateralEngine()
        {
           
            var sut = new EquilateralEngine(_mockBase.triangleHelperMoq.Object);

            var riAngleInput = new TriangularContractBO{a = 400.00};

            _mockBase.triangleHelperMoq
                .Setup(s => s.IsTrianglePossible(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns(false);
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { sut.Process(riAngleInput); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 1);
            var exceptionResult = ((ValidationException) exceptions.FirstOrDefault()).Message;
            Assert.Contains(exceptionResult.Trim(),"Equilateral Triangle is not valid");

        }
        
        [Fact(DisplayName = "Engine Triangle Invalid Request for IsoscelesEngine")]
        public void Engine_When_GetTriangle_WithEmpty_Request_Should_Return_ValidationException_IsoscelesEngine()
        {
           
            var sut = new IsoscelesEngine(_mockBase.triangleHelperMoq.Object);

            var riAngleInput = new TriangularContractBO{Height = 200.00,b = 300};

            _mockBase.triangleHelperMoq
                .Setup(s => s.IsTrianglePossible(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns(false);
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { sut.Process(riAngleInput); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 1);
            var exceptionResult = ((ValidationException) exceptions.FirstOrDefault()).Message;
            Assert.Contains(exceptionResult.Trim()," Isosceles Triangle is not valid");

        }
        
        [Fact(DisplayName = "Engine Triangle Invalid Request for IsoscelesEngine")]
        public void Engine_When_GetTriangle_WithEmpty_Request_Should_Return_ValidationException_When_BaseSmaller_ScaleneEngine()
        {
           
            var sut = new ScaleneEngine(_mockBase.triangleHelperMoq.Object);

            var riAngleInput = new TriangularContractBO{Height = 100.00,b = 10};

            _mockBase.triangleHelperMoq
                .Setup(s => s.IsTrianglePossible(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns(false);
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { sut.Process(riAngleInput); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 1);
            var exceptionResult = ((ValidationException) exceptions.FirstOrDefault()).Message;
            Assert.Contains(exceptionResult.Trim(),"ScaleneEngine Triangle is not valid");

        }
        
        [Fact(DisplayName = "Engine Triangle Invalid Request for IsoscelesEngine")]
        public void Engine_When_GetTriangle_WithEmpty_Request_Should_Return_ValidationException_When_HeightGreater_ScaleneEngine()
        {
           
            var sut = new ScaleneEngine(_mockBase.triangleHelperMoq.Object);

            var riAngleInput = new TriangularContractBO{Height = 100.00,b = 100,a = 5};

            _mockBase.triangleHelperMoq
                .Setup(s => s.IsTrianglePossible(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                .Returns(false);
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { sut.Process(riAngleInput); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 1);
            var exceptionResult = ((ValidationException) exceptions.FirstOrDefault()).Message;
            Assert.Contains(exceptionResult.Trim(),"ScaleneEngine Triangle is not valid");

        }
        
    }
}