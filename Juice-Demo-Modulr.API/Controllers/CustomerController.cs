using API.Validation;
using Juice_Demo_Modulr.Core.Managers;
using Juice_Demo_Modulr.Core.Requests;
using Juice_Demo_Modulr.Core.Responses;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [AllowAnonymous]
    public class CustomerController : ApiController
    {
        #region Fields        
        /// <summary>
        /// The customer manager
        /// </summary>
        private readonly CustomerManager _customerManager;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        public CustomerController()
        {
            _customerManager = new CustomerManager();
        }
        #endregion
        #region Get methods        
        /// <summary>
        /// Gets all customer accounts.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="currency">The currency.</param>
        [HttpGet]
        public async Task GetAllCustomerAccounts(string customerId, string currency)
        {
            await _customerManager.GetAllCustomerAccount(customerId, currency);
        }
        #endregion
        #region Post methods        
        /// <summary>
        /// Creates the inbound payment.
        /// </summary>
        /// <param name="request">The request.</param>
        [HttpPost]
        public async Task CreateInboundPayment(InboundPaymentRequest request)
        {
            await _customerManager.CreateInboundPayment(request);
        }

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        [ValidateModel]
        [HttpPost]
        public async Task CreateCustomer(CreateCustomerRequest request)
        {
            await _customerManager.CreateCustomer(request);
        }

        /// <summary>
        /// Creates the new customer account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="request">The request.</param>
        [ValidateModel]
        [HttpPost]
        public async Task CreateNewCustomerAccount(string customerId, CreateCustomerAccountRequest request)
        {
            await _customerManager.CreateCustomerAccount(customerId, request);
        }

        /// <summary>
        /// Creates the new customer beneficiary account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="request">The request.</param>
        [ValidateModel]
        [HttpPost]
        public async Task CreateNewCustomerBeneficiaryAccount(string customerId, CreateBeneficiaryAccountRequest request)
        {
            await _customerManager.CreateBeneficiaryAccount(customerId, request);
        }

        /// <summary>
        /// Creates the virtual card.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [ValidateModel]
        [HttpPost]
        public async Task<CreateVirtualCardResponse> CreateVirtualCard(string accountId, CreateVirtualCardRequest request)
        {
            return await _customerManager.CreateVirtualCard(accountId, request);
        }

        /// <summary>
        /// Creates the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [ValidateModel]
        [HttpPost]
        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            return await _customerManager.CreatePayment(request);
        }

        /// <summary>
        /// Creates the rule.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [ValidateModel]
        [HttpPost]
        public async Task<CreateRuleResponse> CreateRule(CreateRuleRequest request)
        {
            return await _customerManager.CreateRule(request);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBase> CloseAccount(string accountId)
        {
            return await _customerManager.CloseAccount(accountId);
        }
        #endregion
        #region Delete methods
        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="ruleIds">The rule ids.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<DeleteRuleResponse> DeleteRole(string[] ruleIds)
        {
            return await _customerManager.DeleteRule(ruleIds);
        }
        #endregion
    }
}