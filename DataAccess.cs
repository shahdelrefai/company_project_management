using System.Data.SqlClient;
using CompanyTasksManagement.Models;
using System.Data;

public class DataAccess
{
    string ConnectionString = "Data Source=.;Initial Catalog=ProjectManagementDb;User ID=admin;Password=Pgesco2023";

    SqlConnection connection = null;
    SqlCommand command = null;
    string commandText = null;

    public void executeProcedure()
    {
        connection = new SqlConnection(ConnectionString);
        command = new SqlCommand();
        command.Connection = connection;

        connection.Open();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = commandText;
        command.Parameters.Clear();
    }

    public string GetAccountTypeByUeserId(int ID)
    {
        string account_type = "user";
        commandText = "GetAccountTypeByUeserId";
        executeProcedure();
        command.Parameters.AddWithValue("userId", ID);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            account_type = Convert.ToString(reader["account_type"]);
        }

        return account_type;
    }

    public int GetAuthorityeByUeserId(int ID)
    {
        int authority = 0;
        commandText = "GetAuthorityeByUeserId";
        executeProcedure();
        command.Parameters.AddWithValue("userId", ID);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            authority = Convert.ToInt32(reader["Authority"]);
        }

        return authority;
    }


    public void AddTask(TaskM newTask)
    {
        commandText = "AddTask";
        executeProcedure();


        command.Parameters.AddRange(new[]
            {
            //new SqlParameter("@projId", SqlDbType.Int) { Value = newTask.ProjectID },
            new SqlParameter("@setForDate", SqlDbType.Date) { Value = newTask.SetForDate },
            new SqlParameter("@name", SqlDbType.NVarChar) { Value = newTask.Name },
            new SqlParameter("@assignFor", SqlDbType.Int) { Value = newTask.AssignFor },
            new SqlParameter("@assignBy", SqlDbType.Int) { Value = newTask.AssignBy },
            new SqlParameter("@deadline", SqlDbType.Date) { Value = newTask.Deadline },
            new SqlParameter("@summary", SqlDbType.NVarChar) { Value = newTask.Summary },
            new SqlParameter("@details", SqlDbType.NVarChar) { Value = newTask.Details }

        });

        command.ExecuteNonQuery();
    }

    public void AddProject(Project newProject)
    {
        commandText = "AddProject";
        executeProcedure();


        command.Parameters.AddRange(new[]
            {
            new SqlParameter("@name", SqlDbType.NVarChar) { Value = newProject.Name },
            new SqlParameter("@startDate", SqlDbType.DateTime) { Value = newProject.StartDate },
            new SqlParameter("@deadline", SqlDbType.DateTime) { Value = newProject.Deadline },
            new SqlParameter("@summary", SqlDbType.NVarChar) { Value = newProject.Summary },
            new SqlParameter("@details", SqlDbType.NVarChar) { Value = newProject.Details }

        });

        command.ExecuteNonQuery();
    }


    public void AddDepartement(Departement newDep)
    {
        commandText = "AddDepartement";
        executeProcedure();


        command.Parameters.AddRange(new[]
            {
            new SqlParameter("@name", SqlDbType.NVarChar) { Value = newDep.Name },
            new SqlParameter("@depHeadUsername", SqlDbType.NVarChar) { Value = newDep.Head }

        });

        command.ExecuteNonQuery();
    }

    public void AddTeam(Team newTeam)
    {
        commandText = "AddTeam";
        executeProcedure();


        command.Parameters.AddRange(new[]
            {
            new SqlParameter("@name", SqlDbType.NVarChar) { Value = newTeam.Name },
            new SqlParameter("@depName", SqlDbType.NVarChar) { Value = newTeam.DepartementID }

        });

        command.ExecuteNonQuery();
    }

    public List<TaskM> GetTodayTasksByUserId(int? ID)
    {
        List<TaskM> tasks = new List<TaskM>();

        commandText = "GetTodayTasksByUserId";
        executeProcedure();
        command.Parameters.AddRange(new[]
            {
            new SqlParameter("@userId", SqlDbType.Int) { Value = ID },
            new SqlParameter("@todayDate", SqlDbType.Date) { Value = DateTime.Now}

        });

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            TaskM currTask = new TaskM();

            currTask.Id = Convert.ToInt32(reader["task_id"]);
            //currTask.ProjectID =  Convert.ToInt32(reader["proj_id"]);
            currTask.Name = Convert.ToString(reader["task_name"]);
            currTask.AssignBy = Convert.ToInt32(reader["assign_by_user_id"]);
            if (!reader.IsDBNull("task_deadline")) currTask.Deadline = Convert.ToDateTime(reader["task_deadline"]);
            if (!reader.IsDBNull("task_summary")) currTask.Summary = Convert.ToString(reader["task_summary"]);
            if (!reader.IsDBNull("task_details")) currTask.Details = Convert.ToString(reader["task_details"]);
            //currTask.Notes = Convert.ToString(reader["task_notes"]);
            //currTask.StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["task_start_date"]));
     
            tasks.Add(currTask);
        }

        return tasks;
    }

    public List<TaskM> GetTasksByUserId(int? ID)
    {
        List<TaskM> tasks = new List<TaskM>();

        commandText = "GetTasksByUserId";
        executeProcedure();
        command.Parameters.AddWithValue("userId", ID);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            TaskM currTask = new TaskM();

            currTask.Id = Convert.ToInt32(reader["task_id"]);
            //currTask.ProjectID =  Convert.ToInt32(reader["proj_id"]);
            currTask.Name = Convert.ToString(reader["task_name"]);
            currTask.AssignBy = Convert.ToInt32(reader["assign_by_user_id"]);
            currTask.SetForDate = Convert.ToDateTime(reader["task_set_for_date"]);
            if (!reader.IsDBNull("task_deadline")) currTask.Deadline = Convert.ToDateTime(reader["task_deadline"]);
            if (!reader.IsDBNull("task_summary")) currTask.Summary = Convert.ToString(reader["task_summary"]);
            if (!reader.IsDBNull("task_details")) currTask.Details = Convert.ToString(reader["task_details"]);
            //currTask.Notes = Convert.ToString(reader["task_notes"]);
            //currTask.StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["task_start_date"]));

            tasks.Add(currTask);
        }

        return tasks;
    }

    public List<TaskM> GetAllUserTasks()
    {
        List<TaskM> tasks = new List<TaskM>();

        commandText = "GetAllUserTasks";
        executeProcedure();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            TaskM currTask = new TaskM();

            currTask.Id = Convert.ToInt32(reader["task_id"]);
            //currTask.ProjectID =  Convert.ToInt32(reader["proj_id"]);
            currTask.Name = Convert.ToString(reader["task_name"]);
            currTask.AssignBy = Convert.ToInt32(reader["assign_by_user_id"]);
            currTask.SetForDate = Convert.ToDateTime(reader["task_set_for_date"]);
            if (!reader.IsDBNull("task_deadline")) currTask.Deadline = Convert.ToDateTime(reader["task_deadline"]);
            if (!reader.IsDBNull("task_summary")) currTask.Summary = Convert.ToString(reader["task_summary"]);
            if (!reader.IsDBNull("task_details")) currTask.Details = Convert.ToString(reader["task_details"]);
            //currTask.Notes = Convert.ToString(reader["task_notes"]);
            //currTask.StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["task_start_date"]));

            tasks.Add(currTask);
        }

        return tasks;
    }
    

    public User GetUserByUserId(int ID)
    {
        User user = new User();

        commandText = "GetUserByUserId";
        executeProcedure();
        command.Parameters.AddWithValue("userId", ID);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {

            user.Id = Convert.ToInt32(reader["user_id"]);
            user.Name = Convert.ToString(reader["full_name"]);
            user.Username = Convert.ToString(reader["username"]);
            user.AccountType = Convert.ToString(reader["account_type"]);
            user.Authority = Convert.ToInt32(reader["Authority"]);

            
        }

        return user;
    }

    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();

        commandText = "GetAllUsers";
        executeProcedure();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            User currUser = new User();

            currUser.Id = Convert.ToInt32(reader["user_id"]);
            currUser.Name = Convert.ToString(reader["full_name"]);
            currUser.Username = Convert.ToString(reader["username"]);
            currUser.AccountType = Convert.ToString(reader["account_type"]);
            currUser.Authority = Convert.ToInt32(reader["Authority"]);

            users.Add(currUser);
        }

        return users;
    }

    public List<Departement> GetDepartements()
    {
        List<Departement> departements = new List<Departement>();

        commandText = "GetDepartements";
        executeProcedure();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Departement currDep = new Departement();

            currDep.Id = Convert.ToInt32(reader["dep_id"]);
            currDep.Name = Convert.ToString(reader["dep_name"]);

            departements.Add(currDep);
        }

        return departements;
    }

    public List<User> SearchUsersByUsername()
    {
        List<User> users = new List<User>();

        commandText = "SearchUsersByUsername";
        executeProcedure();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            User currUser = new User();

            currUser.Id = Convert.ToInt32(reader["user_id"]);
            currUser.Name = Convert.ToString(reader["username"]);

            users.Add(currUser);
        }

        return users;
    }


    public bool ReturnIfUsernameFound(string username)
    {
        bool isFound = false;

        commandText = "ReturnIfUsernameFound";
        executeProcedure();

        command.Parameters.Add(new SqlParameter("@inputUsername", SqlDbType.NVarChar));
        command.Parameters["@inputUsername"].Value = username;

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            isFound = true;
        }

        return isFound;
    }

    public bool ReturnIfEmailFound(string email)
    {
        bool isAvailable = true;

        commandText = "ReturnIfEmailFound";
        executeProcedure();

        command.Parameters.Add(new SqlParameter("@inputEmail", SqlDbType.NVarChar));
        command.Parameters["@inputEmail"].Value = email;

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            isAvailable = false;
        }

        return isAvailable;
    }

    public void AddUserAcc(User user)
    {
        commandText = "AddUserAcc";
        executeProcedure();

        command.Parameters.AddRange(new[]
            {
            new SqlParameter("@username", SqlDbType.NVarChar) { Value = user.Username },
            new SqlParameter("@password", SqlDbType.NVarChar) { Value = user.Password },
            new SqlParameter("@email", SqlDbType.NVarChar) { Value = user.Email },
            new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = user.Name }
        });

        command.ExecuteNonQuery();
    }

    public string GetHashedPassword(string username)
    {
        string hashedPassword = "not found";
        commandText = "GetHashedPassword";
        executeProcedure();

        command.Parameters.AddWithValue("@username", username);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            hashedPassword = Convert.ToString(reader["password"]);
        }

        return hashedPassword;
    }

    public int GetUserIdByUsername(string username)
    {
        int userId = 0;
        commandText = "GetUserIdByUsername";
        executeProcedure();

        command.Parameters.AddWithValue("@username", username);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            userId = Convert.ToInt32(reader["user_id"]);
        }

        return userId;
    }

    public string GetNameByUsername(string username)
    {
        string name = "not found";
        commandText = "GetNameByUsername";
        executeProcedure();

        command.Parameters.AddWithValue("@username", username);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            name = Convert.ToString(reader["full_name"]);
        }

        return name;
    }
}
