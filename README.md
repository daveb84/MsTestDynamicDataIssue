# MsTestDynamicDataIssue
Demonstrate problem with MSTest.TestAdapter 2.2.5

With MSTest.TestAdapter 2.2.5, test cases specified with DynamicDataAttributes do not run test cases when test case data is mutated.

See containing projects MsTest223_Working and MsTest225_NotWorking.

Both have the same unit test with 3 test cases that should result in pass, fail, pass.  Only MsTest223_Working runs all 3 test cases.  
