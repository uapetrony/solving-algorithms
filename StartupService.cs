﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LeetCode;

public class StartupService : IStartup
{
    private readonly ILogger<StartupService> _logger;
    private readonly IConfiguration _config;

    public StartupService(ILogger<StartupService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void Run()
    {
        _logger.LogInformation("Application started");

        Console.WriteLine("Press Ctrl + C to stop the application");

        //new RemoveDuplicatesFromSortedArray().Run();
        //new BestTimeToBuyAndSellStock().Run();
        //new RotateArray().Run();
        //new ContainsDuplicates().Run();
        //new SingleElement().Run();
        //new IntersectionOfTwoArrays().Run();
        //new PlusOne().Run();
        //new MoveZeroesToTheEnd().Run();
        //new Arrays.TwoSum().Run();
        //new Arrays.ValidSudoku().Run();
        //new Arrays.RotateImage().Run();
        //new Arrays.MergeSortedArray().Run();
        new Arrays.RemoveElement().Run();

        //new Mathematics.FizzBuzzNumbers().Run();
        //new Mathematics.CountPrimeNumbers().Run();
        //new Mathematics.PowerOfThree().Run();
        //new Mathematics.RomanToInteger().Run();
        Console.ReadLine();
    }
}