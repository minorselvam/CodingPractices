namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobPostings jobPostings = new JobPostings();

            JobSeeker seeker1 = new JobSeeker("Alice");
            JobSeeker seeker2 = new JobSeeker("Bob");

            jobPostings.Attach(seeker1);
            jobPostings.Attach(seeker2);

            jobPostings.AddJob("Software Developer at Microsoft");

            jobPostings.Detach(seeker1);

            jobPostings.AddJob("Data Scientist at Google");

            Console.ReadKey();
        }
    }
}
