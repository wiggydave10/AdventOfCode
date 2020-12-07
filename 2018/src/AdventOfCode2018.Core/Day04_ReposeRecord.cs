using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Core
{
    public class Day04_ReposeRecord
    {
        public static int Process_Part1(string[] entries)
        {
            var security = GetGuardLogs(entries);

            var sleepingPatterns = security.Guards.Select(x => x.Value.SleepingPattern());
            var mostSleepyGuardMinutes = sleepingPatterns.Max(x => x.TotalMinutesAsleep);

            var sleepingPattern = sleepingPatterns.First(x => x.TotalMinutesAsleep == mostSleepyGuardMinutes);
            return sleepingPattern.GuardId * sleepingPattern.MostOftenMinuteAsleep;
        }

        public static int Process_Part2(string[] entries)
        {
            var security = GetGuardLogs(entries);

            var sleepingPatterns = security.Guards.Select(x => x.Value.SleepingPattern());
            var mostSleepyGuardMinutesCount = sleepingPatterns.Max(x => x.MostOftenMinuteAsleepCount);

            var sleepingPattern = sleepingPatterns.First(x => x.MostOftenMinuteAsleepCount == mostSleepyGuardMinutesCount);
            return sleepingPattern.GuardId * sleepingPattern.MostOftenMinuteAsleep;
        }


        private static Security GetGuardLogs(IEnumerable<string> entries)
        {
            var timeRegex = new Regex(@"^(\[[\d-: ]+\])");

            var timeEntries = new SortedList<DateTime, string>();
            foreach (var entry in entries)
            {
                var timePortion = timeRegex.Match(entry).Value;

                var time = DateTime.Parse(timePortion.Trim('[', ']'));
                var action = entry.Replace($"{timePortion} ", string.Empty);

                timeEntries.Add(time, action);
            }

            var security = new Security();
            foreach (var timeEntry in timeEntries)
            {
                if (timeEntry.Value.Contains("#"))
                {
                    var guardRegex = new Regex(@"\#\d+");
                    var result = guardRegex.Match(timeEntry.Value);
                    var guardId = int.Parse(result.Value.Trim('#'));

                    security.SetCurrentGuard(guardId);
                    security.AddGuardEntry(timeEntry.Key, GuardAction.StartShift);
                }
                else if (timeEntry.Value.Contains("falls"))
                {
                    security.AddGuardEntry(timeEntry.Key, GuardAction.Sleep);
                }
                else if (timeEntry.Value.Contains("wakes"))
                {
                    security.AddGuardEntry(timeEntry.Key, GuardAction.WakeUp);
                }
                else
                {
                    throw new NotSupportedException($"Unknown action: {timeEntry.Value}");
                }
            }
            return security;
        }
    }

    internal class Security
    {
        public Security()
        {
            Guards = new Dictionary<int, Guard>();
        }

        public int CurrentGuard { get; private set; }

        public Dictionary<int, Guard> Guards { get; }


        public void SetCurrentGuard(int guardId)
        {
            CurrentGuard = guardId;
        }

        public void AddGuardEntry(DateTime time, GuardAction action)
        {
            var log = new GuardLog(CurrentGuard, time, action);
            if (Guards.ContainsKey(CurrentGuard))
                Guards[CurrentGuard].AddGuardLog(log);
            else
                Guards.Add(CurrentGuard, new Guard(CurrentGuard, log));
        }
    }

    internal class GuardSleepingPattern
    {
        public GuardSleepingPattern(int guardId, int totalMinutesAsleep, int mostOftenMinuteAsleep, int mostOftenMinuteAsleepCount)
        {
            GuardId = guardId;
            TotalMinutesAsleep = totalMinutesAsleep;
            MostOftenMinuteAsleep = mostOftenMinuteAsleep;
            MostOftenMinuteAsleepCount = mostOftenMinuteAsleepCount;
        }

        public int GuardId { get; }
        public int TotalMinutesAsleep { get; }
        public int MostOftenMinuteAsleep { get; }
        public int MostOftenMinuteAsleepCount { get; }
    }

    internal class Guard
    {
        public Guard(int guardId, GuardLog guardLog = null)
        {
            GuardId = guardId;
            GuardLogs = new List<GuardLog>();
            if (guardLog != null)
                GuardLogs.Add(guardLog);
        }

        public int GuardId { get; }
        public IList<GuardLog> GuardLogs { get; }

        public void AddGuardLog(GuardLog guardLog)
        {
            GuardLogs.Add(guardLog);
        }

        public GuardSleepingPattern SleepingPattern()
        {
            DateTime? sleep = null;
            DateTime? awake = null;
            var sleepingTimes = new List<(DateTime sleep, DateTime awake)>();
            foreach (var log in GuardLogs)
            {
                if (log.Action == GuardAction.Sleep)
                    sleep = log.DateTime;
                if (log.Action == GuardAction.WakeUp)
                {
                    awake = log.DateTime;
                    sleepingTimes.Add((sleep: sleep.Value, awake: awake.Value));
                    sleep = null;
                    awake = null;
                }
            }

            var maxTimeAsleep = 0;
            var totalTimeAsleep = 0;
            var sleepingMinutes = new Dictionary<int, int>();
            foreach (var sleepingTime in sleepingTimes)
            {
                var timeAsleep = sleepingTime.awake.Minute - sleepingTime.sleep.Minute;
                if (timeAsleep > maxTimeAsleep)
                    maxTimeAsleep = timeAsleep;
                totalTimeAsleep += timeAsleep;
                var times = Enumerable.Range(sleepingTime.sleep.Minute, sleepingTime.awake.Minute - sleepingTime.sleep.Minute);
                foreach (var time in times)
                {
                    if (sleepingMinutes.ContainsKey(time))
                        sleepingMinutes[time]++;
                    else
                        sleepingMinutes.Add(time, 1);
                }
            }

            if (!sleepingMinutes.Any())
                return new GuardSleepingPattern(GuardId, 0, 0, 0);

            var maxCount = sleepingMinutes.Max(x => x.Value);
            var maxSleepMinute = sleepingMinutes.First(x => x.Value == maxCount);
            return new GuardSleepingPattern(GuardId, totalTimeAsleep, maxSleepMinute.Key, maxSleepMinute.Value);
        }
    }

    internal class GuardLog
    {
        public GuardLog(int guardId, DateTime dateTime, GuardAction action)
        {
            GuardId = guardId;
            DateTime = dateTime;
            Action = action;
        }

        public GuardAction Action { get; }
        public int GuardId { get; }
        public DateTime DateTime { get; }
    }
    internal enum GuardAction
    {
        StartShift,
        Sleep,
        WakeUp,
    }
}