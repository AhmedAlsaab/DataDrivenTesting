# Data Driven Testing

### A demonstration of some lightweight automated test techniques that you can use for Data Driven Testing

## Table of contents

* Introduction
* Build status
* Requirements
* Examples
* Requirements
* Installation
* How to run
* Contributors

## Full Version

The full version with a number of functions and features is only available on a private repository! Here's a screenshot of the GUI for the full version.

![GUI Preview](https://i.imgur.com/ecyYy4G.png)

## Introduction

This repository is a lightweight example of the work I do for my employer in a private repo. I felt like sharing what I have been working on in an effective but concise manner. None of the techniques or code written are by any means examples of 'good code' but have been able to accomplish my set out requirements.

The repo revolves around automating a short contact form in 3 different ways, using Excel as a data file:

* Ordered Tests - Automating a different data set into targetted WebElement in different tests sequentially (ordered)
  
* Looped Tests - Automating the same test with a different data set each loop

* Parralel Looped Tests - Automating the same test with a different data set each loop at the same time (10 tests with 10 different data sets on 10 unique Threads going on at the same time)

## Build Status

```07/10/2019 -- Demo and purpose of this repo accomplished```

## Examples

### Looped Tests

``` C#
[TestFixture]
    public class LoopedTests : ChromeService
    {
        ContactForm contactForm = new ContactForm();

        // Testing the same targetted sections
        // But with different data each loop

        [Test]
        public void LoopingThisTest()
        {
            for (int i = 2; i < 5; i++)
            {
                SetupAndPrepareChromeDriver();
                contactForm.InsertData(i);
                TearDown();
            }
        }

        [TearDown]
        public void TearDown()
        {
            chrome.Close();
            chrome.Quit();
        }
    }
 ```


## Requirements

* This project uses .NET 4.5
* Make sure you have a downloaded copy of ChromeDriver (compatabile with your Chrome version)
* Excel

## Installation

Clone or download the repository. Find the solution (sln) and open in a compatabile IDE (This project was created in VS2017)

## How to run

* Ensure all file locations/paths are set correct (ChromeDriver & Excel)
* Compile (SHIFT + B in VS)
* Select a test and right click to DEBUG or RUN

## Contributors

Ahmed Alsaab

## License

[MIT License]()

