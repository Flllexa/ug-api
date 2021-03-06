API for IUGU - http://iugu.com

To install ug-api, run the following command in the Package Manager Console

PM> Install-Package ug-api

# Token for payments

            // information data 
            var requestToken = new TokenRequest()
            {
                account_id = "{account_id}",
                method = "credit_card",
                test = true,
                data = new CreditCard()
                {
                    first_name = "Card",
                    last_name = "Test",
                    month = "05",
                    year = "2018",
                    number = "4111111111111111",
                    verification_value = "123"
                }
            };
            
            var tokenResult = UgApi.Iugu.Token.CreateToken(requestToken);
            if (tokenResult.success) Console.WriteLine("Token:" + tokenResult.id);
            else Console.WriteLine(tokenResult.errors);
            
# Charge with creditcard and bank slip

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
                    cpf_cnpj = "11111111111",
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
            
            // Creditcard payment using token 
            var chargeCreditcardResult = UgApi.Iugu.Charge.CreateCreditcardPayment(requestCharge);
            if (chargeCreditcardResult.success) Console.WriteLine("Creditcard Authorization: " + chargeCreditcardResult.message);
            else Console.WriteLine(chargeCreditcardResult.errors);
            
            // Creditcard payment using other test token and the payer info to anti theft
            tokenResult = UgApi.Iugu.Token.CreateToken(requestToken);
            requestCharge.token = tokenResult.id;
            var chargeCreditcardWithAntiTheftResult = UgApi.Iugu.Charge.CreateCreditcardAntiTheftPayment(requestCharge);
            Console.WriteLine("Creditcard Anti Theft Authorization: " + chargeCreditcardWithAntiTheftResult.message);
            else Console.WriteLine(chargeCreditcardWithAntiTheftResult.errors);
            
            // BankSlip required test no token
            var chargeBankSlipResult = UgApi.Iugu.Charge.CreateBankSlipPayment(requestCharge);
            if (chargeBankSlipResult.success) Console.WriteLine("BankSlip: " + chargeBankSlipResult.url);
            else Console.WriteLine(chargeBankSlipResult.errors);
            
# Customer

            var requestCustomer = new CustomerRequest()
            {
                email = "test@test.com",
                name = "Persio Flexa"
            };
            
            // create customer
            var createCustomerResult = UgApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);
            
            // get customer
            var getCustomerResult = UgApi.Iugu.Customer.Get(createCustomerResult.id);
            if (getCustomerResult.success) Console.WriteLine("Get Customer: " + getCustomerResult.name);
            else Console.WriteLine(getCustomerResult.errors);
            
            // change customer
            requestCustomer.name = "Mr Flexa";
            var changeCustomerResult = UgApi.Iugu.Customer.Change(createCustomerResult.id, requestCustomer);
            if (changeCustomerResult.success) Console.WriteLine("Change Customer: " + changeCustomerResult.name);
            else Console.WriteLine(changeCustomerResult.errors);
            
            // delete customer
            var deleteCustomerResult = UgApi.Iugu.Customer.Delete(createCustomerResult.id);
            if (deleteCustomerResult.success) Console.WriteLine("Deleted Customer: " + deleteCustomerResult.name);
            else Console.WriteLine(deleteCustomerResult.errors);
            
            // create for next test
            requestCustomer.name = "User 1";
            createCustomerResult = UgApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);
            
            // create for next test
            requestCustomer.name = "User 2";
            createCustomerResult = UgApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);
            
            // create for next test
            requestCustomer.name = "User 3";
            createCustomerResult = UgApi.Iugu.Customer.Create(requestCustomer);
            if (createCustomerResult.success) Console.WriteLine("Create customer: " + createCustomerResult.name + " | " + createCustomerResult.id);
            else Console.WriteLine(createCustomerResult.errors);
            Console.WriteLine("");
            
            var findCustomer = new CustomersRequest()
            {
                limit = 10
            };
            
            // list customers
            var customerListResult = UgApi.Iugu.Customer.List(findCustomer);
            if (customerListResult.success) Console.WriteLine("Customers Total: " + customerListResult.totalItems);
            else Console.WriteLine(customerListResult.errors);
            
# Payment method for customers

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
                token = UgApi.Iugu.Token.CreateToken(requestToken).id
            };
            
            // create payment method without token
            paymentRequest.description = "First payment option";
            var createPaymentMethodResult = UgApi.Iugu.PaymentMethod.Create(paymentRequest, PaymentType.WithoutToken);
            if (createPaymentMethodResult.success) Console.WriteLine("Payment method with token: " + createPaymentMethodResult.item_type + " | " + createPaymentMethodResult.description);
            else Console.WriteLine(createPaymentMethodResult.errors);
            
            // create payment method with token
            paymentRequest.description = "Second payment option";
            var createPaymentMethodWithTokenResult = UgApi.Iugu.PaymentMethod.Create(paymentRequest, PaymentType.WithToken);
            if (createPaymentMethodWithTokenResult.success) Console.WriteLine("Payment method without token: " + createPaymentMethodWithTokenResult.item_type + " | " + createPaymentMethodWithTokenResult.description);
            else Console.WriteLine(createPaymentMethodWithTokenResult.errors);
            
            // change payment method
            paymentRequest.id = createPaymentMethodResult.id; // change the second by first payment method result
            paymentRequest.description = "New payment";
            var changePaymentMethodResult = UgApi.Iugu.PaymentMethod.Change(createCustomerResult.id, paymentRequest);
            if (changePaymentMethodResult.success) Console.WriteLine("Changed payment method from customer: " + createCustomerResult.id + " | " + changePaymentMethodResult.description);
            else Console.WriteLine(changePaymentMethodResult.errors);
            
            // get payment method
            var getPaymentMethodResult = UgApi.Iugu.PaymentMethod.Get(createCustomerResult.id, paymentRequest.id);
            if (getPaymentMethodResult.success) Console.WriteLine("Get payment from customer: " + getPaymentMethodResult.id + " | " + getPaymentMethodResult.description);
            else Console.WriteLine(getPaymentMethodResult.errors);
            
            // get all payments method
            var getAllPaymentsMethodResult = UgApi.Iugu.PaymentMethod.List(createCustomerResult.id);
            if (getAllPaymentsMethodResult.success) Console.WriteLine("Customer Payments: " + getAllPaymentsMethodResult.Count);
            else Console.WriteLine(getAllPaymentsMethodResult.errors);
            
            // delete payment method
            var deletePaymentMethodResult = UgApi.Iugu.PaymentMethod.Delete(createCustomerResult.id, paymentRequest.id);
            if (deletePaymentMethodResult.success) Console.WriteLine("Deleted payment from customer: " + deletePaymentMethodResult.id + " | " + deletePaymentMethodResult.description);
            else Console.WriteLine(deletePaymentMethodResult.errors);
            
# Invoice

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
            var createInvoiceResult = UgApi.Iugu.Invoice.Create(invoiceRequest);
            if (createInvoiceResult.success) Console.WriteLine("Create Invoice: " + createInvoiceResult.secure_url);
            else Console.WriteLine(createInvoiceResult.errors);
            
            // update invoice
            invoiceRequest.email = "test2@teste2.com";
            var updateInvoiceResult = UgApi.Iugu.Invoice.Create(invoiceRequest);
            if (updateInvoiceResult.success) Console.WriteLine("Update Invoice: " + updateInvoiceResult.secure_url);
            else Console.WriteLine(updateInvoiceResult.errors);
            
            // get invoice
            var getInvoiceResult = UgApi.Iugu.Invoice.Get(updateInvoiceResult.id);
            if (getInvoiceResult.success) Console.WriteLine("Get Invoice: " + getInvoiceResult.secure_url);
            else Console.WriteLine(getInvoiceResult.errors);
            
            // list invoice
            var listInvoiceResult = UgApi.Iugu.Invoice.List(new InvoicesRequest());
            if (listInvoiceResult.success) Console.WriteLine("List Invoice: " + listInvoiceResult.totalItems);
            else Console.WriteLine(listInvoiceResult.errors);
            
            // capture invoice
            var captureInvoiceResult = UgApi.Iugu.Invoice.Capture(updateInvoiceResult.id);
            if (captureInvoiceResult.success) Console.WriteLine("Capture Invoice: " + captureInvoiceResult.id);
            else Console.WriteLine(captureInvoiceResult.errors);
            
            // refund invoice
            var refundInvoiceResult = UgApi.Iugu.Invoice.Refund(updateInvoiceResult.id);
            if (refundInvoiceResult.success) Console.WriteLine("Refund Invoice: " + refundInvoiceResult.id);
            else Console.WriteLine(refundInvoiceResult.errors);
            
            // cancel invoice
            var cancelInvoiceResult = UgApi.Iugu.Invoice.Cancel(updateInvoiceResult.id);
            if (cancelInvoiceResult.success) Console.WriteLine("Cancel Invoice: " + cancelInvoiceResult.id);
            else Console.WriteLine(cancelInvoiceResult.errors);
            
            // delete invoice
            var deleteInvoiceResult = UgApi.Iugu.Invoice.Delete(updateInvoiceResult.id);
            if (deleteInvoiceResult.success) Console.WriteLine("Delete Invoice: " + deleteInvoiceResult.id);
            else Console.WriteLine(deleteInvoiceResult.errors);
            Console.WriteLine("");
            
# Plain

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
            var createPlanResult = UgApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);
            
            // get Plan
            var getPlanResult = UgApi.Iugu.Plan.Get(createPlanResult.id);
            if (getPlanResult.success) Console.WriteLine("Get Plan: " + getPlanResult.name);
            else Console.WriteLine(getPlanResult.errors);
            
            // get Plan
            var getIdentifierPlanResult = UgApi.Iugu.Plan.GetByIdentifier(requestPlan.identifier);
            if (getIdentifierPlanResult.success) Console.WriteLine("Get Plan by identifier: " + getIdentifierPlanResult.identifier);
            else Console.WriteLine(getPlanResult.errors);
            
            // change Plan
            requestPlan.name = "Mr Flexa";
            
            var changePlanResult = UgApi.Iugu.Plan.Change(createPlanResult.id, requestPlan);
            if (changePlanResult.success) Console.WriteLine("Change Plan: " + changePlanResult.name);
            else Console.WriteLine(changePlanResult.errors);
            
            // delete Plan
            var deletePlanResult = UgApi.Iugu.Plan.Delete(createPlanResult.id);
            if (deletePlanResult.success) Console.WriteLine("Deleted Plan: " + deletePlanResult.name);
            else Console.WriteLine(deletePlanResult.errors);
            
            // create for next test
            requestPlan.name = "Plan 1";
            requestPlan.identifier = Guid.NewGuid().ToString();
            
            createPlanResult = UgApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);
            
            // create for next test
            requestPlan.name = "Plan 2";
            requestPlan.identifier = Guid.NewGuid().ToString();
            
            createPlanResult = UgApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);
            
            // create for next test
            requestPlan.name = "Plan 3";
            requestPlan.identifier = Guid.NewGuid().ToString();
            
            createPlanResult = UgApi.Iugu.Plan.Create(requestPlan);
            if (createPlanResult.success) Console.WriteLine("Create Plan: " + createPlanResult.name + " | " + createPlanResult.id);
            else Console.WriteLine(createPlanResult.errors);
            
            var findPlan = new PlansRequest()
            {
                limit = 10
            };
            
            var PlanListResult = UgApi.Iugu.Plan.List(findPlan);
            if (PlanListResult.success) Console.WriteLine("Plans Total: " + PlanListResult.totalItems);
            else Console.WriteLine(PlanListResult.errors);
            
# Subscription

            var requestSubscription = new SubscriptionRequest()
            {
                plan_identifier = createPlanResult.identifier,
                customer_id = createCustomerResult.id
            };
            
            // create subscription
            var createSubscriptionResult = UgApi.Iugu.Subscription.Create(requestSubscription, SubscriptionType.WithPlan);
            if (createSubscriptionResult.success) Console.WriteLine("Create Subscription with plan: " + createSubscriptionResult.plan_name + " | " + createSubscriptionResult.id);
            else Console.WriteLine(createSubscriptionResult.errors);
            
            // change subscription
            var changeSubscriptionResult = UgApi.Iugu.Subscription.Change(createSubscriptionResult.id, requestSubscription, SubscriptionType.WithPlan);
            if (changeSubscriptionResult.success) Console.WriteLine("Change Subscription: " + changeSubscriptionResult.plan_name + " | " + changeSubscriptionResult.id);
            else Console.WriteLine(changeSubscriptionResult.errors);
            
# Transfer money

            var requestTransfer = new TransferRequest()
            {
                receiver_id = "77C2565F6F064A26ABED4255894224F0",
                amount_cents = "1000"
            };
            
            // create transfer
            var createTransferResult = UgApi.Iugu.Transfer.Create(requestTransfer);
            if (createTransferResult.success) Console.WriteLine("Create transfer to: " + createTransferResult.receiver.name + " | " + createTransferResult.receiver.id);
            else Console.WriteLine(createTransferResult.errors);
            
            // list transfers
            var transferListResult = UgApi.Iugu.Transfer.List(createTransferResult.id);
            if (transferListResult.success) Console.WriteLine("Transfers sent/receive: " + transferListResult.sent.Length + " | " + transferListResult.received.Length);
            else Console.WriteLine(transferListResult.errors);
            
# Marketplace

            var requestMarketplaceAccount = new MarketplaceRequest()
            {
                name = "77C2565F6F064A26ABED4255894224F0",
                commission_percent = 30
            };
            
            var createMarketplaceAccountResult = UgApi.Iugu.Marketplace.Create(requestMarketplaceAccount);
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
                UgApi.Iugu.Marketplace.Verification(
                createMarketplaceAccountResult.account_id,
                createMarketplaceAccountResult.test_api_token,
                requestMarketplaceAccountVerification);
            }
            

