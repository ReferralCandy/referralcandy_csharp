# ReferralCandy API for C#
To use the library, just add the project folder called **ReferralCandyAPI** to your solution and add it as a dependency to your project.

You can find samples on the project folder called **ReferralCandyAPI_CLI**

You can find our API documentation here: https://www.referralcandy.com/api

## Usage
Steps below are assuming you already have this library referenced in your solution. If not, you may follow the steps here on how to add it to your solution: https://msdn.microsoft.com/en-us/library/7314433t(VS.71).aspx

### Initialization
Initialize the API class for later use with your account's API access ID and API secret key, which can be found in: https://my.referralcandy.com/settings
```
ReferralCandy referralCandy = new ReferralCandy(apiAccessId: "YOUR_ACCOUNT_API_ACCESS_ID",
                                                apiSecretKey: "YOUR_ACCOUNT_API_SECRET_KEY");
```

### Create a request object inline with the request you want to make
Each request type require different fields which can also be named for a much readable code i.e.
```
// Requires an email parameter
// Can be written as:
InviteRequest request = new InviteRequest("john_smith@referralcandy.com");

// Or:
InviteRequest request = new InviteRequest(email: "john_smith@referralcandy.com");
```

### Create an appropriate response object to handle the response returned by the API
```
// Can be written as:
VerifyResponse response = referralCandy.Invite(request);

// Or:
VerifyResponse response = referralCandy.Invite(new InviteRequest("john_smith@referralcandy.com"))

// Or:
VerifyResponse response = referralCandy.Invite(new InviteRequest(email: "john_smith@referralcandy.com"))
```

### Handle the response
All response objects contain the properties `status_code`, `reason`, and `message`
```
// Check if the request was successfull
if (response.status_code == 200) {
  Console.WriteLine("Request was successful!");

  // Do something
} else {
  Console.WriteLine(response.reason);

  // Handle the failure
}

// Print something out anyway
Console.WriteLine("Message: " + response.message);
```

Please feel free to modify the code if necessary for your project's use case. This library is **not** required, it was made to make things easier, hopefully.

## Issues
- If you find any issues with the code, please feel free to create a new issue in this repository.
- If you are having trouble with the library within production, you can contact us at support@referralcandy.com
