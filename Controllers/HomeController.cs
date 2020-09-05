using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller

        // ==================================
        //     Starting Route
        // ==================================
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Fullness") == null){
                HttpContext.Session.SetInt32("Fullness", 20);
            }
            if (HttpContext.Session.GetInt32("Happiness") == null){
                HttpContext.Session.SetInt32("Happiness", 20);
            }
            if (HttpContext.Session.GetInt32("Meals") == null){
                HttpContext.Session.SetInt32("Meals", 3);
            } 
            if (HttpContext.Session.GetInt32("Energy") == null){
                HttpContext.Session.SetInt32("Energy", 50);
            }
            if (HttpContext.Session.GetString("Image")==null){ 
                HttpContext.Session.SetString("Image","Raccoon.jpg");
            } 
            if (HttpContext.Session.GetInt32("Energy")>100 &&  
                HttpContext.Session.GetInt32("Fullness")>100 &&
                HttpContext.Session.GetInt32("Energy")>100)
                {
                    ViewBag.Status = "Win";
                    ViewBag.EndMessage = "Success!  Congratulations! Your Dojodashi is blissed out! Let's chill!";
                    ViewBag.Image = "chillingtenor.gif";
                } 
            
            if (HttpContext.Session.GetInt32("Happiness")<=0 ||
                HttpContext.Session.GetInt32("Fullness")<=0 )
                
                {

                    HttpContext.Session.SetString("Image","burryingandrevives.gif");                        
                    ViewBag.Status = "Lose";
                    ViewBag.EndMessage = "Sadly, Dashi Raccoon has passed away. A moment of silence please.";
                } 

            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Image = HttpContext.Session.GetString("Image");
            ViewBag.Message = HttpContext.Session.GetString("Message");
            // HttpContext.Session.SetString("Image","raccoon.jpg");
            // ViewBag.Image = "raccoon.jpg";
            return View();
        }

        // ==================================
        //     Feed Route
        // ==================================

        [HttpPost("Feed")]
        public IActionResult Feed()
        { 
            Random rand = new Random();
            int? FullnessCount = HttpContext.Session.GetInt32("Fullness");
            int NewFullnessCount = FullnessCount ?? default(int);
            int? MealsCount = HttpContext.Session.GetInt32("Meals");
            int NewMealsCount = MealsCount ?? default(int);
            int AmountFullness = rand.Next(5,11);
            int AmountImage = rand.Next(1,3);

            if (NewMealsCount > 0)
            {
                HttpContext.Session.SetInt32("Fullness", NewFullnessCount + AmountFullness);
                HttpContext.Session.SetInt32("Meals", NewMealsCount -1);
                HttpContext.Session.SetString("Message", $"Dashi Raccoon has eaten and has gained {AmountFullness}.");

                int Image = AmountImage;
                switch (0 + AmountImage)
                {
                case 1:
                HttpContext.Session.SetString("Image","eating.gif");
                break;
                case 2:
                HttpContext.Session.SetString("Image","yummygrapes.gif");
                break;
                case 3:
                HttpContext.Session.SetString("Image","pomegranateEatingRaccoon.gif");
                break;
                }
                
                return RedirectToAction ("Index");
            }
            else
            {
                HttpContext.Session.SetString("Message","Dashi Raccoon does not have enough food to Eat! Perhaps he could work a bit to earn a few meals, and then try again.");
                HttpContext.Session.SetString("Image","hungry.gif");
                return RedirectToAction ("Index");
            }
        }

        // ==================================
        //     Sleep Route
        // ==================================

        [HttpPost("Sleep")]
        public IActionResult Sleep()
        {
            Random rand = new Random();
            int? HappinessCount = HttpContext.Session.GetInt32("Happiness");
            int NewHappinessCount = HappinessCount ?? default(int);
            int? FullnessCount = HttpContext.Session.GetInt32("Fullness");
            int NewFullnessCount = FullnessCount ?? default(int);
            int? EnergyCount = HttpContext.Session.GetInt32("Energy");
            int NewEnergyCount = EnergyCount ?? default(int);
            int AmountImage = rand.Next(1,3);
            {
                HttpContext.Session.SetInt32("Happiness", (int)HappinessCount - 5);
                HttpContext.Session.SetInt32("Fullness", (int)FullnessCount - 5);
                HttpContext.Session.SetInt32("Energy", (int)EnergyCount + 15);
                
                int Image = AmountImage;
                switch (0 + AmountImage)
                {
                case 1:
                HttpContext.Session.SetString("Image","sleepy.gif");
                break;
                case 2:
                HttpContext.Session.SetString("Image","sleepingRaccoon.jpg");
                break;
                case 3:
                HttpContext.Session.SetString("Image","sleepBasketRaccoon.jpg");
                break;
                }

                HttpContext.Session.SetString("Message","Dashi Raccoon slept soundly and now has 15 more Energy!");
                
                return RedirectToAction("Index");
            }
        }
        // ==================================
        //     Work Route
        // ==================================

        [HttpPost("Work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? EnergyCount = HttpContext.Session.GetInt32("Energy");
            int NewEnergyCount = EnergyCount ?? default(int);
            int? MealsCount = HttpContext.Session.GetInt32("Meals");
            int NewMealsCount = MealsCount ?? default(int);
            int AmountFood = rand.Next(1,3);
            int AmountImage = rand.Next(1, 4);

            HttpContext.Session.SetInt32("Energy", NewEnergyCount -5);
            HttpContext.Session.SetInt32("Meals", NewMealsCount + AmountFood);
            HttpContext.Session.SetString("Message", $"Dashi Raccoon has finished working, {AmountFood} was added to the meal supply.");
            
            int Image = AmountImage;
                switch (1 + AmountImage)
                {
                case 2:
                HttpContext.Session.SetString("Image","offtowortenor.gif");
                break;
                case 3:
                HttpContext.Session.SetString("Image","answeringphone.jpg");
                break;
                case 4:
                HttpContext.Session.SetString("Image","sweeping.gif");
                break;
                }
            return RedirectToAction("Index");
        }


        // ==================================
        //     Play Route
        // ==================================
        
        [HttpPost("Play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int? EnergyCount = HttpContext.Session.GetInt32("Energy");
            int NewEnergyCount = EnergyCount ?? default(int);
            int? HappinessCount = HttpContext.Session.GetInt32("Happiness");
            int NewHappinessCount = HappinessCount ?? default(int);
            int AmountHappiness = rand.Next(5, 10);
            int AmountImage = rand.Next(1,4);

            if (EnergyCount > 5)
            {
                HttpContext.Session.SetInt32("Energy", NewEnergyCount - 5);
                HttpContext.Session.SetInt32("Happiness", NewHappinessCount + AmountHappiness);
                HttpContext.Session.SetString("Message", $"Dashi Raccoon has finished playing. Happiness increased by {AmountHappiness}!");
                int Image = AmountImage;
                switch (0 + AmountImage)
                {
                case 1:
                HttpContext.Session.SetString("Image","bicycle.gif");
                break;
                case 2:
                HttpContext.Session.SetString("Image","waterRaccoon.gif");
                break;
                case 3:
                HttpContext.Session.SetString("Image","pianoRaccoon.gif");
                break;
                case 4:
                HttpContext.Session.SetString("Image","mathyRaccoon.gif");
                break;
                }
                // ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                // ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                return RedirectToAction("Index");
            }
            else
                ViewBag.NoPlayMessage = "Dashi raccoon needs more Energy before he can go play.";
                return View ("Index");
        }
        
        // ==================================
        //     Restart Route
        // ==================================

        [HttpPost("Restart")]
        
        public IActionResult Restart() 
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("Image","raccoon.gif");
                return RedirectToAction("Index");
            }  

        [HttpGet("TimeDisplay")]
        public IActionResult TimeDisplay()
        {
            ViewBag.Date=DateTime.Now.ToString("MMM dd,yyyy");
            ViewBag.Time=DateTime.Now.ToString("h:mm tt");
            return View("TimeDisplay");
        }


        [HttpGet("TimeTravel")]
        public IActionResult TimeTravel()
        {
            return View("TimeTravel");
        }

        [HttpGet("Cat")]
        public IActionResult Cat()
        {
            return View("Cat");
        }
        [HttpGet("Pup")]
        public IActionResult Pup()
        {
            return View("Pup");
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View ("Privacy");
        }

    }

}    

