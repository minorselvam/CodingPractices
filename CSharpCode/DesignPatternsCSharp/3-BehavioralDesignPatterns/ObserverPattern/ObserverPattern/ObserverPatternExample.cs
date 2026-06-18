using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 The Observer pattern is a behavioral design pattern that allows an object (the subject) to notify multiple dependent 
objects (observers) about changes in its state, without needing to know who those observers are. This is useful in scenarios 
where a one-to-many dependency exists between objects.

Real-World Example in C#.NET Core: Job Portal System
A Job Portal System is a great real-world example of the Observer pattern. When a company posts a new job listing, 
all registered job seekers who have expressed interest in such job types/categories should get a notification.
 */

namespace ObserverPattern
{
    public class ObserverPatternExample
    {
    }

    //Observer Interface
    public interface IJobSeeker
    {
        void Notify(string job);
    }

    //Concrete observer
    public class JobSeeker:IJobSeeker
    {
        public string Name { get; set; }

        public JobSeeker(string name)
        {
            Name = name;
        }

        public void Notify(string job)
        {
            Console.WriteLine($"Hi {Name}, new job posted: {job}");
        }
    }

    //Subject Interface
    public interface IJobPostings
    {
        void Attach(IJobSeeker seeker);
        void Detach(IJobSeeker seeker);
        void NotifyObservers(string job);
    }

    //Concrete Subject
    public class JobPostings:IJobPostings 
    { 
        private List<IJobSeeker> _jobSeekers = new List<IJobSeeker>();

        public void Attach(IJobSeeker seeker)
        {
            _jobSeekers.Add(seeker);
        }

        public void Detach(IJobSeeker seeker)
        {
            _jobSeekers.Remove(seeker);
        }

        public void NotifyObservers(string job)
        {
            foreach (var jobSeeker in _jobSeekers)
            {
                jobSeeker.Notify(job);
            }
        }

        public void AddJob(String job)
        {
            Console.WriteLine($"New job posted: {job}");
            NotifyObservers(job);
        }
    }
}
