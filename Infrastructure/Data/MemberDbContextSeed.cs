using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
namespace Infrastructure
{
    public class MemberDbContextSeed
    {
        public static async Task SeedAsync(MemberDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Points.Any())
                {
                    var pointsData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/points.json");

                    var points = JsonSerializer.Deserialize<List<Point>>(pointsData);

                    foreach (var item in points)
                    {
                        context.Points.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Members.Any())
                {
                    var membersData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/members.json");

                    var members = JsonSerializer.Deserialize<List<Member>>(membersData);

                    foreach (var item in members)
                    {
                        context.Members.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MemberDbContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}