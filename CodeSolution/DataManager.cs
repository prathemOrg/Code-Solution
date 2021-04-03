using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSolution
{
    class DataManager
    {
        class DataManager
        {
            public void AddUser(User user)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                dc.Users.InsertOnSubmit(user);
                dc.SubmitChanges();
            }
            public void AddProblem(Problem problem)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                dc.Problems.InsertOnSubmit(problem);
                dc.SubmitChanges();
            }
            public void AddSolution(Solution solution)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                dc.Solutions.InsertOnSubmit(solution);
                dc.SubmitChanges();
            }
            public void AddComment(Comment comment)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                dc.Comments.InsertOnSubmit(comment);
                dc.SubmitChanges();
            }
            public void AddVote(Vote vote)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                dc.Votes.InsertOnSubmit(vote);
                dc.SubmitChanges();
            }
            public void DeleteUser(int userID)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                User deleteUser = (from user in dc.Users where user.UserId == userID select user).First();
                dc.Users.DeleteOnSubmit(deleteUser);
                dc.SubmitChanges();
            }
            public void DeleteProblem(int problemID)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                Problem deleteProblem = (from problem in dc.Problems where problem.ProblemId == problemID select problem).First();
                dc.Problems.DeleteOnSubmit(deleteProblem);
                dc.SubmitChanges();
            }
            public void DeleteSolution(int solutionId)
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                Solution deleteSolution = (from solution in dc.Solutions where solution.SolutionId == solutionId select solution).First();
                dc.Solutions.DeleteOnSubmit(deleteSolution);
                dc.SubmitChanges();
            }
            public List<User> GetAllUsers()
            {
                CodeSolutionDataContext dc = new CodeSolutionDataContext();
                List<User> userList = (from users in dc.Users select users).ToList();
                return userList;
            }


        }

    }
}
