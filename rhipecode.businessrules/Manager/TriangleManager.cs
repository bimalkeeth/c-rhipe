using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using rhipecode.businessrules.Resource;
using rhipecode.common.BusinessContract;
using rhipecode.common.Enums;
using rhipecode.common.Interfaces.Engine;
using rhipecode.common.Interfaces.Manager;

namespace rhipecode.businessrules.Manager
{
    public class TriangleManager:ITriangleManager
    {
        protected readonly ITriangularFactory _factory;
        public TriangleManager(ITriangularFactory factory)
        {
            _factory = factory;
        }
        public Points GetTriangle(string message)
        {

            message = message.ToLower();
            var resultPoints = new Points();
            var dataToProcess = new TriangularContractBO();
            if (string.IsNullOrEmpty(message))
            {
                throw new ValidationException(ValidationMessages.ExceptionRequestStringEmpty);
            }
            dataToProcess= GetTriangleProperties(message, dataToProcess);
            if(message.Contains(TriangleEnum.Equilateral.ToString().ToLower()))
            {
                return _factory.GetTriangularProcessor<IEquilateral>().Process(dataToProcess);
            }
            if(message.Contains(TriangleEnum.Isosceles.ToString().ToLower()))
            {
                return _factory.GetTriangularProcessor<IIsosceles>().Process(dataToProcess);
            }
            if(message.Contains(TriangleEnum.Scalene.ToString().ToLower()))
            {
                return _factory.GetTriangularProcessor<IScalene>().Process(dataToProcess);
            }
            return resultPoints;
        }

        private TriangularContractBO GetTriangleProperties(string message, TriangularContractBO processObject)
        {
           
            var heightIndex = message.Split("with").ToList();
            if (heightIndex.Count ==2)
            {
                var subList= heightIndex[1].Split("and").ToList();
                var sideCounter = 0;
                subList.ForEach(a =>
                {
                    if (a.Contains("height"))
                    {
                        processObject.Height=Convert.ToDouble( a.Substring(a.LastIndexOf("of", StringComparison.Ordinal)+2));
                    }
                    if (a.Contains("side"))
                    {
                        if (sideCounter == 0)
                        {
                            processObject.a=Convert.ToDouble( a.Substring(a.LastIndexOf("of", StringComparison.Ordinal)+2));
                        }
                        else
                        {
                            processObject.c=Convert.ToDouble( a.Substring(a.LastIndexOf("of", StringComparison.Ordinal)+2));
                        }

                        sideCounter++;
                    }
                    if (a.Contains("base"))
                    {
                        processObject.b=Convert.ToDouble( a.Substring(a.LastIndexOf("of", StringComparison.Ordinal)+2));
                    }
                }); 
                
            }
            
            return processObject;
        }
        
    }
}