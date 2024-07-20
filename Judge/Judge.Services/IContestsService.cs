﻿using System.Threading.Tasks;
using Judge.Web.Client.Contests;
using Judge.Web.Client.Problems;
using Contest = Judge.Web.Client.Contests.Contest;

namespace Judge.Services;

public interface IContestsService
{
    Task<ContestsInfoList> SearchAsync(ContestsQuery query);
    Task<Contest?> GetAsync(int id, long? userId);
    Task<ContestResult?> GetResultAsync(int id);
    Task<EditContest?> SaveAsync(EditContest editContest);
    Task<Problem?> GetProblemAsync(int contestId, string label);
}