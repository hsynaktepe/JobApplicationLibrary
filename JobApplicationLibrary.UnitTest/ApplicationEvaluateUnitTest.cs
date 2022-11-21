using JobApplicationLibrary;
using JobApplicationLibrary.Models;

using NUnit.Framework;


namespace JobApplicationLibrary_UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
       
        //UnitOfWork_Condition_ExpectedResult

        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {
            //Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 17,
                }
            };

            //Action
            var appResult = evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(ApplicationResult.AutoRejected, appResult);
            //Assert.AreEqual(ApplicationResult.AutoAccepted, appResult);

        }

       
         [Test]
        public void Application_WithNoStack_TransferredToAutoRejected()
        {
            //Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age = 19},
                TechStackList = new System.Collections.Generic.List<string>() { ""}
                
            };

            //Action
            var appResult = evaluator.Evaluate(form);

            //Assert
            //Assert.AreEqual(ApplicationResult.AutoRejected, appResult);
            Assert.AreEqual(ApplicationResult.AutoRejected, appResult);

        }

        [Test]
        public void Application_WithStackOver75P_TransferredToAutoAccepted()
        {
            //Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age = 19 },
                TechStackList = new System.Collections.Generic.List<string>() 
                { "c#", "Rabbitmq", "microsergvice", "visual studuio" },
                YearsOfExperience = 16

            };

            //Action
            var appResult = evaluator.Evaluate(form);

            //Assert
            //Assert.AreEqual(ApplicationResult.AutoRejected, appResult);
            Assert.AreEqual(ApplicationResult.AutoAccepted, appResult);

        }

      

    }
}