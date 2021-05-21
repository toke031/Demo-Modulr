using Juice_Demo_Modulr.Core.Client;
using Juice_Demo_Modulr.Core.Managers;
using Juice_Demo_Modulr.Core.Requests;
using Juice_Demo_Modulr.Core.Responses;
using Juice_Demo_Modulr.Core.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ModulrTest
    {
        private readonly string _customerId = "***********";
        private readonly CustomerManager _customerManager;
        public ModulrTest()
        {
            _customerManager = new CustomerManager();
        }

        [TestMethod]
        public void Authorization()
        {
            string secret = "**************************************";
            string signatureString = "date: Wed, 30 Dec 2020 10:41:38 GMT\nx-mod-nonce: ********************************";
            string expectedSignature = "************************************";

            ModulrClient modulrClient = new ModulrClient();
            string signature = modulrClient.GetSignature(secret, signatureString);
            Assert.AreEqual(expectedSignature, signature, "Signature is not correctly.");
        }

        [TestMethod]
        public async Task CloseAllCustomerAccounts()
        {
            var getAllCustomerAccountResponse = await _customerManager.GetAllCustomerAccount(_customerId, "GBP");
            ResponseBase response = new ResponseBase();
            if (getAllCustomerAccountResponse.Content.Length > 0)
            {
                foreach (var account in getAllCustomerAccountResponse.Content)
                {
                    response = await _customerManager.CloseAccount(account.Id);
                }
                Assert.AreEqual("200", ((int)response.StatusCode).ToString(), $"Bad request. Accounts are not closed.");
            }
            else
            {
                Assert.AreEqual(0, 0);
            }
        }

        /// <summary>
        /// Creates the main account.
        /// </summary>
        [TestMethod]
        public async Task Test1()
        {
            CreateCustomerAccountRequest request = new CreateCustomerAccountRequest()
            {
                Currency = "GBP",
                ExternalReference = "Main Account"
            };
            var response = await _customerManager.CreateCustomerAccount(_customerId, request);
            Assert.AreEqual("201", ((int)response.StatusCode).ToString(), $"Bad request. Customer main account is not created.");
        }

        /// <summary>
        /// Creates the beneficiary account.
        /// </summary>
        [TestMethod]
        public async Task Test2()
        {
            CreateBeneficiaryAccountRequest request = new CreateBeneficiaryAccountRequest()
            {
                Address = new Address()
                {
                    AddressLine1 = "2a",
                    AddressLine2 = "The Quadrant",
                    PostTown = "Epsom",
                    PostCode = "KT17 4RH",
                    Country = "GB"
                },
                BirthDate = null,
                DefaultReference = "Reference Message",
                DestinationIdentifier = new DestinationIdentifier()
                {
                    AccountNumber = "11275497",
                    Bic = "MODRGB2L",
                    CountrySpecificDetails = null,
                    Currency = "GBP",
                    Iban = null,
                    SortCode = "160015",
                    Type = "SCAN"
                },
                EmailAddress = null,
                ExternalReference = "External reference",
                IdToReplace = null,
                Name = "Beneficiary test",
                PhoneNumber = null,
                Qualifier = null
            };
            var response = await _customerManager.CreateBeneficiaryAccount(_customerId, request);
            Assert.AreEqual("201", ((int)response.StatusCode).ToString(), $"Bad request. Beneficiary account is not created.");
        }

        /// <summary>
        /// Creates the sweep account.
        /// </summary>
        [TestMethod]
        public async Task Test3()
        {
            CreateCustomerAccountRequest request = new CreateCustomerAccountRequest()
            {
                Currency = "GBP",
                ExternalReference = "Sweep Account"
            };
            var response = await _customerManager.CreateCustomerAccount(_customerId, request);
            Assert.AreEqual("201", ((int)response.StatusCode).ToString(), $"Bad request. Customer sweep account is not created.");
        }
        /// <summary>
        /// Creates the rule.
        /// </summary>
        [TestMethod]
        public async Task Test4()
        {
            var getAllCustomerAccountResponse = await _customerManager.GetAllCustomerAccount(_customerId, "GBP");
            var sweepAccount = getAllCustomerAccountResponse.Content.Where(x => x.ExternalReference == "Sweep Account").FirstOrDefault();
            var beneficiaryAccount = await _customerManager.GetAllBeneficiariesAccount(_customerId);


            CreateRuleRequest request = new CreateRuleRequest()
            {
                AccountId = sweepAccount.Id,
                CustomerId = _customerId,
                Name = "Test rule",
                Type = "SWEEP",
                Data = new RuleDetails()
                {
                    DestinationId = beneficiaryAccount.Content[0].Id,
                    BalanceToLeave = "20000",
                    TriggerBalance = "20000",
                    DaysToRun = new string[]
                    {
                        "MONDAY",
                        "TUESDAY",
                        "WEDNESDAY",
                        "THURSDAY",
                        "FRIDAY",
                        "SATURDAY",
                        "SUNDAY"
                    },
                    Frequency = "Daily"
                }
            };
            var response = await _customerManager.CreateRule(request);
            Assert.AreEqual("201", ((int)response.StatusCode).ToString(), $"Bad request. Rule is not created.");
        }

        /// <summary>
        /// Creates the virutal card.
        /// </summary>
        [TestMethod]
        public async Task Test5()
        {
            var getAllCustomerAccountResponse = await _customerManager.GetAllCustomerAccount(_customerId, "GBP");

            var mainAccount = getAllCustomerAccountResponse.Content.Where(x => x.ExternalReference == "Main Account").FirstOrDefault();
            CreateVirtualCardRequest request = new CreateVirtualCardRequest()
            {
                Expiry = "2021-06",
                ExternalRef = "Card for AD",
                CardHoleder = new CardHolder()
                {
                    AddressDetail = new Address()
                    {
                        AddressLine1 = "2a",
                        AddressLine2 = "The Quadrant",
                        Country = "GB",
                        PostCode = "KT17 4RH",
                        PostTown = "Epsom"
                    },
                    DateOfBirth = "1987-12-15",
                    FirstName = "Oliver",
                    LastName = "Joshi",
                    MobileNumber = "06063424323",
                    Title = "Some Title"
                },
                Limit = 5000,
                ProductCode = "O120001M"
            };
            var response = await _customerManager.CreateVirtualCard(mainAccount.Id, request);

            Assert.AreEqual("201", ((int)response.StatusCode).ToString(), $"Bad request. Virtual card is not created.");
        }

        /// <summary>
        /// Creates the inbound payment.
        /// </summary>
        [TestMethod]
        public async Task Test6()
        {
            var getAllCustomerAccountResponse = await _customerManager.GetAllCustomerAccount(_customerId, "GBP");
            var sweepAccount = getAllCustomerAccountResponse.Content.Where(x => x.ExternalReference == "Sweep Account").FirstOrDefault();
            var juiceAccount = "70295905";
            InboundPaymentRequest request = new InboundPaymentRequest()
            {
                AccountId = sweepAccount.Id,
                Amount = 50000,
                NumberOfTransactions = 1,
                PayeeDetail = null,
                PayerDetail = new Detail()
                {
                    Address = new Address()
                    {
                        AddressLine1 = "2a",
                        AddressLine2 = "The Quadrant",
                        PostTown = "Epsom",
                        PostCode = "KT17 4RH",
                        Country = "GB"
                    },
                    Identifier = new DestinationIdentifier()
                    {
                        AccountNumber = juiceAccount,
                        Bic = null,
                        CountrySpecificDetails = null,
                        Currency = "GBP",
                        Iban = null,
                        SortCode = "000000",
                        Type = "SCAN"
                    },
                    Name = "Some Name"
                },
                TransactionDate = null,
                Type = "PI_BACS",
                Description = "Some description"
            };

            var response = await _customerManager.CreateInboundPayment(request);
            Assert.AreEqual("200", ((int)response.StatusCode).ToString(), $"Bad request.");

        }

        /// <summary>
        /// Create Payment.
        /// </summary>
        [TestMethod]
        public async Task Test7()
        {
            var getAllCustomerAccountResponse = await _customerManager.GetAllCustomerAccount(_customerId, "GBP");
            var sweepAccount = getAllCustomerAccountResponse.Content.Where(x => x.ExternalReference == "Sweep Account").First();
            CreatePaymentRequest request = new CreatePaymentRequest()
            {
                Amount = 50000,
                Currency = "GBP",
                SourceAccountId = sweepAccount.Id,
                Destination = new DestinationPaymentIdentifier()
                {
                    AccountNumber = "70295905",
                    Type = "SCAN",
                    SortCode = "000000",
                    Name = "Some name"
                },
                Reference = "39104k4032"
            };
            var response = await _customerManager.CreatePayment(request);
            Assert.AreEqual("201", ((int)response.StatusCode).ToString(), $"Payment is not created");
        }

        /// <summary>
        /// Deletes the rule.
        /// </summary>
        [TestMethod]
        public async Task Test8()
        {
            var getAllCustomerAccountResponse = await _customerManager.GetAllCustomerAccount(_customerId, "GBP");

            var sweepAccount = getAllCustomerAccountResponse.Content.Where(x => x.ExternalReference == "Sweep Account").FirstOrDefault();
            var getAllAccountRulesResponse = await _customerManager.GetAllAccountRules(sweepAccount.Id);
            var response = await _customerManager.DeleteRule(new string[] { getAllAccountRulesResponse.Content[0].Id });
            Assert.AreEqual("200", ((int)response.StatusCode).ToString(), $"Bad request. Rule is not deleted.");
        }
       
        /// <summary>
        /// Deletes the beneficiary.
        /// </summary>
        [TestMethod]
        public async Task Test9()
        {
            var getBeneficiaryAccount = await _customerManager.GetAllBeneficiariesAccount(_customerId);
            var response = await _customerManager.DeleteBeneficiaryAccount(_customerId, getBeneficiaryAccount.Content[0].Id);
            Assert.AreEqual("200", ((int)response.StatusCode).ToString(), $"Beneficiary account is not deleted.");
        }

    }
}
