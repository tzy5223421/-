using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace ConsoleApp2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StudentScoreQueryService:IStudentScoreQuery

    {
        private List<StudentScore> mScores =new List<StudentScore>();

        public StudentScoreQueryService()
        {
            mScores.Add(new  StudentScore(){Name = "zhangsan",Score = 90});
            mScores.Add(new StudentScore() {Name = "李四", Score = 87 });
        }
        public StudentScore GetScore(string name)
        {
            return mScores.FirstOrDefault(o => o.Name == name);
        }
    }
}
