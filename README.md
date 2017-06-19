# UserAdminTasks
Accounting tasks
Task: It is necessary to develop a program for recording tasks, using OOP principles in C #.
The task should contain the following data: The date the task was created, the task description, the task assigned to, the planned start date for the task, the planned completion date for the task, the creator.
Functional requirements:
- Creating users;
- Create / edit / delete a task;
- Assigning a task to a specific user (you can assign a task to the creator of the task);
- Change the status of the task execution (accepted / fulfilled / completed);
- View the archive of completed tasks;
- Filter task search for a particular artist.
Non-functional requirements:
- Create 2 databases for storing information on tasks (main and archive);
- Monitor the status of task changes using MS SQL. After the task has been set to "completed", move the complete information on the task (by means of MS SQL) from the main database to the archive.
Tools: MS SQL Server, ASP.Net MVC, ADO.Net
