using Cryptos.Application.Values.Dtos;
using Shouldly;
using System.Linq;
using Xunit;

namespace Cryptos.Tests.Values
{
    public class ValueTest : ApplicationTester
    {
        public ValueTest() : base()
        {
        }

        [Fact]
        public void GetAll()
        {
            var values = ValueService.GetAll();

            values.TotalCount.ShouldBe(2);
            values.CurrentPage.ShouldBeNull();
            values.Items.Count().ShouldBe(2);
            values.Items.First().Amount.ShouldBe(1);
        }

        [Fact]
        public void GetByCryptoId()
        {
            var values = ValueService.GetByCryptoId(Crypto.Id);

            values.ShouldNotBeNull();
            values.TotalCount.ShouldBe(2);
            values.CurrentPage.ShouldBeNull();
            values.Items.Count().ShouldBe(2);
            values.Items.First().Amount.ShouldBe(2);
        }

        [Fact]
        public void Insert()
        {
            var value = ValueService.Insert(new ValueCreationDto()
            {
                Amount = 3,
                CryptoId = Crypto.Id
            });

            value.ShouldNotBeNull();
            value.CryptoId.ShouldBe(Crypto.Id);
            value.CryptoName.ShouldBe(Crypto.Name);
        }
    }
}