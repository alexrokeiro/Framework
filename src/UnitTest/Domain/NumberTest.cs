using Domain;
using Infra;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Domain
{
    public class NumberTest
    {
        [Theory(DisplayName = "GetDividers Test Sucess")]
        [MemberData(nameof(DataDividersSucess))]
        public void GetDividersSucess(int inputNumber, List<int> dividers)
        {
            ///Arrange

            /// Act
            DomainResult<Number> domainResult = Number.Create(inputNumber);
            var result = domainResult.Model.GetDividers();

            ///Assert
            Assert.True(domainResult.IsSucess);
            Assert.Equal(dividers, result);
        }

        [Theory(DisplayName = "GetDividers Test Fail")]
        [MemberData(nameof(DataDividersFail))]
        public void GetDividersFail(int inputNumber)
        {
            ///Arrange

            /// Act
            DomainResult<Number> domainResult = Number.Create(inputNumber);

            ///Assert
            Assert.False(domainResult.IsSucess);
            Assert.Equal("Valor precisa ser maior que zero.", domainResult.Error);
        }

        [Theory(DisplayName = "GetPrimeDividers Test Sucess")]
        [MemberData(nameof(DataPrimeDividersSucess))]
        public void GetPrimeDividersSucess(int inputNumber, List<int> dividers)
        {
            ///Arrange

            /// Act
            DomainResult<Number> domainResult = Number.Create(inputNumber);
            var result = domainResult.Model.GetPrimeDividers();

            ///Assert
            Assert.Equal(dividers, result);
        }

        [Theory(DisplayName = "GetPrimeDividers Test Fail")]
        [MemberData(nameof(DataPrimeDividersFail))]
        public void GetPrimeDividersFail(int inputNumber)
        {
            ///Arrange

            /// Act
            DomainResult<Number> domainResult = Number.Create(inputNumber);

            ///Assert
            Assert.False(domainResult.IsSucess);
            Assert.Equal("Valor precisa ser maior que zero.", domainResult.Error);
        }

        public static IEnumerable<object[]> DataPrimeDividersSucess => new List<object[]>
        {
            new object[] { 45, new List<int> { 1, 3, 5 } }
        ,
            new object[] { 9, new List<int> { 1, 3 } }
        ,
            new object[] { 12, new List<int> { 1, 2, 3 } }
        ,
            new object[] { 24, new List<int> { 1, 2, 3 } }
        ,
            new object[] { 1, new List<int> { 1 } }
        };


        public static IEnumerable<object[]> DataDividersSucess => new List<object[]>
        {
            new object[] { 45, new List<int> { 1, 3, 5, 9, 15, 45 } }
        ,
            new object[] { 9, new List<int> { 1, 3, 9 } }
        ,
            new object[] { 12, new List<int> { 1, 2, 3, 4, 6, 12 } }
        ,
            new object[] { 24, new List<int> { 1, 2, 3, 4, 6, 8, 12, 24 } }
        ,
            new object[] { 1, new List<int> { 1 } }
        };

        public static IEnumerable<object[]> DataDividersFail => new List<object[]>
        {
            new object[] { 0 }
        ,
            new object[] { -9}
        ,
            new object[] { -12}
        ,
            new object[] { -24}
        };

        public static IEnumerable<object[]> DataPrimeDividersFail => new List<object[]>
        {
            new object[] { 0}
        ,
            new object[] { -9}
        ,
            new object[] { -12}
        ,
            new object[] { -24}
        };
    }
}
