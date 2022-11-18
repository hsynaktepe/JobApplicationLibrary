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
            //Assert.AreEqual(ApplicationResult.AutoRejected, appResult);
            Assert.AreEqual(ApplicationResult.AutoAccepted, appResult);

        }

      

    }
}