namespace CarParts.Controllers
{
    using CarParts.Infrastructure;
    using CarParts.Models.Offers;
    using CarParts.Models.Parts;
    using CarParts.Services.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;
    public class PartsController : Controller
    {
        private readonly IPartsService parts;
        public PartsController(IPartsService parts)
        {
            this.parts = parts;
        }

        public IActionResult ChooseMake()
        {
            var makes = this.parts.GetMakes();

            return View(makes);
        }

        [Authorize]
        public IActionResult AddPart(string make)
        {
            var categories = this.parts.GetCategories();
            var models = this.parts.GetModels(make);

            return View(new AddPartFormModel
            {
                MakeName = make,
                Categories = categories,
                Models = models
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPart(AddPartFormModel part)
        {
            if (!this.parts.IsMakeValid(part.MakeName))
            {
                this.ModelState.AddModelError(nameof(part.MakeName), "Make is invalid.");
            }
            if (!this.parts.IsModelValid(part.ModelId))
            {
                this.ModelState.AddModelError(nameof(part.ModelId), "Model is invalid.");
            }
            if (!this.parts.IsCategoryValid(part.CategoryId))
            {
                this.ModelState.AddModelError(nameof(part.CategoryId), "Category is invalid.");
            }

            if (!ModelState.IsValid)
            {
                part.Categories = this.parts.GetCategories();
                part.Models = this.parts.GetModels(part.MakeName);
                return this.View(part);
            }

            this.parts.AddPart(part, this.User.GetId());

            this.TempData[GlobalMessageKey] = "Part Added Successfully";

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Info(string partId)
        {

            var partModel = this.parts.GetPartInfo(partId);

            return View(partModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Info(AddOfferFormModel offerModel)
        {

            this.parts.AddOffer(offerModel);

            this.TempData[GlobalMessageKey] = "Offer send Successfully";

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Edit(string partId)
        {
            var partModel = this.parts.GetEditPartInfo(partId);

            return View(partModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditPartFormModel part)
        {
            if (!this.parts.IsMakeValid(part.MakeName))
            {
                this.ModelState.AddModelError(nameof(part.MakeName), "Make is invalid.");
            }
            if (!this.parts.isModelValid(part.ModelName))
            {
                this.ModelState.AddModelError(nameof(part.ModelName), "Model is invalid.");
            }
            if (!this.parts.isCategoryValid(part.CategoryId))
            {
                this.ModelState.AddModelError(nameof(part.CategoryId), "Category is invalid.");
            }

            if (!ModelState.IsValid)
            {
                part.Categories = this.parts.GetCategories();
                return this.View(part);
            }

            this.parts.EditPart(part);

            this.TempData[GlobalMessageKey] = "Part Edited Successfully";

            return RedirectToAction("MyParts", "Parts");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(string partId)
        {
            if (partId == null)
            {
                return BadRequest();
            }

            this.parts.Delete(partId);

            this.TempData[GlobalMessageKey] = "Part Deleted Successfully";

            return RedirectToAction("MyParts", "Parts");
        }

        public IActionResult MyParts()
        {
            var myParts = this.parts.GetMyParts(this.User.GetId());

            return View(myParts);
        }
    }
}
