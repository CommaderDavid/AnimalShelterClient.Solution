using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AnimalClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalClient.Controllers
{
    public class AnimalsCotroller : Controller
    {
        public IActionResult Index()
        {
            List<Animal> allAnimals = Animal.GetAnimals();
            return View(allAnimals);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Animal animal)
        {
            await Animal.Post(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Animal animal = Animal.GetDetails(id);
            return View(animal);
        }

        public IActionResult Edit(int id)
        {
            Animal animal = Animal.GetDetails(id);
            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id, Animal animal)
        {
            animal.AnimalId = id;
            await Animal.Put(animal);
            return RedirectToAction("Details", id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await Animal.Delete(id);
            return RedirectToAction("Index");
        }
    }
}