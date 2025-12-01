using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YourApp.Controllers
{
    internal class HashBrown { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    public class BreakfastController : Controller
    {
        private readonly List<string> _log = new();

        private void Log(string message) => _log.Add(message);

        private ContentResult LogResult(string title, long elapsedMs)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{title} ({elapsedMs} ms)");
            sb.AppendLine(new string('-', 40));
            foreach (var line in _log)
                sb.AppendLine(line);

            return Content(sb.ToString(), "text/plain");
        }

        [HttpGet("/breakfast-sync")]
        public IActionResult Sync()
        {
            var sw = Stopwatch.StartNew();

            Coffee cup = PourCoffee();
            Log("coffee is ready");

            Egg eggs = FryEggs(2);
            Log("eggs are ready");

            HashBrown hashBrown = FryHashBrowns(3);
            Log("hash browns are ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Log("toast is ready");

            Juice oj = PourOJ();
            Log("oj is ready");
            Log("Breakfast is ready!");

            sw.Stop();
            return LogResult("Synchronous breakfast", sw.ElapsedMilliseconds);
        }

        [HttpGet("/breakfast-async-sequential")]
        public async Task<IActionResult> AsyncSequential()
        {
            var sw = Stopwatch.StartNew();

            Coffee cup = PourCoffee();
            Log("coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            Log("eggs are ready");

            HashBrown hashBrown = await FryHashBrownsAsync(3);
            Log("hash browns are ready");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Log("toast is ready");

            Juice oj = PourOJ();
            Log("oj is ready");
            Log("Breakfast is ready!");

            sw.Stop();
            return LogResult("Async sequential breakfast", sw.ElapsedMilliseconds);
        }

        [HttpGet("/breakfast-async-concurrent")]
        public async Task<IActionResult> AsyncConcurrent()
        {
            var sw = Stopwatch.StartNew();

            Coffee cup = PourCoffee();
            Log("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var hashBrownTask = FryHashBrownsAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            Egg eggs = await eggsTask;
            Log("eggs are ready");

            HashBrown hashBrown = await hashBrownTask;
            Log("hash browns are ready");

            Toast toast = await toastTask;
            Log("toast is ready");

            Juice oj = PourOJ();
            Log("oj is ready");
            Log("Breakfast is ready!");

            sw.Stop();
            return LogResult("Async concurrent breakfast", sw.ElapsedMilliseconds);
        }

        // --- Dokümandaki yardımcı metodların MVC uyarlaması ---

        private Juice PourOJ()
        {
            Log("Pouring orange juice");
            return new Juice();
        }

        private void ApplyJam(Toast toast) =>
            Log("Putting jam on the toast");

        private void ApplyButter(Toast toast) =>
            Log("Putting butter on the toast");

        private Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Log("Putting a slice of bread in the toaster");
            }
            Log("Start toasting...");
            Task.Delay(3000).Wait();
            Log("Remove toast from toaster");
            return new Toast();
        }

        private HashBrown FryHashBrowns(int patties)
        {
            Log($"putting {patties} hash brown patties in the pan");
            Log("cooking first side of hash browns...");
            Task.Delay(3000).Wait();
            for (int patty = 0; patty < patties; patty++)
            {
                Log("flipping a hash brown patty");
            }
            Log("cooking the second side of hash browns...");
            Task.Delay(3000).Wait();
            Log("Put hash browns on plate");
            return new HashBrown();
        }

        private Egg FryEggs(int howMany)
        {
            Log("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Log($"cracking {howMany} eggs");
            Log("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Log("Put eggs on plate");
            return new Egg();
        }

        private Coffee PourCoffee()
        {
            Log("Pouring coffee");
            return new Coffee();
        }

        private async Task<Egg> FryEggsAsync(int howMany)
        {
            Log("Warming the egg pan...");
            await Task.Delay(3000);
            Log($"cracking {howMany} eggs");
            Log("cooking the eggs ...");
            await Task.Delay(3000);
            Log("Put eggs on plate");
            return new Egg();
        }

        private async Task<HashBrown> FryHashBrownsAsync(int patties)
        {
            Log($"putting {patties} hash brown patties in the pan");
            Log("cooking first side of hash browns...");
            await Task.Delay(3000);
            for (int patty = 0; patty < patties; patty++)
            {
                Log("flipping a hash brown patty");
            }
            Log("cooking the second side of hash browns...");
            await Task.Delay(3000);
            Log("Put hash browns on plate");
            return new HashBrown();
        }

        private async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Log("Putting a slice of bread in the toaster");
            }
            Log("Start toasting...");
            await Task.Delay(3000);
            Log("Remove toast from toaster");
            return new Toast();
        }

        private async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }
    }
}
