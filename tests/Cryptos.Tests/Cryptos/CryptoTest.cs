using Cryptos.Application.Cryptos.Dtos;
using Cryptos.Application.Values.Dtos;
using Cryptos.Core.Filtering;
using Shouldly;
using System.Linq;
using Xunit;

namespace Cryptos.Tests.Values
{
    public class CryptoTest : ApplicationTester
    {
        private string _secondCryptoName = "Second";

        public CryptoTest() : base()
        {
        }

        [Fact]
        public void Delete()
        {
            var Crypto = CryptoService.Insert(new CryptoCreationDto()
            {
                Description = "empty description",
                FirstValue = new ValueCreationDto()
                {
                    Amount = 0
                },
                Name = "Delete pending"
            });

            CryptoService.DeleteById(Crypto.Id);

            var DeletedCrypto = CryptoService.GetById(Crypto.Id);
            DeletedCrypto.ShouldBeNull();
        }

        [Fact]
        public void GetAll()
        {
            var Cryptos = CryptoService.GetAll();

            Cryptos.TotalCount.ShouldBe(2);
            Cryptos.CurrentPage.ShouldBeNull();
            Cryptos.Items.Count().ShouldBe(2);
            Cryptos.Items.Last().Name.ShouldBe(_secondCryptoName);
        }

        [Fact]
        public void GetByFilters()
        {
            var Cryptos = CryptoService.GetByFilters(new FilteringOptions() { Keyword = _secondCryptoName, MaxResultCount = 10 });

            Cryptos.ShouldNotBeNull();
            Cryptos.TotalCount.ShouldBe(1);
            Cryptos.CurrentPage.ShouldBe(1);
            Cryptos.Items.Count().ShouldBe(1);
            Cryptos.Items.First().Name.ShouldBe(_secondCryptoName);
        }

        [Fact]
        public void Insert()
        {
            var Crypto = CryptoService.Insert(new CryptoCreationDto()
            {
                Description = "empty description",
                FirstValue = new ValueCreationDto()
                {
                    Amount = 3
                },
                Name = "Third"
            });

            Crypto.ShouldNotBeNull();
            Crypto.Name.ShouldBe("Third");
            Crypto.LastCryptoValue.ShouldBe(3);
        }

        [Fact]
        public void Update()
        {
            var Crypto = CryptoService.Insert(new CryptoCreationDto()
            {
                Description = "empty description",
                FirstValue = new ValueCreationDto()
                {
                    Amount = 0
                },
                Name = "Update pending"
            });

            var updatedCrypto = CryptoService.Update(new CryptoUpdateDto()
            {
                Id = Crypto.Id,
                Description = "empty description",
                Name = "Updated"
            });

            updatedCrypto.ShouldNotBeNull();
            updatedCrypto.Name.ShouldBe("Updated");
        }

        protected override void SetUp()
        {
            base.SetUp();

            var Crypto2 = new CryptoCreationDto()
            {
                Name = _secondCryptoName,
                Description = "Second fake Crypto for testing purposes",
            };

            CryptoService.Insert(Crypto2);
        }
    }
}