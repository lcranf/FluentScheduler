﻿using System;
using FluentScheduler.Extensions;

namespace FluentScheduler.Model
{
	public class YearOnLastDayOfYearUnit
	{
		internal Schedule Schedule { get; private set; }
		internal int Duration { get; private set; }

		public YearOnLastDayOfYearUnit(Schedule schedule, int duration)
		{
			Schedule = schedule;
			Duration = duration;
			Schedule.CalculateNextRun = x => (x > x.Date.FirstOfYear().AddMonths(11).Last()) ? x.Date.FirstOfYear().AddYears(Duration).AddMonths(11).Last() : x.Date.FirstOfYear().AddMonths(11).Last();
		}

		/// <summary>
		/// Schedules the specified task to run at the hour and minute specified on the last day of year.  If the hour and minute have passed, the task will execute the next scheduled year.
		/// </summary>
		/// <param name="hours">0-23: Represents the hour of the day</param>
		/// <param name="minutes">0-59: Represents the minute of the day</param>
		/// <returns></returns>
		public void At(int hours, int minutes)
		{
			Schedule.CalculateNextRun = x => (x > x.Date.FirstOfYear().AddMonths(11).Last().AddHours(hours).AddMinutes(minutes)) ? x.Date.FirstOfYear().AddYears(Duration).AddMonths(11).Last().AddHours(hours).AddMinutes(minutes) : x.Date.FirstOfYear().AddMonths(11).Last().AddHours(hours).AddMinutes(minutes);
		}
	}
}
