using PayPalCheckoutSdk.Core;

public class PayPalClient
{
    public static PayPalHttpClient Client()
    {
        var environment = new SandboxEnvironment("Your-Client-Id", "Your-Secret-Key");
        return new PayPalHttpClient(environment);
    }
}
