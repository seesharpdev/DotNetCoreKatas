Branch|Status|Quality
-|-|-
Master|![Build Status](https://travis-ci.com/seesharpdev/DotNetCoreKatas.svg?branch=master)|[![CodeFactor](https://www.codefactor.io/repository/github/seesharpdev/dotnetcorekatas/badge)](https://www.codefactor.io/repository/github/seesharpdev/dotnetcorekatas)
Develop|![Build Status](https://travis-ci.com/seesharpdev/DotNetCoreKatas.svg?branch=develop)|

# DotNetCoreKatas

Hey! Welcome to my .Net Core 2 Playground. In here you'll find several 
demo apps using both .Net Core Standard, for neutral assemblies like 
contracts, and .Net Core 2 for apps.

There is no short term plan to tackle Mobile Apps using Xamarin 
though this is a subject I'd love to work with given I have the time
to do so.
 
If you feel you can contribute with code in this area please get in touch.

# House Rules
* The first rule of the DotNetCoreKatas is...there is no rules.
* Feel free to contribute through Pull Request!

## Unit Testing

* Unit tests should be readable
> No one wants to spend time trying to figure out what is that your test does. Ideally, this should be clear just by looking at the test name.

* Unit tests should be maintainable
> We should try to write our tests in a way that minor changes to the code shouldn’t make us change all of our tests. The DRY (don’t repeat yourself) principle applies here, and we should treat our test code the same as the production code. This lowers the possibility that one day someone gets to the point where he/she needs to comment out all of our tests because it has become too difficult to maintain them.

* Unit sets should be fast
> If tests are taking too long to execute, it is probable that people will run them less often. That is certainly a bad thing and no one wishes to wait too long for tests to execute.

* Unit tests should not have any dependances
> It is important that anyone who is working on the project can execute tests without the need to provide access to some external system or database. Tests need to run in full isolation.

* Make tests trustworthy rather than just aiming for the code coverage
> Good tests should provide us with the confidence that we will be able to detect errors before they reach production. It is easy to write tests that don’t assert on the right things just to make them pass and to increase code coverage. But there is no point in doing that. We should try to test the right things to be able to rely on them when a time comes to make some changes to the code.