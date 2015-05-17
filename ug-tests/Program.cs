using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iuguapi;

namespace iugu_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Token test
            // information data 
            var requestToken = new TokenRequest()
            {
                account_id = "9c0cf682-d096-49fe-8401-d81fba38fe28",
                method = "credit_card",
                test = true,
                data = new CreditCard()
                {
                    first_name = "Persio",
                    last_name = "Flexa",
                    month = "05",
                    year = "2018",
                    number = "4111111111111111",
                    verification_value = "123"
                }
            };

            var tokenResult = IuguApi.Iugu.Token.CreateToken(requestToken);
            if (tokenResult.errors == null) Console.WriteLine("Token:" + tokenResult.id);
            else Console.WriteLine(tokenResult.errors);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Charge tests 
            // NOTE: the token is actualy using result from token test
            var requestCharge = new ChargeRequest()
            {
                method = "bank_slip",
                token = tokenResult.id,
                email = "teste@teste.com",
                items = new ChargeItem[] { new ChargeItem()
                {
                    description = "Item Um",
                    quantity = 1,
                    price_cents = "1000"
                }},
                payer = new Payer()
                {
                    name = "Persio Flexa",
                    email = "test@test.com",
                    phone_prefix = "11",
                    phone = "999999999",
                    cpf_cnpj = "32779248823",
                    address = new Address()
                    {
                        street = "Rua Tal",
                        number = "1000",
                        city = "São Paulo",
                        state = "SP",
                        country = "Brasil",
                        zip_code = "01311-000"
                    }
                }
            };

            ////////////////
            // Creditcard payment using token 
            var chargeCreditcardResult = IuguApi.Iugu.Charge.CreateCreditcardPayment(requestCharge);
            if (chargeCreditcardResult.success) Console.WriteLine("Creditcard Authorization: " + chargeCreditcardResult.message);
            else Console.WriteLine(chargeCreditcardResult.errors);

            Console.WriteLine("");

            // Creditcard payment using other test token and the payer info to anti theft
            tokenResult = IuguApi.Iugu.Token.CreateToken(requestToken);
            requestCharge.token = tokenResult.id;
            var chargeCreditcardWithAntiTheftResult = IuguApi.Iugu.Charge.CreateCreditcardAntiTheftPayment(requestCharge);
            if (chargeCreditcardWithAntiTheftResult.success) Console.WriteLine("Creditcard Anti Theft Authorization: " + chargeCreditcardWithAntiTheftResult.message);
            else Console.WriteLine(chargeCreditcardWithAntiTheftResult.errors);

            Console.WriteLine("");

            ////////////////
            // BankSlip required test no token
            var chargeBankSlipResult = IuguApi.Iugu.Charge.CreateBankSlipPayment(requestCharge);
            if (chargeBankSlipResult.success) Console.WriteLine("BankSlip: " + chargeBankSlipResult.url);
            else Console.WriteLine(chargeBankSlipResult.errors);

            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Customer tests
            var requestCustomer = new CustomerRequest()
            {
                email = "test@test.com",
                name = "Persio Flexa"
            };

            // create customer
            var createCustomerResult = IuguApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);

            Console.WriteLine("");

            // get customer
            var getCustomerResult = IuguApi.Iugu.Customer.Get(createCustomerResult.id);
            if (getCustomerResult.success) Console.WriteLine("Get Customer: " + getCustomerResult.name);
            else Console.WriteLine(getCustomerResult.errors);

            Console.WriteLine("");

            // change customer
            requestCustomer.name = "Mr Flexa";
            var changeCustomerResult = IuguApi.Iugu.Customer.Change(createCustomerResult.id, requestCustomer);
            if (changeCustomerResult.success) Console.WriteLine("Change Customer: " + changeCustomerResult.name);
            else Console.WriteLine(changeCustomerResult.errors);

            Console.WriteLine("");

            // delete customer
            var deleteCustomerResult = IuguApi.Iugu.Customer.Delete(createCustomerResult.id);
            if (deleteCustomerResult.success) Console.WriteLine("Deleted Customer: " + deleteCustomerResult.name);
            else Console.WriteLine(deleteCustomerResult.errors);

            Console.WriteLine("");

            // create for next test
            requestCustomer.name = "User 1";
            createCustomerResult = IuguApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);

            Console.WriteLine("");

            // create for next test
            requestCustomer.name = "User 2";
            createCustomerResult = IuguApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);

            Console.WriteLine("");

            // create for next test
            requestCustomer.name = "User 3";
            createCustomerResult = IuguApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);
            Console.WriteLine("");

            var findCustomer = new CustomersRequest()
            {
                limit = 10
            };

            // list customers
            var customerListResult = IuguApi.Iugu.Customer.List(findCustomer);
            if (customerListResult.success) Console.WriteLine("Customers Total: " + customerListResult.totalItems);
            else Console.WriteLine(customerListResult.errors);

            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Payment method test
            var paymentRequest = new PaymentMethodRequest()
            {
                customer_id = createCustomerResult.id,
                data = new CreditCard()
                {
                    first_name = "Persio",
                    last_name = "Flexa",
                    month = "05",
                    year = "2018",
                    number = "4111111111111111",
                    verification_value = "123"
                },
                description = "Payment description",
                item_type = "credit_card",
                set_as_default = true,
                token = IuguApi.Iugu.Token.CreateToken(requestToken).id
            };

            // create payment method without token
            paymentRequest.description = "First payment option";
            var createPaymentMethodResult = IuguApi.Iugu.PaymentMethod.Create(paymentRequest, PaymentType.WithoutToken);
            if (createPaymentMethodResult.success) Console.WriteLine("Payment method with token: " + createPaymentMethodResult.item_type + " | " + createPaymentMethodResult.description);
            else Console.WriteLine(createPaymentMethodResult.errors);

            Console.WriteLine("");

            // create payment method with token
            paymentRequest.description = "Second payment option";
            var createPaymentMethodWithTokenResult = IuguApi.Iugu.PaymentMethod.Create(paymentRequest, PaymentType.WithToken);
            if (createPaymentMethodWithTokenResult.success) Console.WriteLine("Payment method without token: " + createPaymentMethodWithTokenResult.item_type + " | " + createPaymentMethodWithTokenResult.description);
            else Console.WriteLine(createPaymentMethodWithTokenResult.errors);

            Console.WriteLine("");

            // change payment method
            paymentRequest.id = createPaymentMethodResult.id; // change the second by first payment method result
            paymentRequest.description = "New payment";
            var changePaymentMethodResult = IuguApi.Iugu.PaymentMethod.Change(createCustomerResult.id, paymentRequest);
            if (changePaymentMethodResult.success) Console.WriteLine("Changed payment method from customer: " + createCustomerResult.id + " | " + changePaymentMethodResult.description);
            else Console.WriteLine(changePaymentMethodResult.errors);

            Console.WriteLine("");

            // get payment method
            var getPaymentMethodResult = IuguApi.Iugu.PaymentMethod.Get(createCustomerResult.id, paymentRequest.id);
            if (getPaymentMethodResult.success) Console.WriteLine("Get payment from customer: " + getPaymentMethodResult.id + " | " + getPaymentMethodResult.description);
            else Console.WriteLine(getPaymentMethodResult.errors);

            Console.WriteLine("");

            // get all payments method
            var getAllPaymentsMethodResult = IuguApi.Iugu.PaymentMethod.List(createCustomerResult.id);
            if (getAllPaymentsMethodResult.success) Console.WriteLine("Customer Payments: " + getAllPaymentsMethodResult.Count);
            else Console.WriteLine(getAllPaymentsMethodResult.errors);

            Console.WriteLine("");

            // delete payment method
            var deletePaymentMethodResult = IuguApi.Iugu.PaymentMethod.Delete(createCustomerResult.id, paymentRequest.id);
            if (deletePaymentMethodResult.success) Console.WriteLine("Deleted payment from customer: " + deletePaymentMethodResult.id + " | " + deletePaymentMethodResult.description);
            else Console.WriteLine(deletePaymentMethodResult.errors);

            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Invoice tests
            var invoiceRequest = new InvoiceRequest()
            {
                email = "test@test.com",
                due_date = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                items = new ChargeItem[] { new ChargeItem()
                        {
                            description= "Item One",
                            quantity = 1,
                            price_cents = "1000"
                        }
                }
            };

            // create invoice
            var createInvoiceResult = IuguApi.Iugu.Invoice.Create(invoiceRequest);
            if (createInvoiceResult.success) Console.WriteLine("Create Invoice: " + createInvoiceResult.secure_url);
            else Console.WriteLine(createInvoiceResult.errors);

            Console.WriteLine("");

            // update invoice
            invoiceRequest.email = "test2@teste2.com";
            var updateInvoiceResult = IuguApi.Iugu.Invoice.Create(invoiceRequest);
            if (updateInvoiceResult.success) Console.WriteLine("Update Invoice: " + updateInvoiceResult.secure_url);
            else Console.WriteLine(updateInvoiceResult.errors);

            Console.WriteLine("");

            // get invoice
            var getInvoiceResult = IuguApi.Iugu.Invoice.Get(updateInvoiceResult.id);
            if (getInvoiceResult.success) Console.WriteLine("Get Invoice: " + getInvoiceResult.secure_url);
            else Console.WriteLine(getInvoiceResult.errors);

            Console.WriteLine("");

            // list invoice
            var listInvoiceResult = IuguApi.Iugu.Invoice.List(new InvoicesRequest());
            if (listInvoiceResult.success) Console.WriteLine("List Invoice: " + listInvoiceResult.totalItems);
            else Console.WriteLine(listInvoiceResult.errors);

            Console.WriteLine("");

            // capture invoice
            var captureInvoiceResult = IuguApi.Iugu.Invoice.Capture(updateInvoiceResult.id);
            if (captureInvoiceResult.success) Console.WriteLine("Capture Invoice: " + captureInvoiceResult.id);
            else Console.WriteLine(captureInvoiceResult.errors);

            Console.WriteLine("");

            // refund invoice
            var refundInvoiceResult = IuguApi.Iugu.Invoice.Refund(updateInvoiceResult.id);
            if (refundInvoiceResult.success) Console.WriteLine("Refund Invoice: " + refundInvoiceResult.id);
            else Console.WriteLine(refundInvoiceResult.errors);

            Console.WriteLine("");

            // cancel invoice
            var cancelInvoiceResult = IuguApi.Iugu.Invoice.Cancel(updateInvoiceResult.id);
            if (cancelInvoiceResult.success) Console.WriteLine("Cancel Invoice: " + cancelInvoiceResult.id);
            else Console.WriteLine(cancelInvoiceResult.errors);

            Console.WriteLine("");

            // delete invoice
            var deleteInvoiceResult = IuguApi.Iugu.Invoice.Delete(updateInvoiceResult.id);
            if (deleteInvoiceResult.success) Console.WriteLine("Delete Invoice: " + deleteInvoiceResult.id);
            else Console.WriteLine(deleteInvoiceResult.errors);
            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Plain tests
            var requestPlan = new PlanRequest()
            {
                name = "Basic Plan",
                identifier = "basic_plan-" + Guid.NewGuid().ToString(),
                interval = 12,
                interval_type = "months",
                currency = "BRL",
                value_cents = "1000",
                features = new Feature[] { new Feature() {
                    name = "Android, Windows Phone and iPhone ",
                    value = 3,
                    identifier = "platforms" }
                }
            };

            // create customer
            var createPlanResult = IuguApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);

            Console.WriteLine("");

            // get Plan
            var getPlanResult = IuguApi.Iugu.Plan.Get(createPlanResult.id);
            if (getPlanResult.success) Console.WriteLine("Get Plan: " + getPlanResult.name);
            else Console.WriteLine(getPlanResult.errors);

            Console.WriteLine("");

            // get Plan
            var getIdentifierPlanResult = IuguApi.Iugu.Plan.GetByIdentifier(requestPlan.identifier);
            if (getIdentifierPlanResult.success) Console.WriteLine("Get Plan by identifier: " + getIdentifierPlanResult.identifier);
            else Console.WriteLine(getPlanResult.errors);

            Console.WriteLine("");

            // change Plan
            requestPlan.name = "Mr Flexa";

            var changePlanResult = IuguApi.Iugu.Plan.Change(createPlanResult.id, requestPlan);
            if (changePlanResult.success) Console.WriteLine("Change Plan: " + changePlanResult.name);
            else Console.WriteLine(changePlanResult.errors);

            Console.WriteLine("");

            // delete Plan
            var deletePlanResult = IuguApi.Iugu.Plan.Delete(createPlanResult.id);
            if (deletePlanResult.success) Console.WriteLine("Deleted Plan: " + deletePlanResult.name);
            else Console.WriteLine(deletePlanResult.errors);

            Console.WriteLine("");

            // create for next test
            requestPlan.name = "Plan 1";
            requestPlan.identifier = Guid.NewGuid().ToString();

            createPlanResult = IuguApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);

            Console.WriteLine("");

            // create for next test
            requestPlan.name = "Plan 2";
            requestPlan.identifier = Guid.NewGuid().ToString();

            createPlanResult = IuguApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);

            Console.WriteLine("");

            // create for next test
            requestPlan.name = "Plan 3";
            requestPlan.identifier = Guid.NewGuid().ToString();

            createPlanResult = IuguApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);

            Console.WriteLine("");

            var findPlan = new PlansRequest()
            {
                limit = 10
            };

            // list Plans
            var PlanListResult = IuguApi.Iugu.Plan.List(findPlan);
            if (PlanListResult.success) Console.WriteLine("Plans Total: " + PlanListResult.totalItems);
            else Console.WriteLine(PlanListResult.errors);

            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Subscription tests
            var requestSubscription = new SubscriptionRequest()
            {
                plan_identifier = createPlanResult.identifier,
                customer_id = createCustomerResult.id
            };

            // create subscription
            var createSubscriptionResult = IuguApi.Iugu.Subscription.Create(requestSubscription, SubscriptionType.WithPlan);
            if (createSubscriptionResult.success) Console.WriteLine("Create Subscription with plan: " + createSubscriptionResult.plan_name + " | " + createSubscriptionResult.id);
            else Console.WriteLine(createSubscriptionResult.errors);

            Console.WriteLine("");

            // change subscription
            var changeSubscriptionResult = IuguApi.Iugu.Subscription.Change(createSubscriptionResult.id, requestSubscription, SubscriptionType.WithPlan);
            if (changeSubscriptionResult.success) Console.WriteLine("Change Subscription: " + changeSubscriptionResult.plan_name + " | " + changeSubscriptionResult.id);
            else Console.WriteLine(changeSubscriptionResult.errors);

            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Transfer tests
            var requestTransfer = new TransferRequest()
            {
                receiver_id = "77C2565F6F064A26ABED4255894224F0",
                amount_cents = "1000"
            };

            // create transfer
            var createTransferResult = IuguApi.Iugu.Transfer.Create(requestTransfer);
            if (createTransferResult.success) Console.WriteLine("Create transfer to: " + createTransferResult.receiver.name + " | " + createTransferResult.receiver.id);
            else Console.WriteLine(createTransferResult.errors);

            Console.WriteLine("");

            // list transfers
            var transferListResult = IuguApi.Iugu.Transfer.List(createTransferResult.id);
            if (transferListResult.success) Console.WriteLine("Transfers sent/receive: " + transferListResult.sent.Length + " | " + transferListResult.received.Length);
            else Console.WriteLine(transferListResult.errors);

            Console.WriteLine("");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // --------------------------------------------------------------------------------------------------------------

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Marketplace tests
            var requestMarketplaceAccount = new MarketplaceRequest()
            {
                name = "77C2565F6F064A26ABED4255894224F0",
                commission_percent = 30
            };

            var createMarketplaceAccountResult = IuguApi.Iugu.Marketplace.Create(requestMarketplaceAccount);
            if (createMarketplaceAccountResult.success) Console.WriteLine("Create mktplace accont live api/test api: " + createMarketplaceAccountResult.live_api_token + " | " + createMarketplaceAccountResult.test_api_token);
            else Console.WriteLine(createMarketplaceAccountResult.errors);

            var requestMarketplaceAccountVerification = new MarketplaceAccountRequest()
            {
                data = new MarketplaceAccountRequestModel()
                {
                    price_range = "Até R$ 100,00",
                    physical_products = false,
                    business_type = "Serviços de Limpeza",
                    person_type = "Pessoa Física",
                    automatic_transfer = true,
                    cpf = "123.123.123-12",
                    name = "Nome da Pessoa",
                    address = "Av. Paulista 320 cj 10",
                    cep = "01419-000",
                    city = "São Paulo",
                    state = "São Paulo",
                    telephone = "11-91231-1234",
                    bank = "Itaú",
                    bank_ag = "1234",
                    account_type = "Corrente",
                    bank_cc = "11231-2"
                },
                files = new MarketplaceFilesRequestModel()
                {
                    id = "/home/user1/Desktop/rg.png",
                    cpf = "/home/user1/Desktop/cpf.png",
                    activity = "/home/user1/Desktop/contrato.png"
                }
            };

            if(!string.IsNullOrEmpty(createMarketplaceAccountResult.test_api_token))
            {
                IuguApi.Iugu.Marketplace.Verification(
                createMarketplaceAccountResult.account_id,
                createMarketplaceAccountResult.test_api_token,
                requestMarketplaceAccountVerification);
            }            

            Console.Read();
        }
    }
}
