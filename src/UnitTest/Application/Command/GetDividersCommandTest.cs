using Application.Commands;
using Infra;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Application.Command
{
    public class GetDividersCommandTest
    {
        public readonly GetDividersCommand.Handler _handler;

        public GetDividersCommandTest()
        {
            _handler = new GetDividersCommand.Handler();
        }

        [Theory(DisplayName = "GetDividersCommand Test Sucess")]
        [MemberData(nameof(DataDividersSucess))]
        public void GetDividersCommandSucess(int inputNumber, List<int> dividers)
        {
            ///Arrange
            GetDividersCommand.Contract contract = new GetDividersCommand.Contract()
            {
                Number = inputNumber
            };

            /// Act
            Result<List<int>> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(dividers, result.Data);
        }

        [Theory(DisplayName = "GetDividersCommand Test Fail")]
        [MemberData(nameof(DataDividersFail))]
        public void GetDividersCommandFail(int inputNumber, List<int> dividers)
        {
            ///Arrange
            GetDividersCommand.Contract contract = new GetDividersCommand.Contract()
            {
                Number = inputNumber
            };

            /// Act
            Result<List<int>> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Valor precisa ser maior que zero.", result.Error);
        }

        [Fact(DisplayName = "GetDividersCommand Test Fail Request Null")]
        public void GetDividersCommandFailRequestNull()
        {
            ///Arrange
            GetDividersCommand.Contract contract = null;

            /// Act
            Result<List<int>> result = _handler.Handle(contract, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            ///Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Request não pode ser null.", result.Error);
            Assert.Null(result.Data);
        }

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
            new object[] { 0, new List<int> { 1, 3, 5, 9, 15, 45 } }
        ,
            new object[] { -9, new List<int> { 1, 3, 9 } }
        ,
            new object[] { -12, new List<int> { 1, 2, 3, 4, 6, 12 } }
        ,
            new object[] { -24, new List<int> { 1, 2, 3, 4, 6, 8, 12, 24 } }
        };
    }
}
