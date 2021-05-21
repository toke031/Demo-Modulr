using Juice_Demo_Modulr.Core.Client;
using Juice_Demo_Modulr.Core.Requests;
using Juice_Demo_Modulr.Core.Responses;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Juice_Demo_Modulr.Core.Managers
{
    public class CustomerManager
    {
        #region Fields        
        /// <summary>
        /// The modulr client
        /// </summary>
        private readonly ModulrClient modulrClient;
        #endregion
        #region Constructor    

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        public CustomerManager()
        {
            modulrClient = new ModulrClient();
        }
        #endregion
        #region Public methods

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            return await modulrClient.PostAsync<CreateCustomerResponse>("customers", request);
        }

        /// <summary>
        /// Gets all customer account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="currency">The currency.</param>
        /// <returns></returns>
        public async Task<GetCustomerAccountsResponse> GetAllCustomerAccount(string customerId, string currency)
        {
            return await modulrClient.GetAsync<GetCustomerAccountsResponse>($"customers/{customerId}/accounts?page=0&size=20&currency={currency}");
        }

        /// <summary>
        /// Gets all account rules.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public async Task<GetCustomerAccountsResponse> GetAllAccountRules(string accountId)
        {
            return await modulrClient.GetAsync<GetCustomerAccountsResponse>($"accounts/{accountId}/rules?page=0&size=20");
        }

        /// <summary>
        /// Gets all beneficiaries account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<GetCustomerAccountsResponse> GetAllBeneficiariesAccount(string customerId)
        {
            return await modulrClient.GetAsync<GetCustomerAccountsResponse>($"beneficiaries?customerId={customerId}&page=0&size=20");
        }

        /// <summary>
        /// Deletes the rule.
        /// </summary>
        /// <param name="ruleIds">The rule ids.</param>
        /// <returns></returns>
        public async Task<DeleteRuleResponse> DeleteRule(string[] ruleIds)
        {
            string rulesIds = "";
            foreach (string ruleId in ruleIds)
            {
                rulesIds += ruleId + ", ";
            }
            rulesIds = rulesIds.Substring(0, rulesIds.Length - 2);
            var encodedRuleIds = System.Web.HttpUtility.UrlEncode(rulesIds);
            Regex reg = new Regex(@"%[a-f0-9]{2}");
            encodedRuleIds = reg.Replace(encodedRuleIds, m => m.Value.ToUpperInvariant());
            return await modulrClient.DeleteAsync<DeleteRuleResponse>($"rules?rIds={encodedRuleIds}");
        }

        /// <summary>
        /// Deletes the beneficiary account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="beneficiaryId">The beneficiary identifier.</param>
        /// <returns></returns>
        public async Task<ResponseBase> DeleteBeneficiaryAccount(string customerId, string beneficiaryId)
        {
            return await modulrClient.DeleteAsync<ResponseBase>($"customers/{customerId}/beneficiaries?bid={beneficiaryId}");
        }

        /// <summary>
        /// Creates the inbound payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ResponseBase> CreateInboundPayment(InboundPaymentRequest request)
        {
            return await modulrClient.PostAsync<ResponseBase>("credit", request);
        }

        /// <summary>
        /// Creates the customer account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<CreateCustomerAccountResponse> CreateCustomerAccount(string customerId, CreateCustomerAccountRequest request)
        {
            return await modulrClient.PostAsync<CreateCustomerAccountResponse>($"customers/{customerId}/accounts", request);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public async Task<ResponseBase> CloseAccount(string accountId)
        {
            return await modulrClient.PostAsync<ResponseBase>($"accounts/{accountId}/close", null);
        }

        /// <summary>
        /// Creates the beneficiary account.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<CreateBeneficiaryAccountResponse> CreateBeneficiaryAccount(string customerId, CreateBeneficiaryAccountRequest request)
        {
            return await modulrClient.PostAsync<CreateBeneficiaryAccountResponse>($"customers/{customerId}/beneficiaries", request);
        }

        /// <summary>
        /// Creates the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            return await modulrClient.PostAsync<CreatePaymentResponse>("payments", request);
        }

        /// <summary>
        /// Creates the virtual card.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<CreateVirtualCardResponse> CreateVirtualCard(string accountId, CreateVirtualCardRequest request)
        {
            return await modulrClient.PostAsync<CreateVirtualCardResponse>($"accounts/{accountId}/cards", request);
        }

        /// <summary>
        /// Creates the rule.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<CreateRuleResponse> CreateRule(CreateRuleRequest request)
        {
            return await modulrClient.PostAsync<CreateRuleResponse>("rules", request);
        }
        #endregion
    }
}
