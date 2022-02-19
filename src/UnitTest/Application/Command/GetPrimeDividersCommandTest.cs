using Application.Commands;
using Infra;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Application.Command
{
    public class GetPrimeDividersCommandTest
    {
        public readonly GetPrimeDividersCommand.Handler _handler;

        public GetPrimeDividersCommandTest()
        {
            _handler = new GetPrimeDividersCommand.Handler();
        }

        [Theory(DisplayName = "GetPrimeDividersCommand Test Sucess")]
        [MemberData(nameof(DataPrimeDividersSucess))]
        public void GetPrimeDividersCommandSucess(int inputNumber, List<int> primeDividers)
        {
            ///Arrange
            GetPrimeDividersCommand.Contract contract = new GetPrimeDividersCommand.Contract()
            {
                Number = inputNumber
            };

            /// Act
            Result<List<int>> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(primeDividers, result.Data);
        }

        [Theory(DisplayName = "GetPrimeDividersCommand Test Fail")]
        [MemberData(nameof(DataPrimeDividersFail))]
        public void GetPrimeDividersCommandFail(int inputNumber, List<int> primeDividers)
        {
            ///Arrange
            GetPrimeDividersCommand.Contract contract = new GetPrimeDividersCommand.Contract()
            {
                Number = inputNumber
            };

            /// Act
            Result<List<int>> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Valor precisa ser maior que zero.", result.Error);
        }

        [Fact(DisplayName = "GetPrimeDividersCommand Test Fail Request Null")]
        public void GetPrimeDividersCommandFailRequestNull()
        {
            ///Arrange
            GetPrimeDividersCommand.Contract contract = null;

            /// Act
            Result<List<int>> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Request não pode ser null.", result.Error);
            Assert.Null(result.Data);
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

        public static IEnumerable<object[]> DataPrimeDividersFail => new List<object[]>
        {
            new object[] { 0, new List<int> { 1, 3, 5 } }
        ,
            new object[] { -9, new List<int> { 1, 3 } }
        ,
            new object[] { -12, new List<int> { 1, 2, 3 } }
        ,
            new object[] { -24, new List<int> { 1, 2, 3 } }
        };
    }
}
