# ug-api (API for IUGU - http://iugu.com)
C# / .NET <br/>
IUGU API 95% complete, maketplace no tested.


# Example

// Token test
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
Console.WriteLine("Token:" + tokenResult.id);
// -----------------------------------------------------------------------------------------

// Create charge payment
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
     }
}
