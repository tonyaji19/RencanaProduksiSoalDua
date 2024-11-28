using Microsoft.AspNetCore.Mvc;
using RencanaProduksiSoalDua.Data;
using RencanaProduksiSoalDua.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RencanaProduksiSoalDua.Controllers
{
    public class ProductionController : Controller
    {
        private readonly ProductionDbContext _context;

        public ProductionController(ProductionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var plan = new ProductionPlan
            {
                Monday = 0,
                Tuesday = 0,
                Wednesday = 0,
                Thursday = 0,
                Friday = 0,
                Saturday = 0,
                Sunday = 0
            };
            return View(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProductionPlan plan)
        {
            if (ModelState.IsValid)
            {
                var newPlan = BalanceProduction(plan);

                _context.ProductionPlanCar.Add(newPlan);
                await _context.SaveChangesAsync();

                return View(newPlan);
            }

            return View(plan);
        }

        public ProductionPlan BalanceProduction(ProductionPlan plan)
        {
            var days = new[] { plan.Monday, plan.Tuesday, plan.Wednesday, plan.Thursday, plan.Friday, plan.Saturday, plan.Sunday };
            var nonZeroDays = days.Where(day => day > 0).ToList();

            if (nonZeroDays.Count == 0)
            {
                return new ProductionPlan
                {
                    Monday = plan.Monday,
                    Tuesday = plan.Tuesday,
                    Wednesday = plan.Wednesday,
                    Thursday = plan.Thursday,
                    Friday = plan.Friday,
                    Saturday = plan.Saturday,
                    Sunday = plan.Sunday,
                    AdjustedMonday = plan.Monday,
                    AdjustedTuesday = plan.Tuesday,
                    AdjustedWednesday = plan.Wednesday,
                    AdjustedThursday = plan.Thursday,
                    AdjustedFriday = plan.Friday,
                    AdjustedSaturday = plan.Saturday,
                    AdjustedSunday = plan.Sunday,
                    CreatedAt = DateTime.Now
                };
            }

            var total = nonZeroDays.Sum();
            var average = total / nonZeroDays.Count;
            var remainder = total % nonZeroDays.Count;

            var adjustedDays = new int[7];
            var maxDays = nonZeroDays.OrderByDescending(x => x).Take(remainder).ToList();

            for (int i = 0; i < 7; i++)
            {
                if (days[i] == 0)
                {
                    adjustedDays[i] = 0;
                }
                else
                {
                    adjustedDays[i] = average;  
                }
            }

            for (int i = 0; i < 7 && remainder > 0; i++)
            {
                if (days[i] > 0 && maxDays.Contains(days[i]))
                {
                    adjustedDays[i] += 1;
                    remainder--;  
                }
            }

            return new ProductionPlan
            {
                Monday = plan.Monday,
                Tuesday = plan.Tuesday,
                Wednesday = plan.Wednesday,
                Thursday = plan.Thursday,
                Friday = plan.Friday,
                Saturday = plan.Saturday,
                Sunday = plan.Sunday,
                AdjustedMonday = adjustedDays[0],
                AdjustedTuesday = adjustedDays[1],
                AdjustedWednesday = adjustedDays[2],
                AdjustedThursday = adjustedDays[3],
                AdjustedFriday = adjustedDays[4],
                AdjustedSaturday = adjustedDays[5],
                AdjustedSunday = adjustedDays[6],
                CreatedAt = DateTime.Now
            };
        }

    }
}
