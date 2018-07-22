## Unit Testing

#### Unit tests should be readable
No one wants to spend time trying to figure out what is that your test does. Ideally, this should be clear just by looking at the test name.

#### Unit tests should be maintainable
We should try to write our tests in a way that minor changes to the code shouldn’t make us change all of our tests. The DRY (don’t repeat yourself) principle applies here, and we should treat our test code the same as the production code. This lowers the possibility that one day someone gets to the point where he/she needs to comment out all of our tests because it has become too difficult to maintain them.

#### Unit sets should be fast
If tests are taking too long to execute, it is probable that people will run them less often. That is certainly a bad thing and no one wishes to wait too long for tests to execute.

#### Unit tests should not have any dependances
It is important that anyone who is working on the project can execute tests without the need to provide access to some external system or database. Tests need to run in full isolation.

#### Make tests trustworthy rather than just aiming for the code coverage
Good tests should provide us with the confidence that we will be able to detect errors before they reach production. It is easy to write tests that don’t assert on the right things just to make them pass and to increase code coverage. But there is no point in doing that. We should try to test the right things to be able to rely on them when a time comes to make some changes to the code.