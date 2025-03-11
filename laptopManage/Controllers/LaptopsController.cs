using laptopManage.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptopManage.Controllers
{
    public class LaptopsController : Controller
    {
       static List<Laptop> laptopsList = new List<Laptop>()
        {
            new Laptop()
            {
                id = 1,
                name = "Huawai Mate book D14",
                ram="16GB",
                hard="521GB",
                cpu="intel core i7 ",
                yearOfIssue=2022,
                size="14 inch",
                manufacturer="Huawai",


            },
            new Laptop()
            {
                id = 2,
                name = "Huawai Mate book D15",
                ram="8GB",
                hard="1T",
                cpu="intel core i5 ",
                 yearOfIssue=2022,
                size="15 inch",
                manufacturer="Huawai",
            },
            new Laptop()
            {
                id = 3,
                name = "Apple MacBook Air Retina Laptop",
                ram="16GB",
                hard="521GB RAM",
                cpu="M2 ",
                 yearOfIssue=2022,
                size="14 inch",
                manufacturer="Apple",
            }

        };

       
        private readonly Laptop _lap;
        public IActionResult Index()
        {
            return View(laptopsList);
        }

        //get
        public IActionResult add()
        {
            return View();
        }

        //post
        [HttpPost]
        public IActionResult add(Laptop lapp)
        {
            if (ModelState.IsValid)
            {
                lapp.id=laptopsList.Count +1;
                laptopsList.Add(lapp);
                return RedirectToAction("Index");
            }
            return View();
            
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id,Laptop item)
        {
            Laptop? lap = laptopsList.FirstOrDefault(x => x.id == Id);
            if (lap != null)
            {
                if(item.name!=null)
                    lap.name = item.name;
                if(item.ram!=null)
                    lap.ram = item.ram;
                if(item.hard!=null)
                    lap.hard = item.hard;
                if(item.manufacturer!=null)
                    lap.manufacturer = item.manufacturer;
                if(item.size!=null)
                    lap.size = item.size;
                if(item.cpu!=null)
                    lap.cpu = item.cpu;
                if(item.yearOfIssue!=null)
                    lap.yearOfIssue = item.yearOfIssue;
                //if (item.name != null || item.ram != null || item.hard != null || item.manufacturer != null || item.cpu != null || item.size != null || item.yearOfIssue != null)
                //{
                //    lap.name = item.name;
                //    lap.ram = item.ram;
                //    lap.hard = item.hard;
                //    lap.id = item.id;
                //    lap.yearOfIssue = item.yearOfIssue;
                //    lap.manufacturer = item.manufacturer;
                //    lap.cpu = item.cpu;
                //    lap.size = item.size;
                //    return RedirectToAction("Index");
                //}
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = laptopsList.FirstOrDefault(i => i.id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }


        
        public IActionResult delete(int Id)
        {
            Laptop? laptop = laptopsList.FirstOrDefault(x => x.id == Id);
            laptopsList.Remove(laptop);
            return RedirectToAction("Index");
        }

        public IActionResult ditails(int Id)
        {
            Laptop? laptop = laptopsList.FirstOrDefault(x=>x.id == Id);
            if (laptop != null)
            {
                return View(laptop);
            }
            return NotFound();
        }
    }
}
