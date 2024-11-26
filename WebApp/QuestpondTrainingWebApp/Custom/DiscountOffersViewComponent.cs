using Microsoft.AspNetCore.Mvc;

namespace QuestpondTrainingWebApp.Component
{
    public class DiscountOffersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(decimal price)
        {
            if (price > 50000)
            {
                decimal discount = price * 15 / 100;
                decimal finalprice = price - discount;
                return View("_discountOffer", finalprice);
            }           

            return View("_noOffer");
        }
    }
}
