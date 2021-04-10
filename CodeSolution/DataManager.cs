using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSolution
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
            List<User> userList = (from user in dc.Users select user).ToList();
            return userList;
        }

        public List<Problem> GetAllProblems()
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            List<Problem> problemList = (from problem in dc.Problems select problem).ToList();
            return problemList;
        }
        public List<Solution> GetAllSolutions()
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            List<Solution> solutionList = (from solution in dc.Solutions select solution).ToList();
            return solutionList;
        }
        public User GetUserByID(int ID)
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            User userInfo = (from user in dc.Users where user.UserId.Equals(ID) select user).First();
            return userInfo;
        }
        public List<Problem> GetProblemsByUserID(int ID)
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            List<Problem> problemList = (from problem in dc.Problems where problem.UserId.Equals(ID) select problem).ToList();
            return problemList;
        }
        public int GetUserRolebyUserID(int userID)
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            int userRoleID = (from user in dc.Users where user.UserId == userID select user.UserRoleId).First();
            return userRoleID;
        }
       public Problem GetProblemByID(int problemID)
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            Problem problemObj = (from problem in dc.Problems where problem.ProblemId.Equals(problemID) select problem).First();
            return problemObj;
        }
        public Solution GetSolutionByID(int solutionID)
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            Solution solutionObj = (from solution in dc.Solutions where solution.ProblemId.Equals(solutionID) select solution).First();
            return solutionObj;
        }
        public Comment GetCommentByID(int commentID)
        {
            CodeSolutionDataContext dc = new CodeSolutionDataContext();
            Comment commentObj = (from comment in dc.Comments where comment.CommentId.Equals(commentID)).First();
            return commentObj;
        }

    }

}

