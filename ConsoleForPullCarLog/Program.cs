namespace ConsoleForPullCarLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine(String.Format("Thread-{0}:Connect ADB",Thread.CurrentThread.Name));
            Console.WriteLine("adb devices");
            Console.ReadKey();
        }
    }
}