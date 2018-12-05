using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using rhipecode.businessrules.Manager;
using rhipecode.common.Interfaces.Engine;
using Xunit;
using Xunit.Abstractions;
using Moq;
using rhipecode.common.BusinessContract;

namespace rhipecode.tests
{
    public class TriangleManager_Test:IClassFixture<TriangleMockBase>
    {
        protected readonly TriangleMockBase _mockBase;
        protected readonly ITestOutputHelper _testOutputHelper;

        public TriangleManager_Test(TriangleMockBase  mockBase,ITestOutputHelper testOutputHelper)
        {
            _mockBase = mockBase;
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact(DisplayName = "Manager Triangle Invalid Request")]
        public void  Manager_When_GetTriangle_WithEmpty_Request_Should_Return_ValidationException()
        {
           
            var sut = new TriangleManager(_mockBase.engineTriangularFactoryMoq.Object);

            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { sut.GetTriangle(string.Empty); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 1);
            var exceptionResult = ((ValidationException) exceptions.FirstOrDefault()).Message;
            Assert.Contains(exceptionResult.Trim(),"Request string is empty or null");

        }
        
        [Fact(DisplayName = "Manager Triangle Invalid Request")]
        public void  Manager_When_GetTriangle_WithValidRequest_Request_Should_Return_ValidTriangle_For_Equilateral()
        {
            var PointsResult=new Points();
            var sut = new TriangleManager(_mockBase.engineTriangularFactoryMoq.Object);

            _mockBase.engineTriangularFactoryMoq.Setup(s => s.GetTriangularProcessor<IEquilateral>())
                .Returns(_mockBase.engineEquilateralMoq.Object);

            _mockBase.engineEquilateralMoq.Setup(s => s.Process(It.IsAny<TriangularContractBO>()))
                .Returns(new Points
                {
                    PointA = new Point2D(0,1),
                    PointB = new Point2D(175,125),
                    PointC = new Point2D(0,126)
                });
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { PointsResult=sut.GetTriangle("Draw an equilateral triangle with side of 400 "); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0);
            Assert.IsType<Points>(PointsResult);
            Assert.Equal(PointsResult.PointA.X, 0);
            Assert.Equal(PointsResult.PointA.Y, 1);
            
            Assert.Equal(PointsResult.PointB.X, 175);
            Assert.Equal(PointsResult.PointB.Y, 125);

            Assert.Equal(PointsResult.PointC.X, 0);
            Assert.Equal(PointsResult.PointC.Y, 126);

        }
        
        [Fact(DisplayName = "Manager Triangle Invalid Request")]
        public void  Manager_When_GetTriangle_WithValidRequest_Request_Should_Return_ValidTriangle_For_Isosceles ()
        {
            var PointsResult=new Points();
            var sut = new TriangleManager(_mockBase.engineTriangularFactoryMoq.Object);

            _mockBase.engineTriangularFactoryMoq.Setup(s => s.GetTriangularProcessor<IIsosceles>())
                .Returns(_mockBase.engineEquilateralMoq.Object);

            _mockBase.engineEquilateralMoq.Setup(s => s.Process(It.IsAny<TriangularContractBO>()))
                .Returns(new Points
                {
                    PointA = new Point2D(0,1),
                    PointB = new Point2D(175,125),
                    PointC = new Point2D(0,126)
                });
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { PointsResult=sut.GetTriangle("Draw an isosceles triangle with a height of 200 and a base of 100 "); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0);
            Assert.IsType<Points>(PointsResult);
            Assert.Equal(PointsResult.PointA.X, 0);
            Assert.Equal(PointsResult.PointA.Y, 1);
            
            Assert.Equal(PointsResult.PointB.X, 175);
            Assert.Equal(PointsResult.PointB.Y, 125);

            Assert.Equal(PointsResult.PointC.X, 0);
            Assert.Equal(PointsResult.PointC.Y, 126);

        }
        
        [Fact(DisplayName = "Manager Triangle Invalid Request")]
        public void  Manager_When_GetTriangle_WithValidRequest_Request_Should_Return_ValidTriangle_For_IScalene ()
        {
            var PointsResult=new Points();
            var sut = new TriangleManager(_mockBase.engineTriangularFactoryMoq.Object);

            _mockBase.engineTriangularFactoryMoq.Setup(s => s.GetTriangularProcessor<IScalene>())
                .Returns(_mockBase.engineEquilateralMoq.Object);

            _mockBase.engineEquilateralMoq.Setup(s => s.Process(It.IsAny<TriangularContractBO>()))
                .Returns(new Points
                {
                    PointA = new Point2D(0,1),
                    PointB = new Point2D(300,203),
                    PointC = new Point2D(0,126)
                });
            
            var exceptions = new List<Exception>();
            var errorValidated = Record.Exception(() => { PointsResult=sut.GetTriangle("Draw an Scalene triangle with a height of 200 and a base of 100  and side of 300"); });

            if (errorValidated != null)
            {
                _testOutputHelper.WriteLine(" Error in Testing Triangular Manager");
                exceptions.Add(errorValidated);
            }
            Assert.Equal(exceptions.Count, 0);
            Assert.IsType<Points>(PointsResult);
            Assert.Equal(PointsResult.PointA.X, 0);
            Assert.Equal(PointsResult.PointA.Y, 1);
            
            Assert.Equal(PointsResult.PointB.X, 300);
            Assert.Equal(PointsResult.PointB.Y, 203);

            Assert.Equal(PointsResult.PointC.X, 0);
            Assert.Equal(PointsResult.PointC.Y, 126);

        }
    }
}