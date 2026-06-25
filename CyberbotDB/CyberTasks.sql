CREATE TABLE [dbo].[CyberTasks]
(
	[TaskId] INT IDENTITY(1,1) PRIMARY KEY,
	[Title] nvarchar(50) NOT NULL,
	[Description] nvarchar(100) NOT NULL,
	[Reminder] DATETIME NULL,
	[Status] nvarchar(20) DEFAULT 'Pending'
)
