using Application.Commands;
using Application.Dto;
using Infra;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Application.Command
{
    public class GetDividersAndPrimeDividersCommandTest
    {
        public readonly GetDividersAndPrimeDividersCommand.Handler _handler;

        public GetDividersAndPrimeDividersCommandTest()
        {
            _handler = new GetDividersAndPrimeDividersCommand.Handler();
        }

        [Theory(DisplayName = "GetDividersAndPrimeDividersCommand Test Sucess")]
        [MemberData(nameof(DataDividersAndPrimeDividersSucess))]
        public void GetDividersAndPrimeDividersCommandSucess(int inputNumber, List<int> dividers, List<int> primeDividers)
        {
            ///Arrange
            GetDividersAndPrimeDividersCommand.Contract contract = new GetDividersAndPrimeDividersCommand.Contract()
            {
                Number = inputNumber
            };

            /// Act
            Result<GetDividersAndPrimeDividersDTO> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(dividers, result.Data.Dividers);
            Assert.Equal(primeDividers, result.Data.PrimeDividers);
        }

        [Theory(DisplayName = "GetDividersAndPrimeDividersCommand Test Fail")]
        [MemberData(nameof(DataDividersAndPrimeDividersFail))]
        public void GetDividersAndPrimeDividersCommandFail(int inputNumber)
        {
            ///Arrange
            GetDividersAndPrimeDividersCommand.Contract contract = new GetDividersAndPrimeDividersCommand.Contract()
            {
                Number = inputNumber
            };

            /// Act
            Result<GetDividersAndPrimeDividersDTO> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Valor precisa ser maior que zero.", result.Error);
            Assert.Null(result.Data);
        }

        [Fact(DisplayName = "GetDividersAndPrimeDividersCommand Test Fail Request Null")]
        public void GetDividersAndPrimeDividersCommandFailRequestNull()
        {
            ///Arrange
            GetDividersAndPrimeDividersCommand.Contract contract = null;

            /// Act
            Result<GetDividersAndPrimeDividersDTO> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Request não pode ser null.", result.Error);
            Assert.Null(result.Data);
        }

        public static IEnumerable<object[]> DataDividersAndPrimeDividersSucess => new List<object[]>
        {
            new object[] { 45, new List<int> { 1, 3, 5, 9, 15, 45 }, new List<int> { 1, 3, 5 } }
        ,
            new object[] { 9, new List<int> { 1, 3, 9 }, new List<int> { 1, 3 } }
        ,
            new object[] { 12, new List<int> { 1, 2, 3, 4, 6, 12 }, new List<int> { 1, 2, 3 } }
        ,
            new object[] { 24, new List<int> { 1, 2, 3, 4, 6, 8, 12, 24 }, new List<int> { 1, 2, 3 } }
        ,
            new object[] { 1, new List<int> { 1 }, new List<int> { 1 } }
        };

        public static IEnumerable<object[]> DataDividersAndPrimeDividersFail => new List<object[]>
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
