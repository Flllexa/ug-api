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
         {<br/>
             first_name = "Card",
             last_name = "Test",
             month = "05",
             year = "2018",
             number = "4111111111111111",
             verification_value = "123"
         }<br/>
     };

     var tokenResult = UgApi.Iugu.Token.CreateToken(requestToken);
     Console.WriteLine("Token:" + tokenResult.id);

