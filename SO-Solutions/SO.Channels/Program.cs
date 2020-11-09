using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SO.Channels
{

    public class Hero
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {

            await ViaSemaphore();
            await ViaChannel();
            Console.ReadLine();
        }

        static readonly ConcurrentQueue<Hero> _queue = new ConcurrentQueue<Hero>();
        static readonly SemaphoreSlim _sem = new SemaphoreSlim(1);
        static async Task ViaSemaphore()
        {
            Write(new Hero()
            {
                ID = 1,
                Name = "FCB"
            });

            var h = await Read();
            Console.WriteLine($"{h.Name}");
        }

        static void Write(Hero h)
        {
            _queue.Enqueue(h);
            _sem.Release();
        }

        static async Task<Hero> Read()
        {
            await _sem.WaitAsync();
            _queue.TryDequeue(out Hero h);
            return h;
        }

        static async Task ViaChannel()
        {
            var c = Channel.CreateBounded<Hero>(1);

            var h = new Hero()
            {
                ID = 1,
                Name = "VRB"
            };
            await c.Writer.WriteAsync(h);
            var rh = await c.Reader.ReadAsync();

            Console.WriteLine($"{rh.Name}");
        }
    }
}
