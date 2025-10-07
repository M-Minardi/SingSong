namespace SingSong.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CANCIÓN ORIGINAL ===");
            var originalAnimals = new[] { "fly", "spider", "bird", "cat", "dog", "cow", "horse" };
            var originalSong = new SongGenerator(originalAnimals);
            Console.WriteLine(originalSong.GenerateCompleteSong());
            
            Console.WriteLine("\n\n=== VERSIÓN PELÍCULA INFANTIL ===");
            var movieAnimals = new[] { "mouse", "cat", "dog", "elephant" };
            var movieSong = new SongGenerator(movieAnimals);
            Console.WriteLine(movieSong.GenerateCompleteSong());
            
            Console.WriteLine("\n\n=== VERSIÓN CORTA ===");
            var shortAnimals = new[] { "fly", "spider" };
            var shortSong = new SongGenerator(shortAnimals);
            Console.WriteLine(shortSong.GenerateCompleteSong());
        }
    }
}