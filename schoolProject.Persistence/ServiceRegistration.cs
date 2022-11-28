using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using schoolProject.Persistence.Contexts;
using schoolProject.Application.Repositories;
using schoolProject.Persistence.Repositories;

namespace schoolProject.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer("Data Source=GKTGPC;Initial Catalog=schoolProject;Integrated Security=True;"), ServiceLifetime.Singleton);

            services.AddSingleton<IStudentReadRepository, StudentReadRepository>();
            services.AddSingleton<IStudentWriteRepository, StudentWriteRepository>();

            services.AddSingleton<ITeacherReadRepository, TeacherReadRepository>();
            services.AddSingleton<ITeacherWriteRepository, TeacherWriteRepository>();



        }
    }
}
