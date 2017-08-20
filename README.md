# CSCC CSCI-2630-Edevices: The Next Generation 
### Picking Up Where the ReturnNull team left off at the end of Spring Semester 2017 and boldly going where no class project has gone before

Just a simple ASP.NET/MVC5 application using Entity Framework designed to allow people to make insurance claims against their registered electronic devices.

Each Milestone was a functionality or feature to be added to the program, and submitted for grading. If I can manage to hit all 10 
pre-planned Milestones I'll see about taking some kind of different approach.

### unitTesting-v1

After completing what would have been Milestone 9, I stopped to develop some unit tests. Working along with Roy Osherove's "The Art of Unit Testing" I tried to mimic the principles and patterns outlined. During the course of my exploration I moved quickly from in-line mock and test object creation, to in-class mock and test object creation via factory methods, to static factory method classes as I added more and more tests to the project.

Realizing this pattern may not be helpful to someone seeing unit testing for the first time (it's a slight jump from "Create the interactor and the value to pass in and check if they're the same" to "Leverage this mini-API of mock repositories and factory methods for simpler test code") I rewrote two of my tests to demonstrate simpler methods. EDeviceClaimSystem.Interactors.Tests.Tests.GetPolicyInteractorTests is heavily commented and displays how to do all the necessary arranging inside the individual tests, and EDeviceClaimSystem.Interactors.Tests.Tests.GetClaimInteractorTests uses in-class factory methods.

The goal of the code in unitTesting-v1 is to provide examples of functioning unit tests at three separate levels of complexity.
