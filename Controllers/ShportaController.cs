using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Orders;
using Projekti.Data;
using Projekti.Models;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using Stripe;

namespace Projekti.Controllers
{
    public class ShportaController : Controller
    {
        private readonly ApplicationDbContext db;
        private Shporta cart = new Shporta();

        public ActionResult Index()
        {
            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var product = db.Libra.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var product = db.Libra.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PayWithPayPal()
        {
            // Implement PayPal payment logic

            // Create order request
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBody());

            // Call PayPal API to create the order
            var response = PayPalClient.Client().Execute(request);
            var result = response.Result<Order>();

            // Redirect to the PayPal checkout page
            return Redirect(result.Links.Find(link => link.Rel == "approve").Href);
        }

        public IActionResult PayPalCheckout()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult PayWithStripe()
        {
            // Configure Stripe with your API key
            StripeConfiguration.ApiKey = "Your-Stripe-Secret-Key";

            // Create a payment intent
            var options = new PaymentIntentCreateOptions
            {
                Amount = 1000, // Amount in cents
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var intent = service.Create(options);

            // Redirect to the Stripe checkout page
            return Redirect(intent.ClientSecret);
        }

        public IActionResult StripeCheckout()
        {
            
            return View();
        }
        private OrderRequest BuildRequestBody()
        {
            var orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
            {
                new PurchaseUnitRequest()
                {
                    AmountWithBreakdown = new AmountWithBreakdown()
                    {
                        CurrencyCode = "USD",
                        Value = "100.00"
                    }
                }
            }
            };

            return orderRequest;
        }
    }
}
