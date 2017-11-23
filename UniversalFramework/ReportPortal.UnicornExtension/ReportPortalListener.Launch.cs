﻿using ReportPortal.Client.Models;
using ReportPortal.Client.Requests;
using ReportPortal.UnicornExtension.EventArguments;
using ReportPortal.Shared;
using System;
using System.Collections.Generic;

namespace ReportPortal.UnicornExtension
{
    public partial class ReportPortalListener
    {
        public delegate void RunStartedHandler(object sender, RunStartedEventArgs e);
        public static event RunStartedHandler BeforeRunStarted;
        public static event RunStartedHandler AfterRunStarted;

        private void StartRun()
        {
            try
            {
                LaunchMode launchMode;
                if (Config.Launch.IsDebugMode)
                {
                    launchMode = LaunchMode.Debug;
                }
                else
                {
                    launchMode = LaunchMode.Default;
                }
                var startLaunchRequest = new StartLaunchRequest
                {
                    Name = Config.Launch.Name,
                    Description = Config.Launch.Description,
                    StartTime = DateTime.UtcNow,
                    Mode = launchMode,
                    Tags = Config.Launch.Tags
                };

                var eventArg = new RunStartedEventArgs(Bridge.Service, startLaunchRequest);

                try
                {
                    BeforeRunStarted?.Invoke(this, eventArg);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception was thrown in 'BeforeRunStarted' subscriber." + Environment.NewLine + exp);
                }

                if (!eventArg.Canceled)
                {
                    Bridge.Context.LaunchReporter = new LaunchReporter(Bridge.Service);
                    Bridge.Context.LaunchReporter.Start(eventArg.Launch);

                    try
                    {
                        AfterRunStarted?.Invoke(this, new RunStartedEventArgs(Bridge.Service, startLaunchRequest, Bridge.Context.LaunchReporter));
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Exception was thrown in 'AfterRunStarted' subscriber." + Environment.NewLine + exp);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("ReportPortal exception was thrown." + Environment.NewLine + exception);
            }
        }

        public delegate void RunFinishedHandler(object sender, RunFinishedEventArgs e);
        public static event RunFinishedHandler BeforeRunFinished;
        public static event RunFinishedHandler AfterRunFinished;

        private void FinishRun()
        {
            try
            {
                var finishLaunchRequest = new FinishLaunchRequest
                {
                    EndTime = DateTime.UtcNow,
                    
                };

                var eventArg = new RunFinishedEventArgs(Bridge.Service, finishLaunchRequest, Bridge.Context.LaunchReporter);
                try
                {
                    BeforeRunFinished?.Invoke(this, eventArg);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception was thrown in 'BeforeRunFinished' subscriber." + Environment.NewLine + exp);
                }

                if (!eventArg.Canceled)
                {
                    Bridge.Context.LaunchReporter.Finish(finishLaunchRequest);
                    Bridge.Context.LaunchReporter.FinishTask.Wait();

                    try
                    {
                        AfterRunFinished?.Invoke(this, new RunFinishedEventArgs(Bridge.Service, finishLaunchRequest, Bridge.Context.LaunchReporter));
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Exception was thrown in 'AfterRunFinished' subscriber." + Environment.NewLine + exp);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("ReportPortal exception was thrown." + Environment.NewLine + exception);
            }
        }


        public void MergeRuns(string descriptionSearchString, string description)
        {
            try
            {
                Client.Filtering.FilterOption filteringOptions = new Client.Filtering.FilterOption();
                filteringOptions.Filters = new List<Client.Filtering.Filter>();
                Client.Filtering.Filter filter = new Client.Filtering.Filter(Client.Filtering.FilterOperation.Contains, "description", descriptionSearchString);
                filteringOptions.Filters.Add(filter);

                LaunchesContainer container = Bridge.Service.GetLaunches(filteringOptions);

                if (container.Launches.Count > 1)
                {
                    MergeLaunchesRequest request = new MergeLaunchesRequest();
                    request.Launches = new List<string>();
                    request.Mode = LaunchMode.Default;
                    request.MergeType = "BASIC";
                    request.Description = container.Launches[0].Description;
                    request.Tags = container.Launches[0].Tags;
                    request.StartTime = container.Launches[0].StartTime.Value;
                    request.EndTime = container.Launches[container.Launches.Count - 1].EndTime.Value;
                    request.Name = container.Launches[0].Name;

                    foreach (Launch launch in container.Launches)
                        if(launch.EndTime != null)
                            request.Launches.Add(launch.Id);

                    Bridge.Service.MergeLaunches(request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error merging launches: " + ex.ToString());
            }
        }
    }
}