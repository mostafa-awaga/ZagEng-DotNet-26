using TaskZagEng.Data;

namespace TaskZagEng.Services
{
    public class JobService : IJobService
    {
        private static readonly List<JobListing> _jobs = new();
        private static int _nextId = 1;
        private static readonly object _lock = new();

        static JobService()
        {
            _jobs.AddRange(new[]
            {
            new JobListing
            {
                Id = _nextId++,
                Title = "Backend Developer",
                Company = "Tech Corp",
                Location = "Cairo",
                Salary = 15_000,
                IsActive = true,
                PostedAt = DateTime.UtcNow.AddDays(-10)
            },
            new JobListing
            {
                Id = _nextId++,
                Title = "Frontend Engineer",
                Company = "Startup Hub",
                Location = "Alexandria",
                Salary = 12_000,
                IsActive = true,
                PostedAt = DateTime.UtcNow.AddDays(-5)
            }
        });
        }

        public IEnumerable<JobListing> GetAllActive()
        {
            lock (_lock)
                return _jobs.Where(j => j.IsActive).ToList();
        }

        public JobListing? GetById(int id)
        {
            lock (_lock)
                return _jobs.FirstOrDefault(j => j.Id == id);
        }

        public void Create(JobListing job)
        {
            lock (_lock)
            {
                job.Id = _nextId++;
                job.IsActive = true;             
                job.PostedAt = DateTime.UtcNow;  
                _jobs.Add(job);
            }
        }

        public void Update(int id, JobListing updated)
        {
            lock (_lock)
            {
                var existing = _jobs.FirstOrDefault(j => j.Id == id)
                    ?? throw new KeyNotFoundException($"Job with ID {id} not found.");

                existing.Title = updated.Title;
                existing.Company = updated.Company;
                existing.Location = updated.Location;
                existing.Salary = updated.Salary;
            }
        }

        public void SoftDelete(int id)
        {
            lock (_lock)
            {
                var job = _jobs.FirstOrDefault(j => j.Id == id)
                    ?? throw new KeyNotFoundException($"Job with ID {id} not found.");

                job.IsActive = false;  
            }
        }
    }
}
