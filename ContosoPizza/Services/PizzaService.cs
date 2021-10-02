using ContosoPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        private static List<Pizza> pizzas { get; }

        private static int nextId = 3;

        static PizzaService()
        {
            pizzas = new List<Pizza>()
            {
                new Pizza()
                {
                    Id = 1,
                    Name = "Pizza 1",
                    IsGlutenFree = true
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Pizza 2",
                    IsGlutenFree = false
                }
            };
        }

        public static List<Pizza> GetAll() => pizzas;

        public static Pizza Get(int id) => pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;

            pizzas.Add(pizza);
        }

        public static void Update(Pizza pizza)
        {
            int index = pizzas.FindIndex(p => p.Id == pizza.Id);

            if (index == -1)
            {
                return;
            }

            pizzas[index] = pizza;
        }

        public static void Delete(int id)
        {
            Pizza pizza = Get(id);

            if (pizza is null)
            {
                return;
            }

            pizzas.Remove(pizza);
        }
    }
}
