﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judge.Model.Contests;
using Microsoft.EntityFrameworkCore;

namespace Judge.Data.Repository;

internal sealed class ContestTaskRepository : IContestTaskRepository
{
    private readonly DataContext context;

    public ContestTaskRepository(DataContext context)
    {
        this.context = context;
    }

    public void Add(ContestTask task)
    {
        this.context.Set<ContestTask>().Add(task);
    }

    public void Delete(ContestTask task)
    {
        this.context.Set<ContestTask>().Remove(task);
    }

    public IEnumerable<ContestTask> GetTasks(int contestId)
    {
        return this.context.Set<ContestTask>()
            .Where(o => o.Contest.Id == contestId)
            .Include(o => o.Task)
            .Include(o => o.Contest)
            .OrderBy(o => o.TaskName)
            .AsEnumerable();
    }

    public async Task<IReadOnlyCollection<ContestTask>> SearchAsync(IEnumerable<int> contestIds)
    {
        return await this.context.Set<ContestTask>()
            .Where(o => contestIds.Contains(o.Contest.Id))
            .ToListAsync();
    }

    public ContestTask? Get(int contestId, string label)
    {
        return this.context.Set<ContestTask>()
            .Include(o => o.Task)
            .Include(o => o.Contest)
            .FirstOrDefault(o => o.Contest.Id == contestId && o.TaskName == label);
    }

    public Task<ContestTask?> TryGetAsync(int contestId, string label)
    {
        return this.context.Set<ContestTask>()
            .Include(o => o.Task)
            .Include(o => o.Contest)
            .FirstOrDefaultAsync(o => o.Contest.Id == contestId && o.TaskName == label)!;
    }

    public IEnumerable<ContestTask> GetTasks()
    {
        return this.context.Set<ContestTask>()
            .Include(o => o.Task)
            .OrderBy(o => o.TaskName)
            .AsEnumerable();
    }

    public async Task<IReadOnlyCollection<ContestTask>> SearchAsync(int contestId)
    {
        return await this.context.Set<ContestTask>()
            .Include(o => o.Task)
            .Where(o => o.ContestId == contestId)
            .OrderBy(o => o.TaskName)
            .ToListAsync();
    }
}