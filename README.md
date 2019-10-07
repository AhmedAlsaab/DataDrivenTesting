# Data Driven Testing

### A demonstration of some lightweight automated test techniques that you can use for Data Driven Testing

## Table of contents

* Introduction
* Build status
* Requirements
* Examples
* Installation
* How to run
* Contributors

## Introduction

This repository is a lightweight example of the work I do for my employer in a private repo. I felt like sharing what I have been working on in an effective but concise manner. None of the techniques or code written are by any means examples of 'good code'. In fact, looping tests is debatable! There are better ways of accomplish what I set out to do but It's what I've been able to cough up so far.

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



## Installation

Clone or download the repository. Find the solution (sln) and open in a compatabile IDE (This project was created in VS2017)

## How to run

Select a test after compiling (SHIFT + B to compile) and right click to DEBUG or RUN


## Contributors

Ahmed Alsaab


## License

[MIT License]()

