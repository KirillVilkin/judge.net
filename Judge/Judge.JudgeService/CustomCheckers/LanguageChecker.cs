﻿using System.Collections.Generic;
using Judge.Checker;
using Judge.JudgeService.Settings;
using Judge.Model.SubmitSolution;
using Judge.Runner;

namespace Judge.JudgeService.CustomCheckers;

internal sealed class LanguageChecker : ICustomChecker
{
    public CheckerType Type => CheckerType.PreExecutable;

    public ICollection<SubmitRunResult> Check(ProblemSettings problemSettings, SubmitResult submitResult,
        FileOptions fileOptions)
    {
        if (problemSettings?.Language != null && problemSettings.Language != submitResult.Submit.LanguageId)
        {
            return new[]
            {
                new SubmitRunResult
                {
                    RunStatus = RunStatus.Success,
                    CheckStatus = CheckStatus.WrongLanguage
                }
            };
        }

        return null;
    }
}